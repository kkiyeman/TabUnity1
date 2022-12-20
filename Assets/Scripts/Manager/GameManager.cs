using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Player
{
    Player1 = 0,
    Player2 = 1
}

public class GameManager : MonoBehaviour
{
    #region Singletone
    public static GameManager instance = null;
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion
   
    public Player1 playingPlayer;
    public Player selectedPlayer;

    Dictionary<Player, Player1> playerList = new Dictionary<Player, Player1>();

    public void InitPlayer()
    {
        if (playerList.Count == 0)
        {
            playerList.Add(Player.Player1, new Player1("Warrior", 05, 100, 100, 5, 1, 1000));
            playerList.Add(Player.Player2, new Player1("Mage", 05, 80, 80, 8, 0, 1200));
        }
        return;
    }

    private void Awake()
    {
        InitPlayer();
    }



    public void SetPlayer()
    {
        InitPlayer();
        Player1 player = playerList[ObjectManager.GetInstance().playerInfo];
        playingPlayer = player;
    }
    public void SaveData(Player player)
    {     
        player = selectedPlayer;
        int sP = (int)player;
        PlayerPrefs.SetString($"playerName_{sP}", playingPlayer.playerName);
        PlayerPrefs.SetInt($"level_{sP}", playingPlayer.level);
        PlayerPrefs.SetInt($"gold_{sP}", playingPlayer.gold);
        PlayerPrefs.SetInt($"totalHp_{sP}", playingPlayer.totalHp);
        PlayerPrefs.SetInt($"curHp_{sP}", playingPlayer.curHp);
        PlayerPrefs.SetInt($"atk_{sP}", playingPlayer.atk);
        PlayerPrefs.SetInt($"def_{sP}", playingPlayer.def);
    }

    public void LoadData(Player player)
    {
        InitPlayer();
        player = selectedPlayer;
        int sP = (int)player;
        playingPlayer.playerName = PlayerPrefs.GetString($"playerName_{sP}", playerList[player].playerName);
        playingPlayer.level = PlayerPrefs.GetInt($"level_{sP}", playerList[player].level);
        playingPlayer.gold =  PlayerPrefs.GetInt($"gold_{sP}", playerList[player].gold);
        playingPlayer.totalHp = PlayerPrefs.GetInt($"totalHp_{sP}", playerList[player].totalHp);
        playingPlayer.curHp = PlayerPrefs.GetInt($"curHp_{sP}", playerList[player].curHp);
        playingPlayer.atk = PlayerPrefs.GetInt($"atk_{sP}", playerList[player].atk);
        playingPlayer.def = PlayerPrefs.GetInt($"def_{sP}", playerList[player].def);
    }


    public void AddGold(int gold)
    {
        playingPlayer.gold += gold;
        SaveData(selectedPlayer);
    }

    public bool SpendGold(int gold)
    {
        if (playingPlayer.gold >= gold)
        {
            playingPlayer.gold -= gold;
            SaveData(selectedPlayer);
            return true;
        }
        
        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        playingPlayer.totalHp += addHp;
        SaveData(selectedPlayer);
    }

    public void IncreaseCurHp(int addHp)
    {
        playingPlayer.curHp += addHp;
        SaveData(selectedPlayer);
    }

    public void IncreaseAtk(int addatk)
    {
        playingPlayer.atk += addatk;
        SaveData(selectedPlayer);
    }

    public void IncreaseDef(int adddef)
    {
        playingPlayer.def += adddef;
        SaveData(selectedPlayer);
    }

    public void SetCurrentHP(int hp)
    {
        playingPlayer.curHp += hp;

        if (playingPlayer.curHp > playingPlayer.totalHp)
            playingPlayer.curHp = playingPlayer.totalHp;

        if (playingPlayer.curHp < 0)
            playingPlayer.curHp = 0;
        SaveData(selectedPlayer);
        //curHp = Mathf.Clamp(curHp, 0, 100);   <= 위 기능들을 한번에 묶어버리는 유니티 전용 함수.
    }

    public void TakeDamage()
    {

    }

   
}
