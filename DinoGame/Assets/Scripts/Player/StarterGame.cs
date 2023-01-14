using System.Collections;
using UnityEngine;
using System;
public class StarterGame : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _waitTime = 1;
    [SerializeField] private float _timeForStartingMoving = 0.4f;
    private bool _isGameStarted;
    public event Action OnStartGame;
    private void Awake()
    {
        StartCoroutine(CoolDown());
    }
    public void StartGame()
    {
        _isGameStarted = true;
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_waitTime);
        yield return new WaitUntil(() => _isGameStarted);
        OnStartGame?.Invoke();
        StartCoroutine(StartPlayerMovement());
    }
    private IEnumerator StartPlayerMovement()
    {
        yield return new WaitForSeconds(_timeForStartingMoving);
        _player.IMovable = _player.GetRunMovement();
    }
}
