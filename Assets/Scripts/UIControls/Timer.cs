using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float msToWait = 5000.0f ;
    public Image interactable;
    private ulong lastClicked;
    //private List<ulong> clicks = new List<ulong>();
    //public Text timer;
    public int orderNo;

    private bool IsReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsleft = (float)(msToWait - m) / 1000.0f;
        Debug.Log(secondsleft);

        if (secondsleft < 0)
        {
            //timer.text = "ready";
            //timerButton.interactable = true;
            interactable.raycastTarget = true;
            interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, 1);
            return true;
        }
        return false;
    }

    private void Start()
    {
        //lastClicked = ulong.Parse(PlayerPrefs.GetString("LastClicked"));
        if (PlayerPrefs.HasKey(string.Format("{0} Clicked", orderNo)))
        {
            lastClicked = ulong.Parse(PlayerPrefs.GetString(string.Format("{0} Clicked", orderNo)));
        }
        if (!IsReady())
        {
            interactable.raycastTarget = false;
            float a = interactable.color.a;
            interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, .5f);
        }
    }

    private void Update()
    {
        if (!interactable.raycastTarget)
        {
            if (IsReady())
            {
                interactable.raycastTarget = true;
                float a = interactable.color.a;
                interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, 1);
                //timer.text = "Ready";
                return;
            }
            
            ulong diff = ((ulong) DateTime.Now.Ticks - lastClicked);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsleft = (float)(msToWait - m) / 1000.0f;

            string r = "";
            //hrs
            r += ((int) secondsleft / 3600).ToString() + "h ";
            secondsleft -= ((int) secondsleft / 3600) * 3600;
            
            //min
            r += ((int) secondsleft / 60).ToString("00") + "m ";
            
            //sec
            r += (secondsleft % 60).ToString("00") + "s";

            //timer.text = r;
        }
    }
    
    public void Time()
    {
        lastClicked = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString(string.Format("{0} Clicked", orderNo), lastClicked.ToString());
        interactable.raycastTarget = false;
        float a = interactable.color.a;
        interactable.color = new Color(interactable.color.r, interactable.color.g, interactable.color.b, .5f);
    }
}
