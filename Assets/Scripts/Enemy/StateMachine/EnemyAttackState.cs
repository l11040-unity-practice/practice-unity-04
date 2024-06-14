using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }
    bool _alreadyApplyForce;
    bool _alreadyAppliedDealing;

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

            if (!_alreadyAppliedDealing && normalizedTime >= _stateMachine.Enemy.Data.Dealing_Start_TransitionTime)
            {
                _stateMachine.Enemy.Weapon.SetAttack(_stateMachine.Enemy.Data.Damage, _stateMachine.Enemy.Data.Force);
                _stateMachine.Enemy.Weapon.gameObject.SetActive(true);
                _alreadyAppliedDealing = true;
            }

            if (_alreadyAppliedDealing && normalizedTime >= _stateMachine.Enemy.Data.Dealing_End_TransitionTime)
            {
                _stateMachine.Enemy.Weapon.gameObject.SetActive(false);
                _alreadyAppliedDealing = false;
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
