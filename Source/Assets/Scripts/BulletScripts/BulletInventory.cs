using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletInventory : MonoBehaviour
{
    List<ScriptableBullet> bulletInventory = new List<ScriptableBullet>();
    List<ScriptableBullet> usedBulletInventory = new List<ScriptableBullet>();
    List<ScriptableBullet> roundBullets = new List<ScriptableBullet>();

    public static int MaxRound = 3;
    public static int MaxBulletsInventory = 9;
    int current = 0;

    FireBullet fireBullet;
    public BulletArray bulletArray;
    BulletText bulletText;

    void Start()
    {
        bulletInventory.Add(null);
        bulletInventory.Clear();
        usedBulletInventory.Add(null);
        usedBulletInventory.Clear();
        fireBullet = FindObjectOfType<FireBullet>();
        bulletText = FindObjectOfType<BulletText>();
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
        if (!callback.action.WasPressedThisFrame() || fireBullet.fired || roundBullets.Count == 0)
            return;

        fireBullet.ShootBullet(roundBullets[current]);
        DiscardFromRound(current);
        current = LoopCurrentBullet();


        if (roundBullets.Count == 0)
            bulletText.UpdateBulletText("None", 0);
        else
            bulletText.UpdateBulletText(roundBullets[current].bulletName, roundBullets[current].tier);
    }

    public void AddToInventory(ScriptableBullet selection)
    {
        bulletInventory.Add(selection);
    }
    public void RemoveFromInventory(int selection) => bulletInventory.RemoveAt(selection);
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
}
