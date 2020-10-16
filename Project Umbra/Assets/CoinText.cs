using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    [SerializeField] Coin coin;

    TextMeshPro coinTMP;
    void Start()
    {
        coinTMP = GetComponent<TextMeshPro>();
        string text = "x" + coin.GetValue().ToString();
        coinTMP.text = text;
    }
}
