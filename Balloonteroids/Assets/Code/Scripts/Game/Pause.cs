using UnityEngine;
using System.Collections;
using Balloonteroids.Code.Scripts.Sound;

public class Pause : MonoBehaviour
{
	public GameObject Paused;
	public GameObject SoundController;

	void Start()
	{
		StartCoroutine(PauseCoroutine());    
	}
	
	IEnumerator PauseCoroutine() {
		
		while (true)
		{
			if (Input.GetButtonDown("Cancel"))
			{
				Paused.SetActive(!Paused.activeSelf);
				SoundController.GetComponent<SoundController>().ToggleBGM();
				if (Time.timeScale == 0)
				{
					Time.timeScale = 1;
				}
				else 
				{
					Time.timeScale = 0;
				}
			}    
			yield return null;    
		}
	}
}
