using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TrigCollider<Player>((player) =>
        {
            player.Health.TryApplyingDamage(_damage);
        });
    }
}
