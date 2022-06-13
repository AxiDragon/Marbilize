using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Obstacle", fileName = "Obstacle")]
public class Obstacle : ScriptableObject
{
    public int cost;
    public float mass;
    public float breakThreshold;
    public bool tokenBox;
    public Vector3 size;
    public Texture2D texture;
}
