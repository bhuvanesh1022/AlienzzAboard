using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAlien : MonoBehaviour
{
    public SpriteRenderer alien;
    public List<Sprite> faces = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        alien.sprite = faces[1];
        Debug.Log("Dragging");
    }

    private void OnMouseUp()
    {
        alien.sprite = faces[3];
    }

    
}
