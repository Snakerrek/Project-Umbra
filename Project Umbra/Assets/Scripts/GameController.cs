using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject coinsText = null;

    TextMeshProUGUI coinTMP;

    const float dataSaveTimePeriod = 15.0f;
    private int coins = 0;

    private void Awake()
    {
        LoadData();
        UpdateCoinsText();
    }
    private void Start()
    {
        InvokeRepeating("SaveData", dataSaveTimePeriod, dataSaveTimePeriod); // Saving game data every *dataSaveTimePeriod* seconds
    }

    private void Update()
    {
        // Testing coins
        if(Input.GetKeyDown("o"))
        {
            AddCoins(10);
        }
        if(Input.GetKeyDown("p"))
        {
            subtractCoins(10);
        }
    }

    #region Coins Methods

    public int GetCoins() {return coins;}
    public void AddCoins(int amount) 
    {
        coins += amount;
        Debug.Log(amount + " coins has been added.");
        UpdateCoinsText();
    }
    public void subtractCoins(int amount)
    {
        coins -= amount;
        Debug.Log(amount + " coins has been substracted");
        UpdateCoinsText();
    }
    void UpdateCoinsText() 
    {
        coinTMP = coinsText.GetComponent<TextMeshProUGUI>();
        coinTMP.text = coins.ToString(); 
    }

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
