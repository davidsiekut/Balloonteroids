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
		
		public static int Lives = 3;
		
		void Start()
		{
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
			
			SoundController.GetComponent<SoundController>().ToggleBGM();
			Player.GetComponent<Controller>().CanControl = true;
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
			score += 1;
			ScoreText.text = score + "";
		}
		
	}
}