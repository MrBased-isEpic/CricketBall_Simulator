using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    #region Singleton
    
    public static BallPhysics Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    
    #endregion

    public float gravity;

    [Space]
    [Tooltip("The angle from which the ball will be thrown")]
    public float maxSwing;
    [Tooltip("The angle the ball will change trajectory after first bounce")]
    public float maxSpin;

    [Space]
    [Tooltip("0 is no bounce, 1 means complete bounce")]
    public float bounce;
    
    
    public readonly float timeTillFirstBounce = 0.75f;
    
    public Vector3 RotateVectorOnY(Vector3 v, float angle)
    {
        float radAngle = angle * Mathf.Deg2Rad;
        
        return new Vector3(
            v.x * Mathf.Cos(radAngle) - v.z * Mathf.Sin(radAngle),
            v.y,
            v.x * Mathf.Sin(radAngle) + v.z * Mathf.Cos(radAngle)
            );
    }
}
