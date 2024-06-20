using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OSHI", menuName = "GachaItem/OSHI", order  = 2)]
public class MidTierSO : ScriptableObject
{
    public int dropChance;
    public string gachaName;
    public MidTierSO(string gachaName, int dropchance)
    {
        this.gachaName = gachaName;
        this.dropChance = dropchance;
    }
}
