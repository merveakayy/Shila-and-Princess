using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sounds : MonoBehaviour
{
   public static Sounds instance;
   public AudioSource[] source;
     [SerializeField] AudioClip hit;
     [SerializeField] AudioClip jump;
     [SerializeField] AudioClip glass;
     [SerializeField] AudioClip door;
     [SerializeField] AudioClip hit2;


     public void jumpSound(Vector3 position)
     {
        Sources().clip = jump;
        transform.position = position;
        Sources().Play();
     }
     public void hitSound(Vector3 position)
     {
        Sources().clip = hit;
        transform.position = position;
        Sources().Play();
     }
     public void damageSound(Vector3 position)
     {
        Sources().clip = hit2;
        transform.position = position;
        Sources().Play();
     }

     private AudioSource Sources()
     {
        for(int i = 0;i<source.Length;i++)
        {
            if(source[i].isPlaying)
            {
                continue;
            }
            return source[i];
        }
        return source[0];
     }

void Awake()
{
    instance = this;
}

}
