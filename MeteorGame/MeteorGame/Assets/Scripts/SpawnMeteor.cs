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
        StartCoroutine(Spawn1());
    }

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject.FindWithTag("LevelText").GetComponent<TextMeshPro>().text = $"level: {level}";
        int currentScore = player.GetComponent<Movement>().score;
        if ((currentScore != 0) && (currentScore % 10 == 0) && (waitSeconds > 0.3))
        {
            if (flag)
            {
                level++;
                waitSeconds -= 0.1f;
                flag = false;
            }
        }
        if((currentScore != 1) && (currentScore % 10 == 1))
        {
            flag = true;
        }
    }

    IEnumerator Spawn1()
    {

        if (GameObject.FindWithTag("Player").GetComponent<Movement>().isAlive)
        {
            yield return new WaitForSeconds(waitSeconds);
            Instantiate(meteorPrefab, new Vector3(Random.Range(3, -3), 3.55f, -2.33f), Quaternion.identity);
            StartCoroutine(Spawn2());
        }
    }

    IEnumerator Spawn2()
    {
        if (GameObject.FindWithTag("Player").GetComponent<Movement>().isAlive)
        {
            yield return new WaitForSeconds(waitSeconds);
            Instantiate(meteorPrefab, new Vector3(Random.Range(3.5f, -3.5f), 3.55f, -2.33f), Quaternion.identity);
            StartCoroutine(Spawn1());
        }
    }


}
