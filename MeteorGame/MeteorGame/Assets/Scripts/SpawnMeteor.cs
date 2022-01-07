using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] GameObject meteorPrefab;
    public float waitSeconds;
    public int level;
    public bool flag;

    private void Start()
    {
        startCoroutineFunc();
        waitSeconds = 1f;
        flag = true;
        level = 1;
    }

    public void startCoroutineFunc()
    {
        // Assigned the starting sequence to public function
        // So play again button can trigger this function to start the spawn sequence again
        StartCoroutine(Spawn1());
    }

    private void Update()
    {
        // Updating level text
        GameObject.FindWithTag("LevelText").GetComponent<TextMeshPro>().text = $"level: {level}";

        // Finding player object by its tag to get "score" variable
        GameObject player = GameObject.FindWithTag("Player");
        int currentScore = player.GetComponent<Movement>().score;

        // Increasing the level when score hits multiples of 10
        // By incresing the level spawning time is getting shorter
        // It means more balls are spawning at the same time but balls are falling the same speed
        if ((currentScore != 0) && (currentScore % 10 == 0) && (waitSeconds > 0.3))
        {
            if (flag)
            {
                level++;
                waitSeconds -= 0.1f;
                flag = false;
            }
        }
        // Because of this control is on update I'm using flags to prevent bugs
        // So I'm turning flag true again when score is 1 more than multiples of 10
        if ((currentScore != 1) && (currentScore % 10 == 1))
        {
            flag = true;
        }
    }

    // Created two spawn function and made them call eachother continuously
    IEnumerator Spawn1()
    {
        // Player is alive check
        if (GameObject.FindWithTag("Player").GetComponent<Movement>().isAlive)
        {
            yield return new WaitForSeconds(waitSeconds);
            Instantiate(meteorPrefab, new Vector3(Random.Range(3, -3), 3.55f, -2.33f), Quaternion.identity);
            StartCoroutine(Spawn2());
        }
    }

    IEnumerator Spawn2()
    {
        // Player is alive check
        if (GameObject.FindWithTag("Player").GetComponent<Movement>().isAlive)
        {
            yield return new WaitForSeconds(waitSeconds);
            Instantiate(meteorPrefab, new Vector3(Random.Range(3.5f, -3.5f), 3.55f, -2.33f), Quaternion.identity);
            StartCoroutine(Spawn1());
        }
    }


}
