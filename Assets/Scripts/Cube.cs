using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int damage = 1;
    public float speedConst;
    private float speed;

    public GameObject effect;

    private Animator camAnim;
    private Animator playerAnim;
    private Animator heartAnim;

    public GameObject[] crashSound;
    

    private void Start()
    {
      speed = speedConst;
      camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
      playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
      heartAnim = GameObject.FindGameObjectWithTag("Heart").GetComponent<Animator>();
    }

    private void Update()
    {
      transform.Translate(Vector2.left * speed);
      if(PauseMenu.GameIsPause){
        speed = 0;
      }
      else
      {
        speed = speedConst;
      }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.CompareTag("Player"))
      {
        int rand = Random.Range(0, crashSound.Length);
        Instantiate(crashSound[rand], transform.position, Quaternion.identity);
        playerAnim.SetTrigger("playerDamageShake");
        camAnim.SetTrigger("damageShake");
        heartAnim.SetTrigger("hardHeartBreak");
        Instantiate(effect, transform.position, Quaternion.identity);
        other.GetComponent<Player>().health -= damage;
        Destroy(gameObject);
      }
    }
}
