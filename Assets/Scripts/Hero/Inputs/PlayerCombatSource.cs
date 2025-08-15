using System;
using System.Collections;
using UnityEngine;

public class PlayerCombatSource : MonoBehaviour
{
    public static Action<bool> HeroAnimAttackDetectorEvent;

    private Coroutine attackDealyRoutine;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && attackDealyRoutine == null)
        {
            attackDealyRoutine = StartCoroutine(nameof(AttackDealyRoutine));
        }
    }

    private IEnumerator AttackDealyRoutine()
    {
        HeroAnimAttackDetectorEvent?.Invoke(true);
        yield return new WaitForSeconds(0.37f);
        HeroAnimAttackDetectorEvent?.Invoke(false);
        attackDealyRoutine = null;
            
    }
}
