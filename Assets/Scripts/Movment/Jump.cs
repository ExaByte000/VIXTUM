using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jump : MovmentBase
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    private bool jumpRequest;
    private bool isGrounded;
    private CapsuleCollider2D boxCollider;
    private Coroutine jumpTimer;

    public bool JumpReqest { get { return jumpRequest; } }
    public bool IsGrounded { get { return isGrounded; } }

    public override bool WantsControl => jumpRequest;

    public override int Priority => 2;

    protected override void Awake()
    {
        base.Awake();
        boxCollider = GetComponentInParent<CapsuleCollider2D>();
    }
    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        if (jumpPressed)
        {
            jumpRequest = true;
            if (jumpTimer != null) StopCoroutine(jumpTimer);
            jumpTimer = StartCoroutine(nameof(JumpTimer));
        }
        
    }

    public override void ActionLogic()
    {
        if (jumpRequest && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpRequest = false;
        }
    }

    private void GroundCheck()
    {
        Vector2 boxCenter = new(boxCollider.bounds.center.x, boxCollider.bounds.min.y - 0.1f);
        Vector2 boxSize = new(boxCollider.bounds.size.x * 1.2f, 0.1f);

        Collider2D[] hits = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0f, groundLayer);
        isGrounded = hits.Length > 0;
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    private IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(0.1f);
        jumpRequest = false;
    }
}

