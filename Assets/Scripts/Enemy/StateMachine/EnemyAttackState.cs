using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    private bool _alreadyApplyForce;

    public override void Enter()
    {
        base.Enter();
        StartAnimation(_stateMachine.Enemy.AnimeData.AttackParameterHash);
        StartAnimation(_stateMachine.Enemy.AnimeData.BaseAttackParameterHash);

        _alreadyApplyForce = false;
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(_stateMachine.Enemy.AnimeData.AttackParameterHash);
        StopAnimation(_stateMachine.Enemy.AnimeData.BaseAttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizedTime = GetNormalizedTime(_stateMachine.Enemy.Animator, "Attack");
        if (normalizedTime < 1f)
        {
            if (normalizedTime >= _stateMachine.Enemy.Data.ForceTransitionTime)
            {
                TryApplyForce();
            }
        }
        else
        {
            if (IsInChasingRange())
            {
                _stateMachine.ChangeState(_stateMachine.ChasingState);
                return;
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.IdleState);
                return;
            }
        }
    }

    private void TryApplyForce()
    {
        if (_alreadyApplyForce) return;
        _alreadyApplyForce = true;
        _stateMachine.Enemy.ForceReceiver.Reset();
        _stateMachine.Enemy.ForceReceiver.AddForce(Vector3.forward * _stateMachine.Enemy.Data.Force);
    }
}
