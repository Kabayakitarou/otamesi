using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    public GameObject Main;
    public static int HP = 100;
    public static int MaxHP = 100;
    public Text TextHP;
    public GameObject HPCanvas;
    public Image HPGage;

    public GameObject Effect;
    public AudioSource audioSorce;
    public AudioClip HitSE;

    public string DamageDetermination;

    public Animator Animator;
    public Enemy1Controller enemy1Controller;

    private bool PlayerDamage = true;
    public static int Damagenum = 0;

    public static PlayerStatusManager instance;

    void Start(){
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
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
        float percent = (float)HP / MaxHP;
        HPGage.fillAmount = percent;
        TextHP.text = HP.ToString();
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == DamageDetermination){
            PlayerDamage = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == DamageDetermination){
            bool PlayerDamage = false;
        }
    }

    public void EnemyAttack(){
        if(PlayerDamage == true){
            Debug.Log("Damage");
            Damage();
        }
    }

    void Damage()
    {
        Animator.SetTrigger("Hit");
        audioSorce.PlayOneShot(HitSE);
        HP -= Damagenum;
    }

}
