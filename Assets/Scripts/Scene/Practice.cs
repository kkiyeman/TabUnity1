using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


        UIManager profile = UIManager.GetInstance();
        profile.SetEventSystem();
        profile.OpenUI("UIProfile");

        UIManager practice = UIManager.GetInstance();
        practice.OpenUI("UIPractice");

        UIManager transition = UIManager.GetInstance();
        transition.OpenUI("UITransition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
