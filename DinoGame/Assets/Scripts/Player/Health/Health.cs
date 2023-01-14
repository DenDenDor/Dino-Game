using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Health
{
    private int _currentHealth;
    private readonly int _maxHealth;
    private readonly int _reloadTime = 500;
    private bool _isCoolDown = true;
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public event Action OnChangeHealth;
    public event Action OnDeath;
    public Health(int currentHealth)
    {
        _currentHealth = currentHealth;
        _maxHealth = _currentHealth;
    }
    public void TryApplyingDamage(int damage)
    {
        if (damage < 0)
        {
            throw new InvalidOperationException();
        }
        if (_isCoolDown)
        {
            _isCoolDown = false;
            _currentHealth -= damage;
            OnChangeHealth?.Invoke();
            if (_currentHealth <= 0)
            {
                OnDeath?.Invoke();
            }
            Timer timer = new Timer(Reload, null, _reloadTime, Timeout.Infinite);
        }
        void Reload(object obj)
        {
            _isCoolDown = true;
        }
    }
     
}
