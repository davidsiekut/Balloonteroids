using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.Player
{
	public class Player : MonoBehaviour
	{
		int lives = 3;
		Controller PlayerController;
	
		void Start()
		{
			PlayerController = GetComponent<Controller>();
		}
		
		void FixedUpdate()
		{
		
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (PlayerController.CanControl && other.name == "Balloon(Clone)")
			{
				Destroy(other.gameObject);
				PlayerController.CanControl = false;
				PlayerController.rigidbody2D.velocity = Vector3.zero;
				
				StartCoroutine(DeathAnimation());
			}
		}
		
		IEnumerator DeathAnimation()
		{
			float i = 0;
			while(transform.localScale.x > 0)
			{
				transform.localScale = new Vector3(transform.localScale.x - 0.01f, 
				                                        transform.localScale.y - 0.01f,
				                                        transform.localScale.z);
				
				transform.Rotate(Vector3.forward, 10.0f);
				
				float x = (i / 20.0f) * Mathf.Cos(i * 20);
				float y = (i / 20.0f) * Mathf.Sin(i * 20);
				
				Vector3 p = transform.position;
				p.x += x;
				p.y += y;
				transform.position = p;
				
				i += 0.01f;
				yield return null;
			}
			
			lives--;
			if (lives < 0)
				gameOver();
			else
				spawn();
		}
		
		void spawn()
		{
			transform.position = new Vector3(0, 0, 3);
			transform.localScale = new Vector3(1, 1, 1);
			PlayerController.CanControl = true;
		}
		
		void gameOver()
		{
		
		}
	}
}