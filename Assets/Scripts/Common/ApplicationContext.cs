using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-10000)]
public class ApplicationContext : MonoBehaviour, ILevelContext
{
    private static ApplicationContext _instance;
    public static ApplicationContext Instance { 
        get {

            if (_instance == null)
            {
                _instance = new GameObject("ApplicationContext").AddComponent<ApplicationContext>();
                DontDestroyOnLoad(Instance);

                _instance.Constructor();
            }

            return _instance;
        }
    }

    private List<Level> _levels = new List<Level>();
    private int _currentLevelId = 0;
    
    public Level CurrentLevel { get => _levels[_currentLevelId]; }

    private void OnApplicationPause (bool paused)
    {
        Time.timeScale = paused ? 0 : 1;
    }

    private void Constructor ()
    {
        // p - player spawn
        // w - wall
        // g - ground field

        foreach (var level in Levels.GetAll)
        {
            AddLevel(level);
        }
    }

    private void AddLevel (Level level)
    {
        level.Id = _levels.Count;
        level.Context = this;
        _levels.Add(level);
    }

    public void LoadLevel (int levelIndex)
    {
        if (levelIndex > _levels.Count - 1)
        {
            levelIndex = 0;
        }

        _currentLevelId = levelIndex;
        DOTween.Clear();
        SceneManager.LoadScene(MainMenu.GameplayScene);
    }
}
