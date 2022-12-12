using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPractice : MonoBehaviour
{
    public GameObject bg;
    public Text log;
    public Button btnAtkUp;
    public Button btnDefUp;
    public Button btnHpUp;
    public Button btnBack;
    public AudioSource audiosource;
    public AudioClip coin;
    public AudioClip beep;
    // Start is called before the first frame update
    void Start()
    {
        btnAtkUp.onClick.AddListener(OnClickAtkUp);
        btnDefUp.onClick.AddListener(OnClickDefUp);
        btnHpUp.onClick.AddListener(OnClickHpUp) ;
        btnBack.onClick.AddListener(OnClickBack);
        log.text = $"무엇을 하시겠습니까?";
    }


    public void OnClickBack()
    {
        var transition = UIManager.GetInstance().GetUI("UITransition");
        transition.GetComponent<UITransition>().FadeOutt();
        Invoke("MainSceneLoad", 1.4f);
        
    }
    public void OnClickAtkUp()
    {
        if (GameManager.GetInstance().gold >= 2000)
        {
            GameManager.GetInstance().IncreaseAtk(2);
            GameManager.GetInstance().SpendGold(2000);
            audiosource.clip = coin;
            audiosource.Play();
            log.text = $"수련성공! Atk+2";
            Invoke("TextReset", 1);
        }
        else
        {
            audiosource.clip = beep;
            audiosource.Play();
            log.text = $"돈이 부족합니다!";
            Invoke("TextReset", 1);
        }

    }
    public void OnClickDefUp()
    {
        if (GameManager.GetInstance().gold >= 1000)
        {
            GameManager.GetInstance().IncreaseDef(1);
            GameManager.GetInstance().SpendGold(1000);
            audiosource.clip = coin;
            audiosource.Play();
            log.text = $"수련성공! Def+1";
            Invoke("TextReset", 1);
        }
        else
        {
            audiosource.clip = beep;
            audiosource.Play();
            log.text = $"돈이 부족합니다!";
            Invoke("TextReset", 1);
        }

    }
    public void OnClickHpUp()
    {
        if (GameManager.GetInstance().gold >= 3000)
        {
            GameManager.GetInstance().IncreaseTotalHP(30);
            GameManager.GetInstance().IncreaseCurHp(30);
            GameManager.GetInstance().SpendGold(3000);
            audiosource.clip = coin;
            audiosource.Play();
            log.text = $"수련성공! Hp+30";
            Invoke("TextReset", 1);
        }
        else
        {
            audiosource.clip = beep;
            audiosource.Play();
            log.text = $"돈이 부족합니다!";
            Invoke("TextReset", 1);
        }
            
    }

    void TextReset()
    {
        log.text = $"무엇을 하시겠습니까?";
    }

    void MainSceneLoad()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }

}
