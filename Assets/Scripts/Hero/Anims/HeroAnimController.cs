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
        

    }

    private void StartAttackAnim(bool attckStart)
    {
        anim.SetBool("IsAttacking", attckStart);
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
}
