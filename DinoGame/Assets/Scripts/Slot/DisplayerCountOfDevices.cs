using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerCountOfDevices : MonoBehaviour
{
    [SerializeField] private Slot _slot;
    [SerializeField] private Text _text;
    private void Awake()
    {
        _slot.OnChangeCountOfDevice += ShowCountOfDevices;
        ShowCountOfDevices();
    }
    private void ShowCountOfDevices()
    {
        _text.text = _slot.CountOfDevice.ToString();
    }
    private void OnDisable()
    {
        _slot.OnChangeCountOfDevice -= ShowCountOfDevices;
    }
}
