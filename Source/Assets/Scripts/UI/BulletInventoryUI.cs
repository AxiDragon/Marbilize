using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletInventoryUI : MonoBehaviour
{
    [SerializeField]
    List<Image> inventoryUIimg = new List<Image>();
    [SerializeField]
    List<TextMeshProUGUI> inventoryUItxt = new List<TextMeshProUGUI>();

    public void UpdateUI(List<ScriptableBullet> bullets)
    {
        int bulletNumber = Mathf.Clamp(bullets.Count, 0, 9);

        for (int i = 0; i < bulletNumber; i++)
        {
            inventoryUIimg[i].sprite = bullets[i].bulletSprite;
            inventoryUItxt[i].text = bullets[i].bulletName;
        }
    }
}
