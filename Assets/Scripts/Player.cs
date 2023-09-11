using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float YIncrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 5;
    public Text healthDisplay;

    public GameObject effect;
    public GameObject effectDown;

    public GameObject panel;
    public GameObject spawner;
    public GameObject bg;

    private Animator camAnim;
    private Animator playerAnim;

    public GameObject[] moveSound;
    public GameObject loseSound;

    public AudioSource mainMusic;

    private void Start()
    {
      camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void Update()
    {
      healthDisplay.text = health.ToString();
      if(health <=0)
      {
        Instantiate(loseSound, transform.position, Quaternion.identity);
        mainMusic.pitch = 0.5f;
        panel.SetActive(true);
        Destroy(gameObject);
        Destroy(GameObject.FindGameObjectWithTag("Cube"));
        Time.timeScale = 0f;
      }

      transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);

      if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
      {
        int rand = Random.Range(0, moveSound.Length);
        Instantiate(moveSound[rand], transform.position, Quaternion.identity);
        camAnim.SetTrigger("shake");
      }
      if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.y < maxHeight)
      {
        Instantiate(effectDown, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y + YIncrement);
      }
      else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && transform.position.y > minHeight)
      {
        Instantiate(effect, transform.position, Quaternion.identity);
        targetPos = new Vector2(transform.position.x, transform.position.y - YIncrement);
      }
    }
}
