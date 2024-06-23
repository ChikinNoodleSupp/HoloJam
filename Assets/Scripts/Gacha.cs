using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{

    [Tooltip("Put OSSSHI prefabs here")]
    public GameObject[] tableOSSSHI;
    [Tooltip("Put OSHI prefabs here")]
    public GameObject[] tableOSHI;
    [Tooltip("Put Oshit prefabs here")]
    public GameObject[] tableOshit;
    [Tooltip("Cant be smaller than 1 or bigger than 100")]
    public int dropChanceOSSSHI;
    [Tooltip("Cant be smaller than 1 or bigger than 100")]
    public int dropChanceOSHI;
    [Tooltip("this HAS to be 100, otherwise you have a chance to pull nothing")]
    public int dropChanceOshit;
    public bool itemDropped;
    public Transform spawnPoint;
    public Money money;
    public int gachaCost;
    [Tooltip("Your gacha pulls will be stored here")]
    public List<GameObject> gachaPulls = new List<GameObject>();
    public Transform storePoint;
    public string gachaItemTag = "GachaItem";


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
        
        Debug.Log("you rolled gacha");
        int randomNumber = Random.Range(0, 101); //1-100
        itemDropped = false;
        //foreach (GameObject gachaItem in gachaPulls)
        //{
        //    //if (gachaItem != null)
        //    //{
        //    //    gachaItem.transform.position = storePoint.transform.position;
        //    //}
        //}

        if (randomNumber <= dropChanceOSSSHI && !itemDropped) //1 out of 100
        {
            // put VFX stuff here
            int randomIndex = Random.Range(0, tableOSSSHI.Length); //pick a random object in this array of game objects
            GameObject newPrefab = Instantiate(tableOSSSHI[randomIndex], spawnPoint.transform.position, Quaternion.identity); //spawns random object from the list
            
            if (IsDuplicate(newPrefab))
            {
                GameObject originalItem = GetOriginalItem(newPrefab);
                scriptCheck(originalItem);
                Destroy(newPrefab );
            }
            else
            {
                gachaPulls.Add(newPrefab);
            }

            itemDropped = true;
        }
        else if (randomNumber <= dropChanceOSHI && randomNumber > 1 && !itemDropped) //30 out of 100
        {
            // put VFX stuff here
            int randomIndex = Random.Range(0, tableOSHI.Length);
            GameObject newPrefab = Instantiate(tableOSHI[randomIndex], spawnPoint.transform.position, Quaternion.identity);

            if (IsDuplicate(newPrefab))
            {
                GameObject originalItem = GetOriginalItem(newPrefab);
                scriptCheck(originalItem);
                Destroy(newPrefab);
            }
            else
            {
                gachaPulls.Add(newPrefab);
            }

            itemDropped = true;
        }
        else if (!itemDropped) //100 out of 100
        {
            // put VFX stuff here
            int randomIndex = Random.Range(0, tableOshit.Length);
            GameObject newPrefab = Instantiate(tableOshit[randomIndex], spawnPoint.transform.position, Quaternion.identity);

            if (IsDuplicate(newPrefab))
            {
                GameObject originalItem = GetOriginalItem(newPrefab);
                scriptCheck(originalItem);
                Destroy(newPrefab);
                
            }
            else
            {
                gachaPulls.Add(newPrefab);
            }

            itemDropped = true;
        }

       bool IsDuplicate(GameObject prefab)
        {
            Debug.Log(prefab.name);
            
            foreach (GameObject newPrefab in gachaPulls)
            {
                Debug.Log(newPrefab.name);
                if (prefab.name  == newPrefab.name)
                {

                    return true;
                }
            }
            return false;
        }


    }

    public void scriptCheck(GameObject gameObject)
    {
        if (gameObject.GetComponent<OSHI>() != null)
        {
            OSHI oshi = gameObject.GetComponent<OSHI>();
            oshi.DuplicateBuff();

        }
        if (gameObject.GetComponent<OSSSHI>() != null)
        {
            OSSSHI ossshi = gameObject.GetComponent<OSSSHI>();
            ossshi.DuplicateBuff();
        }
        if (gameObject.GetComponent<Oshit>() != null)
        {
            Oshit oshit = gameObject.GetComponent<Oshit>();
            oshit.DuplicateBuff();
        }
    }

    public GameObject GetOriginalItem(GameObject orignalItem)
    {

        foreach (GameObject newPrefab in gachaPulls)
        {
            if (newPrefab.name == orignalItem.name)
            {
                return newPrefab;
            }
        }
        return null;
    }
}
