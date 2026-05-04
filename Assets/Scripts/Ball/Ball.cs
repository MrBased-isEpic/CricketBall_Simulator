using UnityEngine;

public class Ball : MonoBehaviour
{
    private readonly NormalBowling normalBowling = new NormalBowling();
    private IBallState _currentState;

    [SerializeField] private float _ballLifetime;
    
    #region Physics

    public Vector3 velocity;

    private float timer;
    
    #endregion
    
    
    void Start()
    {
        TransitionState(normalBowling);
    }
    
    void Update()
    {
        _currentState.Update(this);
        
        
        timer +=  Time.deltaTime;
        CheckRemovalTimer();
    }

    public void TransitionState(IBallState state)
    {
        if (_currentState == state) return;
        _currentState = state;
        _currentState.Setup(this);
    }

    public void ApplyVelocity()
    {
        transform.position += velocity * Time.deltaTime;
    }

    public void ApplyGravity()
    {
        velocity -= new Vector3(0,
            BallPhysicsData.Instance.gravity * Time.deltaTime,
            0);
    }

    public void ApplyBounce()
    {
        velocity = new Vector3(
            velocity.x,
            (velocity.y * -1) * BallPhysicsData.Instance.bounce,
            velocity.z);
            
        transform.position = 
            Vector3.Scale(transform.position, new Vector3(1, 0, 1));
    }
    
    public void CheckRemovalTimer()
    {
        if(timer > _ballLifetime)
            Destroy(this.gameObject);
    }
    

    private Vector3 RotateVectorOnY(Vector3 v, float angle)
    {
        return new Vector3((Mathf.Cos(angle) * v.x) - (Mathf.Sin(angle) * v.z),
            v.y,
            (Mathf.Sin(angle) * v.x) - (Mathf.Cos(angle) * v.z));
    }
}
