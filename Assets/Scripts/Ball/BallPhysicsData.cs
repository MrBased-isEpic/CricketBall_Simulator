using UnityEngine;

public class BallPhysicsData : MonoBehaviour
{
    #region Singleton
    
    public static BallPhysicsData Instance;

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
}
