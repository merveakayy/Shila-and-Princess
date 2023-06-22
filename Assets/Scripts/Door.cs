using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door1;
    public Transform door2;

    public Sounds sounds;

    private void Finish()
    {
        FindAnyObjectByType<GameOver>().EndGame();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<Score>().GetScore()>20)
            {
                Quaternion rotation = door1.rotation;
                rotation.y = -80;
                door1.rotation = rotation;
                rotation = door2.rotation;
                rotation.y = -90;
                door2.rotation = rotation;
                Invoke(nameof(Finish), 5f);
                
                
            }
        }
    }
}
