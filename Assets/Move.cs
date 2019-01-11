using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

	public float length;
	public float speed;

	private bool movingLeft = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > length && movingLeft)
		{
			movingLeft = false;
		}
		if (transform.position.x < -length && !movingLeft)
		{
			movingLeft = true;
		}

		if (movingLeft)
		{
			transform.position += new Vector3(speed*Time.deltaTime,0,0);
		}
		else
		{
			transform.position -= new Vector3(speed*Time.deltaTime,0,0);
		}
	}
}
