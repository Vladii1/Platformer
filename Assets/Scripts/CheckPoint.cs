using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    public int count;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && GameController.instance.currentCheckPoint.GetComponent<CheckPoint>().count < count)
        {
            GameController.instance.currentCheckPoint = gameObject;
        }
    }
}
