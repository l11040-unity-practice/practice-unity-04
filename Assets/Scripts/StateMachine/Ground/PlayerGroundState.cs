using System;
using UnityEngine;
using UnityEngine.InputSystem;

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

        if (_stateMachine.IsAttacking)
        {
            OnAttack();
            return;
        }
    }

    private void OnAttack()
    {
        _stateMachine.ChangeState(_stateMachine.ComboAttackState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (!_stateMachine.Player.Controller.isGrounded &&
            _stateMachine.Player.Controller.velocity.y < Physics.gravity.y * Time.fixedDeltaTime)
        {
            _stateMachine.ChangeState(_stateMachine.FallState);
        }
    }
    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        if (_stateMachine.MovementInput == Vector2.zero) return;

        _stateMachine.ChangeState(_stateMachine.IdleState);

        base.OnMovementCanceled(context);
    }
    protected override void OnJumpStarted(InputAction.CallbackContext context)
    {
        _stateMachine.ChangeState(_stateMachine.JumpState);
        base.OnJumpStarted(context);
    }
}
