using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrkl : MonoBehaviour
{
	public static SceneCtrkl instance;
    public string targetSceneName;
	private void Awake()
	{
		instance = this;
	}
	public void Loader()
	{
		SceneManager.LoadScene(targetSceneName);
	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
