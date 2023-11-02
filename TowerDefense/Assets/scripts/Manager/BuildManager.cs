using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private Tower[] Towers;

    private int selecterTower = 0;

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return Towers[selecterTower];
    }
}
