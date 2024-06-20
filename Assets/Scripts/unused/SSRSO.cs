using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OSSSHI", menuName = "GachaItem/OSSSHI", order = 1)]
public class SSRSO : ScriptableObject
{
    public int dropChance;
    public string gachaName;
   

    public SSRSO(string gachaName, int dropchance)
    {
        this.gachaName = gachaName;
        this.dropChance = dropchance;
    }
}
