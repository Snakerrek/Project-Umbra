using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] int minValue = 1;
    [SerializeField] int maxValue = 10;

    int value;
    private void Awake()
    {
        value = Mathf.FloorToInt(Random.Range(minValue, maxValue));
        Destroy(this, 60.0f);
    }

    public int GetValue()
    {
        return value;
    }
}
