using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{

    public int pullRate = 0;
    public int money = 0;
    public GameObject[] lootTable;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GachaRoll();
            
        }
    }

    public void GachaRoll()
    {
        Debug.Log("you rolled gacha");
        GameObject gameObject = lootTable[Random.Range(0, lootTable.Length)];
    }

}
