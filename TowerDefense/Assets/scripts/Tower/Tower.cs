using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private float shootInterval = 1;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        if (targets.Length == 0)
        {
            return;
        }

        float nearestDistance = 100;
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector2.Distance(transform.position, targets[i].transform.position);
            if (distance < nearestDistance)
            {
                target = targets[i].transform;
                nearestDistance = distance;
            }
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject projectileGameObject = Instantiate(projectilePrefab);
            Projectile projectile = projectileGameObject.GetComponent<Projectile>();
            projectileGameObject.transform.position = transform.position;
            projectile.target = GetTarget();
            yield return new WaitForSeconds(shootInterval);
        }
    }
    public Transform GetTarget()
    {
        return target;
    }

}