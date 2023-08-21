using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{

   public int Money = 10;
   public int startingMoney = 100; 


    public Text ValueText;


    // Start is called before the first frame update
    void Start()
    {
        {
            Money = startingMoney; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        ValueText.text = "Money: " + Money.ToString();
    }
    public void SpendMoney(int amount)
    {
        Money -= amount;
    }
}
