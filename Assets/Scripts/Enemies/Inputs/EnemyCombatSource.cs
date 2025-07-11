using UnityEngine;

public class EnemyCombatSource : MonoBehaviour, ICommandCombatSource
{

    private bool input;

    private void OnEnable()
    {
        SpiderSheepAnimController.EnemyAttackDetectorEvent += GetInputForMelee;
    }
    private void OnDisable()
    {
        SpiderSheepAnimController.EnemyAttackDetectorEvent -= GetInputForMelee;
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
