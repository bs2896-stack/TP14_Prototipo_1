using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Configuración")]
    public int scoreMax = 5;
    public float timerMax = 30f;

    [Header("Estado")]
    private int currentScore = 0;
    private float currentTime;
    private bool gameOver = false;

    private UIManager uiManager;

    void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        currentTime = timerMax;
        uiManager = FindObjectOfType<UIManager>();

        uiManager.UpdateScore(currentScore);
        uiManager.UpdateTimer(currentTime);
    }

    void Update()
    {
        if (gameOver) return;

        
        currentTime -= Time.deltaTime;
        uiManager.UpdateTimer(currentTime);

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            TriggerLoss();
        }
    }

    
    public void ObjectCollected()
    {
        if (gameOver) return;

        currentScore++;
        uiManager.UpdateScore(currentScore);

        if (currentScore >= scoreMax)
            TriggerWin();
    }

    private void TriggerWin()
    {
        gameOver = true;
        Debug.Log("WIN: llegaste al puntaje máximo!");
    }

    private void TriggerLoss()
    {
        gameOver = true;
        Debug.Log("LOSS: se acabó el tiempo!");
    }
}