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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBattleStart()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Battle);
    }
}
