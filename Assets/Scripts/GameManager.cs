using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
	#region singleton
	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	public void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion singleton
	public int score;
	private GameObject world;
	public bool generateSurface = false;
	// Start is called before the first frame update
	void Start()
	{
		world = GameObject.Find("World");
		score = 0;
	}

	// Update is called once per frame
	void Update()
	{
		ScoreManager();
	}
	void ScoreManager()
	{
		int playerPos = Mathf.Abs(Mathf.RoundToInt(world.transform.transform.position.y));
		if (playerPos > score)
		{
			score = playerPos;
			generateSurface = true;
		}
	}
}
