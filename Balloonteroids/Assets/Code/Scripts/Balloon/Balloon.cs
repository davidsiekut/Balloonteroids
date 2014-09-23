using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;

namespace Balloonteroids.Code.Scripts.Balloon
{
	public class Balloon : MonoBehaviour
	{
		public Sprite[] Sprites;

		void Start()
		{
			int r = UnityEngine.Random.Range(0, 4);
			(renderer as SpriteRenderer).sprite = Sprites[r];
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player")
			{
				Destroy(this.gameObject);
			}
			
			if (other.name == "Bullet(Clone)")
			{
				GameController.ShowScorePopup(transform.position);
				Destroy(other.gameObject);
				Destroy(this.gameObject);
			}
		}
	}
}