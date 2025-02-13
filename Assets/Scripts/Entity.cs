using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float health;

    public abstract void TakeDamage(float damage);
    protected abstract void Die();


    //{
    //    if (this is Hero || name == "House")
    //    {
    //        SceneManager.LoadScene("SampleScene");
    //        TestBackgroundMusic.StopFront();
    //    }
    //    Destroy(gameObject);
    //}
    //{
    //    Health--;
    //    if (Health <= 0) Die();
    //}
}
