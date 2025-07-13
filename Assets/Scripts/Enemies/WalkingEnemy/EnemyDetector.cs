using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private float rangeForFollow;
    [SerializeField] private float rangeForAttack;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float attackDelay;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float retreatDistance;

    private Coroutine coroutine;
    private bool isFacingRight = false;
    private Collider2D[] retreatObjects;

    public static Action<float> EnemyMovmentDetectorEvent;
    public static Action<bool> EnemyAnimAttackDetectorEvent;
    public static Action<bool> EnemyFlipEvent;

    
    private void DetectForFollow()
    {
        Collider2D[] followObjects = Physics2D.OverlapCircleAll(transform.position, rangeForFollow, layer);
        if (followObjects.Length != 0)
        {
            CheckForFlip(followObjects[0].transform.position.x - transform.position.x);
        }
        if (followObjects.Length != 0 && retreatObjects.Length == 0)
        {
            EnemyMovmentDetectorEvent?.Invoke(followObjects[0].transform.position.x - attackPoint.position.x);

        }
        else
        {
            EnemyMovmentDetectorEvent?.Invoke(0f);
        }

    }

    private void CheckForFlip(float playerToEnemy)
    {
        if (Mathf.Abs(playerToEnemy) >= 4.8f)
        {
            bool shouldFaceRight = playerToEnemy > 0;
            if (shouldFaceRight != isFacingRight)
            {
                isFacingRight = shouldFaceRight;
                EnemyFlipEvent?.Invoke(isFacingRight);
            }
        }
    }

    private void DetectForAttack()
    {
        Collider2D[] attackObjects = Physics2D.OverlapCircleAll(attackPoint.position, rangeForAttack, layer);
        if (attackObjects.Length != 0)
        {
            if (coroutine == null)
            {
                coroutine = StartCoroutine(nameof(AttackDealyRoutine));
            }
        }
        else
        {
            if (retreatObjects.Length != 0)
            {
                var retreatX = retreatObjects[0].transform.position.x;
                var targetX = retreatX + (isFacingRight ? 5f : -5f);
                EnemyMovmentDetectorEvent?.Invoke(targetX - transform.position.x);
            }
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
        retreatObjects = Physics2D.OverlapCircleAll(transform.position, retreatDistance, layer);
        DetectForFollow();
        DetectForAttack();
    }

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
        Gizmos.DrawWireSphere(attackPoint.position, rangeForAttack);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeForFollow);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, retreatDistance);
    }
}