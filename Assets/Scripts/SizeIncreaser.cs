using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeIncreaser : MonoBehaviour
{
    public float maxSize = 100;
    public float scaleupFactor;
    public int waitTime = 1;
    // Start is called before the first frame update
    public void Blow()
    {
        Debug.Log("Collision!");
        StartCoroutine(Scale());
    }

    // Update is called once per frame
    IEnumerator Scale()
    {
        while (true)
        {
            while (maxSize > transform.localScale.x)
            {
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * scaleupFactor;

                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
