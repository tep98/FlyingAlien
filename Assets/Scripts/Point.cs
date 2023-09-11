using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public GameObject evilCube;

    private void Start()
    {
      Instantiate(evilCube, transform.position, Quaternion.identity); 
    }
}
