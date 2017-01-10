using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csLiveMonster : MonoBehaviour {

    public GameObject[] DeadMonster;
    public GameObject Enemy;

    int num = 5;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
    }


    public void createEnemy()
    {
        //Debug.Log(" Live !!!");
     
        for (int i = 0; i < num; i++)
        {
            //Debug.Log(" Num  :: " + i);
            float dist = Vector3.Distance(gameObject.transform.position,
DeadMonster[i].transform.position);
            if (dist < 1.0f)
            {
                Instantiate(Enemy, new Vector3(DeadMonster[i].transform.position.x, 0.5f, DeadMonster[i].transform.position.z), Quaternion.identity);
            }
        }

      
    }
}

