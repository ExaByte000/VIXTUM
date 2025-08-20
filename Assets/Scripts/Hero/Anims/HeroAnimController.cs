using System;
using System.Collections;
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
    }
    private void OnDisable()
    {
        PlayerCombatSource.HeroAnimAttackDetectorEvent -= StartAttackAnim;
    }

    private void Update()
    {
        anim.SetFloat("VerticalVelocity", rigidbody.linearVelocityY);
        anim.SetBool("IsGrounded", jump.IsGrounded);
        anim.SetBool("MovmentFalg", rigidbody.linearVelocityX != 0);
        anim.SetBool("IsDashing", dash.IsDashing);
        if (Time.time - lastAttackTime > comboResetTime || rigidbody.linearVelocityX != 0)
        {
            comboStep = 0;
            inputBuffered = false;
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
            anim.SetTrigger("Attack1");
            comboStep = 1;
            lastAttackTime = Time.time;
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
            anim.SetTrigger("Attack2");
            comboStep = 2;
            inputBuffered = false;
            lastAttackTime = Time.time;
        }
        else
        {
            comboStep = 0;
        }
    }

    public void OnAttack2End()
    {
        comboStep = 0; 
    }
}
