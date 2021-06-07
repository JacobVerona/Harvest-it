using UnityEngine;
using TMPro;
using System.Collections;

public class LevelHUD : MonoBehaviour
{
    private const string LevelCompleteAnimation = "LevelCompleteAnimation";

    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Animator _levelCompleteAnimator;

    private Level _level;

    private void Awake ()
    {
        _level = ApplicationContext.Instance.CurrentLevel;
     
        _levelText.text = string.Concat("Level: ", _level.Id + 1);
    }

    private void OnEnable ()
    {
        _level.LevelComplete += OnLevelComplete;
    }

    private void OnDisable ()
    {
        _level.LevelComplete -= OnLevelComplete;
    }

    private void OnLevelComplete (Level level, System.Action OnAnimationEnded)
    {
        _levelText.gameObject.SetActive(false);
        _levelCompleteAnimator.gameObject.SetActive(true);
        _levelCompleteAnimator.Play(LevelCompleteAnimation, 0);

        IEnumerator coroutine = LoadNextLevel(OnAnimationEnded);

        StartCoroutine(coroutine);
    }
    
    private IEnumerator LoadNextLevel (System.Action OnAnimationEnded)
    {
        var wait = new WaitForSeconds(2f);
        yield return wait;

        OnAnimationEnded?.Invoke();
    }
}