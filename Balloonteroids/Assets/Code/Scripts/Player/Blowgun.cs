using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.Player
{
	public class Blowgun : MonoBehaviour
	{
		public const float COOLDOWN = 0.5f;
	
		public GameObject Bullet;
		float Cooldown = COOLDOWN;

		void Start()
		{
		
		}
		
		void Update()
		{
			if (Cooldown < 0.5)
			{
				Cooldown -= Time.deltaTime;
				if (Cooldown < 0)
					Cooldown = COOLDOWN;
			}
		}
		
		public void Shoot()
		{
			if (Cooldown == COOLDOWN)
			{
				Cooldown -= 0.0001f;
				GameObject g = GameObject.Instantiate(Bullet) as GameObject;
				g.transform.position = transform.position;
				g.transform.rotation = transform.rotation;
			}
		}
		
		public void ShootSpecial()
		{
			if (Cooldown == COOLDOWN)
			{
				Cooldown -= 0.0001f;
				int numBullets = 10;
				for (int i = 0; i < numBullets; i++)
				{
					GameObject g = GameObject.Instantiate(Bullet) as GameObject;
					g.transform.position = transform.position;
					Vector3 v = Vector3.zero;
					v.z = (360 / numBullets) * i;
					g.transform.rotation = Quaternion.Euler(v);
				}
			}
		}
	}
}