using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public Animator animator;
    public Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Walk()
    {
       
        vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

        animator.SetFloat("Move", vector.x);
    }
    public void March()
    {
        animator.SetFloat("Move", 1);
        StartCoroutine(MoveLeft());
    }

    public IEnumerator MoveLeft()
    {
        for (float i = 0.0f; i <= 3f; i += 0.03f)
        {
            float vx = 0;
            vx -= i;
            this.transform.position = new Vector3(this.transform.position.x + vx, this.transform.position.y, this.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
