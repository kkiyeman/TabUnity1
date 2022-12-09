using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionMenu : MonoBehaviour
{

    public Image bg;
    public Button btnPractice;
    public Button btnHeal;
    public Button btnBattle;
    // Start is called before the first frame update
    void Start()
    {
        btnBattle.onClick.AddListener(OnClickBattleStart);
        btnHeal.onClick.AddListener(OnClickHeal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBattleStart()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }

    public void OnClickHeal()
    {
        GameManager.GetInstance().SetCurrentHP(50);
        GameManager.GetInstance().SpendGold(50);
        GameObject uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().RefreshState();
    }

    public void OnCilckPractice()
    {

    }
}
