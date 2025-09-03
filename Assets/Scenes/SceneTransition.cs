using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    private void OnEnable()
    {
        GamePause.OnPauseChanged += AnimatorEnabled;
    }

    private void OnDisable()
    {
        GamePause.OnPauseChanged += AnimatorEnabled;
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void AnimatorEnabled(bool isEnable)
    {
        GetComponent<Animator>().enabled = isEnable;
    }
}
