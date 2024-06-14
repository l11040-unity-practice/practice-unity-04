using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Collider _myCollider;

    int _damage;
    float _knockback;
    List<Collider> _alreadyCollider = new List<Collider>();

    private void OnEnable()
    {
        _alreadyCollider.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _myCollider) return;
        if (_alreadyCollider.Contains(other)) return;

        _alreadyCollider.Add(other);

        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }

        if (other.TryGetComponent(out ForceReceiver force))
        {
            Vector3 dir = (other.transform.position - _myCollider.transform.position).normalized;
            force.AddForce(_knockback * dir);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        _damage = damage;
        _knockback = knockback;
    }
}
