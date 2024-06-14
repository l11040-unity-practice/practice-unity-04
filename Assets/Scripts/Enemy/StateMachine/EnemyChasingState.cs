using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _stateMachine.MovementSpeedModifier = _groundData.WalkSpeedModifier;
        base.Enter();
        StartAnimation(_stateMachine.Enemy.AnimeData.GroundParameterHash);
        StartAnimation(_stateMachine.Enemy.AnimeData.WalkParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Enemy.AnimeData.GroundParameterHash);
        StopAnimation(_stateMachine.Enemy.AnimeData.WalkParameterHash);
    }

    public override void Update()
    {
        base.Update();
        if (!IsInChasingRange())
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
        else if (IsInAttackRange())
        {
            _stateMachine.ChangeState(_stateMachine.AttackState);
        }
    }


    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (_stateMachine.Target.transform.position - _stateMachine.Enemy.transform.position).sqrMagnitude;
        return playerDistanceSqr <= _stateMachine.Enemy.Data.AttackRange * _stateMachine.Enemy.Data.AttackRange;
    }
}
