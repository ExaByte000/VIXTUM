using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : Entity
{
    [SerializeField] private float armorMultiplire;
    public override void TakeDamage(float damage)
    {
        health -= damage*armorMultiplire;
        if (health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
