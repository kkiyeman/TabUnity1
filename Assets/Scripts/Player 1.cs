using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1
{ 
    public string playerName;
    public int level;
    public int totalHp;
    public int curHp;
    public int atk;
    public int def;
    public int gold;

    public Player1(string idx, int lv, int tHp, int cHp, int Atk, int Def, int cgold)
    {
        playerName = idx;
        level = lv;
        totalHp = tHp;
        curHp = cHp;
        atk = Atk;
        def = Def;
        gold = cgold;
    }
}
