using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LoadLevel(string levelName) => SceneManager.LoadScene(levelName);
    public void Play() => LoadLevel("MainGame1");
    public void Quit() => Application.Quit();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoadLevel("Menu");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
