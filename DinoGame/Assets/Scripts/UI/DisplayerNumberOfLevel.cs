using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayerNumberOfLevel : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private OpenerLastLevel _openerLastLevel;
    private void Start()
    {
       _text.text =  $"{_openerLastLevel.NumberOfLevel} / {_openerLastLevel.CountOfAllLevels}";
    }

}
