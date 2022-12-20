using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    GameObject monster1alive;
    public Monster ranMonster;
    public AudioSource audioplayer;
    public AudioClip battle;
    public AudioClip victory;
    public AudioClip lose;
    // Start is called before the first frame update
    void Awake()
    {
        int ran = Random.Range(0, 2);
        ranMonster = (Monster)ran;
        

        BattleManager battlemanager = BattleManager.Instance;
        battlemanager.InitMonster();
        battlemanager.SetMonster(ran);

        UIManager uimanager = UIManager.GetInstance();
        uimanager.SetEventSystem();
        uimanager.OpenUI("UIProfile");

        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().enemyHp.gameObject.SetActive(true);

        ObjectManager objectmanager = ObjectManager.GetInstance();
        objectmanager.monsterInfo = ranMonster;
        GameObject monster1 = objectmanager.CreateMonster(objectmanager.monsterInfo);
        monster1.transform.localScale = new Vector2(3, 3);
        monster1.transform.position = new Vector3(0, -1, 0);

        EffectPool effectpool = EffectPool.GetInstance();
        effectpool.Initialize(20);


        UIManager transition = UIManager.GetInstance();
        transition.OpenUI("UITransition");
        battlemanager.BattleStart(battlemanager.monsterData, monster1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
