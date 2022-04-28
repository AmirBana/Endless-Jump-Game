using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] TextMeshProUGUI scoreTxt;
	[SerializeField] GameObject StartPanel;
	[SerializeField] GameObject InGamePanel;
	[SerializeField] GameObject EndPanel;
	PlayerMovement playerMovement;
	void Start()
	{
		scoreTxt.text = "Score: 0";
		playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		StartPanel.SetActive(true);
		InGamePanel.SetActive(false);
		EndPanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.Instance.isGameStarted && !GameManager.Instance.isGameOver) ScoreShow();
		if (GameManager.Instance.isGameOver) GameOver();
	}
	void ScoreShow()
	{
		scoreTxt.text = "Score: " + GameManager.Instance.score;
	}
	public void StartGame()
	{
		GameManager.Instance.isGameStarted = true;
		StartPanel.SetActive(false);
		InGamePanel.SetActive(false);
		playerMovement.GetComponent<BoxCollider2D>().isTrigger = true;
		playerMovement.rb.velocity = new Vector2(playerMovement.rb.velocity.x, playerMovement.jumpForce);
	}
	void GameOver()
	{
		InGamePanel.SetActive(false);
		EndPanel.SetActive(true);
	}
	public void FinishGame()
	{
		SceneManager.LoadScene(0);
	}
	public void EXitGame()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}
