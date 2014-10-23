using UnityEngine;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;

namespace Balloonteroids.Code.Scripts.Player
{
	public class Player : MonoBehaviour
	{
		public AudioClip Death;
		public AudioClip GameOver;
		public AudioClip Win;
		Controller PlayerController;
		public GameObject LifeCounter;
		public GameObject GameOverScreen;
		public GameObject WinScreen;

		bool GODMODE = false;

		void Start()
		{
			PlayerController = GetComponent<Controller>();
		}
		
		void FixedUpdate()
		{
			if (GameController.HasWon)
			{
				youWin();
			}
		
			if (Input.GetKeyDown(KeyCode.G))
			{
				GODMODE = !GODMODE;
			}
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.name == "Powerup(Clone)")
			{
				GameObject.Destroy(other.gameObject);
				PlayerController.Powerup();
			}
			
			if (PlayerController.CanControl 
			    && (other.name == "Balloon(Clone)" || other.name == "HotAirBalloon(Clone)" || other.name == "WaterBalloon(Clone)")
			    && !GODMODE)
			{
				Destroy(other.gameObject);
				PlayerController.CanControl = false;
				PlayerController.rigidbody2D.velocity = Vector3.zero;
				
				StartCoroutine(DeathAnimation());
			}
		}
		
		IEnumerator DeathAnimation()
		{
			GetComponent<Animator>().SetBool("IsShooting", false);
			AudioSource.PlayClipAtPoint(Death, transform.position);

			float deathTime = 7.0f;
			float i = 0;
			while(deathTime > 0)
			{
				if (transform.localScale.x > 0)
				{
					transform.localScale = new Vector3(transform.localScale.x - 0.0025f, 
				                                        transform.localScale.y - 0.0025f,
				                                        transform.localScale.z);
				}
				
				transform.Rotate(Vector3.forward, 10.0f);
				
				float x = (i / 40.0f) * Mathf.Cos(i * 40);
				float y = (i / 40.0f) * Mathf.Sin(i * 40);
				
				Vector3 p = transform.position;
				p.x += x;
				p.y += y;
				transform.position = p;
				
				deathTime -= Time.deltaTime;
				i += 0.01f;
				
				// fall behind clouds
				if (deathTime < 5)
					GetComponent<SpriteRenderer>().sortingOrder = -2;
				
				yield return null;
			}
			
			LifeCounter.GetComponent<LifeCounter>().LoseLife();
			GameController.Lives--;
			if (GameController.Lives == 0)
				gameOver();
			else
				spawn();
		}
		
		void spawn()
		{
			transform.position = new Vector3(0, 0, 0);
			transform.localScale = new Vector3(1, 1, 1);
			GetComponent<SpriteRenderer>().sortingOrder = 0;
			PlayerController.CanControl = true;
		}
		
		void gameOver()
		{
			AudioSource.PlayClipAtPoint(GameOver, transform.position);
			GameOverScreen.SetActive(true);
			StartCoroutine(BackToMainMenu());
			Time.timeScale = 0;
		}
		
		public void youWin()
		{
			AudioSource.PlayClipAtPoint(Win, transform.position);
			WinScreen.SetActive(true);
			StartCoroutine(BackToMainMenu());
			Time.timeScale = 0;
		}
		
		IEnumerator BackToMainMenu()
		{
			while (true)
			{
				if (Input.anyKeyDown)
				{
					Time.timeScale = 1;
					Application.LoadLevel("MainMenu");
				}    
				yield return null;    
			}
		}
	}
}