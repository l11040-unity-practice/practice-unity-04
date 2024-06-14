using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    int _health;
    public event Action OnDie;
    public bool IsDie = false;
    void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_health == 0) return;

        _health = Mathf.Max(_health - damage, 0);

        if (_health == 0)
        {
            IsDie = true;
            OnDie?.Invoke();
        }

        Debug.Log(_health);
    }
}
