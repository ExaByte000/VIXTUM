using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        
    }
    
}
