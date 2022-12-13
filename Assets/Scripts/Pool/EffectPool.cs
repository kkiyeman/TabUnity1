using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : MonoBehaviour
{
    public static EffectPool instance = null;
   
    public GameObject hitEffect;

    public Queue<HitEffect> effectPool = new Queue<HitEffect>(); 
    public static EffectPool GetInstance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("@HitEffectPool");
            instance = go.AddComponent<EffectPool>();
        }
        return instance;
    }
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    public void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            effectPool.Enqueue(CreateNewEffect());
        }
    }

    public HitEffect CreateNewEffect()
    {
        Object Effect = Resources.Load($"Effect/Hit_3_normal");
        GameObject hEffect = (GameObject)Instantiate(Effect);
        var HE = hEffect.GetComponent<HitEffect>();
        HE.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        HE.gameObject.SetActive(false);
        HE.transform.SetParent(transform);
        return HE;
    }

    public static HitEffect GetObject()
    {
        if(instance.effectPool.Count>0)
        {
            var HE = instance.effectPool.Dequeue();
            HE.transform.SetParent(null);
            HE.gameObject.SetActive(true);
            return HE;
        }
        else
        {
            var newHE = instance.CreateNewEffect();
            newHE.gameObject.SetActive(true);
            newHE.transform.SetParent(null);
            return newHE;
        }
    }

    public static void ReturnObject(HitEffect hiteffect)
    {
        hiteffect.gameObject.SetActive(false);
        hiteffect.transform.SetParent(instance.transform);
        instance.effectPool.Enqueue(hiteffect);
    }



}
