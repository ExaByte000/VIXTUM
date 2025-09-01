using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuPointBack : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private List<GameObject> anotherButtons = new();
    [SerializeField] private GameObject currentButton;

    public void ClickToBackButton()
    {
        currentButton.GetComponent<TextMeshProUGUI>().enabled = true;
        currentButton.GetComponent<Button>().enabled = true;
        settingsPanel.SetActive(false);
        foreach (var button in anotherButtons)
        {
            button.SetActive(true);
        }
    }

}
