using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button difficultyButton;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        difficultyButton = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyButton.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
        {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame();
        }
}
