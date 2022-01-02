using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnMeteor : MonoBehaviour
{
    [SerializeField] GameObject meteorPrefab;
    public float waitSeconds;
    private int level;
    private bool flag;

    private void Start()
    {
        StartCoroutine(Spawn1());
        waitSeconds = 1f;
        flag = true;
        level = 1;
    }

    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        int currentScore = player.GetComponent<Movement>().score;
        if ((currentScore != 0) && (currentScore % 10 == 0) && (waitSeconds > 0.3))
        {
            if (flag)
            {
                level++;
                waitSeconds -= 0.1f;
                flag = false;
                GameObject.FindWithTag("LevelText").GetComponent<TextMeshPro>().text = $"level: {level}";
            }
        }
        if((currentScore != 1) && (currentScore % 10 == 1))
        {
            flag = true;
        }
    }

    IEnumerator Spawn1()
    {
        yield return new WaitForSeconds(waitSeconds);
        Instantiate(meteorPrefab, new Vector3(Random.Range(3, -3), 3.55f, -2.33f), Quaternion.identity);
        StartCoroutine(Spawn2());
    }

    IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(waitSeconds);
        Instantiate(meteorPrefab, new Vector3(Random.Range(3, -3), 3.55f, -2.33f), Quaternion.identity);
        StartCoroutine(Spawn1());
    }


}
