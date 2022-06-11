using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Bullet", fileName = "Bullet")]
public class ScriptableBullet : ScriptableObject
{
    public string bulletName;
    public int tier;
    public float explosionForce, spread, speed, explosionWidth, recoil;
    public bool isMelee;
    public Material bulletMaterial;
}