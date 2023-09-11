using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroy : MonoBehaviour
{
    private void Start()
    {
      StartCoroutine(DestroyObject(gameObject));
    }

    IEnumerator DestroyObject(GameObject gameObject)
    {
      yield return new WaitForSeconds(2f);
      Destroy(gameObject);
    }
}
