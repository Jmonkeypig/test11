using UnityEngine;
using System.Collections;

public class csMissile : MonoBehaviour {

    public Transform target;
    public float Speed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MissileControl4();
	}

    void MissileControl1()
    {
        Vector3 Dir = target.position - transform.position;
        Dir.Normalize();

        Quaternion qtn = Quaternion.identity;
        qtn.SetLookRotation(Dir);

        transform.rotation = qtn;
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    
    void MissileControl2()
    {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void MissileControl3()
    {
        //방향 벡터 구하기 
        Vector3 Dir = transform.position - target.position;

        //외적 , Axis 축 구하기
        Vector3 Axis = Vector3.Cross(Dir, transform.forward);

        //Quaternion.AngleAxis(angle, Axis)
        //angle - 휘는각도 높을수록 정확도 나옴
        //Axis - 축
        Quaternion NewRotation = Quaternion.AngleAxis(Time.deltaTime * 45, Axis) *
            transform.rotation;

        //좀더부드럽게 회전 - 안하면 각져보임
        transform.rotation = Quaternion.Lerp(transform.rotation,
            NewRotation,
            50.0f * Time.deltaTime);

        //Vector3(0,0,1) 방향 초당 속도로
        Vector3 Pos = Vector3.forward * Time.deltaTime * 2.0f;
        transform.Translate(Pos);
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
