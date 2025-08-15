using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour, ICharacterAction
{
    [SerializeField] protected float range;
    [SerializeField] protected float damage;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask Layer;
    
    public bool isAttacking = false;
    public bool WantsControl => isAttacking;

    public abstract int Priority { get; }

    public abstract void ActionLogic();

    public abstract void ActionRequest(float moveInput, bool meleeAttack, bool rangeAttack);
}
