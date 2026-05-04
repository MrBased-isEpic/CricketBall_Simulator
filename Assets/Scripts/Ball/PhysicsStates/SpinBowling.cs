

public class SpinBowling : IBallState
{

    public void Update(Ball ball)
    {
        ball.ApplyGravity();
        
        if (ball.transform.position.y < 0f)
        {
            ball.velocity = 
                BallPhysics.Instance.RotateVectorOnY(ball.velocity,
                    BallPhysics.Instance.maxSpin * ball.bowlingStyleMultiplier);
            
            ball.ApplyBounce();
            ball.TransitionState(ball.normalBowling);
        }

        ball.ApplyVelocity();
    }
}