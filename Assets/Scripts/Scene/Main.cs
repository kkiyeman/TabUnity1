using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    GameObject cprofile;
    void Start()
    {
        ObjectManager player = ObjectManager.GetInstance();
        GameObject mp = player.CreateCharacter();
        mp.transform.localScale = new Vector2(2, 2);
        mp.transform.position = new Vector3(0, 1.2f, 0);

        UIManager profile = UIManager.GetInstance();
        profile.SetEventSystem();
        profile.OpenUI("UIProfile");
        

        UIManager action = UIManager.GetInstance();
        action.OpenUI("UIActionMenu");
        
    }


    // Update is called once per frame
    void Update()
    {
        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().HpbarColor(uiprofile.GetComponent<UIProfile>().hpBar, uiprofile.GetComponent<UIProfile>().imgFill);
    }
}
