using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnCollisionEnter2D(Collision2D collision){
        //kolizja z Exit
    if (collision.gameObject.CompareTag("Player"))
    {
        int x= SceneManager.GetActiveScene().buildIndex +1;
         if (SceneManager.GetSceneByBuildIndex(x) != null)
        {
            // Scene with build index x exists
            SceneManager.LoadScene(x);

        }
        else
        {
            // Scene with build index x does not exist
        }
        
    }
}
}