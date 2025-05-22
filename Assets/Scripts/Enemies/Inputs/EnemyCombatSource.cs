using UnityEngine;

public class EnemyCombatSource : MonoBehaviour, ICommandCombatSource
{

    private bool input;

    private void OnEnable()
    {
        DetectObjects.EnemyAttackDetectorEvent += GetInputForMelee;
    }
    private void OnDisable()
    {
        DetectObjects.EnemyAttackDetectorEvent -= GetInputForMelee;
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
        Debug.Log(input);
        this.input = input;
    }
}
