using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private Animator mainMenuAnimator;

    private static bool categoryIsSelected = false;
    private static string selectedButtonTrigger = "";
    private string previousButtonTrigger;

    public static bool CatecgryIsSelected { get { return categoryIsSelected; } set { categoryIsSelected = value; } }
    public static string SelectedButtonTrigger { get { return selectedButtonTrigger; } set { selectedButtonTrigger = value; } }

    public List<Button> ButtonsList = new();

    private void Start()
    {
        mainMenuAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (categoryIsSelected)
        {
            StartAnim(selectedButtonTrigger, false);
            previousButtonTrigger = selectedButtonTrigger;
        }
        else
        {
            StartAnim(selectedButtonTrigger, true);
            previousButtonTrigger = selectedButtonTrigger;
        }
    }

    private void StartAnim(string selectedButtonTrigger, bool enabled)
    {
        if (!string.IsNullOrEmpty(selectedButtonTrigger))
        {
            mainMenuAnimator.SetBool(selectedButtonTrigger, true);
            if (previousButtonTrigger != null)
                mainMenuAnimator.SetBool(previousButtonTrigger, false);
            selectedButtonTrigger = "";
        }
        foreach (var button in ButtonsList)
        {
            button.enabled = enabled;
        }

    }

}
