using System;
using UnityEngine;

[Serializable]
public class PlayerAnimeData
{
    [SerializeField] string _groundParameterName = "@Ground";
    [SerializeField] string _idleParameterName = "Idle";
    [SerializeField] string _walkParameterName = "Walk";
    [SerializeField] string _runParameterName = "Run";

    [SerializeField] string _airParameterName = "@Air";
    [SerializeField] string _jumpParameterName = "Jump";
    [SerializeField] string _fallParameterName = "Fall";

    [SerializeField] string _attackParameterName = "@Attack";
    [SerializeField] string _comboAttackParameterName = "ComboAttack";

    [SerializeField] string _baseAttackParameterName = "BaseAttack";


    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }

    public int AirParameterHash { get; private set; }
    public int JumpParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    public int AttackParameterHash { get; private set; }
    public int ComboAttackParameterHash { get; private set; }

    public int BaseAttackParameterHash { get; private set; }


    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(_groundParameterName);
        IdleParameterHash = Animator.StringToHash(_idleParameterName);
        WalkParameterHash = Animator.StringToHash(_walkParameterName);
        RunParameterHash = Animator.StringToHash(_runParameterName);

        AirParameterHash = Animator.StringToHash(_airParameterName);
        JumpParameterHash = Animator.StringToHash(_jumpParameterName);
        FallParameterHash = Animator.StringToHash(_fallParameterName);

        AttackParameterHash = Animator.StringToHash(_attackParameterName);
        ComboAttackParameterHash = Animator.StringToHash(_comboAttackParameterName);
        BaseAttackParameterHash = Animator.StringToHash(_baseAttackParameterName);
    }
}
