using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string playerName = "Kkiyeman";
    public int level = 05;
    public int gold = 1000;
    public int totalHp = 100;
    public int curHp = 100;
    public int atk = 5;
    public int def = 0;


    public void SaveData()
    {
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("totalHp", totalHp);
        PlayerPrefs.SetInt("curHp", curHp);
        PlayerPrefs.SetInt("atk", atk);
        PlayerPrefs.SetInt("def", def);
    }

    public void LoadData()
    {
        playerName = PlayerPrefs.GetString("playerName", "Kkiyeman");
        level = PlayerPrefs.GetInt("level", 05);
        gold =  PlayerPrefs.GetInt("gold", 1000);
        totalHp = PlayerPrefs.GetInt("totalHp", 100);
        curHp = PlayerPrefs.GetInt("curHp", 100);
        atk = PlayerPrefs.GetInt("atk", 5);
        def = PlayerPrefs.GetInt("def", 0);
    }


    public void AddGold(int gold)
    {
        this.gold += gold;
        SaveData();
    }

    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            SaveData();
            return true;
        }
        
        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHp += addHp;
        SaveData();
    }

    public void IncreaseCurHp(int addHp)
    {
        curHp += addHp;
        SaveData();
    }

    public void IncreaseAtk(int addatk)
    {
        atk += addatk;
        SaveData();
    }

    public void IncreaseDef(int adddef)
    {
        def += adddef;
        SaveData();
    }

    public void SetCurrentHP(int hp)
    {
        curHp += hp;

        if (curHp > totalHp)
            curHp = totalHp;

        if (curHp < 0)
            curHp = 0;
        SaveData();
        //curHp = Mathf.Clamp(curHp, 0, 100);   <= 위 기능들을 한번에 묶어버리는 유니티 전용 함수.
    }

    public void TakeDamage()
    {

    }

   
}
