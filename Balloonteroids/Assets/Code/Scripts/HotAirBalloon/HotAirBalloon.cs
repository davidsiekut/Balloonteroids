using UnityEngine;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;

namespace Balloonteroids.Code.Scripts.Balloon
{
public class HotAirBalloon : MonoBehaviour
{
		public float Speed = 5.0f;
		public AudioClip Pop;
		public GameObject WaterBalloon;
		
		public float Cooldown = 5.0f; // throw balloon every x seconds

		void Start()
		{
			float r = UnityEngine.Random.Range(0.0f, 1.0f);
			transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, r, 0.5f));
		}
		
		void Update()
		{
			rigidbody2D.AddRelativeForce(Vector3.left * Speed * Time.fixedDeltaTime);
			
			if (Cooldown < 0)
			{
				Cooldown = 5.0f;
				throwBalloonAtPlayer();

			}
			
			Cooldown -= Time.deltaTime;
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.name == "Bullet(Clone)")
			{
				AudioSource.PlayClipAtPoint(Pop, transform.position);

				GameController.ShowScorePopup(transform.position, 10);

				Destroy(other.gameObject);
				Destroy(this.gameObject);
			}
		}
		
		void throwBalloonAtPlayer()
		{
			Vector2 dest = GameObject.FindGameObjectWithTag("Player").transform.position 
				+ GameObject.FindGameObjectWithTag("Player").transform.forward * 5.0f;
			Vector2 curr = new Vector2(this.transform.position.x, this.transform.position.y);
			Vector2 dir = (dest - curr).normalized;
			
			GameObject g = GameObject.Instantiate(WaterBalloon) as GameObject;
			g.transform.position = transform.position;

			g.GetComponent<WaterBalloon>().SetDirection(dir);

		}
	}
}