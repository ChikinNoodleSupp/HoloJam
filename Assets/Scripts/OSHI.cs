using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSHI : MonoBehaviour
{
    private Money moneyScript;
    public int moneyPop;
    public float moneyTime;
    public int fanfareChance;
    public bool fanfareStatus;
    public float radius = 1.0f;


    void Awake()
    {
        moneyScript = FindObjectOfType<Money>();
        // Start the coroutine to add money after 4 seconds
        StartCoroutine(AddMoneyAfterDelay(moneyTime, moneyPop));
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = radius;
        sphereCollider.isTrigger = true;
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
                Debug.Log("Added " + amount + " money. Total money: " + moneyScript.moneyAmount);
            }
            else
            {
                Debug.LogError("Gacha script reference is not set.");
            }

            int randomNumber = Random.Range(0, 101); //1-100
            if(randomNumber >= fanfareChance)
            {
                fanfareStatus = true;
            }

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GachaItem" && fanfareStatus == true)
        {
            //do the thing to things around you. How? IDK im not a programmer or a designer...
        }
    }
    

}
