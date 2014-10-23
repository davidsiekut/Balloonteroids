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
					Blowgun.GetComponent<Blowgun>().Shoot();
					// TODO sync with canShoot
					animator.SetBool("IsShooting", true);
				}
				else
				{
					animator.SetBool("IsShooting", false);
				}
				
			}
		}
	}
}