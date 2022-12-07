using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Menu,
    Main,
    Battle
}

public class ScenesManager : MonoBehaviour
{
    #region SingletoneMake
    public static ScenesManager instance = null;
    public static ScenesManager GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@ScenesManager");
            instance = go.AddComponent<ScenesManager>();

            DontDestroyOnLoad(go);
        }
        return instance;
    }

    
    #endregion

    #region SceneControl
    public Scene currentScene;
    public Scene prevScene;
    
    public void ChangeScene(Scene scene)
    {
       
        prevScene = currentScene;
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());      
    }

    #endregion


}
