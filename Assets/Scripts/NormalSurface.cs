using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSurface : MonoBehaviour
{
	[SerializeField] float jumpForce = 5f;
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{

		}
	}
}
