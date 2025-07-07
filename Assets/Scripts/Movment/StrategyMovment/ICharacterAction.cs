using UnityEngine;

public interface ICharacterAction
{
    void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed);
    void ActionLogic();

    public bool WantsControl { get; }
    public int Priority { get; }
}
