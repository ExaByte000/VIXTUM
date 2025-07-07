using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D doorCollider;
    [SerializeField] private Animator animator;

    private bool isInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;
    }

    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (doorCollider != null)
            {
                doorCollider.enabled = false;
                animator.SetTrigger("IsOpened");
            }
        }
    }
}
