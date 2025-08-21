using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            GamePause.Instance.SetPause(true);
        }
    }
}
