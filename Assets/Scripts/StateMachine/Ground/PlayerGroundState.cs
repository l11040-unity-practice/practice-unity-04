using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public PlayerGroundState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_stateMachine.Player.AnimeData.GroundParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Player.AnimeData.GroundParameterHash);
    }

    public override void Update()
    {
        base.Update();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
