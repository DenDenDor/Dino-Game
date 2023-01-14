using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CircleDevicePosition : ICreatableDevicePosition
{
    private float _radius;
    private bool _isOutCollider;
    public CircleDevicePosition(float radius, bool isOutCollider)
    {
        _radius = radius;
        _isOutCollider = isOutCollider;
    }
    public (Vector2,bool) CanReturnDevicePosition(Vector2 mousePosition)
    {
        Vector2 spawnPosition = mousePosition;
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(mousePosition, _radius);
        bool foundLand = !_isOutCollider;
        foreach (Collider2D collider2D in collider2Ds)
        {
            collider2D.TrigCollider<Land>(e =>
            {
                spawnPosition = new Vector2(mousePosition.x, e.ReturnAdditionalY);
                foundLand = _isOutCollider;
            });
            if (foundLand)
            {
                break;
            }
        }
        return (spawnPosition,foundLand);
    }
}
