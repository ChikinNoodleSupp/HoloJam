using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public string gachaName;
    public int dropChance;
    public Sprite gachaSprite;
    public string gachaRarity;

    public Loot(string gachaName, int dropchance)
    {
        this.gachaName = gachaName;
        this.dropChance = dropchance;
    }
}
