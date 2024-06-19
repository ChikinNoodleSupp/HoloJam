using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{

   
    public GameObject[] tableOSSSHI;
    public GameObject[] tableOSHI;
    public GameObject[] tableOshit;
    public int dropChanceOSSSHI;
    public int dropChanceOSHI;
    public int dropChanceOshit;
    public bool itemDropped;
    public Transform spawnPoint;
    public Money money;
    public int gachaCost;
    public TempMove TempMove;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && money.moneyAmount >= gachaCost)
        {
            GachaRoll();
            money.moneyAmount -= gachaCost;
            

        }
    }

    public void GachaRoll()
    {
        if (tag == "GachaItem")
        {
            
        }
        Debug.Log("you rolled gacha");
        int randomNumber = Random.Range(0, 101); //1-100
        itemDropped = false;
        
        if (randomNumber <= dropChanceOSSSHI && !itemDropped) //1 out of 100
        {
            int randomIndex = Random.Range(0, tableOSSSHI.Length); //pick a random object in this array of game objects
            Instantiate(tableOSSSHI[randomIndex], spawnPoint.transform.position, Quaternion.identity);
            itemDropped = true;
        }
        else if (randomNumber <= dropChanceOSHI && randomNumber > 1 && !itemDropped) //30 out of 100
        {
            int randomIndex = Random.Range(0, tableOSHI.Length);
            Instantiate(tableOSHI[randomIndex], spawnPoint.transform.position, Quaternion.identity);
            itemDropped = true;
        }
        else if (!itemDropped) //100 out of 100
        {
            int randomIndex = Random.Range(0, tableOshit.Length);
            Instantiate(tableOshit[randomIndex], spawnPoint.transform.position, Quaternion.identity);
            itemDropped = true;
        }

        TempMove.MoveGacha();


    }
}
