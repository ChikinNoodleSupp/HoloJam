using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSSSHI : MonoBehaviour
{
    private Money moneyScript;
    public int moneyPop;
    public float moneyTime;
    public int dupeAmount;

    void Awake()
    {
        moneyScript = FindObjectOfType<Money>();
        // Start the coroutine to add money after 4 seconds
        StartCoroutine(AddMoneyAfterDelay(moneyTime, moneyPop));

    }

    IEnumerator AddMoneyAfterDelay(float delay, int amount)
    {

        while (true)
        {
            // Wait for the specified delay
            yield return new WaitForSeconds(delay);

            // Check if the Money script is assigned
            if (moneyScript != null)
            {
                // Add the specified amount of money
                moneyScript.moneyAmount += amount;
                //Debug.Log("Added " + amount + " money. Total money: " + moneyScript.moneyAmount);
            }
            else
            {
                Debug.LogError("Gacha script reference is not set.");
            }
        }



    }

    public void DuplicateBuff()
    {
        moneyPop += dupeAmount;
    }

}
