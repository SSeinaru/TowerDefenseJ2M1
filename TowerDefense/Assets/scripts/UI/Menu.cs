using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI CurrencyUI;
    [SerializeField] Animator anim;

    private bool AnimTrigger = true;

    public void ToggleMenuOpen()
    {
        AnimTrigger= !AnimTrigger;
        anim.SetBool("MenuOpen", AnimTrigger);
    }
   
    private void OnGUI()
    {
        CurrencyUI.text = GameManager.main.money.ToString();
    }
}
