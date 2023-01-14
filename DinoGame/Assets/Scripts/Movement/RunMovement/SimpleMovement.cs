using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : IGroundMovement
{
    private Rigidbody2D _rigidbody2D;
    public SimpleMovement(Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
    }
    public float GetAdditionalY() => _rigidbody2D.velocity.y;
    
}
