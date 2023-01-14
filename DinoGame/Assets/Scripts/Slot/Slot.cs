using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int _countOfDevice = 1;
    [SerializeField] private PlayerDevice _playerDevice;
    [SerializeField] private Image _icon;
    public PlayerDevice PlayerDevice { get => _playerDevice; private set => _playerDevice = value; }
    public int CountOfDevice { get => _countOfDevice; private set => _countOfDevice = value; }

    public event Action OnChangeCountOfDevice;
    public event Action<Slot> OnClick;
    private void Awake()
    {
        _icon.sprite = _playerDevice.Sprite;
    }
    public void ChangerCountOfDevice(bool isIncreasing)
    {
        int factorOfNegativity = isIncreasing ? 1 : -1;
        CountOfDevice += 1 * factorOfNegativity;
        OnChangeCountOfDevice?.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (CountOfDevice> 0)
        {
            OnClick?.Invoke(this);
        }
    }
}
