using UnityEngine;

public class BallBounceMarker : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    void Update()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
        
        inputDir.Normalize();
        
        transform.position += inputDir * Time.deltaTime * _moveSpeed;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -4, 7),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -2.4f, 2.4f)
        );
    }
}
