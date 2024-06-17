using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{

    //public int pullRate = 0;
    public int money = 0;
    //public GameObject[] lootTable;
    public GameObject gachaDrop;
    public List<Loot> lootList = new List<Loot>();
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GachaRoll();
            //GetGachaItem();
            GetComponent<Gacha>().InstantiateLoot(transform.position);
            
        }
    }

    //public void GachaRoll()
    //{
    //    Debug.Log("you rolled gacha");
    //    //GameObject gameObject = lootTable[Random.Range(0, lootTable.Length)];
    //}

    Loot GetGachaItem()
    {
        int randomNumber = Random.Range(1, 101); //1-100
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }

        }
        if(possibleItems.Count > 0)
        {
            Loot gachaDrop = possibleItems[Random.Range(0, possibleItems.Count)]; //picks a random item 
            return gachaDrop;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPoint)
    {
        Loot gachaDrop = GetGachaItem();
        if (gachaDrop != null)
        {
            GameObject lootGameObject = Instantiate(gachaDrop, spawnPoint, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = gachaDrop.gachaSprite;

            //add VFX code here
        }
    }
}
