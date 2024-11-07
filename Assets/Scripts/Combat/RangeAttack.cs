using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : Attack
{
    Vector2 origin;
    Vector2 direction;
    private void Start()
    {
        attackType = AttackType.Range;
        range = Mathf.Infinity;
    }
    public override void Execute()
    {
        
        
        

        RaycastHit2D hitInfo = Physics2D.Raycast(origin, direction - origin, range, enemyLayer);

        if (hitInfo.collider != null)
        {
            //Debug.Log(hitInfo.collider.gameObject.name);
            hitInfo.collider.GetComponent<Enemy>().TakeDamage();
        }
    }
    private void Update()
    {
        origin = attackPoint.transform.position;

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(origin, direction-origin, Color.red);
    }
}
