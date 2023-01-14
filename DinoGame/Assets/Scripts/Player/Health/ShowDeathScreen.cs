using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDeathScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        _player.Health.OnDeath += ShowScreen;
    }
    private void ShowScreen()
    {
        _animator.enabled = true;
    }
    private void OnDisable()
    {
        _player.Health.OnDeath -= ShowScreen;
    }
}
