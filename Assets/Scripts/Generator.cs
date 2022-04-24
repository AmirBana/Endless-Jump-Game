using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	[SerializeField] GameObject normalSurface;
	[SerializeField] float yBound = 2.4f;
	[SerializeField] float minXBound = -3.2f, maxXBound = 3.2f;
	private int pastScore;
	// Start is called before the first frame update
	void Start()
	{
		pastScore = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.Instance.score > pastScore)
		{
			GenerateSurface();
		}
	}
	public void GenerateSurface()
	{

	}
}
