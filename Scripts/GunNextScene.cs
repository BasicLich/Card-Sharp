using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunNextScene : MonoBehaviour
{
    public string sceneToLoad;
    void OnTriggerEnter2D() {
        SceneManager.LoadScene(sceneToLoad);
    }
}
