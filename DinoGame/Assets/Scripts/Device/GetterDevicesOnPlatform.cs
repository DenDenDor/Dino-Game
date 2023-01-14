using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterDevicesOnPlatform : MonoBehaviour
{
    [SerializeField] private PlatformDevice _platformDevice;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TrigCollider<PlayerDevice>((playerDevice) =>
        {
            if (playerDevice.GetType() != _platformDevice.GetType())
            {
                _platformDevice.PlayerDevices.Add(playerDevice);
            }
        });
    }

}
