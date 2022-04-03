using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectieExplosion : MonoBehaviour
{
    public float delay = 0.5f;
    void Start() {
        Destroy(gameObject, delay);
    }
}
