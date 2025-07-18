using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoSceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Видеоплеер
    public string nextSceneName = "MainScene"; // Название следующей сцены

    void Start()
    {
        // Подписываемся на событие завершения видео
        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play(); // Запускаем видео сразу
    }

    // Вызывается, когда видео закончилось
    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName); // Переключаем сцену
    }
}