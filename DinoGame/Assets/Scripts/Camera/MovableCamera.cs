using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovableCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private Vector3 _offset;
    private Vector2 _velocity;
    [SerializeField] private float _leftLimit = -10;
    [SerializeField] private float _rightLimit = 10;
    [SerializeField] private float _bottomLimit = -10;
    [SerializeField] private float _upperLimit = 10;

    private void Update()
    {
        transform.position = new Vector3
        (
          Mathf.Clamp(transform.position.x, _leftLimit, _rightLimit),
           Mathf.Clamp(transform.position.y, _bottomLimit, _upperLimit),
           transform.position.z
        );

    }
    private void FixedUpdate()
    {
        transform.position = new Vector3
        (GetPlayerPosiotion(transform.position.x, _player.transform.position.x + _offset.x, _velocity.x),
        GetPlayerPosiotion(transform.position.y, _player.transform.position.y + _offset.y, _velocity.y),
        transform.position.z);

    }

    private float GetPlayerPosiotion(float position, float playerPositon, float velocity) => Mathf.SmoothDamp(position, playerPositon, ref velocity, _speed);

}
