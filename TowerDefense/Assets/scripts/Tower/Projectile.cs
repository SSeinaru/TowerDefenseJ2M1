using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int Damage = 5;
    [SerializeField] private float RotationNeeded;

    private Transform Target;
    private void Update()
    {
        LookAtTarget();
    }

    public void SetTarget(Transform _target)
    {
        Target = _target;
    }

    private void FixedUpdate()
    {
        //LookAtTarget();
        if (!Target) return;
        Vector2 direction = (Target.position - transform.position).normalized;

        rb.velocity = direction * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(Damage);
        Destroy(gameObject);
    }
    void LookAtTarget()
    {
        Vector2 direction = Target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.Rotate(0, 0, RotationNeeded);
    }

}
