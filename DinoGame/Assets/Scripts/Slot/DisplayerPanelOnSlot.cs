using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerPanelOnSlot : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Slot _slot;
    private void Start()
    {
        _slot.OnChangeCountOfDevice += TryFadingPanel;
        TryFadingPanel();
    }
    private void TryFadingPanel()
    {
        _canvasGroup.ChangeStateOfCanvasGroup(_slot.CountOfDevice == 0);
    }
    private void OnDisable()
    {
        _slot.OnChangeCountOfDevice -= TryFadingPanel;
    }
}
