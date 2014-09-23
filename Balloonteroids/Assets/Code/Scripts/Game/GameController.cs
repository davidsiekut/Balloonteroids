using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Balloonteroids.Code.Scripts.Game
{
	public class GameController : ScriptableObject
	{
		public GameObject BalloonCluster;
		public static GameObject MainCanvas;
		static Text ScoreText;
		static int score = 0;
		
		void Start()
		{
			MainCanvas = GameObject.FindWithTag("Canvas");
			ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
			
			for(int i = 0; i < 20; i++)
			{
				GameObject g = GameObject.Instantiate(BalloonCluster) as GameObject;
				g.transform.position = new Vector3(0, 5, 0);
			}
		}
		
		void Update()
		{
			
		}
		
		static void addScore(int i)
		{
			score += 1;
			ScoreText.text = score + "";
		}
		
		public static void ShowScorePopup(Vector3 position)
		{
			GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScorePopup")) as GameObject;
			g.transform.position = Camera.main.WorldToScreenPoint(position);
			g.GetComponent<Text>().text = "+1";
			addScore(1);
			g.transform.parent = MainCanvas.transform;
		}
	}
}