using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    int levelNumber;

    public bool isGameOver = false;

    public static GameManager Instance;

    [SerializeField] private Text scoreText;

    private void Awake()
    {

        if (Instance == null)
        {

            Instance = this;

        }

    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score : " + Finish.score;


        if (isGameOver)
        {

            scoreText.gameObject.SetActive(true);


        }

    }
}
