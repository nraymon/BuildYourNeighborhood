﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Action OnHousePlacement;
    public Button PlaceHouseBtn;

    public Transform obj;

    public Color outlineColor;

    List<Button> buttonList;

    private void Start()
    {
        buttonList = new List<Button> { PlaceHouseBtn };

        PlaceHouseBtn.onClick.AddListener(() =>
        {
            Debug.Log("hello\n");
            ResetButtonColor();
            ModifyOutline(PlaceHouseBtn);
            OnHousePlacement?.Invoke();
        });
    }

    private void ModifyOutline(Button button)
    {
        var outline = button.GetComponent<Outline>();
        outline.effectColor = outlineColor;
        outline.enabled = true;
    }

    private void ResetButtonColor()
    {
        foreach(Button button in buttonList)
        {
            button.GetComponent<Outline>().enabled = false;
        }
    }
}