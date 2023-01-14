using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMovement : IMovable
{
    private MovementInformation _movementInformation;
    private IGroundMovement _iGroundMovement;
    public MovementInformation MovementInformation { get => _movementInformation; set => _movementInformation = value; }

    public RunMovement(MovementInformation movementInformation, IGroundMovement iGroundMovement)
    {
        _iGroundMovement = iGroundMovement;
        _movementInformation = movementInformation;
    }
    public void Move()
    {
        _movementInformation.Rigidbody2D.velocity = new Vector2(_movementInformation.Speed, _iGroundMovement.GetAdditionalY());
    }
}
