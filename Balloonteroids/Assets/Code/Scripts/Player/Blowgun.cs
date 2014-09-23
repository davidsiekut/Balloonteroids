using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.Player
{
	public class Blowgun : MonoBehaviour
	{
		public GameObject Bullet;
		float Cooldown = 0.5f;

		void Start()
		{
		
		}
		
		void Update()
		{
			if (Cooldown < 0.5)
			{
				Cooldown -= Time.deltaTime;
				if (Cooldown < 0)
					Cooldown = 0.5f;
			}
		}
		
		public void Shoot()
		{
			if (Cooldown == 0.5f)
			{
				Cooldown -= 0.0001f;
				GameObject g = GameObject.Instantiate(Bullet) as GameObject;
				g.transform.position = transform.position;
				g.transform.rotation = transform.rotation;
			}
		}
	}
}