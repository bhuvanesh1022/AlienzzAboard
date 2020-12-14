using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public enum Meters { Hunger, Happiness, Curiosity, Null};
    [SerializeField] int val;
    [SerializeField] int val2;
    [SerializeField] Meters meter;
    [SerializeField] Meters meter2;
    public TimerClickable timer;
    public GameObject alien;
    public GameObject alien2;

    private void Start()
    {
        
    }

    public void Onclick()
    {
        Debug.Log("went");
        if (alien.activeInHierarchy)
        {
            MyAlien.OnSomethingDropped += InteractionOnAlien;
            MyAlien.OnSomethingDropped.Invoke();
            //MyAlien.OnSomethingDropped -= InteractionOnAlien;
            Debug.Log("int1");
        }
        if (alien2.activeInHierarchy)
        {
            MyAlien.OnSomethingDropped += InteractionOnAlien2;
            MyAlien.OnSomethingDropped.Invoke();
            //MyAlien.OnSomethingDropped -= InteractionOnAlien2;
            Debug.Log("int2");
        }
        //this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void InteractionOnAlien()
    {
        switch (meter)
        {
            case Meters.Hunger:
                alien.GetComponent<MyAlienManager>().meters[0] += val;
                Debug.Log("hunger");
                break;

            case Meters.Happiness:
                alien.GetComponent<MyAlienManager>().meters[1] += val;
                break;

            case Meters.Curiosity:
                alien.GetComponent<MyAlienManager>().meters[2] += val;
                break;
            
            case Meters.Null:
                break;
            
            default:
                break;
            
        }
        switch (meter2)
        {
            case Meters.Hunger:
                alien.GetComponent<MyAlienManager>().meters[0] += val2;
                break;

            case Meters.Happiness:
                alien.GetComponent<MyAlienManager>().meters[1] += val2;
                break;

            case Meters.Curiosity:
                alien.GetComponent<MyAlienManager>().meters[2] += val2;
                break;
            
            case Meters.Null:
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
            case Meters.Hunger:
                alien2.GetComponent<MyAlienManager>().meters[0] += val;
                break;

            case Meters.Happiness:
                alien2.GetComponent<MyAlienManager>().meters[1] += val;
                break;

            case Meters.Curiosity:
                alien2.GetComponent<MyAlienManager>().meters[2] += val;
                break;
            
            case Meters.Null:
                break;
            
            default:
                break;
            
        }
        switch (meter2)
        {
            case Meters.Hunger:
                alien2.GetComponent<MyAlienManager>().meters[0] += val2;
                break;

            case Meters.Happiness:
                alien2.GetComponent<MyAlienManager>().meters[1] += val2;
                break;

            case Meters.Curiosity:
                alien2.GetComponent<MyAlienManager>().meters[2] += val2;
                break;
            
            case Meters.Null:
                break;
            
            default:
                break;
            
        }
        
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= InteractionOnAlien2;
    }
}
