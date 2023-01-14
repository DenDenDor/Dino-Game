using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableEgg : MonoBehaviour, IClickable
{
    [SerializeField] private StarterGame _starterGame;
    public void Click()
    {
        _starterGame.StartGame();
        Destroy(this);
    }
}
