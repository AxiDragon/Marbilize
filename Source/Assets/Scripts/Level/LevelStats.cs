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

            if (zonesCompleted % zonesPerArea == 0)
                areasCompleted++;

            CalculateDifficulty();
        }
    }

    public static int zonesPerArea = 4;

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

    public static int Difficulty = 100;
    public static float TimeSpeed = 1.2f;
    public static GameObject CurrentZone;

    private void Start()
    {
        Difficulty = 100;
        ZonesCompleted = 0;
        AreasCompleted = 0;
        Time.timeScale = TimeSpeed;
    }

    public static void CalculateDifficulty()
    {
        Difficulty = 50 + ((int)Mathf.Sqrt(AreasCompleted) * ZonesCompleted);
    }

    public static void CheckList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            print(list[i]);
        }
    }
}
