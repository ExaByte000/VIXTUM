using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MovmentBase
{
    [SerializeField] private float speed;
    private float moveInput;

    private void SpriteFlip()
    {
        if(moveInput > 0)
        {
            transform.parent.localScale = new Vector3(1,1,1);
        }
        else if(moveInput < 0)
        {
            transform.parent.localScale = new Vector3(-1,1,1);
        }
    }

    public override void ActionLogic()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    public override void ActionRequest(float moveInput)
    {
        this.moveInput = moveInput;
        SpriteFlip();
    }
}


