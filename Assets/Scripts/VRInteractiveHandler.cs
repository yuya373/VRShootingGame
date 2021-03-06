﻿using UnityEngine;
using VRStandardAssets.Utils;

public class VRInteractiveHandler : MonoBehaviour {

    [SerializeField] private Renderer renderer;
    [SerializeField] private VRInteractiveItem interactive;
    [SerializeField] private int score;
    [SerializeField] private Explode explosion;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        var gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponentInChildren<GameController>();
        var distance = transform.position.z / (5f * 2f);
        transform.localScale *= distance;
        score *= Mathf.CeilToInt(distance);
    }

    // Update is called once per frame
    void Update () {
    }

    private void OnEnable()
    {
        interactive.OnOver += HandleOver;
        interactive.OnOut += HandleOut;
        interactive.OnClick += HandleClick;
    }

    private void OnDisable()
    {
        interactive.OnOver -= HandleOver;
        interactive.OnOut -= HandleOut;
        interactive.OnClick -= HandleClick;
    }

    private void HandleOver()
    {
        renderer.material.color = Color.red;
    }

    private void HandleOut()
    {
        renderer.material.color = Color.white;
    }

    private void HandleClick()
    {
        // NOTE: destroy explosion immidiately and particle does not start.
        // Destroy(gameObject);
        renderer.enabled = false;
        NotifyKilled();
        Explode e = Instantiate(explosion, transform.position, Quaternion.identity);
        e.DestroyHook += KillSelf;
    }

    private void KillSelf()
    {
        Destroy(gameObject);
    }

    private void NotifyKilled()
    {
        gameController.EnemyKilled(score);
    }
}
