using System;
using System.Collections;
using UnityEngine;

public class PlayerCombatSource : MonoBehaviour
{
    public static Action<bool> HeroAnimAttackDetectorEvent;

    private Coroutine attackDealyRoutine;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            HeroAnimAttackDetectorEvent?.Invoke(true);
            //attackDealyRoutine = StartCoroutine(nameof(AttackDealyRoutine));
        }
    }

    private IEnumerator AttackDealyRoutine()
    {
        HeroAnimAttackDetectorEvent?.Invoke(true);
        yield return null;
        HeroAnimAttackDetectorEvent?.Invoke(false);
        attackDealyRoutine = null;
            
    }
}
