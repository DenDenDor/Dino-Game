using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SlotBuyer : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots;
    private Slot _slot;

    public List<Slot> Slots { get => _slots; private set => _slots = value; }

    public event Action<PlayerDevice> OnChoosePlayerDevice;
    private void Awake()
    {
        Slots.ForEach(e => e.OnClick += ChooseSlot);
    }
    private void ChooseSlot(Slot slot)
    {
        _slot = slot;
        OnChoosePlayerDevice?.Invoke(_slot.PlayerDevice);
    }
    private void OnDisable()
    {
        Slots.ForEach(e => e.OnClick -= ChooseSlot);
    }
}
