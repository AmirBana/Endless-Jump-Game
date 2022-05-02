using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSurface : MonoBehaviour
{
	[SerializeField] float jumpForce = 5f;
	private float destroyPos;
	[SerializeField] GameObject bomb;
	private void Start()
	{
		destroyPos = GameObject.Find("Destroy Pos").transform.position.y;
		if (bomb != null) SpawnExtras();
	}
	private void Update()
	{
		if (transform.position.y < destroyPos) Destroy(gameObject);
	}
	private void SpawnExtras()
	{
		int rand = Random.Range(0, 4);
		if (rand == 0)
		{
			bomb.SetActive(true);
		}
	}
}
