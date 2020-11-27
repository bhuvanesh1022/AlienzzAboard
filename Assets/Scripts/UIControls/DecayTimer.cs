using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecayTimer : MonoBehaviour
{
    public float decayRate;
    public Image interactable;
    public int orderNo;
    public MyAlienManager alien;
    private ulong lastClicked;

    private bool IsReady()
    {
        //ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
        //ulong m = diff / TimeSpan.TicksPerMillisecond;
        //float secondsleft = (float)(msToWait - m) / 1000.0f;
        //Debug.Log(secondsleft / 100);
        /*ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
        ulong m = (diff / TimeSpan.TicksPerMillisecond);
        float secondsleft = (float)(msToWait - m)/1000f;

        Debug.Log(secondsleft);
        if (secondsleft < 0)
        {
            //    interactable.raycastTarget = true;
            //    interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, 1);
            return true;
        }*/
        return false;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(string.Format("{0} Has Updated", orderNo)))
        {
            lastClicked = ulong.Parse(PlayerPrefs.GetString(string.Format("{0} Has Updated", orderNo)));
            PlayerPrefs.DeleteKey(string.Format("{0} Has Updated", orderNo));

            ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
            float elepseSeconds = (diff / TimeSpan.TicksPerMillisecond)/1000f;

            Debug.Log("elepseSeconds " + elepseSeconds);

            alien.meters[orderNo] -= elepseSeconds * decayRate;
        }
        else
        {
            //Timer();
        }
        //if (!IsReady())
        //{
        //    interactable.raycastTarget = false;
        //    float a = interactable.color.a;
        //    interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, .5f);
        //}
        //Debug.Log(DateTime.);
    }

	private void Update()
	{
        alien.meters[orderNo] -= Time.deltaTime * decayRate;
	}

	private void FixedUpdate()
    {
        //if (!interactable.raycastTarget)
        //{
        //    if (IsReady())
        //    {
        //        interactable.raycastTarget = true;
        //        float a = interactable.color.a;
        //        interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, 1);
        //        return;
        //    }

        //    ulong diff = ((ulong) DateTime.Now.Ticks - lastClicked);
        //    ulong m = diff / TimeSpan.TicksPerMillisecond;
        //    float secondsleft = (float)(msToWait - m) / 1000.0f;
        //    Debug.Log(secondsleft);
        //    string r = "";
        //    //hrs
        //    r += ((int) secondsleft / 3600).ToString() + "h ";
        //    secondsleft -= ((int) secondsleft / 3600) * 3600;

        //    //min
        //    r += ((int) secondsleft / 60).ToString("00") + "m ";

        //    //sec
        //    r += (secondsleft % 60).ToString("00") + "s";

        //    //timer.text = r;
        //}
        

        /*if (IsReady())
        {
            ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsleft = (float)(msToWait - m) / 1000.0f;

            
            Debug.Log(secondsleft);
        }*/
        //Debug.Log(interactable.fillAmount);
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            lastClicked = (ulong)DateTime.Now.Ticks;
            PlayerPrefs.SetString(string.Format("{0} Has Updated", orderNo), lastClicked.ToString());
        }

    }

    private void OnApplicationQuit()
    {
        lastClicked = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString(string.Format("{0} Has Updated", orderNo), lastClicked.ToString());
    }

    public void Timer()
    {
        lastClicked = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString(string.Format("{0} Has Updated", orderNo), lastClicked.ToString());
        //interactable.raycastTarget = false;
        //float a = interactable.color.a;
        //interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, .5f);
    }
}
