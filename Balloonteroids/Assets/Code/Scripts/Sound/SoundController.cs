using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Balloonteroids.Code.Scripts.Sound
{
	public class SoundController : MonoBehaviour
	{
		AudioSource BGM;

		void Start()
		{
			BGM = GetComponent<AudioSource>();
		}

		public void ToggleBGM()
		{
			if (BGM.isPlaying)
			{
				BGM.Pause();
			}
			else
			{
				BGM.Play();
			}
		}
	}
}