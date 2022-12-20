using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterBase
{
    protected string MonsterName;
    public int hp;
    public int curhp;
    public int atk;
    public int def;
    public float delay;
    public int gold;

    public string GetMonsterName()
    {
        return MonsterName;
    }

    public void SetMonserName(string name)
    {
        MonsterName = name;
    }

    public string mMonsterName
    {
        get { return MonsterName; }
        set { MonsterName = value; }
    }

    public string mMonsterName2 { get; set; }


    //���� X

    //3���� ���

    //1. virtual < - > override (base)
    //public virtual void Attack()
    //{
    //    Debug.Log("�����մϴ�!!!");
    //}

    //2. abstract
    public abstract void Attack();
}
