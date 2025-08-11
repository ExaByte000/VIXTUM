using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float health;

    public float Health { get { return health; } set { health = value; } }

    public abstract void TakeDamage(float damage);
    protected abstract void Die();

}
