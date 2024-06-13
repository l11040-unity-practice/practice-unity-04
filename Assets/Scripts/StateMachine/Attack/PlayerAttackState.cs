public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.MovementSpeedModifier = 0;
        base.Enter();
        StartAnimation(_stateMachine.Player.AnimeData.AttackParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimeData.AttackParameterHash);
    }
}
