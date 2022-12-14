using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonsterBase
{
    public Monster1(string mName, int tHp, int cHp, int aTk, int dfe, float deLay, int goLd)
    {
        this.MonsterName = mName;
        this.hp = tHp;
        this.curhp = cHp;
        this.atk = aTk;
        this.def = dfe;
        this.delay = deLay;
        this.gold = goLd;
    }

    public override void Attack()
    {
        int pDef = GameManager.GetInstance().playingPlayer.def;
        GameManager.GetInstance().SetCurrentHP(-atk + pDef);
    }

}
