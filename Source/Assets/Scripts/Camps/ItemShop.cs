using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    public BaseCamp baseCamp;
    TokenManager tokenManager;

    public ItemScriptable[] explosiveItem, statsItem, moneyItem, otherItem;
    List<ItemScriptable[]> items = new List<ItemScriptable[]>();
    public MeshRenderer itemSprite;
    public TextMeshPro itemName;
    public TextMeshPro itemDescription;
    int type, randomItem;
    public bool free = false;
    bool bought = false;

    void Start()
    {
        //baseCamp = GetBaseCamp();
        tokenManager = FindObjectOfType<TokenManager>();
        
        items.Add(explosiveItem);
        items.Add(statsItem);
        items.Add(moneyItem);
        items.Add(otherItem);

        type = Random.Range(0, items.Count);
        randomItem = Random.Range(0, items[type].Length);
        itemSprite.material.SetTexture("_MainTex", items[type][randomItem].itemSprite.texture);
        itemSprite.material.SetColor("_SpriteColor", items[type][randomItem].itemColor);

        itemName.text = items[type][randomItem].itemName;
        itemDescription.text = items[type][randomItem].itemDescription;
    }

    private void Update()
    {
        if (bought)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            int cost = free ? 0 : 3;
            if (tokenManager.Tokens >= cost && baseCamp.lit)
            {
                bought = true;
                baseCamp.enabled = false;
                tokenManager.Tokens -= cost;
                ItemStats.UpdateItemStats(items[type][randomItem].itemName);
                gameObject.SetActive(false);
            }
        }
    }

    BaseCamp GetBaseCamp()
    {
        switch(name)
        {
            case string input when input.Contains("Middle"):
                return GameObject.Find("Middle").GetComponent<BaseCamp>();
            case string input when input.Contains("Left"):
                return GameObject.Find("Left").GetComponent<BaseCamp>();
            case string input when input.Contains("Right"):
                return GameObject.Find("Right").GetComponent<BaseCamp>();
            default:
                return null;
        }
    }
}
