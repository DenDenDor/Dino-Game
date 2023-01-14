using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    private protected void InstantiateParticle(Vector3 position)
    {
        Instantiate(_particle, position, Quaternion.identity);
    }
    protected abstract void CreateParticle();
}
