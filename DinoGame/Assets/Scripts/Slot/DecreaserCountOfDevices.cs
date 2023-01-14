using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaserCountOfDevices : MonoBehaviour
{
    [SerializeField] private DeviceMover _deviceMover;
    [SerializeField] private SlotBuyer _slotBuyer;
    private ChangerCountOfDevices _changerCountOfDevices;
    private void Awake()
    {
        _deviceMover.OnCreatePlayerDevice += DecreaseCountOfDevices;
        _changerCountOfDevices = new ChangerCountOfDevices(_slotBuyer);
    }
    private void DecreaseCountOfDevices(PlayerDevice playerDevice)
    {
        _changerCountOfDevices.ChangeCountOfSlotDevices(playerDevice, false);
    }
        private void OnDisable()
    {
        _deviceMover.OnCreatePlayerDevice -= DecreaseCountOfDevices;
    }

}
