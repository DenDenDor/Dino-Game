using UnityEngine;
public interface IMovable
{
  
    public void Move();
    MovementInformation MovementInformation { get; set; }
}
