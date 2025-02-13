using System.Collections;
using System.Collections.Generic;
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

    public bool IsDashing {  get { return isDashing; } }
    public float DashDuration {  get { return dashDuration; } }

    public override void ActionRequest(float moveInput)
    {
        if (canDash) 
        {
            this.moveInput = moveInput;
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


}
