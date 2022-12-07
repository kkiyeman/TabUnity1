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
}
