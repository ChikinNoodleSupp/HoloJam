using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text moneyText;
    public int moneyAmount;
    public int moneyStartAmount;
    //private float timer = 0f;
    //public float delayAmount;
    public Gacha gacha;

    private void Start()
    {
        moneyAmount = moneyStartAmount;
    }
    //Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if (timer >= delayAmount)
        //{
        //    timer = 0f;
        //    moneyAmount++;
        //}
        moneyText.text = "Money:" + Mathf.Round(moneyAmount);
    }
}
