using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovableEnitite 
{
    public IMovable IMovable { get; set; }

    public MovementInformation MovementInformation { get; set; }
    public IMovable GetRunMovement();

}
