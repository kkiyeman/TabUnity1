using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITransition : MonoBehaviour
{
    public Image fader;
    #region SingletoneMake
    public static UITransition instance = null;
    public static UITransition GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@UITransition");
            instance = go.AddComponent<UITransition>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }
    #endregion

    public void Start()
    {
        gameObject.SetActive(false);
    }

    public void FadeOutt()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }
    public IEnumerator FadeOut()
    {
        
        for (float i = 0.0f; i <= 1.2f; i += 0.1f)
        {
            fader.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.1f);
        }


    }
    
}
