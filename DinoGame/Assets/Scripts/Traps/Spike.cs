using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    [SerializeField] private float _waitTime = 5;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        _animator.SetTrigger("Attack");
        yield return new WaitForSeconds(_waitTime);
        StartCoroutine(CoolDown());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ApplyDamage(collision);
    }
}
