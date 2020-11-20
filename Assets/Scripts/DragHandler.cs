using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum Meters { Hunger, Happiness, Curiosity};
    [SerializeField] int val;
    [SerializeField] Meters meter;
    Vector3 startPos;


    public Transform alien;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        alien.GetComponent<MyAlien>().notOnMe = true;
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
        }

        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
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

            default:
                break;
        }
        Debug.Log(val);
        MyAlien.OnSomethingDropped -= DroppedOnAlien;
    }
}
