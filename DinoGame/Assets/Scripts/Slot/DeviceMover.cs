using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
public class DeviceMover : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _radius;
    [SerializeField] private Camera _camera;
    [SerializeField] private SlotBuyer _slotBuyer;
    private PlayerDevice _playerDevice;
    private bool _isClicked;
    public event Action<PlayerDevice> OnCreatePlayerDevice;
    private void Awake()
    {
        _slotBuyer.OnChoosePlayerDevice += ChoosePlayerDevice;
    }
    private void ChoosePlayerDevice(PlayerDevice playerDevice)
    {
        _canvasGroup.ChangeStateOfCanvasGroup(true);
        _playerDevice = playerDevice;
        _isClicked = true;
        _icon.sprite = _playerDevice.Sprite;
    }
    private void Update()
    {
        if (_isClicked)
        {
            Vector2 mousePosition = Input.mousePosition;
            transform.position = mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 position = _camera.ScreenToWorldPoint(mousePosition);
                (Vector2,bool) devicePosition = _playerDevice.ICreatableDevicePosition.CanReturnDevicePosition(position);
                if (devicePosition.Item2)
                {
                    PlayerDevice playerDevice = Instantiate(_playerDevice, devicePosition.Item1, Quaternion.identity);
                    OnCreatePlayerDevice?.Invoke(playerDevice);
                }
                _isClicked = false;
                _canvasGroup.ChangeStateOfCanvasGroup(false);

            }
        }
    }
    private void OnDisable()
    {
        _slotBuyer.OnChoosePlayerDevice -= ChoosePlayerDevice;
    }
}
