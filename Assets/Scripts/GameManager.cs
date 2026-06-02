using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Configuración")]
    public int scoreMax = 5;
    public float timerMax = 30f;

    [Header("Estado")]
    private float currentTime;
    private bool gameOver = false;

    private UIManager uiManager;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 1; // por si viene de un reinicio
    }

    void Start()
    {
        currentTime = timerMax;
        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateTimer(currentTime);
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }

        currentTime -= Time.deltaTime;
        uiManager.UpdateTimer(currentTime);

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            uiManager.UpdateTimer(currentTime);
            gameOver = true;
            uiManager.MostrarPantallaGameOver();
            Time.timeScale = 0;
        }
    }

    public void TriggerWin()
    {
        gameOver = true;
        uiManager.MostrarPantallaWin();
        Time.timeScale = 0;
    }
}