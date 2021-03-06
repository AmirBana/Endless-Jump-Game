using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	[SerializeField] GameObject normalSurface;
	[SerializeField] Transform surfaceHolder;
	[SerializeField] float yBound = 2.4f;
	[SerializeField] float minXBound = -2f, maxXBound = 2f;
	private int pastScore;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.Instance.generateSurface)
		{
			GenerateSurface();
		}
	}
	public void GenerateSurface()
	{
		int amount = Random.Range(1, 5);
		for (int i = 0; i < amount; i++)
		{
			float xPos = Random.Range(minXBound, maxXBound);
			Vector2 spawnPos = new Vector2(xPos, transform.position.y);
			Debug.Log(spawnPos);
			GameObject surface = Instantiate(normalSurface, spawnPos, normalSurface.transform.rotation, surfaceHolder);
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
		}
		GameManager.Instance.generateSurface = false;
	}
}
