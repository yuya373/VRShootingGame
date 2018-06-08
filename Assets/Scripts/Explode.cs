using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public event System.Action DestroyHook;

    // Use this for initialization
    void Start () {
        var pss = GetComponentsInChildren<ParticleSystem>();
        var durations = new float [pss.Length];
        for (int i = 0; i < pss.Length; i++)
        {
            pss[i].Clear();
            pss[i].Play();
            durations[i] = pss[i].main.duration;
        }
        Destroy(gameObject, Mathf.Max(durations));
    }

    void OnDestroy() {
        if (DestroyHook != null)
        {
            DestroyHook();
        }
    }
}
