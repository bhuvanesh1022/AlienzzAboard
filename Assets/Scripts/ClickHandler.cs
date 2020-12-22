using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public enum Meters { Trust };
    [SerializeField] int val;
    [SerializeField] Meters meter;
    public TimerClickable timer;
    public GameObject alien;
    public GameObject alien2;
    public GameObject Bubble;
    public Image img;
    public Sprite emojiIcon;
    public float Unlock;

    private void Update()
    {
        if (alien.activeInHierarchy)
        {
            if (alien.GetComponent<MyAlienManager>().meters[0] < Unlock)
            {
                this.GetComponent<CanvasGroup>().interactable = false;
            }
            if (alien.GetComponent<MyAlienManager>().meters[0] > Unlock)
            {
                this.GetComponent<CanvasGroup>().interactable = true;
            }
        }

        if (alien2.activeInHierarchy)
        {
            if (alien2.GetComponent<MyAlienManager>().meters[0] < Unlock)
            {
                this.GetComponent<CanvasGroup>().interactable = false;
            }
            if (alien2.GetComponent<MyAlienManager>().meters[0] > Unlock)
            {
                this.GetComponent<CanvasGroup>().interactable = true;
            }
        }
    }

    public void Onclick()
    {
        if (alien.activeInHierarchy)
        {
            MyAlien.OnSomethingDropped += InteractionOnAlien;
            MyAlien.OnSomethingDropped.Invoke();
            
        }
        if (alien2.activeInHierarchy)
        {
            MyAlien.OnSomethingDropped += InteractionOnAlien2;
            MyAlien.OnSomethingDropped.Invoke();
        }
        StartCoroutine(speechReaction());
    }

    IEnumerator speechReaction()
    {
        img.sprite = emojiIcon;
        // if (emojiIcon!= null)
        // {
        //     img.sprite = emojiIcon;
        // }
        Bubble.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        img.sprite = null;
        Bubble.SetActive(false);
    }

    public void InteractionOnAlien()
    {
        switch (meter)
        {
            case Meters.Trust:
                alien.GetComponent<MyAlienManager>().meters[0] += val;
                alien.GetComponent<MyAlien>().dropped = true;
                if (val > 0)
                {
                    alien.GetComponent<MyAlien>().valGreater = true;
                }
                if (val == 0)
                {
                    alien.GetComponent<MyAlien>().valGreater = false;
                }
                Debug.Log("hunger");
                break;
            
            default:
                break;
            
        }
        alien.GetComponent<MyAlien>().valshow = val;
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= InteractionOnAlien;
    }
    
    public void InteractionOnAlien2()
    {
        switch (meter)
        {
            case Meters.Trust:
                alien2.GetComponent<MyAlienManager>().meters[0] += val;
                if (val > 0)
                {
                    alien2.GetComponent<MyAlien>().valGreater = true;
                }
                if (val == 0)
                {
                    alien2.GetComponent<MyAlien>().valGreater = false;
                }
                break;
            
            default:
                break;
            
        }
        alien2.GetComponent<MyAlien>().dropped = true;
        alien2.GetComponent<MyAlien>().valshow = val;
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= InteractionOnAlien2;
    }
}
