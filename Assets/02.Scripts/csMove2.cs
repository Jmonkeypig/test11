﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMove2 : MonoBehaviour {

    float speed = 20.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        //실제이동
        transform.Translate(Vector3.right * h);
        transform.Translate(Vector3.forward * v);

	}
}
