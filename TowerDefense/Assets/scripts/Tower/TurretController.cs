using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float firingRate = 1f;

    private TurretTargetting targeting;
    private float timeUntilFire;

    private void Start()
    {
        targeting = GetComponent<TurretTargetting>();
    }

    private void Update()
    {
        if (targeting.Target == null)
        {
            targeting.FindTarget();
        }
        else
        {
            RotateToTarget();
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / firingRate && targeting.IsTargetInRange())
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject projectileObj = Instantiate(Projectile, shootingPoint.position, Quaternion.identity);
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.SetTarget(targeting.Target);
    }

    private void RotateToTarget()
    {
        if (targeting.Target != null)
        {
            Vector2 direction = targeting.Target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
