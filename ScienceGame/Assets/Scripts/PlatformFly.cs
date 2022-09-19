using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFly : MonoBehaviour
{
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

	}

	public void StartHover()
	{
		isHovering = true;
	}
	public void EndHover()
	{
		isHovering = false;
		myrig.gravityScale = 1;
	}
}
