using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyProgressBar : MonoBehaviour
{
    
    public Image moneyBarSprite;

    


    public void UpdateMoneyBar(float moneyTime, float currentTime)
    {
        moneyBarSprite.fillAmount = currentTime / moneyTime;
    }
}
