using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.TrigCollider<Player>((player) =>
        {
            player.Flip();
            player.IMovable = player.GetRunMovement();
        });

    }
}
