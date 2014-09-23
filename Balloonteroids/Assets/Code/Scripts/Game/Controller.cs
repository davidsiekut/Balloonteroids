using UnityEngine;
using System.Collections.Generic;

namespace Balloonteroids.Code.Scripts.Game
{
	public class Controller : MonoBehaviour
	{
		//private List<GameObject> balloons;
		public GameObject BalloonCluster;
		
		void Start()
		{
			//balloons = new List<GameObject>();
			
			for(int i = 0; i < 20; i++)
			{
				GameObject g = GameObject.Instantiate(BalloonCluster) as GameObject;
				g.transform.position = new Vector3(0, 5, 0);
			}
		}
		
		void Update()
		{
			
		}
	}
}