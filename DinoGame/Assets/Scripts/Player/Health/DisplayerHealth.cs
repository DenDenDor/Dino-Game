using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerHealth : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _healthBar;
    private void Start()
    {
        _player.Health.OnChangeHealth += UpdateHealthBar;
    }
    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)_player.Health.CurrentHealth / _player.Health.MaxHealth;
    }
    private void OnDisable()
    {
        _player.Health.OnChangeHealth -= UpdateHealthBar;
    }
}
