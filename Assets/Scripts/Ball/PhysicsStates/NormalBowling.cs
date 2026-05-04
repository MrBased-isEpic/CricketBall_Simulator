

public class NormalBowling : IBallState
{
    // Maintains lateral velocity while applying gravity.
    public void Update(Ball ball)
    {
        ball.ApplyGravity();

        if (ball.transform.position.y < 0f)
        {
            ball.ApplyBounce();
        }

        ball.ApplyVelocity();
    }
}
