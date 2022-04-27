using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSurface : MonoBehaviour
{
	[SerializeField] float jumpForce = 5f;
	private float destroyPos;
	private void Start()
	{
		destroyPos = GameObject.Find("Destroy Pos").transform.position.y;
	}
	private void Update()
	{
		if (transform.position.y < destroyPos) Destroy(gameObject);
	}
}
