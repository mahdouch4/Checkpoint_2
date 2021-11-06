using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Health : MonoBehaviour

{
    public int score;
    public float health = 100f;
    public GameObject Healthadd;
    public GameObject Coin;
    public float damage = 25f;
    public float Addedhealth =15f;
    private Animator animator;
    public Text Text;
    public bool dead = false;
    public Slider healthSlider;
    public string vi;
    public GameObject DeathSound;
    public GameObject Obstacle;
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerPrefs.SetInt("Highscore",score);
    }
    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            Die();
        }
        healthSlider.value = health / 100;
        Debug.Log(vi);
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetString("HighScore",vi);
        }
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
       DeathSound.GetComponent<AudioSource>().Play();
       StartCoroutine(Wait());
       PlayerPrefs.SetString("Current",vi);

    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles"){
            TakeDamage();
            Obstacle.GetComponent<AudioSource>().Play();

        }
         if (collision.gameObject.tag == "Regeneration"){
            Regenerate();
            Destroy(collision.gameObject);      
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            Coin.GetComponent<AudioSource>().Play();
            score++;
            Destroy(collision.gameObject);
            Debug.Log("dsdsd");
            vi = score.ToString();
            Text.text = vi;
        }
    }
    public void Scene1() 
    {  
        SceneManager.LoadScene("Menu");
    }  
    IEnumerator Wait()
{	
    yield return new WaitForSeconds(2);
    Destroy(gameObject);
    Scene1();
}
}
