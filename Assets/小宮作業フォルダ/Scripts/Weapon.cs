using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Effect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            var effect = Instantiate(Effect);
            effect.transform.position = other.transform.position;
            Destroy(other.gameObject);
            Destroy(effect, 5);
        }
    }
}
