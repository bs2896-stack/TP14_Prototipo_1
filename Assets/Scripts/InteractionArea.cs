using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public int score = 0;
    public UIManager uiManagerScript;

    void Awake (){
        uiManagerScript = GameObject.FindObjectOfType<UIManager>();
    }


    void OnTriggerEnter(Collider other)
    { if(other.gameObject.CompareTag("Collectible")){
        Destroy(other.gameObject);
        score ++;
        uiManagerScript.UpdateScore(score);
    }
       
    }
}
