using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerStartText : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    private StarterGame _starterGame;
    [SerializeField] private float _duration = 0.3f;
    private void Awake()
    {
        _starterGame = FindObjectOfType<StarterGame>();
        _starterGame.OnStartGame += FadeCanvasGroup;
    }
    private void FadeCanvasGroup() => StartCoroutine(_canvasGroup.Fade(0,_duration));
    private void OnDisable()
    {
        _starterGame.OnStartGame -= FadeCanvasGroup;
    }
}
