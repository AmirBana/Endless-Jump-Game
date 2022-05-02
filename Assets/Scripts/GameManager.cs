using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
	public int bestScore;
	public bool isGameStarted;
	public bool isGameOver;
	private GameObject world;
	public bool generateSurface = false;
	// Start is called before the first frame update
	void Start()
	{
		LoadScore();
		world = GameObject.Find("World");
		score = 0;
		isGameStarted = false;
		isGameOver = false;
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
	public void ScoreCheck()
	{
		if (score > bestScore)
		{
			bestScore = score;
			SaveScore();
		}
	}
	[System.Serializable]
	class SaveData
	{
		public int bestScore;
	}

	public void SaveScore()
	{
		SaveData data = new SaveData();
		data.bestScore = score;
		string json = JsonUtility.ToJson(data);
		File.WriteAllText(Application.persistentDataPath + "/space_jump.json", json);
	}
	public void LoadScore()
	{
		string path = Application.persistentDataPath + "/space_jump.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);
			bestScore = data.bestScore;
		}
	}
	public void ResetScore()
	{
		score = 0;
		SaveScore();
		LoadScore();
	}
}
