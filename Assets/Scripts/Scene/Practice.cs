using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObjectManager player = ObjectManager.GetInstance();
        GameObject mp = player.CreateCharacter();
        mp.transform.localScale = new Vector2(1.3f, 1.3f);
        mp.transform.position = new Vector3(0, 1.1f, 0);

        UIManager profile = UIManager.GetInstance();
        profile.SetEventSystem();
        profile.OpenUI("UIProfile");

        UIManager practice = UIManager.GetInstance();
        practice.OpenUI("UIPractice");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
