using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOutScript: MonoBehaviour
{
	float lerpValue = 0.0f;
	float lerpValueChange = 0.005f;
	Color lerp1;
	Color lerp2;
	// Use this for initialization
	void Start()
	{
		lerp1 = new Color (1,1,1,1);
		lerp2 = new Color (1,1,1,0);
	}
	// Update is called once per frame
	void Update()
	{
		this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = Color.Lerp(lerp1, lerp2, lerpValue);
		lerpValue = lerpValue + lerpValueChange;
		if (lerpValue > 0.98f)
		{
			lerpValueChange = -0.02f;
		}
		if (lerpValue < 0.02f)
		{
			lerpValueChange = 0.02f;
		}
	}
}