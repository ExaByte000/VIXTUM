using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class Hero : Entity
{
    public static Action<int> Dead;
    [SerializeField] private int SceneNumber = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    [SerializeField] private float armorMultiplire;
    public override void TakeDamage(float damage)
    {
        health -= damage*armorMultiplire;
        Debug.Log($"{name} θμεες {health} υο");
        if (health <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        Dead.Invoke(SceneNumber);
    }
}
