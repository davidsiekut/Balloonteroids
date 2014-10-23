using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.Player
{
	public class Controller : MonoBehaviour
	{
		public float Acceleration = 0.0f;
		public float MaxSpeed = 10.0f;
		public float TurnSpeed = 0.0f;
		public GameObject Jetpack;
		public GameObject Blowgun;
		public bool CanControl = false;
		
		Animator animator;
		
		float powerupTimer = 0.0f;
		
		void Start()
		{
			animator = GetComponent<Animator>();
		}
		
		void FixedUpdate()
		{
			if (CanControl)
			{
				transform.Rotate(-Vector3.forward * Input.GetAxis("Horizontal") * TurnSpeed * Time.fixedDeltaTime); 
							
				if (Input.GetAxis("Vertical") > 0)
				{
					if (Jetpack.GetComponent<ParticleSystem>().isStopped)
					{
						Jetpack.GetComponent<ParticleSystem>().Play();
					}
	
					rigidbody2D.AddRelativeForce(Vector3.up * Acceleration * Time.fixedDeltaTime); 
				}
				
				if (Input.GetButton("Jump"))
				{
					if (powerupTimer > 0)
					{
						Blowgun.GetComponent<Blowgun>().ShootSpecial();
					}
					else
					{
						Blowgun.GetComponent<Blowgun>().Shoot();
					}
					
					animator.SetBool("IsShooting", true);
				}
				else
				{
					animator.SetBool("IsShooting", false);
				}
			}
			
			if (powerupTimer > 0)
				powerupTimer -= Time.deltaTime;
		}
		
		public void Powerup()
		{
			powerupTimer = 3.0f;
		}
	}
}