using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAlien : MonoBehaviour
{
    public enum UserInteraction { Started, Holding, Released};
    public UserInteraction interaction;

    public delegate void SomethingDropped();
    public static SomethingDropped OnSomethingDropped;

    public SpriteRenderer alien;
    public List<Sprite> faces = new List<Sprite>();
    public List<Image> meters = new List<Image>();
 
    public bool notOnMe;

    float petDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        notOnMe = true;
        petDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < meters.Count; i++) meters[i].fillAmount = GetComponent<MyAlienManager>().meters[i]/100;

        if (Input.GetMouseButtonDown(0))
        {
            interaction = UserInteraction.Started;
            OnHitfeedback();
        }

        if (Input.GetMouseButton(0) && !notOnMe)
        {
            interaction = UserInteraction.Holding;
            OnHitfeedback();
        }

        if (Input.GetMouseButtonUp(0))
        {
            interaction = UserInteraction.Released;
            OnHitfeedback();
            notOnMe = true;
        }
    }

    public void OnHitfeedback()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if(hit.transform == transform)
            switch (interaction)
            {
                case UserInteraction.Started:
                    notOnMe = false;
                    break;

                case UserInteraction.Holding:
                    alien.sprite = faces[1];
                    petDuration += Time.deltaTime / 100.0f;
                    GetComponent<MyAlienManager>().meters[1] += petDuration;
                    break;

                case UserInteraction.Released:
                    alien.sprite = faces[3];
                    OnSomethingDropped?.Invoke();
                    break;

                default:
                    break;
            }
    }
}
