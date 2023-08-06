using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] SelectedCounterObject;
    [SerializeField] GameObject[] normalCounter;
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnCounterSelected += SelectCounter;
    }

    private void SelectCounter(object sender, Player.OnCounterSelectedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
            Show();
        else
            Hide();
    }


    void Show()
    {
        foreach(var i in normalCounter)
            i.gameObject.SetActive(false);
        foreach (var i in SelectedCounterObject)
            i.gameObject.SetActive(true);
    }

    void Hide()
    {
        foreach(var i in normalCounter)
            i.gameObject.SetActive(true);
        foreach (var i in SelectedCounterObject)
            i.gameObject.SetActive(false);
    }
}
