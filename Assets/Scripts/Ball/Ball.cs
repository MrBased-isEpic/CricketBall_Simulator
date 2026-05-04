using UnityEngine;

public class Ball : MonoBehaviour
{
    // Split Different ball behaviors into states
    public readonly SpinBowling spinBowling = new SpinBowling();
    public readonly SwingBowling swingBowling = new SwingBowling();
    public readonly NormalBowling normalBowling = new NormalBowling();
    private IBallState _currentState;

    [SerializeField] private float _ballLifetime;
    
    #region Physics

    public Vector3 velocity;
    public float bowlingStyleMultiplier;
    
    private float timer;
    
    #endregion
    
    
    public void Setup(BowlingStyle bowlingStyle, float bowlStyleMultiplier)
    {
        switch (bowlingStyle)
        {
            case BowlingStyle.Spin:
                TransitionState(spinBowling);
                break;
            case BowlingStyle.Swing:
                TransitionState(swingBowling);
                break;
        }
        
        this.bowlingStyleMultiplier = bowlStyleMultiplier;
    }
    
    #region LifeCycle
    
    void Update()
    {
        _currentState.Update(this);
        
        timer += Time.deltaTime;
        CheckRemovalTimer();
    }

    public void TransitionState(IBallState state)
    {
        if (_currentState == state) return;
        _currentState = state;
    }
    
    public void CheckRemovalTimer()
    {
        if(timer > _ballLifetime)
            Destroy(this.gameObject);
    }
    
    #endregion
    
    #region PhysicsFunc

    public void ApplyVelocity()
    {
        transform.position += velocity * Time.deltaTime;
    }

    public void ApplyGravity()
    {
        velocity -= new Vector3(0,
            BallPhysics.Instance.gravity * Time.deltaTime,
            0);
    }

    public void ApplyBounce()
    {
        velocity = new Vector3(
            velocity.x,
            (velocity.y * -1) * BallPhysics.Instance.bounce,
            velocity.z);
            
        transform.position = 
            Vector3.Scale(transform.position, new Vector3(1, 0, 1));
    }
    
    #endregion
    
}
