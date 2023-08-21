using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int startingMoney = 100;
    private int currentMoney;

    private void Start()
    {
        currentMoney = startingMoney;
    }

    public bool CanAfford(int amount)
    {
        return currentMoney >= amount;
    }

    public void DeductMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
        }
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
    }
}