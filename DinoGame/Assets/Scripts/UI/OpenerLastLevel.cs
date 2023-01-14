using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OpenerLastLevel : MonoBehaviour
{
    [SerializeField] private LoaderScene _loaderScene;
    private int _numberOfLevel = 1;
    private int _countOfAllLevels = 8;
    public int NumberOfLevel { get => _numberOfLevel; private set => _numberOfLevel = value; }
    public int CountOfAllLevels { get => _countOfAllLevels; private set => _countOfAllLevels = value; }

    private void Awake()
    {
        LoadSavableLevel();
    }
    public void LoadSavableLevel()
    {
        SavableLevel savableLevel = Loader<SavableLevel>.Load(new SavableLevel());
        if (savableLevel == null)
        {
            return;
        }
        int.TryParse(savableLevel.CountOfLevel, out _numberOfLevel);
    }
    public void OpenLastLevel()
    {
        int numberOfLevel = NumberOfLevel > CountOfAllLevels ? CountOfAllLevels : NumberOfLevel;
        _loaderScene.LoadLevel(numberOfLevel);
    }
}
