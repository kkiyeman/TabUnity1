using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region SingletoneMake
    public static BattleManager instance = null;
    public static BattleManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@BattleManager");
            instance = go.AddComponent<BattleManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }


    #endregion

    public Monster1 monsterData;
    GameObject monstersprite;
    GameObject uiTab;
    UIProfile uiprofile;

    public Battle battlescene;



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

    public void BattleStart(Monster1 monster,GameObject monster1shape)      
    {
        monsterData = monster;
        monstersprite = monster1shape;
        UIManager.GetInstance().OpenUI("UITab");
        StartCoroutine("Battle");
    }

    public IEnumerator Battle()
    {
        while(GameManager.GetInstance().curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            int def = GameManager.GetInstance().def;
            GameManager.GetInstance().SetCurrentHP(-damage+def);

            GameObject uiprofile = UIManager.GetInstance().GetUI("UIProfile");
            if (uiprofile != null)
            {
                uiprofile.GetComponent<UIProfile>().RefreshState();
            }

            Debug.Log($"몬스터가 플레이어에게 공격을 했습니다 - 데미지 : {damage} \n남은 체력 : {GameManager.GetInstance().curHp}");

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

        monsterData.curhp -= GameManager.GetInstance().atk;
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
        var monster1 = monster.CreateDeadMonster();
        monster1.transform.localScale = new Vector2(3, 3);
        monster1.transform.position = new Vector3(0, -1, 0);
       

        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().deadUi.gameObject.SetActive(true);
        uiprofile.GetComponent<UIProfile>().dead.text = $"승리~!";
        uiprofile.GetComponent<UIProfile>().dead.color = Color.green;
        battlescene = FindObjectOfType<Battle>();
        battlescene.audioplayer.clip = battlescene.victory;
        battlescene.audioplayer.Play();

        GameManager.GetInstance().AddGold(monsterData.gold);
        StopCoroutine("Battle");
        Invoke("MoveToMain", 4);
    }

    void Lose()
    {
        battlescene = FindObjectOfType<Battle>();
        battlescene.audioplayer.clip = battlescene.lose;
        battlescene.audioplayer.Play();
        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().deadUi.gameObject.SetActive(true);
        uiprofile.GetComponent<UIProfile>().dead.text = $"패배!!";
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
