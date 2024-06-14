using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        _stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(_stateMachine.Enemy.AnimeData.GroundParameterHash);
        StartAnimation(_stateMachine.Enemy.AnimeData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Enemy.AnimeData.GroundParameterHash);
        StopAnimation(_stateMachine.Enemy.AnimeData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();

        if (IsInChasingRange())
        {
            _stateMachine.ChangeState(_stateMachine.ChasingState);
        }
    }
}
