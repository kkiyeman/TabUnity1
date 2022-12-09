using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    Button btnTab;
    // Start is called before the first frame update
    void Start()
    {
        btnTab = GetComponentInChildren<Button>();
        btnTab.onClick.AddListener(OnTab);
    }

    void OnTab()
    {
        Debug.Log("АјАн!!!");
        BattleManager.GetInstance().AttackMonster();

    }
}