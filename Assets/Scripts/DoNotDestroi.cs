using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroi : MonoBehaviour
{
    public static DoNotDestroi instance;
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
