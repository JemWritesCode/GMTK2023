using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheMainScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("2-MainLevel", LoadSceneMode.Single);
    }
}
