using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gamemaster : MonoBehaviour
{
    private int lifepoints=3;
    public int score = 0;    
    private GameObject scoretrack;
    


   
    private void Awake()
    {
        scoretrack = GameObject.FindGameObjectWithTag("Score");
        scoretrack.GetComponentInChildren<TMP_Text>().text = $"Score: {score}\nLifepoints: {lifepoints}" ;

    }
   
    public void scoreincrease()
    {
        score++;
        scoretrack.GetComponentInChildren<TMP_Text>().text = $"Score: {score}\nLifepoints: {lifepoints}" ;
    }

    public void gothit()
        {
            lifepoints--;
            scoretrack.GetComponentInChildren<TMP_Text>().text = $"Score: {score}\nLifepoints: {lifepoints}" ;
            if(lifepoints==0)
            {
                SceneManager.LoadScene(0);
            }
        }      
}
