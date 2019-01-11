using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

	public bool drawRay = true;
	public Animator animator;
	public AudioSource audio;
	public GameObject holes;

	public GameObject target;
	public GameObject hole;
	public int startingShoots = 5;
	public Text best;
	public Text points;
	public Text shootsLeft;
	
	
	private int _shootsleft;
	private int _currentPoints;

	private GameObject _targetInstance;
	// Use this for initialization
	void Start ()
	{
		Reset();
		UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		if (drawRay)
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
				if (_targetInstance == null)
				{
					_targetInstance = Instantiate(target, hit.point, Quaternion.identity);
				}
				else
				{
					_targetInstance.transform.position = hit.point;
				}
			}
			else
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
			}
		}
	}

	public void MakeShoot()
	{
		if (_shootsleft > 0)
		{
			audio.Play();
			animator.SetTrigger("shoot");
			_shootsleft--;
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
			{
				Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
				GameObject holeInstance = Instantiate(hole, hit.point, Quaternion.identity);
				holeInstance.transform.SetParent(holes.transform);
//				holeInstance.transform.localScale = new Vector3(0.03f,3f,0.03f);
				holeInstance.transform.rotation = Quaternion.identity;
			}
			UpdateUI();
		}	
	}

	public void Reset()
	{
		foreach (var o in GameObject.FindGameObjectsWithTag("hole"))
		{
			DestroyImmediate(o.gameObject);
		}
		int best = PlayerPrefs.GetInt("best");
		if (best < _currentPoints)
		{
			PlayerPrefs.SetInt("best", _currentPoints);
		}

		_shootsleft = startingShoots;
		_currentPoints = 0;
		UpdateUI();
	}

	private void UpdateUI()
	{
		points.text = "Points: "+_currentPoints;
		best.text = "Best: "+PlayerPrefs.GetInt("best");
		shootsLeft.text = "Shoots left: " + _shootsleft;
	}

	public void AddPoint(int amount)
	{
		_currentPoints += amount;
		UpdateUI();
	}

	public void Help()
	{
		drawRay = !drawRay;
		if (_targetInstance != null)
		{
			Destroy(_targetInstance);
		}
	}
}