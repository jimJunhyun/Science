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
	Animator anim;

	enum SkillStatus
	{
		None = 0,
		Ice,
		Fire
	}

	private void Awake()
	{
		platformLayer = 1 << platformLayer;
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
    {
        mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mPos - new Vector2(transform.position.x, transform.position.y)).normalized;
		UseMagic();
    }

	void UseMagic()
	{
		if (Input.GetMouseButton(0))
		{
			if (hit = Physics2D.Raycast(transform.position, dir, maxDist, platformLayer))
			{
				hit.transform.GetComponent<PlatformFly>().temperature -= tempPerSec * Time.deltaTime;
				Debug.DrawLine(transform.position, hit.point, Color.cyan);
			}
			anim.SetInteger("SkillStatus", ((int)SkillStatus.Ice));
		}
		else if (Input.GetMouseButton(1))
		{
			if (hit = Physics2D.Raycast(transform.position, dir, maxDist, platformLayer))
			{
				hit.transform.GetComponent<PlatformFly>().temperature += tempPerSec * Time.deltaTime;
				Debug.DrawLine(transform.position, hit.point, Color.red);
			}
			anim.SetInteger("SkillStatus", ((int)SkillStatus.Fire));
		}
		else
		{
			anim.SetInteger("SkillStatus", ((int)SkillStatus.None));
		}
	}
}
