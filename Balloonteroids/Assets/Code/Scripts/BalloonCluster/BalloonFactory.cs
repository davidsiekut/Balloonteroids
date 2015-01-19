using UnityEngine;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;

namespace Balloonteroids.Code.Scripts.BalloonCluster
{
	public class BalloonFactory : MonoBehaviour
	{
		public GameObject Balloon;
		public int balloons;	
		
		void Start()
		{

		}
		
		public void Populate()
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
			balloons--; // the one that just popped
			
			if (balloons > 1)
			{
				balloons /= 2; // half will pop off
			
				GameObject g = GameObject.Instantiate(Resources.Load("Prefabs/Entity/BalloonCluster")) as GameObject;
				g.transform.position = this.transform.position;
				
				int children = this.transform.childCount;
				//Debug.Log("Children in cluster: " + children);
				for (int i = 0; i < children / 2; i++)
				{
					this.transform.GetChild(0).SetParent(g.transform);
				}
				g.GetComponent<BalloonFactory>().balloons = g.transform.childCount;
				GameController.clusters.Add(g);
			}
			
			Debug.Log(balloons);
			return balloons;
		}
		
		void Update()
		{
			//if (balloons == 0)
				//Destroy(gameObject);
		}
	}
}