using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Meters { Trust};
    public int val;
    [SerializeField] Meters meter;
    Vector3 startPos;
    public Timer timer;
    public Transform alien;
    public Transform alien2;
    public bool canDrag;
    public float Unlock;
    
    private void Start()
    {
        canDrag = true;
    }

    private void Update()
    {
        if (alien.GetComponent<MyAlienManager>().meters[0] < Unlock)
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
            this.GetComponent<CanvasGroup>().alpha = 0.4f;
        }
        if (alien.GetComponent<MyAlienManager>().meters[0] > Unlock)
        {
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
            this.GetComponent<CanvasGroup>().alpha = 1f;
        }
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
            case Meters.Trust:
                
                alien.GetComponent<MyAlienManager>().meters[0] += val;
                
                if (val > 0)
                {
                    alien.GetComponent<MyAlien>().valGreater = true;
                }
                if (val == 0)
                {
                    alien.GetComponent<MyAlien>().valGreater = false;
                }
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
            case Meters.Trust:
                alien2.GetComponent<MyAlienManager>().meters[0] += val;
                break;

            default:
                break;
            
        }
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= DroppedOnAlien2;
    }
}
