using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletInventory : MonoBehaviour
{
    public List<ScriptableBullet> bulletInventory = new List<ScriptableBullet>();
    public List<ScriptableBullet> usedBulletInventory = new List<ScriptableBullet>();
    public List<ScriptableBullet> roundBullets = new List<ScriptableBullet>();
    public ScriptableBullet pea;

    public static int MaxRound = 3;
    public static int MaxBulletsInventory = 9;
    int current = 0;

    FireBullet fireBullet;
    public BulletArray bulletArray;
    BulletText bulletText;
    [SerializeField]
    BulletInventoryUI bulletInventoryUI;

    void Start()
    {
        bulletInventory.Add(null);
        bulletInventory.RemoveAt(bulletInventory.Count - 1);
        usedBulletInventory.Add(null);
        usedBulletInventory.RemoveAt(usedBulletInventory.Count - 1);
        fireBullet = FindObjectOfType<FireBullet>();
        bulletText = FindObjectOfType<BulletText>();
        NewRound();
    }

    public void UpdateCurrentBullet(InputAction.CallbackContext callback)
    {
        float input = callback.action.ReadValue<float>();

        if (roundBullets.Count == 0 || input == 0f)
            return;


        switch (input)
        {
            case var _ when input < 0f:
                current--;
                break;
            case var _ when input > 0f:
                current++;
                break;
        }

        current = LoopCurrentBullet();

        if (bulletText)
            bulletText.UpdateBulletText(roundBullets[current].bulletName, roundBullets[current].tier);
    }

    private int LoopCurrentBullet()
    {
        if (roundBullets.Count == 0)
            return 0;

        int output;
        output = current % (roundBullets.Count);
        if (output < 0)
            output = roundBullets.Count - 1;
        return output;
    }

    public void FireBullet(InputAction.CallbackContext callback)
    {
        if (!callback.action.WasPressedThisFrame() || fireBullet.fired)
            return;

        if (roundBullets.Count == 0)
        {
            fireBullet.ShootBullet(pea);
        }
        else
        {
            fireBullet.ShootBullet(roundBullets[current]);
            DiscardFromRound(current);
            current = LoopCurrentBullet();

            if (roundBullets.Count == 0)
                bulletText.UpdateBulletText("Pea", 0);
            else
                bulletText.UpdateBulletText(roundBullets[current].bulletName, roundBullets[current].tier);
        }
    }

    public void AddToInventory(ScriptableBullet selection)
    {
        bulletInventory.Add(selection);
        if (bulletInventoryUI != null)
            bulletInventoryUI.UpdateUI(bulletInventory);
        else
            print("Bullet inventory is null");
    }

    public void SwapInventory(ScriptableBullet selection, int index)
    {
        bulletInventory[index] = selection;
        bulletInventoryUI.UpdateUI(bulletInventory);
    }

    public void RemoveFromInventory(int selection)
    {
        bulletInventoryUI.UpdateUI(bulletInventory);
        bulletInventory.RemoveAt(selection);
    }
    public void AddToRoundFromInventory(int selection)
    {
        roundBullets.Add(bulletInventory[selection]);
        bulletInventory.RemoveAt(selection);
    }
    public void AddToRound(ScriptableBullet selection) => bulletInventory.Add(selection);
    public void DiscardFromRound(int selection)
    {
        usedBulletInventory.Add(roundBullets[selection]);
        roundBullets.RemoveAt(selection);
    }
    public void RemoveFromRound(int selection) => bulletInventory.RemoveAt(selection);
    public void TestRound()
    {
        for (int i = 0; i < bulletInventory.Count; i++)
            roundBullets.Add(bulletInventory[i]);
    }

    public void NewRound()
    {
        roundBullets.Clear();
        int bulletAmount = Mathf.Clamp(ItemStats.bullets, 0, 9);
        List<int> bullets = new List<int>();

        for (int i = 0; i < 9; i++)
        {
            bullets.Add(i);
        }


        for (int i = 0; i < bulletAmount; i++)
        {
            int random = Random.Range(0, bullets.Count);
            roundBullets.Add(bulletInventory[random]);
            bullets.RemoveAt(random);
        }

        bulletText.UpdateBulletText(roundBullets[0].bulletName, roundBullets[0].tier);
    }
}
