using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArray : MonoBehaviour
{
    [Tooltip("0 Default, 1 Recoil, 2 Punch, 3 Snipe, 4 Explode")]
    public ScriptableBullet[] Tier1Bullets, Tier2Bullets, Tier3Bullets;
    public List<ScriptableBullet[]> bullet = new List<ScriptableBullet[]>();
    BulletInventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<BulletInventory>();
        bullet.Add(Tier1Bullets);
        bullet.Add(Tier2Bullets);
        bullet.Add(Tier3Bullets);

        InitializeInventory(3, 3, 3);
    }

    void InitializeInventory(int tier1Bullets, int tier2Bullets, int tier3Bullets)
    {
        InitializeInventoryTier(tier1Bullets, bullet[0][0]);
        InitializeInventoryTier(tier2Bullets, bullet[1][0]);
        InitializeInventoryTier(tier3Bullets, bullet[2][0]);
    }

    void InitializeInventoryTier(int amount, ScriptableBullet type)
    {
        for (int i = 0; i < amount; i++)
        {
            inventory.AddToInventory(type);
        }
    }
}
