using UnityEngine;

public class PlayerInputSource : MonoBehaviour, ICommandSource
{
    public bool GetDashPressed() => Input.GetButtonDown("Dash");

    public float GetMoveInput() => Input.GetAxisRaw("Horizontal");

    public bool GetJumpPressed() => Input.GetButtonDown("Jump");
}
