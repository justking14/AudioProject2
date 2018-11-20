using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeRain : MonoBehaviour {
public Transform brick;	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			            Instantiate(brick, new Vector3(Random.Range(-10.0f, 10.0f), 3.0f,Random.Range(-10.0f, 10.0f)), Quaternion.identity);

	}
}
