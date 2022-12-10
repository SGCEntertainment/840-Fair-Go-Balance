using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private float totalTime;

    [SerializeField] GameObject game;
    [SerializeField] Text timerText;

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
            Instantiate(Resources.Load<Popup>("popup"), GameObject.Find("screen").transform).SetData(timerText.text, () =>
            {
                GameManager.Instance.RestartGame();
            });
        };
    }

    private void Update()
    {
        timerText.text = $"{GameManager.Instance.Score}";
    }
}