using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject game;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        LoadingGO.OnLoadingStarted += () =>
        {
            game.SetActive(false);
        };

        LoadingGO.OnLoadingFinished += () =>
        {
            game.SetActive(true);
            GameManager.Instance.RestartGame();
        };

        GameManager.OnGameFinsihed += (score) =>
        {
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(scoreText.text, () =>
            {
                GameManager.Instance.RestartGame();
            });
        };
    }

    private void Update()
    {
        scoreText.text = "";
    }
}