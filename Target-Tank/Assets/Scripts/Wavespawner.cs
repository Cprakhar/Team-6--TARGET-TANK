using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavespawner : MonoBehaviour
{
    [System.Serializable]
    #region Variables
    public class enemys
    {
        public Transform enemypos;
    }
    public Transform enemy;
    public float rate;
    int enemies = 0;
    public enemys[] pos;
    #endregion
    #region Methods
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(EnemyDrop());
            gameObject.GetComponent<BoxCollider>().enabled = false;  
        }
        
    }

    int i = 0;
    IEnumerator EnemyDrop()
    {
        while (enemies < pos.Length)
        { 
            Instantiate(enemy, pos[i].enemypos.position, Quaternion.identity);
            Debug.Log("Spawn");
            yield return new WaitForSeconds(rate);
            enemies += 1;
            i++;
        }
        yield break;
    }
    #endregion
}
