using UnityEngine;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine _stateMachine;
    protected readonly PlayerGroundData _groundData;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this._stateMachine = stateMachine;
        _groundData = stateMachine.Enemy.Data.GroundData;
    }
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void HandleInput() { }
    public virtual void PhysicsUpdate() { }

    public virtual void Update()
    {
        Move();
    }

    protected void StartAnimation(int animatorHash)
    {
        _stateMachine.Enemy.Animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        _stateMachine.Enemy.Animator.SetBool(animatorHash, false);
    }

    private void Move()
    {
        Vector3 movementDir = GetMovementDir();
        Move(movementDir);
        Rotate(movementDir);
    }

    private Vector3 GetMovementDir()
    {
        Vector3 dir = (_stateMachine.Target.transform.position - _stateMachine.Enemy.transform.position).normalized;

        return dir;
    }
    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        _stateMachine.Enemy.Controller.Move(((direction * movementSpeed) + _stateMachine.Enemy.ForceReceiver.Movement) * Time.deltaTime);
    }

    private float GetMovementSpeed()
    {
        float moveSpeed = _stateMachine.MovementSpeed * _stateMachine.MovementSpeedModifier;
        return moveSpeed;
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Transform playerTransfrom = _stateMachine.Enemy.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransfrom.rotation = Quaternion.Slerp(playerTransfrom.rotation, targetRotation, _stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    protected void ForceMove()
    {
        _stateMachine.Enemy.Controller.Move(_stateMachine.Enemy.ForceReceiver.Movement * Time.deltaTime);
    }
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }

    protected bool IsInChasingRange()
    {
        if (_stateMachine.Target.IsDie) return false;
        float playerDistanceSqr = (_stateMachine.Target.transform.position - _stateMachine.Enemy.transform.position).sqrMagnitude;
        return playerDistanceSqr <= _stateMachine.Enemy.Data.PlayerChasingRange * _stateMachine.Enemy.Data.PlayerChasingRange;
    }
}
