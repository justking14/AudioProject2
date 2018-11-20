using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";

	}
	void OnTriggerEnter( Collider other ){		

    if( other.gameObject.CompareTag( "Respawn" ) ){
        print("yeah");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
		if( other.gameObject.CompareTag( "Pick Up" ) )
		{
			other.gameObject.SetActive( false );
			count = count + 1;
			SetCountText();

			GetComponent<ChuckSubInstance>().RunCode( string.Format( @"
			SinOsc foo => dac;
			repeat( {0} )
			{{
				Math.random2f( 300, 1000 ) => foo.freq;
				100::ms => now;
			}}
		", count ) );
		}
	}

	void OnCollisionEnter( Collision collision )
	{




		//float intensity = collision.relativeVelocit
		float intensity = Mathf.Clamp01( collision.relativeVelocity.magnitude / 16 );

		// square it to make the ramp upward more dramatic
		intensity = intensity * intensity;

		// set the intensity and fire the event
		//GetComponent<ChuckSubInstance>().SetFloat( "impactIntensity", intensity );
		//GetComponent<ChuckSubInstance>().BroadcastEvent( "impactHappened" );
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );

		Vector3 movement = new Vector3( moveHorizontal, 0.0f, moveVertical );

		rb.AddForce( movement * speed );
		Vector3 pos = GetComponent<Rigidbody>().position;
        Vector3 pos2 = new Vector3(pos.x,1.0f,pos.z);
	    transform.position = pos2;
	}
void Update(){
	Vector3 pos = GetComponent<Rigidbody>().position;
        Vector3 pos2 = new Vector3(pos.x,0.0f,pos.z);
	    transform.position = pos2;
    if(transform.position.x <= -25.5 || transform.position.x >= 25.5 ||transform.position.z <= -25.5 || transform.position.z >= 25.5){
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

}

}

	void SetCountText()
	{
		countText.text = "";//Count: " + count.ToString();
		if( count >= 12 )
		{
			//winText.text = "You Win!";
		}
	}
}
