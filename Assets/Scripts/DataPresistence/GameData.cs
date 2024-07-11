using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Money money;

    public GameData()
    {
        money.moneyAmount = 300;
    }
}
