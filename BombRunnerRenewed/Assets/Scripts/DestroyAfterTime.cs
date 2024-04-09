using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the VFX

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
