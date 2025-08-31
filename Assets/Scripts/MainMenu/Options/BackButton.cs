using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private string animationTrigger;
    [SerializeField] private GameObject buttons;
    [SerializeField] private Sprite optionsSprite;
    [SerializeField] private ChangeImage changeImage;
    [SerializeField] private Vector2 offsetMin;
    [SerializeField] private Vector2 offsetMax;
    [SerializeField] private Vector2 anchorMin;
    [SerializeField] private Vector2 anchorMax;

    private RectTransform buttonRectTransform;
    private Image buttonImage;

    private void Start()
    {
        buttonRectTransform = changeImage.ButtonRectTransform;
        buttonImage = changeImage.ButtonImage;
    }

    public void BackButtonClick()
    {
        buttonRectTransform.offsetMin = offsetMin; //new(8.139759e-07f, 0.005582836f); -3.5763e-07 0 
        buttonRectTransform.offsetMax = offsetMax; //new(1.035072e-05f, 2.700835e-08f); -3.5763e-07 0
        buttonRectTransform.anchorMin = anchorMin; //new(0.7395834f, 0.278f); 0.7395834 0.4246947
        buttonRectTransform.anchorMax = anchorMax; //new(0.8901877f, 0.575229f); 0.8901877 0.575229
        buttonImage.sprite = optionsSprite;
        MainMenuController.CatecgryIsSelected = false;
        MainMenuController.SelectedButtonTrigger = animationTrigger;
        buttons.SetActive(false);
    }
}
