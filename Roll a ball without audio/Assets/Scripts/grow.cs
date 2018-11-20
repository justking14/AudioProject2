using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grow : MonoBehaviour {
public bool Assigned = false;
	// Use this for initialization
	public void StartSong () {

				GetComponent<ChuckSubInstance>().RunCode( string.Format( @"
			SinOsc foo => dac;
			while( {0} )
			{{
				{1} => foo.freq;
				100::ms => now;
			}}
		", Assigned ? 1 : 0, Random.Range(200,1000) ) );
	}
	
	// Update is called once per frame
	void Update () {
		if(Assigned == true){
            GetComponent<Transform>().localScale+=new Vector3(0.25f, 0.0f, 0.25f);

        if(GetComponent<Transform>().localScale.x > 50){
         GetComponent<Transform>().position=new Vector3(99.1f, 0.0f, 0.1f);

             GetComponent<Transform>().localScale=new Vector3(1.0f, 1.0f, 1.0f);
            Assigned = false;
        }
	    }
	}
}
