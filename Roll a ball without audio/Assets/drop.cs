using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

    float entryTime = 0;
    float actionDone = 1;

	// Update is called once per frame
	void Update () {
		if(actionDone == 0 && Time.time - entryTime > 3){
            actionDone = 1;
        Destroy(gameObject);

        }
	}
    
    void OnCollisionEnter (Collision other) {
        if(actionDone == 1){
            entryTime = Time.time;
            actionDone = 0;
GetComponent<ChuckSubInstance>().RunCode(@"
			SinOsc foo => dac;
			repeat( 2 )
			{
				Math.random2f( 300, 1000 ) => foo.freq;
				100::ms => now;
			}
		");

    }

 }
}
