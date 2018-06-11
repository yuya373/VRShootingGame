using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    [SerializeField] private Transform anchor;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform target;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        // DrawTo(target.position);
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }

    public void DrawTo(Vector3 pos)
    {
        lineRenderer.SetPosition(0, anchor.position);
        lineRenderer.SetPosition(1, pos);
        lineRenderer.enabled = true;
    }
}

