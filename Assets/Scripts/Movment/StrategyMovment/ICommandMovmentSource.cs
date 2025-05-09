using UnityEngine;

public interface ICommandMovmentSource
{
    float GetMoveInput();
    bool GetJumpPressed();
    bool GetDashPressed();
}
