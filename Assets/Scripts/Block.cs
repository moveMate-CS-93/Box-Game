using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBlock : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
