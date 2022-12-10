using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void Quit() => Application.Quit();

    private void OnApplicationQuit()
    {
        Debug.Log("�� �����");
    }

    public void LoadCurrentScene(string sceneName) => SceneManager.LoadScene(sceneName);
}