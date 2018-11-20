using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makedrops : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab;
public int numberOfObjects = 1;
public float radius = 1f;

void Start() 
{
    for (int i = 0; i < numberOfObjects; i++)
    {
        float angle = i * Mathf.PI * 2 / numberOfObjects;
        Vector3 pos = new Vector3(Random.Range(-20.0f, 20.0f), 15.0f,Random.Range(-20.0f, 20.0f));
        Instantiate(prefab, pos, Quaternion.identity);
    }
 InvokeRepeating("makeDrop", 0.0f, 1.0f);
}
	
	




// Update is called once per frame
	void Update () {
		
	}

void makeDrop(){
Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 5.0f,Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, pos, Quaternion.identity);
}}