using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject coinsText = null;

    TextMeshProUGUI coinTMP;

    const float dataSaveTimePeriod = 15.0f;
    private int coins = 0;

    [Header("SuperSkills")]
    [SerializeField] GameObject spiralOfFirePrefab = null;
    [SerializeField] float spiralOfFireCooldown = 30.0f;
    [SerializeField] GameObject spiralOfFireShadow = null;
    [SerializeField] GameObject spiralOfFireCooldownText = null;
    private float spiralOfFireCooldownTmp;
    private Text spiralOfFireText;


    Player player;

    private void Awake()
    {
        LoadData();
        UpdateCoinsText();
    }
    private void Start()
    {
        player = FindObjectOfType<Player>();
        spiralOfFireText = spiralOfFireCooldownText.GetComponent<Text>();

        //Setting all cooldowns to 0
        spiralOfFireCooldownTmp = 0.0f;

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

        // Superskills cooldowns
        SpiralOfFireCooldown();
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

    #region SuperSkills Methods
    public void UseSpiralOfFire()
    {
        if (spiralOfFireCooldownTmp <= 0.0f)
        {
            Instantiate(spiralOfFirePrefab, player.transform.position, Quaternion.identity);
            spiralOfFireCooldownTmp = spiralOfFireCooldown;
            spiralOfFireShadow.SetActive(true);
        }
        else
            Debug.Log("Skill have cooldown of: " + spiralOfFireCooldownTmp + "s.");
    }

    private void SpiralOfFireCooldown()
    {
        if (spiralOfFireCooldownTmp > 0.0f)
        {
            spiralOfFireCooldownTmp -= Time.deltaTime;
            spiralOfFireText.text = Mathf.CeilToInt(spiralOfFireCooldownTmp).ToString();
            spiralOfFireText.color = Color.white;
        }
        else
        {
            spiralOfFireShadow.SetActive(false);
            spiralOfFireText.text = "V";
            spiralOfFireText.color = Color.black;
        }
    }

    #endregion
}
