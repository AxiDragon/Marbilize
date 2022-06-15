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

    List<GameObject> UIElements = new List<GameObject>();

    ScriptableBullet assignBullet;
    BulletInventory inventory;
    MovementEnabler enabler;

    [HideInInspector]
    public bool paused = false;

    private void Start()
    {
        inventory = FindObjectOfType<BulletInventory>();
        enabler = FindObjectOfType<MovementEnabler>();

        foreach(Transform child in transform)
        {
            UIElements.Add(child.gameObject);
        }

        ChangeUIState(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;

            Time.timeScale = paused ? 0f : LevelStats.TimeSpeed;

            ChangeUIState(paused);
        }
    }

    public void UpdateUI(List<ScriptableBullet> bullets)
    {
        int bulletNumber = Mathf.Clamp(bullets.Count, 0, 9);

        for (int i = 0; i < bulletNumber; i++)
        {
            inventoryUIimg[i].sprite = bullets[i].bulletSprite;
            inventoryUItxt[i].text = bullets[i].bulletName;
        }
    }

    public void ChangeUIState(bool on)
    {
        for (int i = 0; i < UIElements.Count; i++)
            UIElements[i].SetActive(on);

        if (on)
        {
            Cursor.lockState = CursorLockMode.None;
            enabler.Disable();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            enabler.Enable();
        }

    }

    public void ChangeAssignBullet(ScriptableBullet bullet)
    {
        assignBullet = bullet;
    }

    public void ChangeInventoryBullet(int index)
    {
        if (paused)
            return;

        inventory.bulletInventory[index] = assignBullet;
        UpdateUI(inventory.bulletInventory);
        ChangeUIState(false);

        Time.timeScale = LevelStats.TimeSpeed;
    }
}
