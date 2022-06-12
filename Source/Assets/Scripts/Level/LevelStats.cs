using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public static int ZonesCompleted = 0;
    public static int AreasCompleted = 0;
    public static int Difficulty = 5;

    public static void CalculateDifficulty()
    {
        Difficulty = 5 + (AreasCompleted * ZonesCompleted);
    }

    public static void CheckList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            print(list[i]);
        }
    }
}
