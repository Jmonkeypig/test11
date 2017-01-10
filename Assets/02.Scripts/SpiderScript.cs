using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{

    enum SPIDERSTATE
    {
        NONE = -1,
        IDLE = 0,
        MOVE,
        ATTACK,
        DAMAGE,
        DEAD
    }
    SPIDERSTATE spiderState = SPIDERSTATE.IDLE;

    float stateTime = 0.0f;
    public float idleStateMaxTime = 2.0f;

    Transform target;

    public float speed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float attackableRange = 5.5f;
    public float attackStateMaxTime = 2.0f;

    //점수
    public int score =10;

    //죽을때 파티클
    public GameObject explosionParticle=null;

    //죽은 흔적
    public GameObject deadObj=null;


    //음향 효과
    public AudioClip clip;

    CharacterController characterController;

    int hp = 5;

    public static bool CheckSpiderAttack = false;



    void Awake()
    {
        spiderState = SPIDERSTATE.IDLE;
        GetComponent<Animation>().Play("iddle");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (spiderState == SPIDERSTATE.NONE || spiderState == SPIDERSTATE.DEAD)
            return;

    // Debug.Log("name:" + collision.gameObject.name);


    //태그를 통한 충돌처리
    //Debug.Log("Tag:" + collision.gameObject.tag);

    //if (collision.gameObject.tag != "Bomb")
    //{
    //    return;
    //}

    int layerIndex = collision.gameObject.layer;
        //if (layerIndex != 9)
        //    return;

        if (LayerMask.LayerToName(layerIndex) != "Bomb")
            return;
        spiderState = SPIDERSTATE.DAMAGE;
    }

    IEnumerator DeadProcess()
    {
        GetComponent<Animation>()["death"].speed = 0.5f;
        GetComponent<Animation>().Play("death");

        while (GetComponent<Animation>().isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        //터지는 파티클 효과

        yield return new WaitForSeconds(1.0f);

        GameObject explosionObj = Instantiate(explosionParticle) as GameObject;
        Vector3 explosionObjPos = transform.position;
        explosionObjPos.y = 0.6f;
        explosionObj.transform.position = explosionObjPos;

        // 죽은 오브젝트 교체

        yield return new WaitForSeconds(0.5f);

        GameObject deadObj2 = Instantiate(deadObj) as GameObject;
        Vector3 deadObjPos = transform.position;
        deadObjPos.y = 0.6f;
        deadObj2.transform.position = deadObjPos;

    
        float rotationY = Random.Range(-180.0f, 180.0f);
        deadObj.transform.eulerAngles = new Vector3(0.0f, rotationY, 0.0f);
        Destroy(gameObject);
    }

    void Start()
    {
        target = GameObject.Find("Archer").transform;
        characterController = GetComponent<CharacterController>();

    }

    void Update()
    {
        switch (spiderState)
        {
            case SPIDERSTATE.IDLE:

                stateTime += Time.deltaTime;
                if (stateTime > idleStateMaxTime)
                {
                    stateTime = 0.0f;
                    spiderState = SPIDERSTATE.MOVE;
                }
                break;




            case SPIDERSTATE.MOVE:
                CheckSpiderAttack = true;
           //     Debug.Log("SpiderMove :: " + CheckSpiderAttack);

                GetComponent<Animation>().Play("walk");

                float distance = (target.position - transform.position).magnitude;
                if (distance < attackableRange)
                {
                    spiderState = SPIDERSTATE.ATTACK;
                    stateTime = attackStateMaxTime;
                }
                else
                {
                   // Vector3 dir = target.position - transform.position;
                   // dir.y = 0.0f;
                   // dir.Normalize();
                   // characterController.SimpleMove(dir * speed);
                   // transform.rotation = Quaternion.Lerp(
                   // transform.rotation,
                   //Quaternion.LookRotation(dir),
                   // rotationSpeed * Time.deltaTime);
                }
                break;





            case SPIDERSTATE.ATTACK:

                CheckSpiderAttack = false;
                //Debug.Log("SpiderAttack :: " + CheckSpiderAttack);

                stateTime += Time.deltaTime;

                if (stateTime > attackStateMaxTime)
                {
                    stateTime = 0.0f;
                    GetComponent<Animation>().Play("attack_Melee");
                    GetComponent<Animation>().PlayQueued("iddle", QueueMode.CompleteOthers);

                }


                //거미가 공격 후 따라와서 공격하는 코드
                float distance1 = (target.position - transform.position).magnitude;
                if (distance1 > attackableRange)
                {
                    spiderState = SPIDERSTATE.MOVE;
                }
                break;



            case SPIDERSTATE.DAMAGE:

                
                 --hp;
                GetComponent<Animation>()["damage"].speed = 0.5f;
                GetComponent<Animation>().Play("damage");
                GetComponent<Animation>().PlayQueued("iddle", QueueMode.CompleteOthers);
                stateTime = 0.0f;
                spiderState = SPIDERSTATE.IDLE;

                if (hp <= 0)
                {
                    spiderState = SPIDERSTATE.DEAD;
                }
                break;



            case SPIDERSTATE.DEAD:
                //Destroy(gameObject);
                StartCoroutine(DeadProcess());
                spiderState = SPIDERSTATE.NONE;


                break;
        }
    }

}
