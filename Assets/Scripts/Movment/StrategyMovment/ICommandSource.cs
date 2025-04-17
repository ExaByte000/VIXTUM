using UnityEngine;

public interface ICommandSource
{
    float GetMoveInput();
    bool GetJumpPressed();
    bool GetDashPressed();
}
