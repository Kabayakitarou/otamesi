using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    public GameObject Main;
    public int HP;
    public int MaxHP;
    public Text TextHP;
    public GameObject HPCanvas;
    public Image HPGage;

    public GameObject Effect;
    public AudioSource audioSorce;
    public AudioClip HitSE;

    public string DamageDetermination;

    public Animator Animator;
    public Enemy1Controller enemy1Controller;

    void Start(){
    }

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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        MaxHP = StepCountButton.PlayerLevel*100;
        HP = MaxHP;
        float percent = (float)HP / MaxHP;
        HPGage.fillAmount = percent;
        TextHP.text = HP.ToString();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == DamageDetermination & enemy1Controller.attacked == 1)
        {
            Debug.Log("Damage");
            Damage();
        }
    }

    void Damage()
    {
        enemy1Controller = GameObject.Find("Enemy1").GetComponent<Enemy1Controller>();
        Animator.SetTrigger("Hit");
        audioSorce.PlayOneShot(HitSE);
        HP -= enemy1Controller.AttackDamage;
    }
}
