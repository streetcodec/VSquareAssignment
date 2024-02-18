using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public GameLogic gameLogic;
    public static PersistentManager Instance { get; private set;}
    public int score;
    private void Awake()
    {
        if(Instance == null)
        {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    void Update()
    {
        if(score > 0 && gameLogic.score == 0)
        {

        }
        else score = gameLogic.score;
        
    }
    
}
