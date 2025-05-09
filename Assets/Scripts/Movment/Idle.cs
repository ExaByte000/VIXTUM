using UnityEngine;

public class Idle : MovmentBase
{
    public override bool WantsControl => true;

    public override int Priority => 0;

    public override void ActionLogic()
    {
        rb.linearVelocityX = 0f;
    }

    public override void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        return;
    }
}
