
using System;
using UnityEngine;

[Serializable]
public class PlayerGroundData
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; set; } = 5f;
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; set; } = 1f;

    [field: Header("Idle Data")]
    [field: Header("Walk Data")]
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; set; } = 0.225f;
    [field: Header("Run Data")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; set; } = 1f;
}

[Serializable]
public class PlayerAirData
{
    [field: Header("Jump Data")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; set; } = 5f;
}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }

}
