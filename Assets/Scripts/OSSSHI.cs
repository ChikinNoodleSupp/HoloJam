using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OSSSHI : MonoBehaviour
{
    private Money moneyScript;
    public int moneyPop;
    public float moneyTime;
    public int dupeAmount;
    [SerializeField] private MoneyProgressBar moneyBar;
    public GameObject itemUI;
    public bool hasUI;

    void Awake()
    {
        moneyScript = FindObjectOfType<Money>();
        // Start the coroutine to add money after 4 seconds
        StartCoroutine(AddMoneyAfterDelay(moneyTime, moneyPop));

    }

    public void InstantiateUI()
    {
        if (hasUI == false)
        {
            itemUI.SetActive(true);
            hasUI = true;
        }

    }

    public void CloseUI()
    {
        if (hasUI == true)
        {
            itemUI.SetActive(false);
            hasUI = false;
        }
    }

    //public void UpdateMoneyBar(float moneyTime, float currentTime)
    //{
    //    moneyBarSprite.fillAmount = amount;
    //}

    IEnumerator AddMoneyAfterDelay(float delay, int amount)
    {

        while (true)
        {

            float elapsedTime = 0f;
            while (elapsedTime < delay)
            {
                moneyBar.moneyBarSprite.fillAmount = elapsedTime / delay;
                yield return null;
                elapsedTime += Time.deltaTime;
            }

            moneyBar.moneyBarSprite.fillAmount = 1;



            // Check if the Money script is assigned
            if (moneyScript != null)
            {
                // Add the specified amount of money
                moneyScript.moneyAmount += moneyPop;

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
