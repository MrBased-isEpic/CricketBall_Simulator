using UnityEngine;
using UnityEngine.UI;

public class Bowler : MonoBehaviour
{
    [SerializeField] private Button _swingButton;
    [SerializeField] private Button _spinButton;
    
    [SerializeField] private Button _changeBowlerSideButton;

    [SerializeField] private Button _bowlButton;
    [SerializeField] private PowerSlider _powerSlider;
    [SerializeField] private Transform _ballBounceMarker;
    [SerializeField] private Transform _ballSpawnPosition;
    
    [Space]
    [SerializeField] private Transform _ballPrefab;
    
    private BowlingStyle _bowlingStyle;

    private void Start()
    {
        _swingButton.onClick.AddListener(()=>ChangeBowlingStyle(BowlingStyle.Swing));
        _spinButton.onClick.AddListener(()=>ChangeBowlingStyle(BowlingStyle.Spin));
        
        _changeBowlerSideButton.onClick.AddListener(SwitchBowlerSide);
        _bowlButton.onClick.AddListener(Bowl);
    }

    #region Interface
    
    private void ChangeBowlingStyle(BowlingStyle bowlingStyle)
    {
        _bowlingStyle = bowlingStyle;
        Debug.Log($"Switching Bowling Style to {_bowlingStyle}");
    }
    private void SwitchBowlerSide()
    {
        transform.position = Vector3.Scale(transform.position, new Vector3(1f, 1f, -1f));
    }
    private void Bowl()
    {
        Ball ball = Instantiate(_ballPrefab, _ballSpawnPosition.position, Quaternion.identity).
            GetComponent<Ball>();

        ball.Setup(_bowlingStyle, GetBowlingStyleMultiplier());
        
        switch (_bowlingStyle)
        {
            case BowlingStyle.Spin:
                ball.velocity = GetStraightBowlingVelocity(ball);
                break;
            case BowlingStyle.Swing:
                ball.velocity = GetSwingBowlingVelocity(ball, ball.bowlingStyleMultiplier);
                break;
        }
        
    }
    
    #endregion

    #region BowlingCalculations
    
    private float GetBowlingStyleMultiplier()
    {
        float power = _powerSlider.Power;

        if (power > 0.84)
        {
            return 1;
        }
        else if(power > 0.56)
        {
            return .7f;
        }
        else if(power > 0.28)
        {
            return .4f;
        }
        else
        {
            return 0;
        }
    }
    private Vector3 GetStraightBowlingVelocity(Ball ball)
    {
        Vector3 targetDifference = _ballBounceMarker.position - ball.transform.position;

        return new Vector3(
            targetDifference.x / 0.75f,
            1,
            targetDifference.z / 0.75f);
    }
    private Vector3 GetSwingBowlingVelocity(Ball ball, float bowlStyleMultiplier)
    {
        Vector3 initVelocity = GetStraightBowlingVelocity(ball);

        return BallPhysics.Instance.RotateVectorOnY(initVelocity,
            BallPhysics.Instance.maxSwing * bowlStyleMultiplier);
    }
    
    #endregion
}
