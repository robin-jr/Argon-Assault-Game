using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVfx;

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(deathVfx, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
    }
}