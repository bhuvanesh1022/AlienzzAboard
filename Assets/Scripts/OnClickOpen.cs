using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickOpen : MonoBehaviour
{
    public List<GameObject> paneltobeClosed;
    public GameObject paneltobeActive;
    public Button btn;

    public int count = 0;

    public void OnOpen()
    {
        Debug.Log("clicked");
        if (count == 0 )
        {
            for (int i = 0; i < paneltobeClosed.Count; i++)
            {
                paneltobeClosed[i].SetActive(false);
            }
            paneltobeActive.SetActive(true);
            count += 1;
            Debug.Log("panelopen");
            return;
        }
        if (count == 1)
        {
            paneltobeActive.SetActive(false);
            count = 0;
            Debug.Log("panelclosed");
        }
        
    }
}
