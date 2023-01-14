using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreatableDevicePosition
{
    public (Vector2, bool) CanReturnDevicePosition(Vector2 mousePosition);
}
