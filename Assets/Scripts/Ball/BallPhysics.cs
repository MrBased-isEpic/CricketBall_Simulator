using UnityEngine;

// Mostly a stand-in to input ball behavior at run-time. Would usually be a SO.
public class BallPhysics : MonoBehaviour
{
    #region Singleton
    
    public static BallPhysics Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    
    #endregion

    [Tooltip("Acceleration in the -y direction, Not advisable to change this.")]
    public float gravity;

    [Space]
    [Tooltip("The angle from which the ball will be thrown.")]
    public float maxSwing;
    [Tooltip("The angle the ball will change trajectory after first bounce.")]
    public float maxSpin;

    [Space]
    [Tooltip("0 is a dead ball, 1 is a complete bounce.")]
    public float bounce;
    
    [Tooltip("Hardcoded value for the time taken by the ball to hit the floor.")]
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
