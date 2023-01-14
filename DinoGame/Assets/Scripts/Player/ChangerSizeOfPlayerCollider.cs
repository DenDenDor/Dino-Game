using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerSizeOfPlayerCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider2D;
    [SerializeField] private StarterGame _starterGame;
    private Vector2 _startSize = new Vector2(1, 1);
    private void Awake()
    {
        _starterGame.OnStartGame += SetSize;
    }
    private void SetSize()
    {
        _collider2D.offset = Vector2.zero;
        _collider2D.size = _startSize;
    }
    private void OnDisable()
    {
        _starterGame.OnStartGame -= SetSize;
    }
}
