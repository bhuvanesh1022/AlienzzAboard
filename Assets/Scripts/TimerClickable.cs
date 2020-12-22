using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerClickable : MonoBehaviour
{
    public float msToWait = 5000.0f ;
    public Button Btn;
    public int orderNo;
    public Text timer;
    private ulong lastClicked;
    public String Name;

    private bool IsReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsleft = (float)(msToWait - m) / 1000.0f;

        if (secondsleft < 0)
        {
            Btn.interactable = true;
            return true;
        }
        return false;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(string.Format("{0} Clicked", orderNo)))
        {
            lastClicked = ulong.Parse(PlayerPrefs.GetString(string.Format("{0} Clicked", orderNo)));
        }
        if (!IsReady())
        {
            Btn.interactable = false;
        }
    }

    private void Update()
    {
        if (!Btn.interactable)
        {
            if (IsReady())
            {
                timer.text = Name;
                Btn.interactable = true;
                return;
            }
            
            ulong diff = ((ulong) DateTime.Now.Ticks - lastClicked);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsleft = (float)(msToWait - m) / 1000.0f;
            string r = "";
            //hrs
            //r += ((int) secondsleft / 3600).ToString() + "h ";
            secondsleft -= ((int) secondsleft / 3600) * 3600;
            
            //min
            //r += ((int) secondsleft / 60).ToString("00") + "m ";
            
            //sec
            r += (secondsleft % 60).ToString("00") + "s";

            timer.text = r;
        }
    }
    
    public void Time()
    {
        lastClicked = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString(string.Format("{0} Clicked", orderNo), lastClicked.ToString());
        Btn.interactable = false;
    }
}
