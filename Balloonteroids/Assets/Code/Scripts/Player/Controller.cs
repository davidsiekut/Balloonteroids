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
	
		void Start()
		{
			//Jetpack.GetComponent<ParticleSystem>().Play();
		}
		
		void FixedUpdate()
		{
			transform.Rotate(-Vector3.forward * Input.GetAxis("Horizontal") * TurnSpeed * Time.fixedDeltaTime); 
						
			if(Input.GetAxis("Vertical") > 0)
			{
				if (Jetpack.GetComponent<ParticleSystem>().isStopped)
				{
					Jetpack.GetComponent<ParticleSystem>().Play();
				}

				rigidbody2D.AddRelativeForce(Vector3.up * Acceleration * Time.fixedDeltaTime); 
			}
		}
	}
}