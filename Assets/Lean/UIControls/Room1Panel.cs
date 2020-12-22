using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Room1Panel : Base_UIPanel
{
    public GameObject nextBtn, prevBtn;
    public List<Transform> itemHolders = new List<Transform>();
    Transform itemHolderParent;
    public List<DragHandler> draghandler = new List<DragHandler>();
    public override void OpenBehavior()
    {
        base.OpenBehavior();

        myAlien.DOPunchRotation(new Vector3(0f, 0f, 45f), .25f);

        itemHolderParent = transform.GetChild(0).transform;
        nextBtn.SetActive(true);
        prevBtn.SetActive(false);

        for (int i = 0; i < itemHolderParent.childCount; i++)
            if (!itemHolders.Contains(itemHolderParent.GetChild(i).transform))
                itemHolders.Add(itemHolderParent.GetChild(i).transform);

        StartCoroutine(nameof(SettleHolders));
    }

    IEnumerator SettleHolders()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < itemHolders.Count; i++)
        {
            itemHolders[i].DOBlendableMoveBy(new Vector3(0, -400f, 0), 0f);
            yield return null;
        }

        for (int i = 0; i < itemHolders.Count; i++)
        {
            itemHolders[i].DOBlendableMoveBy(new Vector3(0, 400f, 0), .25f).SetEase(Ease.OutElastic);
            yield return new WaitForSeconds(.125f);
        }
    }
}
