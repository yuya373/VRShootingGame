using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private int score;
    [SerializeField] private UnityEngine.UI.Text scoreLabel;

    // Use this for initialization
    void Start () {
        score = 0;
    }

    // Update is called once per frame
    void Update () {
        scoreLabel.text = score.ToString();
    }

    public void addScore(int addition)
    {
        score += addition;
    }
}
