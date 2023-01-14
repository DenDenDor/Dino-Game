using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] private protected int _damage;
    protected void ApplyDamage(Collider2D collision)
    {
        collision.TrigCollider<Player>((player) =>
        {
            player.Health.TryApplyingDamage(_damage);
        });
    }
}
