using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAlien : MonoBehaviour
{
    public enum UserInteraction { Started, Holding, Released,Dropped};
    public UserInteraction interaction;
    public delegate void SomethingDropped();
    public static SomethingDropped OnSomethingDropped;

    public SpriteRenderer alien;
    
    public List<Sprite> faces = new List<Sprite>();
    public List<Image> meters = new List<Image>();
    public bool notOnMe;
    public bool dropped = false;
    public bool valGreater;
    float petDuration;
    public int valshow;
    public GameObject valshowScreen;
    public GameObject blockPanel;
    
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
            //OnHitfeedback();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            interaction = UserInteraction.Released;
            OnHitfeedback();
            notOnMe = true;
        }

        for (int i = 0; i < meters.Count; i++)
        {
            if (meters[i].fillAmount <= 0.30f && interaction != UserInteraction.Holding && dropped==false)
            {
                alien.sprite = faces[0];
                return;
            }
            if (meters[i].fillAmount <= 0.30f && interaction == UserInteraction.Holding && dropped==false)
            {
                //alien.sprite = faces[1];
                return;
            }
            if (meters[i].fillAmount > 0.30f && dropped==false)
            {
                alien.sprite = faces[2];
            }
        }
        if (dropped)
        {
            if (valGreater)
            {
                StartCoroutine(ChangeOnDropped());
            }
            else if (valGreater == false)
            {
                StartCoroutine(LessOnDropped());
            }
        }
        
        
    }

    public void OnHitfeedback()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
        
        if(hit.transform == transform )
            switch (interaction)
            {
                case UserInteraction.Started:
                    notOnMe = false;
                    break;

                case UserInteraction.Holding:
                    //alien.sprite = faces[1];
                    //petDuration += Time.deltaTime / 100.0f;
                    //GetComponent<MyAlienManager>().meters[1] += petDuration;
                    break;

                case UserInteraction.Released:
                    Debug.Log("Invoke");
                    OnSomethingDropped?.Invoke();
                    //dropped = true;
                    break;
                
                default:
                    break;
            }
    }

    IEnumerator ChangeOnDropped()
    {
        blockPanel.SetActive(true);
        alien.sprite = faces[1];
        Debug.Log("change");
        meters[0].color= Color.green;
        valshowScreen.SetActive(true);
        valshowScreen.GetComponentInChildren<Text>().text = "+" + valshow;
        yield return new WaitForSeconds(1.5f);
        meters[0].color = new Color(0.2f,0.6f,0.9f,1);
        valshowScreen.GetComponentInChildren<Text>().text = null;
        valshowScreen.SetActive(false);
        dropped = false;
        valGreater = false;
        yield return new WaitForSeconds(0.5f);
        blockPanel.SetActive(false);
    }
    IEnumerator LessOnDropped()
    {
        blockPanel.SetActive(true);
        alien.sprite = faces[0];
        Debug.Log("change");
        meters[0].color= Color.red;
        valshowScreen.SetActive(true);
        valshowScreen.GetComponentInChildren<Text>().text = "" + valshow;
        yield return new WaitForSeconds(1.5f);
        meters[0].color = new Color(0.2f,0.6f,0.9f,1);
        valshowScreen.GetComponentInChildren<Text>().text = null;
        valshowScreen.SetActive(false);
        dropped = false;
        yield return new WaitForSeconds(0.5f);
        blockPanel.SetActive(false);
    }
    
}
