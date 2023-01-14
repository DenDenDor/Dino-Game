using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverDevice : MonoBehaviour
{
    [SerializeField] private DeviceMover _deviceMover;
    [SerializeField] private SlotBuyer _slotBuyer;
    private List<PlayerDevice> _currentPlayerDevices = new List<PlayerDevice>();
    private ChangerCountOfDevices _changerCountOfDevices;
    public List<PlayerDevice> CurrentPlayerDevices { get => _currentPlayerDevices; private set => _currentPlayerDevices = value; }
    private void Awake()
    {
        _deviceMover.OnCreatePlayerDevice += AddPlayerDevice;
        _changerCountOfDevices = new ChangerCountOfDevices(_slotBuyer);
    }
    private void AddPlayerDevice(PlayerDevice playerDevice)
    {
        _currentPlayerDevices.Add(playerDevice);
        playerDevice.OnClick += Remove;
    }
    private void Remove(PlayerDevice playerDevice)
    {
        _currentPlayerDevices.Remove(playerDevice);
        playerDevice.OnClick -= Remove;
        _changerCountOfDevices.ChangeCountOfSlotDevices(playerDevice, true);
        playerDevice.DestroyPlayerDevice();
    }
    private void OnDisable()
    {
        _deviceMover.OnCreatePlayerDevice -= AddPlayerDevice;
    }
}
