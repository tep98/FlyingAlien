using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text score;
    public ScoreManager sm;

    private void Start()
    {
      score.text = ("Your score: ") + sm.score.ToString();
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space)){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
      }
    }
}
