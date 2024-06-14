public class PlayerAirState : PlayerBaseState
{
    public PlayerAirState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_stateMachine.Player.AnimeData.AirParameterHash);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimeData.AirParameterHash);
    }
}
