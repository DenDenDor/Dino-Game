using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoverEgg : MonoBehaviour
{
    [SerializeField] private float _waitTime= 0.2f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        StartCoroutine(CoolDown()); 
    }
    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_waitTime);
        _spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
        Destroy(gameObject);
    }
}
