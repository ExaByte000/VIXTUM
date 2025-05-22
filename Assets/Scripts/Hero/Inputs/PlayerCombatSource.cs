using UnityEngine;

public class PlayerCombatSource : MonoBehaviour, ICommandCombatSource
{
    public bool MeleeAttack() => Input.GetButtonDown("Fire1");

    public bool RangeAttack() => Input.GetButtonDown("Fire2");
}
