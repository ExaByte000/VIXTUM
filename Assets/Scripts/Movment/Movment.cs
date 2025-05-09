using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MovmentBase
{
    [SerializeField] private float speed;
    private float moveInput;

    public override bool WantsControl => moveInput != 0;

    public override int Priority => 1;

    private void SpriteFlip()
    {
        if(moveInput > 0)
        {
            transform.parent.transform.parent.localScale = new Vector3(1,1,1);
        }
        else if(moveInput < 0)
        {
            transform.parent.transform.parent.localScale = new Vector3(-1,1,1);
        }
    }

    public override void ActionLogic()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        this.moveInput = moveInput;
        SpriteFlip();

    }

}


