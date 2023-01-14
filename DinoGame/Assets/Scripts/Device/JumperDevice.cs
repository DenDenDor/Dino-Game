using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperDevice : PlayerDevice
{
    [SerializeField] private Animator _animator;

    public override void DestroyPlayerDevice()
    {
        Destroy(gameObject);
    }

    public override ICreatableDevicePosition ReturnDevicePosition() => new CircleDevicePosition(_radius, true);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TrigCollider<IJumpableEntitie>((entitie) =>
        {
            _animator.SetTrigger("Jump");
            entitie.IMovable = entitie.GetJumpableMovement();
        });
    }
}
