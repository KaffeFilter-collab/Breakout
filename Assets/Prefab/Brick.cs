using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Brick : MonoBehaviour
{
    private static int activeBricks=0;
    public TextMeshProUGUI leveltxt;
    public int level = 1;
    private void Awake(){

    activeBricks++;
}


  private void  OnCollisionEnter2D(Collision2D collision) 
  {
   activeBricks--;
    Destroy(gameObject);



    if(activeBricks==0){
            level++;
            leveltxt.text = level.ToString();
  LoadNextScene();
    }
  }

  //TODO move somwhere else maby
void LoadNextScene()
{
//Determin sceen index
 int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
 int targetsceneindex= currentSceneIndex+1;
//check if next sceen index is out of bounds
if (targetsceneindex >=SceneManager.sceneCountInBuildSettings)
{
targetsceneindex=0;
}
SceneManager.LoadScene(targetsceneindex);
}

}
