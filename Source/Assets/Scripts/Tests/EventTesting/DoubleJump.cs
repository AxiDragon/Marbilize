using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/DoubleJump")]
public class DoubleJump : Ability
{
    public override void ExecuteAbility(GameObject target)
    {
        //Jump();
    }
}

[CreateAssetMenu(menuName = "Abilities/DoubleJump", fileName = "InstantlyDie")]
public class InstantlyDie : Ability
{
    public override void ExecuteAbility(GameObject target)
    {
        Destroy(target);
    }
}

public abstract class Ability : ScriptableObject
{
    public abstract void ExecuteAbility(GameObject target);
}
