using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class VRInteractiveHandler : MonoBehaviour {

    [SerializeField] private Renderer renderer;
    [SerializeField] private VRInteractiveItem interactive;
    [SerializeField] private int score;
    [SerializeField] private GameController gameController;

    // Use this for initialization
    void Start () {
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
        addScore();
    }

    private void addScore()
    {
        gameController.addScore(score);
    }
}
