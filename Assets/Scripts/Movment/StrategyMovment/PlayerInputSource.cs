using UnityEngine;

public class PlayerInputMovmentSource : MonoBehaviour, ICommandMovmentSource
{
    public bool GetDashPressed() => Input.GetButtonDown("Dash");

    public float GetMoveInput() => Input.GetAxisRaw("Horizontal");

    public bool GetJumpPressed() => Input.GetButtonDown("Jump");
}
