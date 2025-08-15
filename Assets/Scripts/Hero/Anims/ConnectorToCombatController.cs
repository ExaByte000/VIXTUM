using UnityEngine;

public class ConnectorToCombatController : MonoBehaviour, ICommandCombatSource
{
    private bool input;

    private void OnEnable()
    {
        HeroAnimController.HeroAttackDetectorEvent += GetInputForMelee;
    }
    private void OnDisable()
    {
        HeroAnimController.HeroAttackDetectorEvent -= GetInputForMelee;
    }

    public bool MeleeAttack()
    {
        return input;
    }

    public bool RangeAttack()
    {
        return false;
    }

    private void GetInputForMelee(bool input)
    {
        this.input = input;
    }
}
