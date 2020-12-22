using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

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
    public GameObject buildmoretrustTxt;
    private void Start()
    {
        canDrag = true;
    }

    private void Update()
    {
        if (alien.gameObject.activeInHierarchy)
        {
            if (alien.GetComponent<MyAlienManager>().meters[0] < Unlock)
            {
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
                this.transform.parent.GetComponent<Image>().color = Color.grey;
                if (buildmoretrustTxt != null)
                {
                    buildmoretrustTxt.SetActive(true);
                }
                
            }
            if (alien.GetComponent<MyAlienManager>().meters[0] > Unlock)
            {
                this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                this.transform.parent.GetComponent<Image>().color = Color.white;
                if (buildmoretrustTxt != null)
                {
                    buildmoretrustTxt.SetActive(false);
                }
                
            }
        }
        if (alien2.gameObject.activeInHierarchy)
        {
            if (alien2.GetComponent<MyAlienManager>().meters[0] < Unlock)
            {
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
                this.transform.parent.GetComponent<Image>().color = Color.grey;
                if (buildmoretrustTxt != null)
                {
                    buildmoretrustTxt.SetActive(true);
                }
            }
            if (alien2.GetComponent<MyAlienManager>().meters[0] > Unlock)
            {
                this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                this.transform.parent.GetComponent<Image>().color = Color.white;
                if (buildmoretrustTxt != null)
                {
                    buildmoretrustTxt.SetActive(false);
                }
            }
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            startPos = this.transform.localPosition;
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
        this.transform.localPosition = startPos;

        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.transform == alien)
        {
            MyAlien.OnSomethingDropped += DroppedOnAlien;
        }

        if (hit.transform == alien2)
        {
            MyAlien.OnSomethingDropped += DroppedOnAlien2;
        }
        
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
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
        alien.GetComponent<MyAlien>().valshow = val;
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= DroppedOnAlien;
        alien.GetComponent<MyAlien>().dropped = true;
    }
    
    public void DroppedOnAlien2()
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
        alien2.GetComponent<MyAlien>().valshow = val;
        if(timer!=null) timer.Time();
        MyAlien.OnSomethingDropped -= DroppedOnAlien2;
        alien2.GetComponent<MyAlien>().dropped = true;
    }
}
