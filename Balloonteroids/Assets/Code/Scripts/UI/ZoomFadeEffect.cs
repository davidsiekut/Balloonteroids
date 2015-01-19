using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZoomFadeEffect : MonoBehaviour
{

	void Start()
	{
		StartCoroutine(ZoomFade());
	}
	
	void Update()
	{
	
	}
	
	IEnumerator ZoomFade()
	{
		while(true)
		{
			this.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, this.GetComponent<Text>().color.a - 0.01f);
			this.transform.localScale = new Vector3(transform.localScale.x + 0.01f, 
				transform.localScale.y + 0.01f,
		        transform.localScale.z);
			yield return null;
		}
	}
}
