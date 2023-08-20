using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public GameObject MoneyManager;
    public int MoneyAmount;
    // Start is called before the first frame update
    void Start()
    {
        MoneyManager = GameObject.FindGameObjectWithTag("Money");

        StartCoroutine(addingslowley());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator addingslowley()
    {
        yield return new WaitForSeconds(2f);
        MoneyCounter script = MoneyManager.GetComponent<MoneyCounter>();

        script.Money = script.Money + MoneyAmount;
        StartCoroutine(addingslowley());

    }
}
