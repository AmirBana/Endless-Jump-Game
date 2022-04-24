using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] TextMeshProUGUI scoreTxt;
	void Start()
	{
		scoreTxt.text = "Score: 0";
	}

	// Update is called once per frame
	void Update()
	{
		ScoreShow();
	}
	void ScoreShow()
	{
		scoreTxt.text = "Score: " + GameManager.Instance.score;
	}
}
