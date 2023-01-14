using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IJumpableEntitie
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _timeForReloading = 3000;
    [SerializeField] private int _startHealth = 6;
    private Health _health;
    private IGroundMovement _iGroundMovement;
    private IMovable _iMovable;
    private MovementInformation _movementInformation;
    public IMovable IMovable { get => _iMovable; set => _iMovable = value; }
    public MovementInformation MovementInformation { get => _movementInformation; set => _movementInformation = value; }
    public int TimeForReloading { get => _timeForReloading; set => _timeForReloading = value; }
    public Health Health { get => _health; private set => _health = value; }
    public IGroundMovement IGroundMovement { get => _iGroundMovement; set => _iGroundMovement = value; }

    public event Action OnJump;
    public event Action OnRun;
    private void Awake()
    {
        _health = new Health(_startHealth);
        IGroundMovement = new SimpleMovement(_rigidbody2D);
        _movementInformation = new MovementInformation(transform, _speed, _rigidbody2D);
    }
    public void Flip()
    {
        _movementInformation.Flip();
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
    private void Update()
    {
        IMovable?.Move();
    }

    public IMovable GetJumpableMovement()
    {
        OnJump?.Invoke();
        return new JumpMovement(MovementInformation, TimeForReloading, this);
    }
    public IMovable GetRunMovement()
    {
        OnRun?.Invoke();
        return new RunMovement(_movementInformation, IGroundMovement);
    }
}
