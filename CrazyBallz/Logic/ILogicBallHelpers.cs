using Data;
using Logic;

internal static class ILogicBallHelpers
{

    public static LogicBall Instantiate(IBall ball)
    {
        return new LogicBall(ball);
    }
}