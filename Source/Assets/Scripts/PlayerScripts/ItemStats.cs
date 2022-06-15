using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public static int tokenBoxLimit = 1;
    public static int bullets = 1;
    public static float tokenBoxChance = 0.01f;
    public static float jumpMod = 1f;
    public static float speedMod = 1f;
    public static float explosionWidthMod = 1f;
    public static float explosionPowerMod = 1f;
    public static float recoilMod = 1f;
    public static float mass = .5f;
    public static float shieldGainModifier = 1f;
    public static bool fallOff = false;
    static Rigidbody rb;

    private void Start() => rb = GameObject.Find("Player").GetComponent<Rigidbody>();

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
                tokenBoxChance += 0.01f;
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
