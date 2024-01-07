using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickManager : MonoBehaviour
{
    public int rows = 3;
    public int columns = 4;

    public float horizontalSpacing = 0.5f;
    public float verticalSpacing   = 0.25f;

    public Brick brickPrefab;

    private int destroyedBricks = 0;

    private void Start()
    {
        
            // instantiate bricks
    for (int y = 0; y < rows; y++)
            {
        for (int x = 0; x < columns; x++)
                {
                    Brick newBrick = Instantiate(
                        brickPrefab,
                        transform.position + GetBrickLocalPosition(x, y),
                        Quaternion.identity);

                   
                   
                    newBrick.transform.SetParent(transform);
                   
                }
            }
        }
    

    

    private Vector3 GetBrickLocalPosition(int x, int y)
    {
        return new Vector3(
                        (brickPrefab.transform.localScale.x + horizontalSpacing) * x,-(brickPrefab.transform.localScale.y + verticalSpacing) * y,0);
    }

    public void OnBeforeBrickDestroy(Brick brick)
    {
        destroyedBricks++;
       

        if (destroyedBricks >= rows * columns)
        {
        
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        buildIndex++;
        if (buildIndex >= SceneManager.sceneCountInBuildSettings)
        {
            buildIndex = 0;
        }

        SceneManager.LoadScene(buildIndex);
    }
}