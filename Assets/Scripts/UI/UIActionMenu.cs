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
        btnPractice.onClick.AddListener(OnCilckPractice);
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
        GameManager.GetInstance().SetCurrentHP(GameManager.GetInstance().totalHp/2);
        GameManager.GetInstance().SpendGold(50);
        var hEffect = ObjectManager.GetInstance().CreateHitEffect("Health_Up_green");
        hEffect.transform.localPosition = new Vector3(0, 1, 0);
        hEffect.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        //var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        // uiprofile.GetComponent<UIProfile>().RefreshState();
        //uiprofile.GetComponent<UIProfile>().HpbarColor(uiprofile.GetComponent<UIProfile>().hpBar, uiprofile.GetComponent<UIProfile>().imgFill);
    }

    public void OnCilckPractice()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Practice);
    }
}
