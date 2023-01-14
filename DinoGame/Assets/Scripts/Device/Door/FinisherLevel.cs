using System.Collections;
using System;
using UnityEngine;

public class FinisherLevel : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private LoaderScene _loaderScene;
    [SerializeField] private OpenerLastLevel _openerLastLevel;
    private float _waitTime = 0.6f;
    private int _factorOfIncreasingLevelNumber = 1;
    private void Awake()
    {
        _door.OnReachDoor += FinishLevel;
    }
    private void FinishLevel()
    {
        StartCoroutine(CoolDown());
    }
    private IEnumerator CoolDown()
    {
        int numberOfNextLevel = _openerLastLevel.NumberOfLevel;
        bool isOnFinalLevel = numberOfNextLevel == _openerLastLevel.CountOfAllLevels;
        numberOfNextLevel += isOnFinalLevel ? 0 : _factorOfIncreasingLevelNumber;
        Debug.Log("NEXT LEVEL IS: " + numberOfNextLevel);
        Saver<SavableLevel>.Save(new SavableLevel(numberOfNextLevel.ToString()));
        yield return new WaitForSeconds(_waitTime);
        _openerLastLevel.LoadSavableLevel();
        Action OnChooseScene = isOnFinalLevel ? _loaderScene.LoadMenu : _openerLastLevel.OpenLastLevel;
        OnChooseScene?.Invoke();
    }
    private void OnDisable()
    {
        _door.OnReachDoor -= FinishLevel;
    }
}
