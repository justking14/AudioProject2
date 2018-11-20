using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start()
	{
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame, after Update
	void LateUpdate()
	{
		transform.position = player.transform.position + offset * 2;
	}
}
