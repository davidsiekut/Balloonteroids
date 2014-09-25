using UnityEngine;
using System.Collections;
using Balloonteroids.Code.Scripts.Game;

public class LifeCounter : MonoBehaviour
{
	public GameObject Heart;
	GameObject[] Hearts;
	
	void Start()
	{
		Hearts = new GameObject[GameController.Lives];
	
		for (int i = 0; i < GameController.Lives; i++)
		{
			Hearts[i] = GameObject.Instantiate(Heart, Vector3.zero, Quaternion.identity) as GameObject;
			Hearts[i].transform.parent = transform;
			Hearts[i].transform.localPosition = new Vector3(i * -34, 0, 0);
		}
	}
	
	public void LoseLife()
	{
		for (int i = GameController.Lives - 1; i >= 0; i--)
		{
			if (Hearts[i].activeSelf)
			{
				Hearts[i].SetActive(false);
				break;
			}
		}
	}
}
