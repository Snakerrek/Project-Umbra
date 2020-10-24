using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] int healAmount = 25;

    private void Start()
    {
        Destroy(gameObject, 60.0f);
    }
    public int GetHealAmount()
    {
        return healAmount;
    }
    
}
