using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChangeScene : MonoBehaviour
{
    public int targetSceneIndex; // Индекс сцены в Build Settings

    private void OnMouseDown() // Срабатывает при клике ЛКМ
    {
        SceneManager.LoadScene(targetSceneIndex);
    }
}