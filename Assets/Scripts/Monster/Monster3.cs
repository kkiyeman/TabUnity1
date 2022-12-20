using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonsterBase
{
    public Monster3(string mName, int tHp, int cHp, int aTk, int dfe, float deLay, int goLd)
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
        //base.Attack();
        float ran = Random.Range(0, 100.0f);
        int dmg = atk;
        if (ran < 20)
            dmg *= 0;
        int pDef = GameManager.GetInstance().playingPlayer.def;
        if (dmg >= pDef)
            GameManager.GetInstance().SetCurrentHP(-dmg + pDef);
        else
            GameManager.GetInstance().SetCurrentHP(-dmg);
    }
}
