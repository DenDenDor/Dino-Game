using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    [SerializeField] private float _additionalY;
    public float ReturnAdditionalY => _additionalY + transform.position.y;
}
