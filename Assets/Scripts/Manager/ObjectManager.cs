using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
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
public GameObject CreateCharacter()
    {
        Object charObj = Resources.Load("Sprite/Player");
        GameObject character = (GameObject)Instantiate(charObj);
        

        return character;
    }

    public GameObject CreateMonster()
    {
        Object monsterObj = Resources.Load("Sprite/Monster1");
        GameObject monster = (GameObject)Instantiate(monsterObj);


        return monster;
    }

    public ParticleSystem CreateHitEffect(string hiteffect)
    {
        Object Effect = Resources.Load($"Effect/{hiteffect}");
        GameObject hEffect= (GameObject)Instantiate(Effect);
      


        return hEffect.GetComponent<ParticleSystem>();
    }

    public GameObject CreateDeadMonster()
    {
        Object monsterObj = Resources.Load("Sprite/DeadMonster1");
        GameObject monster = (GameObject)Instantiate(monsterObj);


        return monster;
    }
}
