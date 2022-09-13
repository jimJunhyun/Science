using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFly : MonoBehaviour
{
	public float maxRise;
	public Rigidbody2D myrig;
	public float temperature;

	public bool isHovering;
	Vector2 riseDir;
	

	private void Awake()
	{
		myrig = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if(temperature <= -256)
		{
			StartHover();
		}
		else
		{
			EndHover();
		}

		if (isHovering)
		{
			myrig.gravityScale = 0;
		}
		else
		{
			myrig.gravityScale = 1;
		}
	}

	public void StartHover()
	{
		isHovering = true;
	}
	public void EndHover()
	{
		isHovering = false;
	}
}
