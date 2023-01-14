using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJumpableEntitie : IMovableEnitite
{
    public int TimeForReloading { get; set; }
    public IMovable GetJumpableMovement();
}
