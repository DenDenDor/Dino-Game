using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UphillMovement : IGroundMovement
{
    private Rigidbody2D _rigidbody2D;
    private float _raduis = 6;
    public UphillMovement(Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
    }
    public float GetAdditionalY()
    {
        Debug.Log("TYytr");
        return _rigidbody2D.velocity.y + _raduis;
    }
}
