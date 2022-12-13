using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    public void Return()
    {
        
        Invoke("Disappear", 1);
    }
    public void Disappear()
    {
        EffectPool.ReturnObject(this);
    }


}
