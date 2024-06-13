public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(_stateMachine.Player.AnimeData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimeData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }
}
