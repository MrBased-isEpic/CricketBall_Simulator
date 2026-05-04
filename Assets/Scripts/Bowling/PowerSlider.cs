using UnityEngine;

public class PowerSlider : MonoBehaviour
{
    [SerializeField] private RectTransform _powerLine;
    [SerializeField] private float _powerLineMaxHeight;
    
    private float _powerLinePos;
    private float _powerChangeDir;

    private bool _update;

    public float Power => 1 - Mathf.Abs(_powerLinePos);

    private void Start()
    {
        _powerLinePos = 0;
        _powerChangeDir = 1;

        _update = true;
    }

    private void Update()
    {
        if(_update)
            UpdatePower();
    }

    private void UpdatePower()
    {
        _powerLinePos += _powerChangeDir * Time.deltaTime;

        if (Mathf.Abs(_powerLinePos) > 1)
            _powerChangeDir *= -1;
        
        _powerLine.anchoredPosition = new Vector2(_powerLine.anchoredPosition.x, 
            _powerLineMaxHeight * _powerLinePos);
    }
}
