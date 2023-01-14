using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinParticle : PlayerParticle
{
    [SerializeField] private Door _door;
    private void Awake()
    {
        _door.OnReachDoor += CreateParticle;
    }
    protected override void CreateParticle() => InstantiateParticle(transform.position);
    private void OnDisable()
    {
        _door.OnReachDoor -= CreateParticle;
    }
}
