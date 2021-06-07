using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public const string MainMenuScene = "MainMenu";
    public const string GameplayScene = "Gameplay";

    [SerializeField] private TMPro.TMP_Text _tapToPlay;

    private float _defaultSize;

    private AsyncOperation _loadSceneOperation;

    private void Awake ()
    {
        _defaultSize = _tapToPlay.fontSize;
    }

    private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(GameplayScene);
        }
        _tapToPlay.fontSize = _defaultSize + Mathf.PingPong(Time.time * 5f, 5f);
    }
}
