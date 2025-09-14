using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class HeroAnimController : MonoBehaviour
{
    [SerializeField] private Jump jump;
    [SerializeField] private Dash dash;
    private Rigidbody2D rigidbody;

    private Animator anim;

    public static Action<bool> HeroAttackDetectorEvent;

    private int comboStep = 0;
    private bool inputBuffered = false;
    private bool attackCooldownFlag = false;
    private float attackCooldown = 1f;

    private float comboResetTime = 0.4f;
    private float lastAttackTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerCombatSource.HeroAnimAttackDetectorEvent += StartAttackAnim;
        GamePause.OnPauseChanged += HandlePause;
        Hero.Dead += StartDeathAnim;
    }
    private void OnDisable()
    {
        PlayerCombatSource.HeroAnimAttackDetectorEvent -= StartAttackAnim;
        GamePause.OnPauseChanged -= HandlePause;
        Hero.Dead -= StartDeathAnim;
    }

    private void Update()
    {
        if (GamePause.Instance.IsPaused)
            return;

        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);
        bool isInDeathState = currentState.IsName("Death"); // замените "Death" на точное имя состояния

        if (anim.GetBool("Death"))
        {
            Debug.Log($"DEATH ANIM - State: {currentState.shortNameHash}, Time: {currentState.normalizedTime}, " +
                     $"Speed: {anim.speed}, IsPlaying: {anim.GetCurrentAnimatorStateInfo(0).length > 0}");
        }

        anim.SetFloat("VerticalVelocity", rigidbody.linearVelocityY);
        anim.SetBool("IsGrounded", jump.IsGrounded);
        anim.SetBool("MovmentFalg", rigidbody.linearVelocityX != 0);
        anim.SetBool("IsDashing", dash.IsDashing);
        anim.SetBool("AttackCooldown", attackCooldownFlag);
        if (Time.time - lastAttackTime > comboResetTime || rigidbody.linearVelocityX != 0)
        {
            comboStep = 0;
            inputBuffered = false;
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
        }
    }

    private void StartAttackAnim(bool attckStart)
    {

        if (attckStart) 
        {
            HandleAttackInput();
        }
    }

    public void StratAttack()
    {
        StartCoroutine(AttackDealyRoutine());
    }

    private IEnumerator AttackDealyRoutine()
    {
        HeroAttackDetectorEvent?.Invoke(true);
        yield return null;
        HeroAttackDetectorEvent?.Invoke(false);
    }

    private void HandleAttackInput()
    {
        

        if (comboStep == 0) 
        {
            anim.SetBool("Attack1", true);
            comboStep = 1;
            lastAttackTime = Time.time;
            //anim.SetBool("Attack1", false);
        }
        else if (comboStep == 1) 
        {
            inputBuffered = true; 
        }
    }
    public void OnAttack1End()
    {
       
        if (inputBuffered) 
        {
            anim.SetBool("Attack2", true);
            comboStep = 2;
            inputBuffered = false;
            lastAttackTime = Time.time;
        }
        else
        {
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", false);
            comboStep = 0;
        }
    }

    public void OnAttack2End()
    {
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        comboStep = 0; 
    }

    private void HandlePause(bool isPaused)
    {
        anim.enabled = !isPaused;
    }

    public void AttackCooldownStart()
    {
        attackCooldownFlag = true;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        attackCooldownFlag = false;
    }

    public void StartDeathAnim(bool death)
    {
        Debug.Log($"StartDeathAnim called - Before: Death={anim.GetBool("Death")}");
        anim.SetBool("Death", true);
        Debug.Log($"StartDeathAnim called - After: Death={anim.GetBool("Death")}");
    }
}
