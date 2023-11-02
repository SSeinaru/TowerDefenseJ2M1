using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControllerWizard : MonoBehaviour
{
    // Start is called before the first frame update
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
}
