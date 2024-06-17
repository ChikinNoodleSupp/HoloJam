using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{

    public int pullRate = 0;
    public int money = 0;
    //public GameObject[] lootTable;
    public GameObject gachaDrop;
    public List<Loot> lootList = new List<Loot>();
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GachaRoll();
            GetGachaItem();
            
        }
    }

    public void GachaRoll()
    {
        Debug.Log("you rolled gacha");
        //GameObject gameObject = lootTable[Random.Range(0, lootTable.Length)];
    }

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
    }
}
