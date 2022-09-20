using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    public Color heatedMax;
    public Color cooledMax;
	public float maxExpedColrTemp;

	Color curCol;
    PlatformFly myFly;
	SpriteRenderer mySr;

	private void Awake()
	{
		myFly = GetComponent<PlatformFly>();
		mySr = GetComponent<SpriteRenderer>();
	}
	// Update is called once per frame
	void Update()
    {
        curCol = mySr.color;
		curCol = Color.Lerp(cooledMax, heatedMax, myFly.temperature / maxExpedColrTemp + 1);
		//Debug.Log(myFly.temperature / maxExpedColrTemp);
		mySr.color = curCol;
    }
}
