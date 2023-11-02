using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager main;

    public Transform pathStart;

    public Transform[] waypoints;

    private EnemySpawner enemySpawner;
    [SerializeField] public int money;
    // Start is called before the first frame update
    private void Awake()
    {
        main = this;
    }
    void Start()
    {
        enemySpawner= GetComponent<EnemySpawner>();

        Vector2 newSpawnPosition = waypoints[0].transform.position;
        enemySpawner.SetSpawnPosition(newSpawnPosition);

        money = 100;
    }

    // Update is called once per frame
    public void GetMoney(int Money)
    {
        money += Money;
    }
    public bool SpendMoney(int MoneySpent)
    {
        if (MoneySpent <= money)
        {
            //bought+
            money -= MoneySpent;
            return true;
        }
        else
        {
            Debug.Log("erm no");
            return false;
        }
    }
}
