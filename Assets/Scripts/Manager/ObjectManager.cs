using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public Player playerInfo;
    public Monster monsterInfo;
    #region SingletoneMake
    public static ObjectManager instance = null;
    public static ObjectManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion
    // Start is called before the first frame update
public GameObject CreateCharacter(Player player)
    {
        playerInfo = player;
        Object charObj = Resources.Load($"Sprite/{playerInfo}");
        GameObject character = (GameObject)Instantiate(charObj);
        

        return character;
    }

    public GameObject CreateMonster(Monster rMon)
    {
        monsterInfo = rMon;
        Object monsterObj = Resources.Load($"Sprite/{monsterInfo}");
        GameObject monster = (GameObject)Instantiate(monsterObj);


        return monster;
    }

    public ParticleSystem CreateHitEffect(string hiteffect)
    {
        Object Effect = Resources.Load($"Effect/{hiteffect}");
        GameObject hEffect= (GameObject)Instantiate(Effect);
      


        return hEffect.GetComponent<ParticleSystem>();
    }

    public GameObject CreateDeadMonster(Monster rMon)
    {
        monsterInfo = rMon;
        Object monsterObj = Resources.Load($"Sprite/Dead{monsterInfo}");
        GameObject monster = (GameObject)Instantiate(monsterObj);


        return monster;
    }
}
