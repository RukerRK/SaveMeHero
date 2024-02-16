using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private GameObject spawnPoint;
    
    private List<GameObject> goblins = new List<GameObject>();

    private int killRemain = 100;
    private int hp = 3;
    private int numberOfGoblin = 0;
    
    
    
    void Start() 
    {
        UpdateKillText();
        UpdateHPText();
    }

    void FixedUpdate() 
    {
        SpawnGoblin();
    }
    
    void Awake()
    {
        // Ensure that only one instance of the GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make the GameManager a persistent object
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SpawnGoblin()
    {
        if (numberOfGoblin <= 9 && killRemain > 0)
        {
             for (int i = 0; i < 1; i++) 
             { 
                 GameObject newGoblin = Instantiate(goblinPrefab, new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y), Quaternion.identity);
                 goblins.Add(newGoblin);
                 numberOfGoblin += 1;
             }
        }
       
    }

    public int UpdateKillRemain(int k)
    {
        killRemain -= k;
        
        return killRemain;
    }

    public int UpdateNumberOfGoblin(int g)
    {
        numberOfGoblin -= g;

        return numberOfGoblin;
    }

    public int UpdateHp(int h)
    {
        hp -= h;
        
        return hp;
    }

    void UpdateKillText()
    {
        killText.text = "Kill Remain :" + killRemain;
    }

    void UpdateHPText()
    {
        hpText.text = "HP :" + hp;
    }
    
    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
