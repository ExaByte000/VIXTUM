using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private Animator mainMenuAnimator;

    private static bool categoryIsSelected = false;
    public static bool CatecgryIsSelected { private get { return categoryIsSelected; } set { categoryIsSelected = value; } }

    public List<Button> ButtonsList = new();

    private void Start()
    {
        mainMenuAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (categoryIsSelected)
        {
            mainMenuAnimator.SetBool("CatecgryIsSelected", categoryIsSelected);
            foreach (var button in ButtonsList)
            { 
                button.enabled = false;
            }
        }
    }

}
