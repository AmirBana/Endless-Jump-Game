using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	private BoxCollider2D playerCollider;
	private bool isTriggered = false;
	private float deathPos;
	private float xSpeed = 10f;
	public float yRayOffset = -2f;
	public float jumpForce = 7f;
	public Transform block;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<BoxCollider2D>();
		deathPos = GameObject.Find("Destroy Pos").transform.position.y;
	}
	void Update()
	{
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		if (GameManager.Instance.isGameStarted && !GameManager.Instance.isGameOver)
		{
			HorizontalMovement();
			TriggerCheckerAndJump();
			DeathCheck();
		}
	}
	private void HorizontalMovement()
	{
		// Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		// Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		// float xDir = worldPosition.x - transform.position.x;
		float xDir = Input.GetAxisRaw("Horizontal");
		rb.velocity = new Vector2(xDir * xSpeed, rb.velocity.y);
		float xBound = 3.1f;
		if (transform.position.x < -xBound || transform.position.x > xBound)
		{
			transform.position = new Vector2(Mathf.Clamp(transform.position.x * -1, -xBound + 0.2f, xBound - 0.2f), transform.position.y);
		}
	}
	private void TriggerCheckerAndJump()
	{
		Vector2 rayPos = new Vector2(transform.position.x, transform.position.y + yRayOffset);
		RaycastHit2D hitInfo;
		hitInfo = Physics2D.Raycast(rayPos, Vector2.down, 0.1f);
		if (rb.velocity.y <= 0 && hitInfo.collider != null)
		{
			if (hitInfo.collider.gameObject.CompareTag("Surface"))
			{
				block = hitInfo.collider.gameObject.transform;
				block.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}
			block.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
		}

	}
	private void DeathCheck()
	{
		if (transform.position.y < deathPos)
		{
			GameManager.Instance.isGameOver = true;
		}
	}
}
