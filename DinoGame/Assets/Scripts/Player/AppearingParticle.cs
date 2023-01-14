using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearingParticle : PlayerParticle
{
    [SerializeField] private StarterGame _starterGame;
    [SerializeField] private Transform _point;
    protected override void CreateParticle()
    {
        InstantiateParticle(_point.position);
    }

    private void Awake()
    {
        _starterGame.OnStartGame += CreateParticle;
    }
    private void OnDisable()
    {
        _starterGame.OnStartGame -= CreateParticle;
    }

}
