using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    private AudioSource glass;
    void Start()
    {
        glass = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            glass.Play();
            FindObjectOfType<Effects>().DiamondsEffect(transform.position);
            Score.instance.ScoreUp();
            Destroy(gameObject);
        }
    }
}
