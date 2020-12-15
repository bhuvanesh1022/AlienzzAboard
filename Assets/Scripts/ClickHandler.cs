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
    public Text Text;
    public Image img;
    public String emojiComment ;
    public Sprite emojiIcon;
    public float Unlock;

    private void Update()
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

    public void Onclick()
    {
        StartCoroutine(speechReaction());
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
    }

    IEnumerator speechReaction()
    {
        if (Bubble.activeInHierarchy)
        {
            Text.text = emojiComment;
            if (emojiIcon != null)
            {
                img.sprite = emojiIcon;
            }
            yield return new WaitForSeconds(1f);
            img.sprite = null;
            Bubble.SetActive(false);
        }
        else if (!Bubble.activeInHierarchy)
        {
            Text.text = emojiComment;
            if (emojiIcon!= null)
            {
                img.sprite = emojiIcon;
            }
            Bubble.SetActive(true);
            yield return new WaitForSeconds(1f);
            img.sprite = null;
            Bubble.SetActive(false);
        }
    }

    public void InteractionOnAlien()
    {
        switch (meter)
        {
            case Meters.Trust:
                alien.GetComponent<MyAlienManager>().meters[0] += val;
                Debug.Log("hunger");
                break;
            
            default:
                break;
            
        }
        
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= InteractionOnAlien;
    }
    
    public void InteractionOnAlien2()
    {
        switch (meter)
        {
            case Meters.Trust:
                alien2.GetComponent<MyAlienManager>().meters[0] += val;
                break;
            
            default:
                break;
            
        }

        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= InteractionOnAlien2;
    }
}
