using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerDevice : Trigger, IClickable
{
    [SerializeField] private protected float _radius = 1;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private ICreatableDevicePosition _iCreatableDevicePosition;
    public Sprite Sprite => _spriteRenderer.sprite;
    public ICreatableDevicePosition ICreatableDevicePosition 
    {
        get => _iCreatableDevicePosition ??= ReturnDevicePosition();
             private set => _iCreatableDevicePosition = value; 
    }
    public event Action<PlayerDevice> OnClick;
    private void Awake()
    {
        _iCreatableDevicePosition = ReturnDevicePosition();
    }
    public void Click()
    {
        OnClick?.Invoke(this);
    }
    public abstract void DestroyPlayerDevice();
    public abstract ICreatableDevicePosition ReturnDevicePosition();
}
