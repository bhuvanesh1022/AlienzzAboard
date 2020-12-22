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
    public MyAlienManager alien2;
    private ulong lastClicked;
    public Image meter;
    public Text metercount;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey(string.Format("{0} Has Updated", orderNo)))
        {
            lastClicked = ulong.Parse(PlayerPrefs.GetString(string.Format("{0} Has Updated", orderNo)));

            ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
            float elepseSeconds = (diff / TimeSpan.TicksPerMillisecond)/1000f;
            

            alien.meters[orderNo] -= Mathf.Clamp(elepseSeconds * decayRate, 0f, 100f);
            if (alien.meters[orderNo] < 0)
                alien.meters[orderNo] = 0;
            
            alien2.meters[orderNo] -= Mathf.Clamp(elepseSeconds * decayRate, 0f, 100f);
            if (alien2.meters[orderNo] < 0)
                alien2.meters[orderNo] = 0;
        }
    }

	private void Update()
	{
        float amt = meter.fillAmount;
        metercount.text = (amt * 100).ToString("F0");
        alien.meters[orderNo] -= Time.deltaTime * decayRate;
        if (alien.meters[orderNo] < 0)
            alien.meters[orderNo] = 0;
        alien2.meters[orderNo] -= Time.deltaTime * decayRate;
        if (alien2.meters[orderNo] < 0)
            alien2.meters[orderNo] = 0;
    }
    
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            lastClicked = (ulong)DateTime.Now.Ticks;
            PlayerPrefs.SetString(string.Format("{0} Has Updated", orderNo), lastClicked.ToString());
        }
        else
        {
            lastClicked = ulong.Parse(PlayerPrefs.GetString(string.Format("{0} Has Updated", orderNo)));

            ulong diff = ((ulong)DateTime.Now.Ticks - lastClicked);
            float elepseSeconds = (diff / TimeSpan.TicksPerMillisecond) / 1000f;
            
            alien.meters[orderNo] -= elepseSeconds * decayRate;
            if (alien.meters[orderNo] < 0)
                alien.meters[orderNo] = 0;
            
            alien2.meters[orderNo] -= elepseSeconds * decayRate;
            if (alien2.meters[orderNo] < 0)
                alien2.meters[orderNo] = 0;
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
    }
}
