using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const float spawnRate = 1.0f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private int playerScore = 0;
    public bool gameActive = true;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameActive = false;
    }

    IEnumerator SpawnTarget()
    {
        while(gameActive == true)
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
