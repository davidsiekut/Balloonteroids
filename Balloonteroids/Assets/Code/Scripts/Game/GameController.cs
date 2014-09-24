using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Balloonteroids.Code.Scripts.Game
{
	public class GameController : ScriptableObject
	{
		public float SpawnRate;	
		float spawnRate;
		public GameObject BalloonCluster;
		public static GameObject MainCanvas;
		static Text ScoreText;
		static int score = 0;
		
		void Start()
		{
			MainCanvas = GameObject.FindWithTag("Canvas");
			ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
		}
		
		void Update()
		{
			spawnRate -= Time.deltaTime;
			if (spawnRate < 0)
			{
				spawnRate = SpawnRate;
				GameObject g = GameObject.Instantiate(BalloonCluster) as GameObject;
				g.transform.position = new Vector3(0, 5, 0);
			}
		}
		
		static void addScore(int i)
		{
			score += 1;
			ScoreText.text = score + "";
		}
		
		public static void ShowScorePopup(Vector3 position, int i)
		{
			GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScorePopup")) as GameObject;
			g.transform.position = Camera.main.WorldToScreenPoint(position);
			g.GetComponent<Text>().text = "+" + i;
			addScore(i);
			g.transform.parent = MainCanvas.transform;
		}
	}
}