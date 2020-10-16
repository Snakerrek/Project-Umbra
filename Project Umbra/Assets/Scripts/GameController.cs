using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int coins = 0;

    const float dataSaveTimePeriod = 15.0f;

    private void Awake()
    {
        LoadData();
    }
    private void Start()
    {
        InvokeRepeating("SaveData", dataSaveTimePeriod, dataSaveTimePeriod); // Saving game data every *dataSaveTimePeriod* seconds
    }


    #region Coins Methods

    public int GetCoins() {return coins;}
    public void AddCoins(int amount) {coins += amount;}

    #endregion

    #region Save/Load Methods
    public void SaveData()
    {
        SaveSystem.SaveData(this);
        Debug.Log("Data saved");
    }
    public void LoadData()
    {
        GameData data = SaveSystem.LoadData();
        coins = data.coins;
        Debug.Log("Data loaded");
    }
    #endregion
}
