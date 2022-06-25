using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
     
    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<PlayerMovement>().getIntoSlime();
    }
    private void OnTriggerExit2D(Collider2D other) {
        FindObjectOfType<PlayerMovement>().getOutOfSlime();
    }
}
