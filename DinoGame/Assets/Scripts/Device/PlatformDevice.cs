using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDevice : PlayerDevice
{
    private List<PlayerDevice> _playerDevices = new List<PlayerDevice>();
    public List<PlayerDevice> PlayerDevices { get => _playerDevices; private set => _playerDevices = value; }

    public override void DestroyPlayerDevice()
    {
        for (int i = 0; i < PlayerDevices.Count; i++)
        {
            PlayerDevices[i].Click();
        }
        Destroy(gameObject);
    }
    public override ICreatableDevicePosition ReturnDevicePosition() => new CircleDevicePosition(_radius,false);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.TrigCollider<Player>((player) =>
        {
            Debug.Log(" UUUUU IO!");
            //player.IGroundMovement = new UphillMovement(player.MovementInformation.Rigidbody2D);
        });
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.TrigCollider<Player>((player) =>
        {
            //player.IGroundMovement = new SimpleMovement(player.MovementInformation.Rigidbody2D);
        });

    }
}
