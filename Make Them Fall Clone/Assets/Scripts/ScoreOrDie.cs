using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOrDie : MonoBehaviour
{
    
    
    

    private void OnEnable()
    {
        Invoke("prefabDestroy", 4f);
        
    }

    void Update()
    {
          transform.Translate(new Vector3(0, GameObject.Find("GameManager").GetComponent<GameManager>().speed*Time.deltaTime, 0));
       
    }

    void prefabDestroy()
    {
        Destroy(gameObject);
    }
}
