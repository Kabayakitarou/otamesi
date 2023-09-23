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

    private bool PlayerDamage = true;
    public static int Damagenum = 0;

    public static PlayerStatusManager instance;

    private void Awake(){
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
        Debug.Log(PlayerStatusManager.instance.HP);
    }

    /*public void LevelUpPSM(){
        MaxHP = StepCountButton.PlayerLevel*100;
        Debug.Log(MaxHP);
        HP = MaxHP;
        //TextHP.text = HP.ToString();
    }*/

    public void OnTriggerStay(Collider other){
        if(other.tag == DamageDetermination){
            PlayerDamage = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == DamageDetermination){
            PlayerDamage = false;
        }
    }

    public void EnemyAttack(){
        if(PlayerDamage == true){
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
