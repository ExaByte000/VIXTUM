using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Dash : MovmentBase
{
    [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCoolDown;
    
    private bool isDashing = false;
    private bool canDash = true;
    private float originalGravity;
    private Coroutine dashRoutine;
    private float moveInput;
    private float lastMoveInput;

    public override int Priority => 3;
    public override bool WantsControl => IsDashing;

    public bool IsDashing {  get { return isDashing; } }
    public float DashDuration {  get { return dashDuration; } }

    

    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        this.moveInput = moveInput;
        if (moveInput != 0) lastMoveInput = moveInput;
        if (canDash && dashPressed) 
        {
            isDashing = true;
            canDash = false;
            if (dashRoutine != null) StopCoroutine(dashRoutine);
            dashRoutine = StartCoroutine(nameof(DashRoutine));
        }
    }

    public override void ActionLogic()
    {
        if (isDashing)
        {
            if (moveInput == 0)
            {
                rb.linearVelocityX = lastMoveInput * dashForce;
                return;
            }
            rb.linearVelocityX = moveInput * dashForce;
        }
    }

    private IEnumerator DashRoutine()
    {
        originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        rb.linearVelocityY = 0f;
        
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        rb.gravityScale = originalGravity;
        rb.linearVelocityX = 0;

        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

    private void OnEnable()
    {
        GamePause.OnPauseChanged += PauseLogic;
    }

    private void OnDisable()
    {
        GamePause.OnPauseChanged += PauseLogic;
    }

    private void PauseLogic(bool isPaused)
    {
        if (isPaused)
            rb.linearVelocity = Vector2.zero;
    }
}
