using UnityEngine;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;

namespace Balloonteroids.Code.Scripts.BalloonCluster
{
	public class BalloonFactory : MonoBehaviour
	{
		public GameObject Balloon;
		private int balloons;
		
		void Start()
		{
			int r = UnityEngine.Random.Range(1, 10);
			balloons = r;
			
			for (int i = 0; i < r; i++)
			{
				float j = i * 0.1f;
				// mess around with first and second terms to get a nice spiral
				float x = (j / 1.5f) * Mathf.Cos(j * 18);
				float y = (j / 1.5f) * Mathf.Sin(j * 18);
				GameObject g = GameObject.Instantiate(Balloon) as GameObject;
				g.transform.parent = this.transform;
				g.transform.localPosition = new Vector3(x, y, 0);
			}
			
			GameController.BalloonPlusPlus(balloons);
		}
		
		public int Pop()
		{
			balloons--;
			return balloons;
		}
		
		void Update()
		{
			if (balloons == 0)
				Destroy(gameObject);
		}
	}
}