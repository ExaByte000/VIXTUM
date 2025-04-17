using UnityEngine;

public abstract class MovmentBase : MonoBehaviour
{
    protected Rigidbody2D rb;
    
    protected virtual void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    //public abstract void ActionLogic();
    //public abstract void ActionRequest(float moveInput);
}
