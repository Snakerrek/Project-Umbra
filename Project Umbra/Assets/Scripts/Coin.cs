using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] int minValue = 1;
    [SerializeField] int maxValue = 10;

    int value;
    private void Awake()
    {
        value = Mathf.FloorToInt(Random.Range(minValue, maxValue));
    }

    private void Start()
    {
        GameObject coinText = transform.GetChild(0).gameObject;
        TextMeshPro coinTextTMP = coinText.GetComponent<TextMeshPro>();
        coinTextTMP.text = "x" + value.ToString();
        Destroy(gameObject, 60.0f);
    }

    public int GetValue()
    {
        return value;
    }
}
