using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private int CorpseWorth = 10;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            GameManager.main.GetMoney(CorpseWorth);
            OnDeath();
            Destroy(gameObject);
        }
    }

    void OnDeath()
    {
        EnemySpawner.ObjectDestroyed();
    }
}
