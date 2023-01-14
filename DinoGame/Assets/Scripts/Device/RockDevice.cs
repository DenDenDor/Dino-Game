using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDevice : PlayerDevice, IJumpableEntitie
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _timeForReloading = 1000;
    private MovementInformation _movementInformation;
    private IMovable _iMovable;
    public IMovable IMovable { get => _iMovable; set => _iMovable = value; }
    public MovementInformation MovementInformation { get => _movementInformation; set => _movementInformation = value; }
    public int TimeForReloading { get => _timeForReloading; set => _timeForReloading = value; }
    public override void DestroyPlayerDevice()
    {
        Destroy(gameObject);
    }
    private void Awake()
    {
        _movementInformation = new MovementInformation(transform, 0, _rigidbody2D);
    }
    public override ICreatableDevicePosition ReturnDevicePosition() => new CircleDevicePosition(_radius, false);
    private void Update()
    {
        _iMovable?.Move();
    }

    public IMovable GetJumpableMovement()
    {
        return new JumpMovement(MovementInformation, TimeForReloading, this);
    }

    public IMovable GetRunMovement()
    {
        return new RunMovement(_movementInformation, new SimpleMovement(_rigidbody2D));
    }
}
