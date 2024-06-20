using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Oshit", menuName = "GachaItem/Oshit", order  = 3)]
public class LowTierSO : ScriptableObject
{
    public int dropChance;
    public string gachaName;
    public LowTierSO(string gachaName, int dropchance)
    {
        this.gachaName = gachaName;
        this.dropChance = dropchance;
    }
}
