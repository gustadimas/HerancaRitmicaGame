using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayableDirector))]
public class SceneLoader : MonoBehaviour
{
    PlayableDirector playableDirector;

    [SerializeField]
    PlayableAsset fadeOutTimeline;

    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return FadeSceneOutCoroutine();

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeSceneOutCoroutine()
    {
        playableDirector.Play(fadeOutTimeline);

        yield return new WaitForSeconds((float)playableDirector.duration);
    }
}
