using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    #region Editor

    [SerializeField]
    private Animator _transition;

    [SerializeField]
    private CubeFallingApart _fallingApart;

    [SerializeField]
    private float _transitionTime;

    #endregion

    #region Methods

    private void Start()
    {
        if (_fallingApart != null)
        {
            _fallingApart.IsFalling += OnIsFalling;
        }
        else
        {
            return;
        }
    }

    private void OnIsFalling()
    {
        Invoke(nameof(TransitionToNextLevel), 1f);
    }

    private void TransitionToNextLevel()
    {
        StartCoroutine(TransitionToNextLevelInternal(_transitionTime));
    }

    private IEnumerator TransitionToNextLevelInternal(float delay)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(delay);

        var sceneHandler = new SceneHandler();
        sceneHandler.NextLevel();
    }

    #endregion
}
