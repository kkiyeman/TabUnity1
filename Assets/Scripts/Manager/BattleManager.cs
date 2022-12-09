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
    

    public void Start()
    {
        
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
            GameManager.GetInstance().SetCurrentHP(-damage);

            GameObject uiprofile = UIManager.GetInstance().GetUI("UIProfile");
            if (uiprofile != null)
                uiprofile.GetComponent<UIProfile>().RefreshState();
            
            Debug.Log($"���Ͱ� �÷��̾�� ������ �߽��ϴ� - ������ : {damage} \n���� ü�� : {GameManager.GetInstance().curHp}");

        }
        
        Lose();
        




    }

    public void AttackMonster()
    {
        float ranx = Random.Range(0, 2);
        float rany = Random.Range(1,2.5f);
        var hEffect = ObjectManager.GetInstance().CreateHitEffect();
        hEffect.transform.localPosition = new Vector3(ranx, rany, 0);
        hEffect.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

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
        monster1.transform.position = new Vector3(0, 1, 0);
       

        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().deadUi.gameObject.SetActive(true);
        uiprofile.GetComponent<UIProfile>().dead.text = $"�¸�~!";
        uiprofile.GetComponent<UIProfile>().dead.color = Color.green;



        GameManager.GetInstance().AddGold(monsterData.gold);
        StopCoroutine("Battle");
        Invoke("MoveToMain", 4);
    }

    void Lose()
    {
        var uiprofile = UIManager.GetInstance().GetUI("UIProfile");
        uiprofile.GetComponent<UIProfile>().deadUi.gameObject.SetActive(true);
        uiprofile.GetComponent<UIProfile>().dead.text = $"�й�!!";
        UIManager.GetInstance().CloseUI("UITab");
        StopCoroutine("Battle");

        GameManager.GetInstance().SetCurrentHP(100);
        GameManager.GetInstance().SpendGold(200);

        Invoke("MoveToMain", 2);

    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}