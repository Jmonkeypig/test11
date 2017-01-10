using UnityEngine;
using System.Collections;

public class csViewpointChange : MonoBehaviour {


    public GameObject FirstPersonCamera;
    public GameObject ThirdPersonCamera;


	// Use this for initialization
	void Start () {
        ThirdPersonCamera.GetComponent<Camera>().enabled = true;
        ThirdPersonCamera.GetComponent<AudioListener>().enabled = true;
        FirstPersonCamera.GetComponent<Camera>().enabled = false;
        FirstPersonCamera.GetComponent<AudioListener>().enabled = false;
    }


    void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,150,50), " FirstPersonCamera"))
        {

            ThirdPersonCamera.GetComponent<Camera>().enabled = true;
            ThirdPersonCamera.GetComponent<AudioListener>().enabled = true;
            FirstPersonCamera.GetComponent<Camera>().enabled = false;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = false;
        }
        if (GUI.Button(new Rect(10, 70, 150, 50), " ThirdPersonCamera"))
        {

            ThirdPersonCamera.GetComponent<Camera>().enabled = false;
            ThirdPersonCamera.GetComponent<AudioListener>().enabled = false;
            FirstPersonCamera.GetComponent<Camera>().enabled = true;
            FirstPersonCamera.GetComponent<AudioListener>().enabled = true;
        }

    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
