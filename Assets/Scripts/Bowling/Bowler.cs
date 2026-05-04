using UnityEngine;
using UnityEngine.UI;

public class Bowler : MonoBehaviour
{
    [SerializeField] private Button _swingButton;
    [SerializeField] private Button _spinButton;
    
    [SerializeField] private Button _changeBowlerSideButton;

    [SerializeField] private Button _bowlButton;
    [SerializeField] private PowerSlider _powerSlider;
    [SerializeField] private Transform _ballBounceMarker;
    [SerializeField] private Transform _ballSpawnPosition;
    
    [Space]
    [SerializeField] private Transform _ballPrefab;
    
    private BowlingStyle _bowlingStyle;

    private void Start()
    {
        _swingButton.onClick.AddListener(()=>ChangeBowlingStyle(BowlingStyle.Swing));
        _spinButton.onClick.AddListener(()=>ChangeBowlingStyle(BowlingStyle.Spin));
        
        _changeBowlerSideButton.onClick.AddListener(SwitchBowlerSide);
        _bowlButton.onClick.AddListener(Bowl);
    }

    private void ChangeBowlingStyle(BowlingStyle bowlingStyle)
    {
        _bowlingStyle = bowlingStyle;
    }

    private void SwitchBowlerSide()
    {
        transform.position = Vector3.Scale(transform.position, new Vector3(1f, 1f, -1f));
    }

    private void Bowl()
    {
        Debug.Log(_ballBounceMarker.position);
    }
}
