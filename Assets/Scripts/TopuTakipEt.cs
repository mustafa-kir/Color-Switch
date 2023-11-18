using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopuTakipEt : MonoBehaviour {

    public Transform topunTransformu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(topunTransformu.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, topunTransformu.position.y, transform.position.z);
        }
	}
}
