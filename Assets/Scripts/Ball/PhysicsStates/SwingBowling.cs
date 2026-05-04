using UnityEngine;

public class SwingBowling : IBallState
{
    // Rotates the velocity around the y-axis to achieve the effect.
    public void Update(Ball ball)
    {
        ball.ApplyGravity();
        
        ball.velocity = 
            BallPhysics.Instance.RotateVectorOnY(ball.velocity,
                (((-BallPhysics.Instance.maxSwing * 2)
                  / BallPhysics.Instance.timeTillFirstBounce) 
                 * Time.deltaTime)
                * ball.bowlingStyleMultiplier);

        if (ball.transform.position.y < 0f)
        {
            ball.ApplyBounce();
            ball.TransitionState(ball.normalBowling);
        }

        ball.ApplyVelocity();
    }
}