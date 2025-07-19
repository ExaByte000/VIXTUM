using System.Collections;
using UnityEngine;

public class EnemyMovment : MovmentBase
{
    [SerializeField] private float speed;
    [SerializeField] private bool isFacingRight = true;

    private float moveInput;

    public override bool WantsControl => moveInput != 0;
    public override int Priority => 1;

    private void OnEnable()
    {
        EnemyDetector.EnemyFlipEvent += HandleFlip;
    }

    private void OnDisable()
    {
        EnemyDetector.EnemyFlipEvent -= HandleFlip;
    }

    private void HandleFlip(bool shouldFaceRight)
    {
        //if (shouldFaceRight != isFacingRight)
        //{
            SpriteFlip();
        //}
    }

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
        //float direction = Mathf.Clamp(moveInput, -1f, 1f);
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        this.moveInput = moveInput;
    }
}