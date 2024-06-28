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
    public Button gachaButton;
    public Button gachaButtonx10;

    private Color originalColor;
    private Color originalColorx10;
    private Color gachaButtonColor = Color.green;
    private Color gachaButtonColorx10 = Color.green;

    private void Start()
    {
        moneyAmount = moneyStartAmount;
        if(gachaButton != null)
        {
            originalColor = gachaButton.image.color;
            originalColorx10 = gachaButtonx10.image.color;
        }
    }
    
    void Update()
    {
        
        moneyText.text = "" + Mathf.Round(moneyAmount); //shows money on UI


        if(gachaButton != null)
        {
            if(moneyAmount >= gacha.gachaCost)
            {
                gachaButton.image.color = gachaButtonColor;
            }
            else
            {
                gachaButton.image.color = originalColor;
            }
        }
        if (gachaButtonx10 != null)
        {
            if (moneyAmount >= gacha.gachaCost * 10)
            {
                gachaButtonx10.image.color = gachaButtonColorx10;
            }
            else
            {
                gachaButtonx10.image.color = originalColorx10;
            }


        }

    }
}
