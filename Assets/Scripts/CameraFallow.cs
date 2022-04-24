using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour
{
	public float blockYPos = -3.7f;
	[SerializeField] Transform world;
	public float speed = 1f;
	private PlayerMovement playerMovement;
	// Start is called before the first frame update
	void Start()
	{
		playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
	}
	// Update is called once per frame
	void LateUpdate()
	{

		if (playerMovement.block != null)
		{
			if (transform.TransformPoint(playerMovement.block.position).y > blockYPos)
			{
				WorldMove();
			}
		}
	}
	public void WorldMove()
	{
		world.Translate(0, -speed * Time.deltaTime, 0);
	}
}
