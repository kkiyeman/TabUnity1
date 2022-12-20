using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Monster
{
    Monster1 = 0,
    Monster2 = 1,
    Monster3 = 2,
    Monster4 = 3,
    Monster5 = 4
}
public class BattleManager : MonoBehaviour
{
    #region SingletoneMake
    public static BattleManager instance = null;
    public static BattleManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("@BattleManager");
                instance = go.AddComponent<BattleManager>();

                DontDestroyOnLoad(go);
            }
            return instance;
        }
        
    }


    #endregion

    public MonsterBase monsterData;
    GameObject monstersprite;
    GameObject uiTab;
    UIProfile uiprofile;

    public Battle battlescene;

    Dictionary<Monster,MonsterBase> monster = new Dictionary<Monster,MonsterBase>();

    public void InitMonster()
    {
        if (monster.Count == 0)
        {            
            monster.Add(Monster.Monster1, new Monster1("Orc Warrior", 200, 200, 10, 1, 1.5f, 500));
            monster.Add(Monster.Monster2, new Monster1("Orc Mage", 150, 150, 15, 0, 1.5f, 600));
            monster.Add(Monster.Monster3, new Monster2("Urk Warrior", 400, 400, 20, 2, 1.5f, 1200));
            monster.Add(Monster.Monster4, new Monster2("Urk Mage", 350, 350, 25, 1, 1.5f, 1400));
            monster.Add(Monster.Monster5, new Monster3("Troll", 1000, 1000, 50, 3, 1.5f, 4000));
        }
        return;
    }

    public void SetMonster(int ran)
    {
        Monster rMon = (Monster)ran;
        MonsterBase ob = monster[rMon];
        monsterData = ob;
        
    }
    private void Awake()
    {
        
    }
    public void Start()
    {
        battlescene = FindObjectOfType<Battle>();
        GameObject uiprofile = UIManager.GetInstance().GetUI("UIProfile");
            if (uiprofile != null)
                uiprofile.GetComponent<UIProfile>().RefreshState();
        
    }

    private void Update()
    {

        GameObject uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        if (uiprofile != null)
        {
            uiprofile.GetComponent<UIProfile>().enemyHp.maxValue = monsterData.hp;
            uiprofile.GetComponent<UIProfile>().enemyHp.value = monsterData.curhp;
        }



    }

    public void BattleStart(MonsterBase monster,GameObject monster1shape)      
    {
        monsterData = monster;
        monstersprite = monster1shape;
        UIManager.GetInstance().OpenUI("UITab");
        StartCoroutine("Battle");
    }

    public IEnumerator Battle()
    {
        while(GameManager.GetInstance().playingPlayer.curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            monsterData.Attack();

            GameObject uiprofile = UIManager.GetInstance().GetUI("UIProfile");
            if (uiprofile != null)
            {
                uiprofile.GetComponent<UIProfile>().RefreshState();
            }

            Debug.Log($"몬스터가 플레이어에게 공격을 했습니다 - 데미지 : {monsterData.atk} \n남은 체력 : {GameManager.GetInstance().playingPlayer.curHp}");

        }
        
        Lose();
       
    }

    public void AttackMonster()
    {
        float ranx = Random.Range(0, 2);
        float rany = Random.Range(-1,0.5f);
        var hEffect = EffectPool.GetObject();
        hEffect.transform.localPosition = new Vector3(ranx, rany, 0);
        hEffect.Return();

        monsterData.curhp -= GameManager.GetInstance().playingPlayer.atk;
        if(monsterData.curhp<=0)
        {
            Victory();
            
        }
    }

    void Victory()
    {
        UIManager.GetInstance().CloseUI("UITab");
        monstersprite.gameObject.SetActive(false);
        ObjectManager monster = ObjectManager.GetInstance();
        var monster1 = monster.CreateDeadMonster(monster.monsterInfo);
        monster1.transform.localScale = new Vector2(3, 3);
        monster1.transform.position = new Vector3(0, -1, 0);
       

        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().deadUi.sprite = uiprofile.GetComponent<UIProfile>().victory;     
        uiprofile.GetComponent<UIProfile>().animator.SetTrigger("trigger");
        battlescene = FindObjectOfType<Battle>();
        battlescene.audioplayer.clip = battlescene.victory;
        battlescene.audioplayer.Play();

        GameManager.GetInstance().AddGold(monsterData.gold);
        StopCoroutine("Battle");
        Invoke("MoveToMain", 3);
    }

    void Lose()
    {
        battlescene = FindObjectOfType<Battle>();
        battlescene.audioplayer.clip = battlescene.lose;
        battlescene.audioplayer.Play();
        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().deadUi.sprite = uiprofile.GetComponent<UIProfile>().defeat;
        uiprofile.GetComponent<UIProfile>().animator.SetTrigger("trigger");
        UIManager.GetInstance().CloseUI("UITab");
        StopCoroutine("Battle");

        GameManager.GetInstance().SetCurrentHP(100);
        GameManager.GetInstance().SpendGold(200);

        Invoke("MoveToMain", 3);

    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
