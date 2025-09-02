using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        if (GamePause.Instance.IsPaused)
        {
            GetComponent<Animator>().enabled = false;
        }
        else
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
