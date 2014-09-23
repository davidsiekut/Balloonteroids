using UnityEngine;
using System.Collections;

namespace Balloonteroids.Code.Scripts.Entity
{
	public class Wrap : MonoBehaviour
	{
		void Start()
		{
		}
		
		void FixedUpdate()
		{
			Vector3 v = Camera.main.WorldToViewportPoint(transform.position);
			Vector3 newPos = transform.position;
	
			if (v.x < 0 || v.x > 1)
			{
				newPos.x = -newPos.x;
			}
		
			if (v.y < 0 || v.y > 1)
			{
				newPos.y = -newPos.y;
			}
			
			transform.position = newPos;
		}
	}
}