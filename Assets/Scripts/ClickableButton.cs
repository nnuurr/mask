using System;
using UnityEngine;

public class ClickableButton : Clickable
{
    [SerializeField]
    private uint buttonNumber;

    private ClickableButtonsManager buttonsManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonsManager = GetComponentInParent<ClickableButtonsManager>();
    }

    public override void Clicked()
    {
        buttonsManager.ClickButton(buttonNumber);
    }
}
