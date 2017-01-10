using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csTrap : MonoBehaviour {

    public GameObject Player;
    public Transform target;
    public float Speed = 10.0f;

    bool moveActive = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position,
Player.transform.position);

        if(dist < 10)
        {
            moveActive = true;
        }

        if(moveActive == true)
        {
            MissileControl4();
        }
     
    }
    void MissileControl4()
    {
        Vector3 Dir = target.position - transform.position;
        Dir.Normalize();

        Quaternion targetQtn = Quaternion.LookRotation(Dir);

        //부드럽게 회전하기
        transform.rotation = Quaternion.Lerp(transform.rotation,
            targetQtn,
            15.0f * Time.deltaTime);


        Vector3 Pos = Vector3.forward * Time.deltaTime * Speed;
        transform.Translate(Pos);
    }

}
