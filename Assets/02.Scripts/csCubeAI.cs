using UnityEngine;
using System.Collections;

public class csCubeAI : MonoBehaviour
{


    public bool go = true;
    public GameObject[] waypoints;

    int num = 0;
    float speed = 5.0f;

    bool moveAble;
  
    
    void Start()
    {
        StartCoroutine(MoveStart1());
        moveAble = SpiderScript.CheckSpiderAttack;
    }


    // Use this for initialization
    void Update()
    {
        moveAble = SpiderScript.CheckSpiderAttack;
        if (moveAble == true)
        {
           // Debug.Log("CUBE MoveAble !!! :: " + moveAble);
            float dist = Vector3.Distance(gameObject.transform.position,
           waypoints[num].transform.position);
            // Debug.Log(" num == " + num);

            if (go)
            {
                if (dist > 0.1)
                {
                    Move();
                }
                else
                {
                    if (num + 1 == waypoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
            }


        }

    }

    void Move()
    {
        //Debug.Log(" move !!");
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    IEnumerator MoveStart1()
    {
        yield return new WaitForSeconds(2.0f);
        moveAble = true;
    }
}