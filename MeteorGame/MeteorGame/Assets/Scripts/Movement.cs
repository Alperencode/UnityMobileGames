using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] float maxArea;
    [SerializeField] GameObject gameOverText;
    [HideInInspector] public bool isAlive;
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
                flag = false;
            }
            Destroy(Camera.main.GetComponent<SpawnMeteor>());
        }
        
    }
}
