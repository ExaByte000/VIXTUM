using UnityEngine;

public class Idle : MovmentBase, ICharacterMovement
{
    public bool WantsControl => true;

    public int Priority => 0;

    public void ActionLogic()
    {
        rb.linearVelocityX = 0f;
    }

    public void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed)
    {
        return;
    }
}
