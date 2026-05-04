

public class NormalBowling : IBallState
{

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
