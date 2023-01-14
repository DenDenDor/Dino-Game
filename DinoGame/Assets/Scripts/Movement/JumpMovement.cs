using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JumpMovement : IMovable
{
    private float _jumpForce = 7;
    private float _lossesByGravity = 1.3f;
    private MovementInformation _movementInformation;
    public MovementInformation MovementInformation { get => _movementInformation; set => _movementInformation = value; }
    public JumpMovement(MovementInformation movementInformation, int timeForJump, IMovableEnitite iMovableEnitite)
    {
        _movementInformation = movementInformation;
        Timer timer = new Timer(ChangeMovement, null, timeForJump, Timeout.Infinite);
        void ChangeMovement(object obj)
        {
             if (iMovableEnitite.IMovable == this)
            {
                iMovableEnitite.IMovable = iMovableEnitite.GetRunMovement();
            }
        }
    }
  
    public void Move()
    {
        _movementInformation.Rigidbody2D.velocity =  Vector2.up * _jumpForce + new Vector2(_movementInformation.Speed / _lossesByGravity,0);
    }
}
