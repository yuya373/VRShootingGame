using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private int score = 0;
    private int enemyCount = 0;
    [SerializeField] private UnityEngine.UI.Text scoreLabel;
    [SerializeField] private float enemyAppearInterval;
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private GameObject enemy;

    // Use this for initialization
    void Start() {
        StartCoroutine(Timer(enemyAppearInterval));
    }

    // Update is called once per frame
    void Update() {
        scoreLabel.text = score.ToString();
        // scoreLabel.text = enemyCount.ToString();
    }

    public void EnemyKilled(int s)
    {
        enemyCount -= 1;
        score += s;
    }

    private void CreateEnemy()
    {
        enemyCount += 1;
        // Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f),
        //                                0,
        //                                Random.Range(-10.0f, 10.0f));
        var z = Random.Range(5f, 25f);
        var x = Random.Range(-5f, 5f);
        var y = Random.Range(-5f, 5f);
        Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);
    }

    IEnumerator Timer(float second)
    {
        while(true)
        {
            if (enemyCount < maxEnemyCount)
            {
                CreateEnemy();
            }
            yield return new WaitForSeconds(second);
        }
    }
}
