using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerCountOfDevices : MonoBehaviour
{
    private SlotBuyer _slotBuyer;
    public ChangerCountOfDevices(SlotBuyer slotBuyer)
    {
        _slotBuyer = slotBuyer;
    }
    public void ChangeCountOfSlotDevices(PlayerDevice playerDevice, bool isIncreasing)
    {
        Slot slot = _slotBuyer.Slots.Find(e => e.PlayerDevice.GetType() == playerDevice.GetType());
        slot.ChangerCountOfDevice(isIncreasing);
    }
}
