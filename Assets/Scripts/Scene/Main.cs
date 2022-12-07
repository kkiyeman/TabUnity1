using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObjectManager player = ObjectManager.GetInstance();
        player.CreateCharacter();

        UIManager profile = UIManager.GetInstance();
        profile.SetEventSystem();
        profile.OpenUI("UIProfile");

        UIManager action = UIManager.GetInstance();
        action.OpenUI("UIActionMenu");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
