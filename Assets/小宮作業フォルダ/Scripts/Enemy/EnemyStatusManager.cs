using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusManager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;
    public GameObject HPCanvas;
    public Image HPGage;

    public GameObject Effect;
    public AudioSource audioSorce;
    public AudioClip HitSE;

    public string DamageDetermination;

    public Animator Animator;

    private void Update()
    {
        if(HP <= 0)
        {
            HP = 0;
            var effect = Instantiate(Effect);
            effect.transform.position = transform.position;
            Destroy(effect, 5);
            Destroy(Main);
            Destroy(HPCanvas);
        }

        float percent = (float)HP / MaxHP;
        HPGage.fillAmount = percent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == DamageDetermination)
        {
            Damage();
        }
    }

    void Damage()
    {
        Animator.SetTrigger("Hit");
        audioSorce.PlayOneShot(HitSE);
        HP--;
    }
}
