using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI gameOverUI;
    public Button restartButton;
    private int score;
    public bool isGameActive;

    private float spawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        

        }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
        {
        while (isGameActive)
            {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            }
        }

    public void UpdateScore(int scoreToAdd)
        {
        score += scoreToAdd;
        scoreUI.text = "Score: " + score;
        }

    public void GameOver()
        {
        gameOverUI.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        }

    public void RestartGame()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    public void StartGame()
        {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        GameObject.Find("StartScreen").SetActive(false);
        }
}
