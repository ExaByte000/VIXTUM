using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuPointClick : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private List<GameObject> anotherButtons = new();
    [SerializeField] private GameObject currentButton;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private string titleName;


   

    public void ClickToButton()
    {
        currentButton.GetComponent<TextMeshProUGUI>().enabled = false;
        currentButton.GetComponent<Button>().enabled = false;
        settingsPanel.SetActive(true);
        foreach (var button in anotherButtons)
        {
            button.SetActive(false);
        }
        title.text = titleName;
    }
}
