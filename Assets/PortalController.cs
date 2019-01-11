using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

	public GameObject portalEffect;
	public GameObject monsterPrefab;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SpawnLoop());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnLoop()
	{
		while (true)
		{
			portalEffect.SetActive(true);
			yield return new WaitForSeconds(0.5f);
//			Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity);
			yield return new WaitForSeconds(2f);
			portalEffect.SetActive(false);
		}
	}
}
