using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;
    public int moneyAmount;
    public int moneyStartAmount;
    public Gacha gacha;

    private void Start()
    {
        moneyAmount = moneyStartAmount;
        
    }
    
    void Update()
    {
        
        moneyText.text = "Money:" + Mathf.Round(moneyAmount); //shows money on UI

        if(moneyAmount >= gacha.gachaCost)
        {
            gacha.GachaNotice();
            
        }

    }
}
