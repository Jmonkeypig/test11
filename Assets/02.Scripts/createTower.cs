using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class createTower : MonoBehaviour
{

    public GameObject point1;
    public GameObject point2;

    public GameObject Tower;

    bool check;
    // Use this for initialization
    void Start()
    {
        point1.SetActive(false);
        point2.SetActive(false);
        check = false;
        Debug.Log("check = " + check);
    }

    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            
                if (Input.GetButtonUp("Fire1"))
                {
                    Debug.Log("check = " + check);
                    //Debug.Log("errorr....................");

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag.Equals("Pos"))
                        {
                            Debug.Log("Clicked!!");
                            Instantiate(Tower, new Vector3(hit.transform.position.x, 0.5f, hit.transform.position.z), Quaternion.identity);

                        }

                    }
                    point1.SetActive(false);// 다시 타워건설 가능지역 표시를 없앤다
                    point2.SetActive(false);
                    check = false;

                }
            
        }



    }

    public void createObject()
    {
        point1.SetActive(true);  //타워건설 가능 지역 표시
        point2.SetActive(true);
        check = true;
    }


}