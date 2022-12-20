using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonsterBase
{ 
    public Monster2(string mName, int tHp, int cHp, int aTk, int dfe, float deLay, int goLd)
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
        float ran = Random.Range(0, 100.0f);
        int dmg = atk;
        if (ran < 10)
            dmg *= 2;
        int pDef = GameManager.GetInstance().playingPlayer.def;
        GameManager.GetInstance().SetCurrentHP(-dmg + pDef);
    }
}

