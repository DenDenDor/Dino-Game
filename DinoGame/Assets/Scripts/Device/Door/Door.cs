using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Door : MonoBehaviour
{
    [SerializeField] private Sprite _openDoor;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public event Action OnReachDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TrigCollider<Player>((player) =>
        {
            _spriteRenderer.sprite = _openDoor;
            OnReachDoor?.Invoke();
        });
    }
}
