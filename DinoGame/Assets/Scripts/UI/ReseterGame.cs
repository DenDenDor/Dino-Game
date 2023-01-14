using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseterGame : MonoBehaviour
{
    [SerializeField] private OpenerLastLevel _openerLastLevel;
    private int _numberOfStartScene =1 ;
    public void ResetGame()
    {
        Saver<SavableLevel>.Save(new SavableLevel(_numberOfStartScene.ToString()));
        _openerLastLevel.LoadSavableLevel();
    }
}
