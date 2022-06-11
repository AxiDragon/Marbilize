using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletInventory : MonoBehaviour
{
    List<ScriptableBullet> bulletInventory = new List<ScriptableBullet>(); 
    List<ScriptableBullet> usedBulletInventory = new List<ScriptableBullet>();
    List<ScriptableBullet> roundBullets= new List<ScriptableBullet>(); 

    public static int MaxRound = 3;
    public static int MaxBulletsInventory = 9;
    int current = 0;

    FireBullet fireBullet;

    private void Start()
    {
        fireBullet = FindObjectOfType<FireBullet>();
    }

    public void UpdateCurrentBullet(InputAction.CallbackContext callback)
    {
        float input = callback.ReadValue<float>();

        switch (input)
        {
            case var _ when input < 0:
                current--;
                if (current < 0)
                    current = 2;
                break;
            case var _ when input > 0:
                current++;
                if (current > roundBullets.Count - 1)
                    current = 0;
                break;
        }
    }

    public void FireBullet(InputAction.CallbackContext callback)
    {
        if (!callback.action.WasPressedThisFrame())
                return;

        fireBullet.ShootBullet(roundBullets[current]);
        DiscardFromRound(current);
    }

    public void AddToInventory(ScriptableBullet selection) => bulletInventory.Add(selection);
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
        bulletInventory.Add(bulletInventory[0]);
        bulletInventory.Add(bulletInventory[0]);
        bulletInventory.Add(bulletInventory[0]);
    }
}
