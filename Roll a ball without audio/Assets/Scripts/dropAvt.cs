using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropAvt : MonoBehaviour {

	// Use this for initialization
	
public GameObject prefab;
void Start () {
		
	}
	
	
void Update () {
		Vector3 pos = GetComponent<Rigidbody>().position;
        Vector3 pos2 = new Vector3(pos.x,pos.y - 0.1f,pos.z);
	    transform.position = pos2;


}
    

void OnCollisionEnter (Collision col)
    {
        bool spotFound = false;
        if(col.gameObject.name == "Ground"){
            Vector3 pos = GetComponent<Rigidbody>().position;
            Vector3 pos2 = new Vector3(pos.x, 0.0f,pos.z);

            foreach(GameObject respawn in GameObject.FindGameObjectsWithTag("Respawn")){
                if(spotFound == false){
                    grow gr = respawn.GetComponent<grow>();
                    if(gr.Assigned == false){
                        gr.Assigned = true;
                        gr.StartSong();
                        respawn.transform.position = pos2;
                        spotFound = true;
                        GetComponent<Collider>().enabled = false;
                    }
                }   
            }
        }
    }









}

