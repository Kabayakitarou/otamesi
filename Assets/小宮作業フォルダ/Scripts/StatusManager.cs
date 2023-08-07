using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;

    public GameObject Effect;
    public AudioSource audioSorce;
    public AudioClip HitSE;

    public string TagName;

    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);
            effect.transform.position = transform.position;
            Destroy(effect, 5);
            Destroy(Main);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == TagName)
        {
            Damage();
        }
    }

    void Damage()
    {
        audioSorce.PlayOneShot(HitSE);
        HP--;
    }
}
