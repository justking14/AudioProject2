using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

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
            GetComponent<Transform>().localScale+=new Vector3(0.5f, 0.1f, 0.5f);

        if(GetComponent<Transform>().localScale.x > 100){
         GetComponent<Transform>().position=new Vector3(99.1f, 0.0f, 0.1f);

            GetComponent<Transform>().localScale=new Vector3(10.0f, 100.0f, 10.0f);
           Assigned = false;
        }
	    }
	}
	void OnTriggerEnter( Collider other ){		

        if( other.gameObject.CompareTag( "Finish" ) ){
            print("yea222h");
            SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        }

    }



}
