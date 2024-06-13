using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float JumpForce { get; set; }
    public Transform MainCamTransform { get; set; }
    public PlayerIdleState IdleState { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        MainCamTransform = Camera.main.transform;

        IdleState = new PlayerIdleState(this);

        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }
}