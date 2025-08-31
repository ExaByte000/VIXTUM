using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FixedAspect : MonoBehaviour
{
    [SerializeField] private float targetAspectWidth = 16f;
    [SerializeField] private float targetAspectHeight = 9f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateAspect();
    }

    void Update()
    {
        // Проверяем если пользователь изменил размер окна
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            UpdateAspect();
        }
    }

    private int lastWidth, lastHeight;

    private void UpdateAspect()
    {
        float targetAspect = targetAspectWidth / targetAspectHeight;
        float windowAspect = (float)Screen.width / Screen.height;

        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Добавляем черные полосы сверху и снизу
            Rect rect = cam.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            cam.rect = rect;
        }
        else
        {
            // Добавляем черные полосы слева и справа
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;
        }

        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }
}
