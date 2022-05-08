using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    private Scene actualScene;

    private void Start() {
        this.actualScene = SceneManager.GetActiveScene();
    }

    public void previousScene() {
        SceneManager.LoadScene(this.actualScene.buildIndex-1, LoadSceneMode.Single);
    }

    public void loadSceneByIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void nextScene() {
        SceneManager.LoadScene(this.actualScene.buildIndex+1, LoadSceneMode.Single);
    }
}
