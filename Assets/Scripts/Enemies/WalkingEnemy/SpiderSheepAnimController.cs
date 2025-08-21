using System;
using System.Collections;
using UnityEngine;

public class SpiderSheepAnimController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator anim;
    private bool attackFlag = false;

    public static Action<bool> EnemyAttackDetectorEvent;

    private void OnEnable()
    {
        EnemyDetector.EnemyAnimAttackDetectorEvent += StartAttackAnim;
        GamePause.OnPauseChanged += HandlePause;
    }

    private void OnDisable()
    {
        EnemyDetector.EnemyAnimAttackDetectorEvent -= StartAttackAnim;
        GamePause.OnPauseChanged -= HandlePause;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    private void Update()
    {
        //Debug.Log(rigidbody.linearVelocityX);
        //anim.SetFloat("VerticalVelocity", rigidbody.linearVelocityY);
        //anim.SetBool("IsGrounded", jump.IsGrounded);
        anim.SetBool("MovmentFalg", Math.Abs(rigidbody.linearVelocityX) > 1 && !attackFlag);
        //anim.SetBool("IsDashing", dash.IsDashing);

    }

    private void StartAttackAnim(bool attackStart)
    {
        attackFlag = attackStart;
        anim.SetBool("AttackFlag", attackStart);
        
    }

    public void StratAttack()
    {
        StartCoroutine(AttackDealyRoutine());
    }

    private IEnumerator AttackDealyRoutine()
    {
        EnemyAttackDetectorEvent?.Invoke(true);
        yield return null;
        EnemyAttackDetectorEvent?.Invoke(false);
    }

    private void HandlePause(bool isPaused)
    {
        anim.enabled = !isPaused;
    }
}
