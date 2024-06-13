using System;
using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine _stateMachine;
    protected readonly PlayerGroundData groundData;
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this._stateMachine = stateMachine;
        groundData = stateMachine.Player.Data.GroundData;
    }
    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        Move();
    }

    protected void StartAnimation(int animatorHash)
    {
        _stateMachine.Player.Animator.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        _stateMachine.Player.Animator.SetBool(animatorHash, false);
    }

    private void ReadMovementInput()
    {
        _stateMachine.MovementInput = _stateMachine.Player.Input.PlayerActions.Movement.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 movementDir = GetMovementDir();
        Move(movementDir);
        Rotate(movementDir);
    }

    private Vector3 GetMovementDir()
    {
        Vector3 forward = _stateMachine.MainCamTransform.forward;
        Vector3 right = _stateMachine.MainCamTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward * _stateMachine.MovementInput.y + right * _stateMachine.MovementInput.x;
    }
    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        _stateMachine.Player.Controller.Move((direction * movementSpeed) * Time.deltaTime);
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
            Transform playerTransfrom = _stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransfrom.rotation = Quaternion.Slerp(playerTransfrom.rotation, targetRotation, _stateMachine.RotationDamping * Time.deltaTime);
        }
    }
}
