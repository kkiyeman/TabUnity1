using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager manager = UIManager.GetInstance();
        manager.SetEventSystem();
        manager.OpenUI("UIMainMenu");


    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
