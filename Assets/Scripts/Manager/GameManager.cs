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


    public void AddGold(int gold)
    {
        this.gold += gold;
    }

    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        {
            this.gold -= gold;
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHp)
    {
        totalHp += addHp;
    }

    public void SetCurrentHP(int hp)
    {
        curHp += hp;

        if (curHp > totalHp)
            curHp = totalHp;

        if (curHp < 0)
            curHp = 0;

        //curHp = Mathf.Clamp(curHp, 0, 100);   <= 위 기능들을 한번에 묶어버리는 유니티 전용 함수.
    }

    public void TakeDamage()
    {

    }

   
}
