using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MovmentBase
{
    [SerializeField] private float speed;
    private float moveInput;

    private void Update()
    {
        SpriteFlip();
    }

    private void SpriteFlip()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localScale = new Vector3(mousePosition.x < transform.position.x ? 1 : -1, 1, 1);
    }

    public override void ActionLogic()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    public override void ActionRequest(float moveInput)
    {
        this.moveInput = moveInput;
    }
}


