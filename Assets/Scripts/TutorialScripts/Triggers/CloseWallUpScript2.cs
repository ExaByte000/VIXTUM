using UnityEngine;

public class CloseWallUpScript2 : MonoBehaviour
{
    [SerializeField] private GameObject closeWallUp;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            closeWallUp.SetActive(false);
        }
            
    }
}
