using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStats : MonoBehaviour
{
    public static int Zone = 0;
    public static int Area = 0;

    public static void CheckList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            print(list[i]);
        }
    }
}
