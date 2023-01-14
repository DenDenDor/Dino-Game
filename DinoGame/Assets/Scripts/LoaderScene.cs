using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScene : MonoBehaviour
{
    public void LoadMenu()
    {
        StartCoroutine(LoadScene("Menu"));
    }
    public void LoadLevel(int level)
    {
        StartCoroutine(LoadScene("Level" + level));
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }
    private IEnumerator LoadScene(string nameOfScene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameOfScene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
