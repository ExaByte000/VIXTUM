using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static Unity.Cinemachine.IInputAxisOwner.AxisDescriptor;

public class Enemy : Entity
{
    [SerializeField] protected float detectRange = 3f;
    //[SerializeField] protected LayerMask layer;
    //[SerializeField] protected Transform target;
    [SerializeField] protected float speed = 10f;
    //protected EnemyDetector ånemyDetector;

    private Coroutine damageTimer;

    public bool TakeDamageFlag { get; set; }


    public override void TakeDamage(float damage)
    {
        TakeDamageFlag = true;
        if (damageTimer != null) 
            StopCoroutine(damageTimer);
        damageTimer = StartCoroutine(nameof(DamageTimer));
        health -= damage;
        
        Debug.Log($"{name} èìååò {health} õï");
        if (health <= 0) Die();
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator DamageTimer()
    {
        yield return new WaitForSeconds(0.3f);
        TakeDamageFlag = false;
    }
}
