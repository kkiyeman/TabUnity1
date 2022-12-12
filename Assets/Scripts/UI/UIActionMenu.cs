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
    public Text log;

    public bool anotherText = false;
    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        anotherText = false;
        audiosource = GetComponent<AudioSource>();
        btnBattle.onClick.AddListener(OnClickBattleStart);
        btnHeal.onClick.AddListener(OnClickHeal);
        btnPractice.onClick.AddListener(OnCilckPractice);
        StartCoroutine(Waiting());
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
        if(GameManager.GetInstance().totalHp >GameManager.GetInstance().curHp)
        {
            Heal();
        }
        else
        {
            StopAllCoroutines();
            audiosource.Play();
            anotherText = true;
            log.text = "HP가 가득입니다!";
            Invoke("DefaultText", 2.1f);


        }
        //var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        // uiprofile.GetComponent<UIProfile>().RefreshState();
        //uiprofile.GetComponent<UIProfile>().HpbarColor(uiprofile.GetComponent<UIProfile>().hpBar, uiprofile.GetComponent<UIProfile>().imgFill);
    }

    public void OnCilckPractice()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Practice);
    }

    private void Heal()
    {
        GameManager.GetInstance().SetCurrentHP(GameManager.GetInstance().totalHp / 2);
        GameManager.GetInstance().SpendGold(50);
        var hEffect = ObjectManager.GetInstance().CreateHitEffect("Health_Up_green");
        hEffect.transform.localPosition = new Vector3(0, 1, 0);
        hEffect.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }

    public IEnumerator Waiting()
    {
        while (!anotherText)
        {
            log.text = "용사 대기중";
            yield return new WaitForSeconds(0.5f);
            log.text = "용사 대기중.";
            yield return new WaitForSeconds(0.5f);
            log.text = "용사 대기중..";
            yield return new WaitForSeconds(0.5f);
            log.text = "용사 대기중...";
            yield return new WaitForSeconds(0.5f);
        }
        
         
    }

    private void DefaultText()
    {
        anotherText = false;
        StartCoroutine(Waiting());
    }


}
