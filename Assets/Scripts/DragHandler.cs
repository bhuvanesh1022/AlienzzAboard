﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Meters { Hunger, Happiness, Curiosity, Hunger1, Happiness1, Curiosity1 , Null};
    [SerializeField] int val;
    [SerializeField] int val2;
    [SerializeField] Meters meter;
    [SerializeField] Meters meter2;
    Vector3 startPos;
    public Timer timer;
    public Transform alien;
    public Transform alien2;
    public bool canDrag;
    //public MyAlien myalien;

    private void Start()
    {
        canDrag = true;
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            startPos = this.transform.position;
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            alien.GetComponent<MyAlien>().notOnMe = true;
            alien2.GetComponent<MyAlien>().notOnMe = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = startPos;

        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.transform == alien)
        {
            MyAlien.OnSomethingDropped += DroppedOnAlien;
            Debug.Log("hitted"+hit.transform.name);
        }

        if (hit.transform == alien2)
        {
            MyAlien.OnSomethingDropped += DroppedOnAlien2;
            Debug.Log("hitted"+hit.transform.name);
        }

        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("BLCOKED");
    }

    public void DroppedOnAlien()
    {
        switch (meter)
        {
            case Meters.Hunger:
                alien.GetComponent<MyAlienManager>().meters[0] += val;
                break;

            case Meters.Happiness:
                alien.GetComponent<MyAlienManager>().meters[1] += val;
                break;

            case Meters.Curiosity:
                alien.GetComponent<MyAlienManager>().meters[2] += val;
                break;

            case Meters.Hunger1:
                alien.GetComponent<MyAlienManager>().meters[0] += val;
                break;

            case Meters.Happiness1:
                alien.GetComponent<MyAlienManager>().meters[1] += val;
                break;

            case Meters.Curiosity1:
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

            case Meters.Hunger1:
                alien.GetComponent<MyAlienManager>().meters[0] += val2;
                break;

            case Meters.Happiness1:
                alien.GetComponent<MyAlienManager>().meters[1] += val2;
                break;

            case Meters.Curiosity1:
                alien.GetComponent<MyAlienManager>().meters[2] += val2;
                break;
            
            case Meters.Null:
                break;
            
            default:
                break;
            
        }
        
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= DroppedOnAlien;
    }
    
    public void DroppedOnAlien2()
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

            case Meters.Hunger1:
                alien2.GetComponent<MyAlienManager>().meters[0] += val;
                break;

            case Meters.Happiness1:
                alien2.GetComponent<MyAlienManager>().meters[1] += val;
                break;

            case Meters.Curiosity1:
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

            case Meters.Hunger1:
                alien2.GetComponent<MyAlienManager>().meters[0] += val2;
                break;

            case Meters.Happiness1:
                alien2.GetComponent<MyAlienManager>().meters[1] += val2;
                break;

            case Meters.Curiosity1:
                alien2.GetComponent<MyAlienManager>().meters[2] += val2;
                break;
            
            case Meters.Null:
                break;

            default:
                break;
            
        }
        
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= DroppedOnAlien2;
    }
}
