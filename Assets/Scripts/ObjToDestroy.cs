using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjToDestroy : MonoBehaviour
{
    [SerializeField] private int HP=4;
    [SerializeField] private GameObject EffectDmg1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage){
    HP-=damage;
    EffectDmg();   
    if(HP<=0){
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         Destroy(gameObject);
         
      }
    }
    //Ektowne obrażenia
    private void EffectDmg(){
      var damageEffect=Instantiate(EffectDmg1,transform.position, Quaternion.identity);
      Destroy(damageEffect, 1f);
    }

}
