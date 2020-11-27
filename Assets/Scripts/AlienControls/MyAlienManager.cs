using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAlienManager : MonoBehaviour
{
    public List<float> meters;
	private void Start()
	{
        for (int i = 0; i < meters.Count; i++)
        {
            string key = string.Format("meter_{0}", i + 1);
            meters[i] = PlayerPrefs.GetFloat(key, 50);
        }
	}

	private void Update()
    {
        for (int i = 0; i < meters.Count; i++)
        {
            if (meters[i] > 0)
            {

            }
        }
    }

	private void OnApplicationPause(bool pause)
	{
        Debug.Log("OnApplicationPause " + pause);
        if(pause)
        {
            for (int i = 0; i < meters.Count; i++)
            {
                string key = string.Format("meter_{0}", i + 1);
                PlayerPrefs.SetFloat(key, meters[i]);
            }
        }
	}

	private void OnApplicationQuit()
	{
        Debug.Log("OnApplicationQuit");
        for (int i = 0; i < meters.Count; i++)
        {
            string key = string.Format("meter_{0}", i + 1);
            PlayerPrefs.SetFloat(key, meters[i]);
        }
	}
}
