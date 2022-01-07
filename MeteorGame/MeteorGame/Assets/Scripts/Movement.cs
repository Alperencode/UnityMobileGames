using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float maxArea;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject playAgainButton;
    [HideInInspector] public bool isAlive;
    [HideInInspector] public int score;
    private bool flag = true;
    // private float horizontal;
    
    void Update()
    {
        // Limiting the player movement
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxArea, maxArea), transform.position.y, transform.position.z);

        if (isAlive)
        {

            // keyboard movement
            // horizontal = Input.GetAxis("Horizontal");
            // transform.Translate(new Vector3(horizontal * horizontalSpeed * Time.deltaTime, 0, 0));

            // Mobile Movement
            flag = true;
            int i = 0;
            while (i < Input.touchCount)
            {
                //  Splitting screen width in half
                if (Input.GetTouch(i).position.x > Screen.width / 2)
                {
                    // right movement
                    transform.Translate(new Vector3(horizontalSpeed * Time.deltaTime * 0.5f, 0, 0));

                }
                else if (Input.GetTouch(i).position.x < Screen.width / 2)
                {
                    // left movement
                    transform.Translate(new Vector3(-horizontalSpeed * Time.deltaTime * 0.5f, 0, 0));
                }
                i++;
            }
        }
        else
        {
            if (flag)
            {
                // If player is dead
                // Instantiate Game Over UI elements
                Instantiate(gameOverText);
                Instantiate(playAgainButton);
                flag = false;
            }
        }
        
    }

    public void PlayAgain()
    {

        // Debug.Log("PlayAgain() called");

        // Destroying Game ove UI elements
        GameObject[] GameOverUIs = GameObject.FindGameObjectsWithTag("GameOverUIs");
        foreach (GameObject objects in GameOverUIs) Destroy(objects);
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject meteor in meteors) Destroy(meteor);

        // Resetting Player variables
        GameObject.FindWithTag("Player").GetComponent<Movement>().isAlive = true;
        GameObject.FindWithTag("Player").GetComponent<Movement>().score = 0;
        GameObject.FindWithTag("ScoreText").GetComponent<TextMeshPro>().text = "score: 0";

        // Resetting Meteor script
        Camera.main.GetComponent<SpawnMeteor>().level = 1;
        Camera.main.GetComponent<SpawnMeteor>().waitSeconds = 1f;
        Camera.main.GetComponent<SpawnMeteor>().flag = true;
        Camera.main.GetComponent<SpawnMeteor>().startCoroutineFunc();
    }
}
