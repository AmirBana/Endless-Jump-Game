using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody2D rb;
	private BoxCollider2D playerCollider;
	private bool isTriggered = false;
	private float deathPos;
	public float xSpeed = 10f;
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
			if (transform.position.y < deathPos)
			{
				Death();
			}

		}
	}
	private void HorizontalMovement()
	{
		//float xDir = Input.GetAxisRaw("Horizontal");
		float xDir = Input.acceleration.x;
		Debug.Log(xDir + "");
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
				block.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			}
			else if (hitInfo.collider.gameObject.CompareTag("Bomb"))
			{
				hitInfo.collider.gameObject.SetActive(false);
				GameManager.Instance.isGameOver = true;
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				Invoke("Death", 2f);
			}
		}

	}
	private void Death()
	{
		GameManager.Instance.isGameOver = true;
		GameManager.Instance.ScoreCheck();

	}
}
