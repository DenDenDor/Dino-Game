using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInformation 
{
    private float _factorOfFlip = 1;
    private bool _isFlipped;
    private readonly float _speed;
    private readonly Transform _currentTransform;
    private readonly Rigidbody2D _rigidbody2D;
    public float Speed => _speed * _factorOfFlip;
    public Transform CurrentTransform => _currentTransform;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public void Flip()
    {
        _factorOfFlip = _isFlipped ? 1 : -1;
        _isFlipped = !_isFlipped;
    }
    public MovementInformation(Transform currentTrasform, float speed, Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
        _speed = speed;
        _currentTransform = currentTrasform;
    }
}
