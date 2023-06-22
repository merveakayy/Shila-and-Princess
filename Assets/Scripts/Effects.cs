using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public ParticleSystem diamonds;
    public ParticleSystem damage;

    public void DiamondsEffect(Vector3 position)
    {
        diamonds.transform.position = position;
        diamonds.Play();
    }
    public void DamageEffect(Vector3 position)
    {
        damage.transform.position = position;
        damage.Play();
    }
}
