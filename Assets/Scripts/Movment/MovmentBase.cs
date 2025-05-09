using UnityEngine;

public abstract class MovmentBase : MonoBehaviour, ICharacterAction
{
    protected Rigidbody2D rb;

    abstract public bool WantsControl { get; }

    abstract public int Priority { get; }

    abstract public void ActionLogic();

    public abstract void ActionRequest(float moveInput, bool jumpPressed, bool dashPressed);
    

    protected virtual void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
}
