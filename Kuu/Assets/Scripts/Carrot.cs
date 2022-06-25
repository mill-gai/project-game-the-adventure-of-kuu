using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    private int carrotPoint;
    private bool isCollect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isCollect)
        {
            isCollect = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().UpdateCarrotNum();
        }
    }
}
