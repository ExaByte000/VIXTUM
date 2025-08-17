using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
