using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    public override int Priority => 1;

    public override void ActionLogic()
    {
        if (isAttacking)
        {
            Collider2D[] hitEnimies = Physics2D.OverlapCircleAll(attackPoint.transform.position, range, Layer);
            if (hitEnimies != null)
            {
                foreach (Collider2D enemyCollider in hitEnimies)
                {
                    enemyCollider.GetComponent<Entity>().TakeDamage(damage);
                }
            }
            isAttacking = false;
        }
    }

    public override void ActionRequest(float moveInput, bool meleeAttack, bool rangeAttack)
    {
        if (meleeAttack)
        {
            isAttacking = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.transform.position, range);
    }

}
