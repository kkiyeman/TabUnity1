using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    GameObject cprofile;
    void Start()
    {
        ObjectManager player = ObjectManager.GetInstance();
        GameObject mp = player.CreateCharacter(player.playerInfo);
        mp.transform.localScale = new Vector2(1.3f, 1.3f);
        mp.transform.position = new Vector3(0, 1.1f, 0);

        GameManager gamemanager = GameManager.GetInstance();
        gamemanager.LoadData(gamemanager.selectedPlayer);
       // gamemanager.SetPlayer();

        // ObjectManager player = ObjectManager.GetInstance();
        //GameObject mp = player.CreateCharacter();
        // mp.transform.localScale = new Vector2(1.3f, 1.3f);
        // mp.transform.position = new Vector3(0, 1.1f, 0);

        UIManager profile = UIManager.GetInstance();
        profile.SetEventSystem();
        profile.OpenUI("UIProfile");
        

        UIManager action = UIManager.GetInstance();
        action.OpenUI("UIActionMenu");

        UIManager transition = UIManager.GetInstance();
        transition.OpenUI("UITransition");

        


    }



}
