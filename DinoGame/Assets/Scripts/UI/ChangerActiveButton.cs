using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerActiveButton : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    public void ChangeActive()
    {
        _gameObject.SetActive(!_gameObject.activeInHierarchy); 
    }
}
