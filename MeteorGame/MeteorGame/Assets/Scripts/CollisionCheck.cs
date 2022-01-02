using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionCheck : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ground"))
        {
            // Find player and if its alive increase the score
            GameObject player = GameObject.FindWithTag("Player");
            if (player.GetComponent<Movement>().isAlive)
            {
                player.GetComponent<Movement>().score++;
                GameObject.FindWithTag("ScoreText").GetComponent<TextMeshPro>().text = $"score: {player.GetComponent<Movement>().score}";
            }

            // Destroy this gameobject
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            // Stop the meteor and change the isAlive bool
            Destroy(this.GetComponent<MeteorMove>());
            other.GetComponent<Movement>().isAlive = false;
        }

    }

}
