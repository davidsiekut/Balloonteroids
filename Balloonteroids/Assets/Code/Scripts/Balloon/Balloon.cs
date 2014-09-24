using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;
using Balloonteroids.Code.Scripts.BalloonCluster;

namespace Balloonteroids.Code.Scripts.Balloon
{
	public class Balloon : MonoBehaviour
	{
		public Sprite[] Sprites;
		public AudioClip Pop;

		void Start()
		{
			int r = UnityEngine.Random.Range(0, 4);
			(renderer as SpriteRenderer).sprite = Sprites[r];
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				//Destroy(this.gameObject);
			}
			
			if (other.name == "Bullet(Clone)")
			{
				AudioSource.PlayClipAtPoint(Pop, transform.position);
				if (transform.parent.GetComponent<BalloonFactory>().Pop() == 0)
				{
					GameController.ShowScorePopup(transform.position, 2);
				}
				else
				{
					GameController.ShowScorePopup(transform.position, 1);
				}

				Destroy(other.gameObject);
				Destroy(this.gameObject);
			}
		}
	}
}