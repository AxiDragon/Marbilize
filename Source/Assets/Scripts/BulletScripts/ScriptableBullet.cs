using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Bullet", fileName = "Bullet")]
public class ScriptableBullet : ScriptableObject
{
    public string bulletName;
    public int tier;
    public float explosionForce, spread, speed, 
        explosionWidth, recoil, collisionRadius;
    public bool isMelee;
    public bool affectsPlayer;
    public Sprite bulletSprite;
    public bool explode = true;
    public AudioClip audio;
}