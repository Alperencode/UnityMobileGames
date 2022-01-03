using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float maxArea;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject playAgainButton;
    public bool isAlive;
    [HideInInspector] public int score;
    float horizontal;
    private bool flag = true;
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxArea, maxArea), transform.position.y, transform.position.z);
        // horizontal = Input.GetAxis("Horizontal");

        if (isAlive)
        {

            // keyboard movement
            // transform.Translate(new Vector3(horizontal * horizontalSpeed * Time.deltaTime, 0, 0));

            // Mobile Movement
            flag = true;
            int i = 0;
            while (i < Input.touchCount)
            {

                if (Input.GetTouch(i).position.x > Screen.width / 2)
                {
                    // right
                    transform.Translate(new Vector3(horizontalSpeed * Time.deltaTime * 0.5f, 0, 0));

                }
                else if (Input.GetTouch(i).position.x < Screen.width / 2)
                {
                    // left
                    transform.Translate(new Vector3(-horizontalSpeed * Time.deltaTime * 0.5f, 0, 0));
                }
                i++;
            }
        }
        else
        {
            if (flag)
            {
                Instantiate(gameOverText);
                Instantiate(playAgainButton);
                flag = false;
            }
        }
        
    }

    public void PlayAgain()
    {
        Debug.Log("PlayAgain() called");
        GameObject[] GameOverUIs = GameObject.FindGameObjectsWithTag("GameOverUIs");
        foreach (GameObject objects in GameOverUIs) Destroy(objects);
        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject meteor in meteors) Destroy(meteor);

        GameObject.FindWithTag("Player").GetComponent<Movement>().isAlive = true;
        GameObject.FindWithTag("Player").GetComponent<Movement>().score = 0;
        GameObject.FindWithTag("ScoreText").GetComponent<TextMeshPro>().text = $"score: 0";
        Camera.main.GetComponent<SpawnMeteor>().level = 1;
        Camera.main.GetComponent<SpawnMeteor>().waitSeconds = 1f;
        Camera.main.GetComponent<SpawnMeteor>().flag = true;
        Camera.main.GetComponent<SpawnMeteor>().startCoroutineFunc();
    }
}
