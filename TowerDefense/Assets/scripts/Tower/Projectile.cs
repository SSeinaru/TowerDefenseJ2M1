using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform target;
    [SerializeField] private float speed = 10;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }   

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        LookAtTarget();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
    void LookAtTarget()
    {
        Vector2 direction = target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        transform.Rotate(0, 0, 90);
    }
}
