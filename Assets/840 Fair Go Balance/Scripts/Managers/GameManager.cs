using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private bool GameStarted { get; set; }

    private float totalTime;
    public (int, int) Score { get; set; }

    private GameObject rootRef;

    private GameObject Root { get; set; }
    private Transform EnvironmentRef { get; set; }

    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action<(int, int)> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Root = Resources.Load<GameObject>("root");
        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Update()
    {
        if(!GameStarted)
        {
            return;
        }

        totalTime += Time.deltaTime;
        Score = (Mathf.FloorToInt(totalTime / 60), Mathf.FloorToInt(totalTime % 60));
    }

    public void RestartGame()
    {
        totalTime = 0;
        Score = (0,0);

        rootRef = Instantiate(Root, EnvironmentRef);
        GameStarted = true;
    }

    public void GameOver()
    {
        if(rootRef)
        {
            Destroy(rootRef);
        }

        OnGameFinsihed?.Invoke(Score);
        GameStarted = false;
    }
}