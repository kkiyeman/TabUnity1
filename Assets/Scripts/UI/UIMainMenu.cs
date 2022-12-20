using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]Button btnToSelect;
    [SerializeField]Canvas canSelect;
    [SerializeField] Button btnPlayer1;
    [SerializeField] Button btnPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        
        btnToSelect.onClick.AddListener(OnClickStart);
        btnPlayer1.onClick.AddListener(OnClickPlayer1);
        btnPlayer2.onClick.AddListener(OnClickPlayer2);
    }

    void OnClickPlayer1()
    {
        var gamemanager = GameManager.GetInstance();
        gamemanager.selectedPlayer = Player.Player1;
        gamemanager.SetPlayer();
        gamemanager.LoadData(gamemanager.selectedPlayer);
        ObjectManager.GetInstance().playerInfo = Player.Player1;       
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
    
    void OnClickPlayer2()
    {
        var gamemanager = GameManager.GetInstance();
        gamemanager.selectedPlayer = Player.Player2;
        gamemanager.SetPlayer();
        gamemanager.LoadData(gamemanager.selectedPlayer);
        ObjectManager.GetInstance().playerInfo = Player.Player2;
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
    void OnClickStart()
    {
        canSelect.gameObject.SetActive(true);
    }

}
