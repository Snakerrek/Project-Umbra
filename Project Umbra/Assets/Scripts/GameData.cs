using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coins;


    public GameData (GameController gameController)
    {
        coins = gameController.GetCoins();
    }

}
