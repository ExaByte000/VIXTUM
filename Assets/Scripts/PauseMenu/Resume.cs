using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public void ResumeGame()
    {
        GamePause.Instance.SetPause(false);
        pauseMenu.SetActive(false);
        
    }
    
}
