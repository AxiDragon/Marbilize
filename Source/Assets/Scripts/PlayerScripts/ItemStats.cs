using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public static int tokenBoxLimit = 2;
    public static int bullets = 3;
    public static float tokenBoxChance = 0.03f;
    public static float jumpMod = 1f;
    public static float speedMod = 1f;
    public static float explosionWidthMod = 1f;
    public static float explosionPowerMod = 1f;
    public static float recoilMod = 1f;
    public static float mass = .5f;
    public static float shieldGainModifier = 1f;
    public static bool fallOff = false;
    static Rigidbody rb;

    private void Start()
    {
        tokenBoxLimit = 2;
        bullets = 3;
        tokenBoxChance = 0.03f;
        jumpMod = 1f;
        speedMod = 1f;
        explosionWidthMod = 1f;
        explosionPowerMod = 1f;
        recoilMod = 1f;
        mass = .5f;
        shieldGainModifier = 1f;
        fallOff = false;
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    public static void UpdateItemStats(string itemName)
    {
        switch (itemName)
        {
            case "BOOT":
                speedMod *= 1.3f;
                break;
            case "AERO":
                jumpMod *= 1.3f;
                break;
            case "VOLATILE":
                explosionWidthMod *= 1.3f;
                break;
            case "REACTIVE":
                explosionPowerMod *= 1.3f;
                break;
            case "TOKEN BOX":
                tokenBoxLimit++;
                break;
            case "LUCKY COIN":
                tokenBoxChance += 0.04f;
                break;
            case "HEAVY":
                mass *= 1.3f;
                rb.mass = mass;
                break;
            case "LIGHT":
                mass *= 0.7f;
                rb.mass = mass;
                break;
            case "STEADY":
                recoilMod *= 0.7f;
                break;
            case "SHAKEN":
                recoilMod *= 1.3f;
                break;
            case "STRONG SHIELD":
                shieldGainModifier *= 1.3f;
                break;
            case "EXTRA BULLET":
                bullets++;
                break;
        }
    }

    public static object GetPropertyValue(object source, string property)
    {
        return source.GetType().GetProperty(property).GetValue(source, null);
    }
}
