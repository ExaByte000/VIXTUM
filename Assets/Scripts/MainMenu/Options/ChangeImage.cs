using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private Sprite optionsSprite;
    [SerializeField] private string animationTrigger;
    [SerializeField] private GameObject buttons;
    [SerializeField] private Vector2 offsetMin;
    [SerializeField] private Vector2 offsetMax;
    [SerializeField] private Vector2 anchorMin;
    [SerializeField] private Vector2 anchorMax;

    private RectTransform buttonRectTransform;
    private Image buttonImage;

    public RectTransform ButtonRectTransform { get { return buttonRectTransform; } set {buttonRectTransform = value; } }
    public Image ButtonImage { get { return buttonImage; } set { buttonImage = value; } }

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonRectTransform = GetComponent<RectTransform>();
    }

    public void OptionsImageChanger()
    {
        buttonRectTransform.offsetMin = offsetMin; //new(8.139759e-07f, 0.005582836f);
        buttonRectTransform.offsetMax = offsetMax; //new(1.035072e-05f, 2.700835e-08f);
        buttonRectTransform.anchorMin = anchorMin; //new(0.7395834f, 0.278f);
        buttonRectTransform.anchorMax = anchorMax; //new(0.8901877f, 0.575229f);
        buttonImage.sprite = optionsSprite;
        MainMenuController.CatecgryIsSelected = true;
        MainMenuController.SelectedButtonTrigger = animationTrigger;
        buttons.SetActive(true);

    }
}
