using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMagic : MonoBehaviour
{
    public float tempPerSec;
    public float maxDist;
    public int platformLayer = 8;
    Vector2 dir;
    Vector2 mPos;
    RaycastHit2D hit;
	private void Awake()
	{
		platformLayer = 1 << platformLayer;
	}

	// Update is called once per frame
	void Update()
    {
        mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mPos - new Vector2(transform.position.x, transform.position.y)).normalized;
		if (Input.GetMouseButton(0))
		{
            if(hit = Physics2D.Raycast(transform.position, dir, maxDist, platformLayer))
			{
				hit.transform.GetComponent<PlatformFly>().temperature -= tempPerSec;
				Debug.DrawLine(transform.position, hit.point);
			}
			
		}
    }
}
