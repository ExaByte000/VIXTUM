using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class RangeAttack : Attack
{
    private Vector2 origin;
    private Vector2 direction;
    private bool isOpened = false;

    private void Start()
    {
        //actionType = ActionType.RangeAttack;
        origin = new();
        direction = new();
        range = Mathf.Infinity;
    }

    public override int Priority => 2;

    public override void ActionLogic()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(origin, direction - origin, range, Layer);

        if (hitInfo.collider != null && isOpened)
        {
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
        }
        isAttacking = false;
    }

    public override void ActionRequest(float moveInput, bool meleeAttack, bool rangeAttack)
    {
        if (rangeAttack)
        {
            isAttacking = true;
        }
    }

    private void Update()
    {
        origin = attackPoint.transform.position;

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(origin, (direction - origin)*1000f, Color.red);
    }

    private void OpenAttack()
    {
        isOpened = true;
    }

}
