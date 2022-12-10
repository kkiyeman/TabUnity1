using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Slider enemyHp;
    public Image logUi;
    public Image imgFill;
    public Image emgFill;
    public Image deadUi;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;

    public TMP_Text curHp;
    public TMP_Text log;

    public TMP_Text dead;
    // Start is called before the first frame update
    void Start()
    {

        RefreshState();
        HpbarColor(hpBar, imgFill);
        HpbarColor(enemyHp, emgFill);
    }

    // Update is called once per frame
    void Update()
    {
        RefreshState();
        HpbarColor(hpBar, imgFill);
        HpbarColor(enemyHp, emgFill);

    }

    public void RefreshState()
    {
        txtLevel.text = $"Lv : {GameManager.GetInstance().level}";
        txtName.text = $"{GameManager.GetInstance().playerName}";
        txtGold.text = $"{GameManager.GetInstance().gold} G";

        
        hpBar.maxValue = GameManager.GetInstance().totalHp;
        hpBar.value = GameManager.GetInstance().curHp;

        curHp.text = $"{hpBar.value}/{hpBar.maxValue}";
        
        
    }

    public void HpbarColor(Slider slider,Image image)
    {
        if(slider.value> slider.maxValue * 2 / 3)
        {
            image.color = Color.green;
        }
        else if (slider.maxValue / 3 < slider.value &&  slider.value <= slider.maxValue*2/3)
        {
            image.color = new Color32(236, 139, 34, 255);       
        }
        else if (slider.value <= slider.maxValue / 3)
        {
            image.color = Color.red;
        }

        //if (hpBar.value == 0)
        //{

        //    deadUi.gameObject.SetActive(true);
        //}

    }
}

