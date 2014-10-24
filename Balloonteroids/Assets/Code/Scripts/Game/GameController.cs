using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Balloonteroids.Code.Scripts.Player;
using Balloonteroids.Code.Scripts.Sound;
using Balloonteroids.Code.Scripts.BalloonCluster;

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
		public GameObject Powerup;
		float powerupTimer = 20.0f;
		
		public static int Lives;
		
		static public int clustersPerLevel = 1;
		//static int clustersPopped = 0;
		
		public static List<GameObject> clusters;
		static int balloonsTotal = 0;
		static int balloonsLeft = 0;
		
		//static int currentLevel = 0;
		
		static bool firstSpawned = false;
		static bool secondSpawned = false;
		static bool thirdSpawned = false;
		
		public static bool HasWon = false;
		
		void Start()
		{
			Lives = 3;
			//currentLevel = 0;
			//clustersPopped = 0;
			balloonsTotal = 0;
			balloonsLeft = 0;
			firstSpawned = false;
			secondSpawned = false;
			thirdSpawned = false;
			score = 0;
			
			clusters = new List<GameObject>();
			//Time.timeScale = 0;
			MainCanvas = GameObject.FindWithTag("Canvas");
			ScoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
			Player = GameObject.FindWithTag("Player");
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
				g.GetComponent<BalloonFactory>().Populate();
				g.transform.position = new Vector3(0, 5, 0);
				clusters.Add(g);
				yield return null;
			}
			
			balloonsLeft = balloonsTotal;
			
			//Debug.Log("Total balloons: " + balloonsLeft);
			
			SoundController.GetComponent<SoundController>().ToggleBGM();
			Player.GetComponent<Balloonteroids.Code.Scripts.Player.Controller>().CanControl = true;
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
			if (powerupTimer < 0)
			{
				powerupTimer = 10.0f;
				
				GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/Entity/Powerup")) as GameObject;
				
				float x = UnityEngine.Random.Range(0.0f, 1.0f);
				float y = UnityEngine.Random.Range(0.0f, 1.0f);
				g.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(x, y, 4.0f));
			}
			
			powerupTimer -= Time.deltaTime;
		}
		
		public static void BalloonPlusPlus(int b)
		{
			balloonsTotal += b;
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
			
			// do not decrement if hotairballoon
			if (i != 10)
				balloonsLeft--;
			//Debug.Log("Balloons left: " + balloonsLeft + " out of " + balloonsTotal 
			//          + "(" + ((float)balloonsLeft / (float)balloonsTotal) * 100 + "%)");
			
			// speed up remaining
			if (balloonsLeft <= balloonsTotal * 0.8)
			{
				foreach (GameObject g in clusters)
				{
					if (g != null)
						g.GetComponent<BalloonCluster.Controller>().SpeedUp();
				}
			}
			
			// spawn hot air balloon
			if (balloonsLeft <= balloonsTotal * 0.9 && !firstSpawned)
			{
				GameObject.Instantiate(Resources.Load("Prefabs/Entity/HotAirBalloon"));
				firstSpawned = true;
			}
			else if (balloonsLeft <= balloonsTotal * 0.6 && !secondSpawned)
			{
				GameObject.Instantiate(Resources.Load("Prefabs/Entity/HotAirBalloon"));
				secondSpawned = true;
			}
			else if (balloonsLeft <= balloonsTotal * 0.3 && !thirdSpawned)
			{
				GameObject.Instantiate(Resources.Load("Prefabs/Entity/HotAirBalloon"));
				thirdSpawned = true;
			}
			
			if (balloonsLeft == 0)
			{
				HasWon = true;
			}
		}
	}
}