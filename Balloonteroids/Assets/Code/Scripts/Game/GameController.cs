using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Balloonteroids.Code.Scripts.Player;
using Balloonteroids.Code.Scripts.Sound;

namespace Balloonteroids.Code.Scripts.Game
{
	public class GameController : MonoBehaviour
	{
		public float SpawnRate;
		float spawnRate;
		public GameObject BalloonCluster;
		public static GameObject MainCanvas;
		public AudioClip Begin;
		
		static Text ScoreText;
		static int score = 0;
		
		public GameObject SoundController;
		public GameObject Player;
		
		public static int Lives;
		
		static public int clustersPerLevel = 10;
		static int clustersPopped = 0;
		
		static List<GameObject> clusters;
		
		static int currentLevel = 0;
		
		void Start()
		{
			Lives = 1;
			currentLevel = 0;
			clustersPopped = 0;
			score = 0;
			
			clusters = new List<GameObject>();
			//Time.timeScale = 0;
			MainCanvas = GameObject.FindWithTag("Canvas");
			ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
			StartCoroutine(BeginGame());
		}
		
		IEnumerator BeginGame()
		{
			AudioSource.PlayClipAtPoint(Begin, Vector3.zero);
			
			float introTime = 3.0f;
			
			while (introTime > 0)
			{
				introTime -= Time.deltaTime;
				yield return null;
			}
			
			for(int i = 0; i < clustersPerLevel; i++)
			{
				GameObject g = GameObject.Instantiate(BalloonCluster) as GameObject;
				g.transform.position = new Vector3(0, 5, 0);
				clusters.Add(g);
				yield return null;
			}
			
			SoundController.GetComponent<SoundController>().ToggleBGM();
			Player.GetComponent<Controller>().CanControl = true;
		}
		
		void Update()
		{
			//spawnRate -= Time.deltaTime;
			//if (spawnRate < 0 && (clusters.Count < clustersPerLevel))
			//{
			//	spawnRate = SpawnRate;
			//	GameObject g = GameObject.Instantiate(BalloonCluster) as GameObject;
			//	g.transform.position = new Vector3(0, 5, 0);
			//	clusters.Add(g);
			//}
		}
		
		public static void ShowScorePopup(Vector3 position, int i)
		{
			GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScorePopup")) as GameObject;
			g.transform.position = Camera.main.WorldToScreenPoint(position);
			g.GetComponent<Text>().text = "+" + i;
			addScore(i);
			g.transform.parent = MainCanvas.transform;
		}
		
		static void addScore(int i)
		{
			score += i;
			ScoreText.text = score + "";
			
			if (i == 2)
				clustersPopped++;
			
			// speed up remaining
			if (clustersPopped >= clustersPerLevel * 0.8)
			{
				foreach (GameObject g in clusters)
				{
					if (g != null)
						g.GetComponent<BalloonCluster.Controller>().SpeedUp();
				}
			}
			
			if (clustersPopped >= clustersPerLevel)
			{
				currentLevel++;
				// next level
			}
		}
	}
}