using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public int scoreMax = 5;
    private int currentScore = 0;
    private UIManager uiManager;

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            currentScore++;
            uiManager.UpdateScore(currentScore);

            if (currentScore >= scoreMax)
                GameManager.Instance.TriggerWin();
        }
    }
}