using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private bool GameStarted { get; set; }
    private float GameSpeed { get; set; } = 0.5f;
    public float Score { get; set; }


    private Player Player { get; set; }
    private GameObject Tree { get; set; }
    private Transform EnvironmentRef { get; set; }

    public static Action OnHandlePulled { get; set; } = delegate { };
    public static Action<float> OnGameFinsihed { get; set; } = delegate { };

    private void Awake()
    {
        Player = Resources.Load<Player>("player");
        Tree = Resources.Load<GameObject>("tree");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Update()
    {
        if(!GameStarted)
        {
            return;
        }

        Score += GameSpeed * Time.deltaTime;
    }

    public void RestartGame()
    {
        Score = 0;

        Instantiate(Player, EnvironmentRef);
        Instantiate(Tree, EnvironmentRef);

        GameStarted = true;
    }

    public void GameOver()
    {
        OnGameFinsihed?.Invoke(Score);
        GameStarted = false;
    }
}