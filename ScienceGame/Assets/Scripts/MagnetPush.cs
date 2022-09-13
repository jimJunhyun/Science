using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPush : MonoBehaviour
{
    public float power;
    public float radius;
    public int platformLayer = 8;

	int layermask;
	Collider2D[] cols;
	private void Awake()
	{
		layermask = 1 << platformLayer;
	}
	// Update is called once per frame
	void Update()
    {
		cols = Physics2D.OverlapCircleAll(transform.position, radius, layermask);
		if (cols.Length != 0)
		{
			
			foreach (var item in cols)
			{
				
				PlatformFly platform = item.GetComponent<PlatformFly>();
				if (platform != null && platform.isHovering)
				{
					platform.myrig.AddForce((platform.transform.position -transform.position).normalized * power);
				}
			}
			cols = null;
		}
    }

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
