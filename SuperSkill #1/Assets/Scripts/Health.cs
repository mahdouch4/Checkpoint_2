using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour

{
    public float health = 100f;
    public GameObject Healthadd;
    public float damage = 25f;
    public float Addedhealth =15f;
    private Animator animator;
    public bool dead = false;
    public Slider healthSlider;
    void Start()
    {
        animator = GetComponent<Animator>();     
    }
    void Update()
    {
        if(health <= 0){
            health = 0;
            Die();
        }
        Debug.Log(health);
        healthSlider.value = health / 100;
    }
    void TakeDamage(){
        health -= damage;
    }
    void Regenerate(){
        health += Addedhealth;
        if(health > 100f){
            health = 100f;
        }
    }
    void Die(){
       animator.SetBool("isDead",true);
       StartCoroutine(Wait());
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles"){
            TakeDamage();
        }
         if (collision.gameObject.tag == "Regeneration"){
            Regenerate();
            Destroy(collision.gameObject);      
        }
    }
    IEnumerator Wait()
{	
    yield return new WaitForSeconds(2);
    Destroy(gameObject);
}
}
