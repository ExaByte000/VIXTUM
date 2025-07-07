using UnityEngine;

public class CloseWallUpScript : MonoBehaviour
{
    [SerializeField] private GameObject closeWallUp;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            closeWallUp.SetActive(true);
        }
        
    }
}
