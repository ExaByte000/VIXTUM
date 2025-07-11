using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    [SerializeField] private float rangeForFollow;
    [SerializeField] private float rangeForAttack;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float attackDelay; //переделать когда будут анимации
    private Coroutine coroutine; //переделать когда будут анимации



    public static Action<float> EnemyMovmentDetectorEvent;
    public static Action<bool> EnemyAnimAttackDetectorEvent;
    private void DetectForFollow()
    {
        Collider2D[] followObjects = Physics2D.OverlapCircleAll(transform.position, rangeForFollow, layer);
        if(followObjects.Length != 0)
        {
            EnemyMovmentDetectorEvent?.Invoke(followObjects[0].transform.position.x - transform.position.x);
        }
        else
        {
            EnemyMovmentDetectorEvent?.Invoke(0f);
        }
        
    }
    private void DetectForAttack()
    {
        Collider2D[] attackObjects = Physics2D.OverlapCircleAll(transform.position, rangeForAttack, layer);
        if(attackObjects.Length != 0)
        {
            if(coroutine == null)
            {
                coroutine = StartCoroutine(nameof(AttackDealyRoutine));
            }
        }
        else
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            EnemyAnimAttackDetectorEvent?.Invoke(false);
        }

    }

    private void Update()
    {
        DetectForFollow();
        DetectForAttack();
    }

    /// <summary>
    /// переделать когда будут анимации
    /// </summary>
    /// <returns></returns>
    private IEnumerator AttackDealyRoutine()
    {
        while (true)
        {
            EnemyAnimAttackDetectorEvent?.Invoke(true);
            yield return new WaitForSeconds(1);
            EnemyAnimAttackDetectorEvent?.Invoke(false);
            yield return new WaitForSeconds(attackDelay);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, rangeForAttack);
        Gizmos.DrawWireSphere(transform.position, rangeForFollow);

    }
}
