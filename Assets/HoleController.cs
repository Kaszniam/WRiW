using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{

	private int points;

	private bool collided = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (collided)
		{
			collided = false;
			FindObjectOfType<Shoot>().AddPoint(points);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		points = Int32.Parse(other.gameObject.name);
		collided = true;
	}
}
