using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    [HideInInspector] public string objectID;

    private void Awake() {
        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }

    private void Start() {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++) {
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this) {
                if (Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID) {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
//void LoadNextScene()

//Determin sceen index
 //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
 //int targetsceneindex= currentSceneIndex+1;
//check if next sceen index is out of bounds
//if (targetsceneindex >=SceneManager.sceneCountInBuildSettings)
//{
//targetsceneindex=0;
//}
//SceneManager.LoadScene(targetsceneindex);

