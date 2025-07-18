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

    public override void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log($"{name} ����� {health} ��");
        if (health <= 0) Die();
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }


    [SerializeField] protected float detectRange = 3f;
    [SerializeField] protected LayerMask layer;
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 10f;
    //public ScoreSystem scoreSystem;
    //protected Rigidbody2D rb;
    //protected EnemyMovement movement;
    protected EnemyDetector �nemyDetector;
    int targetsCountInTriggerZone;
    //private Coroutine check;

    //protected virtual void Start()
    //{
    //    //rb = GetComponent<Rigidbody2D>();
    //    detectObjects = GetComponentInChildren<DetectObjects>();
    //    //movement = new(speed, rb);
    //}

    //protected virtual void FixedUpdate()
    //{
    //    //float moveInput = target.position.x - transform.position.x;
    //    //movement.Move(moveInput);
    //}

    //protected virtual void Update()
    //{
    //    if (detectObjects.DetectForAttack(detectRange, layer).Count() != targetsCountInTriggerZone)
    //    {

    //        UpdateCountOfTargets();
    //        //if (check != null)
    //        //{
    //        //    StopCoroutine(check);
    //        //}
    //        //check = StartCoroutine("CollisionCheck");
    //        Debug.Log("���� �������");

    //    }
    //}

    //private void UpdateCountOfTargets()
    //{
    //    targetsCountInTriggerZone = detectObjects.DetectForAttack(detectRange, layer).Count();
    //}

    //protected IEnumerator CollisionCheck()
    //{
    //    while (targetsCountInTriggerZone != 0)
    //    {
    //        foreach (Collider2D foudedTarget in detectObjects.DetectForAttack(detectRange, layer))
    //        {

    //            if (foudedTarget.gameObject.layer == 6 || foudedTarget.gameObject.layer == 9)
    //            {
    //                //foudedTarget.GetComponent<Entity>().TakeDamage();
    //            }
    //        }

    //        yield return new WaitForSeconds(1);
    //    }
    //}

    //public void TakeDamage(ActionType attackType)
    //{
    //    //Health--;
    //    //if (Health <= 0) Die(attackType);
    //}
    //protected void Die(ActionType attackType)
    //{
    //    if (attackType == (ActionType)1 || attackType == 0)
    //    {
    //        Debug.Log("���� ������� ������");
    //        //scoreSystem.Score = 10;
    //        //scoreSystem.ComboCounter++;
    //    }
    //    Die();
    //}

}
