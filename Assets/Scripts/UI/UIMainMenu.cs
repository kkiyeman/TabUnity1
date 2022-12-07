using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    Button btnStart;

    // Start is called before the first frame update
    void Start()
    {
        btnStart = GetComponentInChildren<Button>();
        btnStart.onClick.AddListener(OnClickStart);
    }

    void OnClickStart()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
