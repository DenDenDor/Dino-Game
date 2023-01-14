using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Door _door;
    private void Awake()
    {
        _door = FindObjectOfType<Door>();
        _door.OnReachDoor += StopPlayer;
    }
    private void StopPlayer()
    {
        _player.MovementInformation = null;
        _player.IMovable = null;
    }
    private void OnDisable()
    {
        _door.OnReachDoor -= StopPlayer;
    }
}
