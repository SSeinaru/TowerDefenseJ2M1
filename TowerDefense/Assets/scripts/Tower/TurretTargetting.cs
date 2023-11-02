using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetting : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float targetingRange = 5f;
    private Transform target;

    public Transform Target { get { return target; } }

    public void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, Vector2.zero, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
        else
        {
            target = null;
        }
    }

    public bool IsTargetInRange()
    {
        return target != null && Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
}
