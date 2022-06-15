using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BulletShop : MonoBehaviour
{
    TextMeshPro text;
    MeshRenderer mr;
    BulletInventoryUI inventoryUI;
    public BaseCamp baseCamp;
    public ScriptableBullet bullet;
    BulletArray bulletArray;

    void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
        mr = GetComponentInChildren<MeshRenderer>();
        inventoryUI = FindObjectOfType<BulletInventoryUI>();

        bulletArray = FindObjectOfType<BulletArray>();
        int randomTierNumber = Random.Range(0, 9);
        int randomTier;

        switch (randomTierNumber)
        {
            case 9:
                randomTier = 3;
                break;
            case int number when number >= 6:
                randomTier = 2;
                break;
            default:
                randomTier = 1;
                break;
        }

        int randomBullet = Random.Range(0, bulletArray.bullet[randomTier].Length);
        bullet = bulletArray.bullet[randomTier][randomBullet];

        mr.material.SetTexture("_MainTex", bullet.bulletSprite.texture);
        mr.material.SetFloat("_Tier", bullet.tier);

        text.text = bullet.bulletName;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && baseCamp.lit)
            ChooseBullet();
    }

    void ChooseBullet()
    {
        Time.timeScale = 0.01f;
        inventoryUI.ChangeUIState(true);
        inventoryUI.ChangeAssignBullet(bullet);

        BulletShop[] bulletShops = FindObjectsOfType<BulletShop>();

        for (int i = 0; i < bulletShops.Length; i++)
        {
            bulletShops[i].baseCamp.gameObject.SetActive(false);
            if (bulletShops[i] != this)
            {
                bulletShops[i].gameObject.SetActive(false);
            }
        }

        gameObject.SetActive(false);
    }
}
