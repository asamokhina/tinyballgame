using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeReduser : MonoBehaviour
{
    public float minSize = 1;
    public float reduseFactor;
    public int waitTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scale());
    }

    // Update is called once per frame
    IEnumerator Scale()
    {
        while (true)
        {
            while (minSize <= transform.localScale.x)
            {
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * reduseFactor;
                yield return null;
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
