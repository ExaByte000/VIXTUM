using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MovmentBase
{
    [SerializeField] private float speed;
    private float moveInput;
    [SerializeField] private bool isFacingRight = true;

    public override bool WantsControl => moveInput != 0;

    public override int Priority => 1;

    private void SpriteFlip()
    {
        isFacingRight = !isFacingRight;

        Transform parentTransform = transform.parent.transform.parent;

        Vector3 scale = parentTransform.localScale;
        scale.x *= -1;
        parentTransform.localScale = scale;
    }

    public override void ActionLogic()
    {
        float direction = Mathf.Clamp(moveInput, -1f, 1f);
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        this.moveInput = moveInput;
        
        if (moveInput > 0 && !isFacingRight)
        {
            SpriteFlip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            SpriteFlip();
        }

    }

}


