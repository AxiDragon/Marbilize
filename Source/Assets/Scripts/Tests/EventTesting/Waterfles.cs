using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waterfles", menuName = "Containers/Waterfles")]
public class Waterfles : ScriptableObject
{
    [Range(0f, 500f)]
    public float waterContent = 100f;
}
