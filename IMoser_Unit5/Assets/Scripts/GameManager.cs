using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const float spawnRate = 1.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    private int playerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());

        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
    }

    public void UpdateScore(int ScoreDelta)
    {
        playerScore += ScoreDelta;
        if(playerScore < 0)
        {
            playerScore = 0;
        }
        scoreText.text = "Score: " + playerScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
