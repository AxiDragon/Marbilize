using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    private static int zonesCompleted = 0;
    public static int ZonesCompleted
    {
        get { return zonesCompleted; }
        set
        {
            zonesCompleted = value;

            if (zonesCompleted % 9 == 0)
                areasCompleted++;

            CalculateDifficulty();
        }
    }

    private static int areasCompleted = 0;
    public static int AreasCompleted
    {
        get { return areasCompleted; }
        set
        {
            areasCompleted = value;
            CalculateDifficulty();
        }
    }

    public static int Difficulty = 25;
    public static GameObject CurrentZone;

    private void Start()
    {
        Difficulty = 25;
        ZonesCompleted = 0;
        AreasCompleted = 0;
    }

    public static void CalculateDifficulty()
    {
        Difficulty = 25 + (AreasCompleted * ZonesCompleted);
    }

    public static void CheckList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            print(list[i]);
        }
    }
}
