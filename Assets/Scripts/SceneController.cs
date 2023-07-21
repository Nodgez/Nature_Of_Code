using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ResetScene()
    {
        var loadedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(loadedSceneIndex);
    }
}
