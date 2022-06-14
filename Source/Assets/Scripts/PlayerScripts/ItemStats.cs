using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public static int tokenBoxLimit = 1;
    public static float tokenBoxChance = 0.01f;
    public static float jumpMod = 1f;
    public static float speedMod = 1f;
    public static float explosionWidthMod = 1f;
    public static bool fallOff = false;

    public static void UpdateItemStats(string itemName)
    {
        switch (itemName)
        {
            case "Boots":
                speedMod += 0.3f;
                break;
            case "Aero":
                jumpMod += 0.3f;
                break;
        }
    }

    public static object GetPropertyValue(object source, string property)
    {
        return source.GetType().GetProperty(property).GetValue(source, null);
    }
}
