using UnityEngine;

public class FadeOutDisable : MonoBehaviour
{

    public virtual void DisableGameObject()
    {
         transform.parent.gameObject.SetActive(false);
    }
}
