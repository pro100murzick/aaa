using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{

    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rigidbody;
    private bool isPinned = false;

    void FixedUpdate()
    {
        if (isPinned == false)
        {
            rigidbody.MovePosition(rigidbody.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionObj)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (collisionObj.tag == "Pin")
        {
            FindObjectOfType<Manager>().GameOver();
            Debug.Log("Game OVER!!!");
        }
        else if (collisionObj.tag == "Rotator")
        {
            isPinned = true;
            transform.SetParent(collisionObj.transform);
            FindObjectOfType<ScoreText>().ChangeNumberOfPins();
            Manager manager = FindObjectOfType<Manager>();
            manager.AddPin();
            if (manager.GetTotalNumberOfPins() == manager.GetCurrentNumberOfPins())
            {
                manager.LevelComplete(sceneIndex);
            }
        }
    }
}
