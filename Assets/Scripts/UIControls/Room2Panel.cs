using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Panel : Base_UIPanel
{
    public GameObject nextBtn, prevBtn;
    public List<Transform> itemHolders = new List<Transform>();
    
    Transform itemHolderParent;

    public override void OpenBehavior()
    {
        base.OpenBehavior();

        itemHolderParent = transform.GetChild(0).transform;
        nextBtn.SetActive(false);
        prevBtn.SetActive(true);
        for (int i = 0; i < itemHolderParent.childCount; i++)
            if (!itemHolders.Contains(itemHolderParent.GetChild(i).transform))
                itemHolders.Add(itemHolderParent.GetChild(i).transform);
    }
}
