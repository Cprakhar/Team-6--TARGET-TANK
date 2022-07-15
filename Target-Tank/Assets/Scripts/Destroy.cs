using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destroy : MonoBehaviour
{
    #region Variables
    public GameObject collider1, collider2;
    public string sound;
    public float damage;
    public GameObject explosioneffect1, explosioneffect2, explosioneffect3, effect;
    GameObject effect1, effect2, effect3, effect4;
    Gameover gameover;
    Healthbar healthbar1;
    #endregion
    #region Methods
    public void OnCollisionEnter(Collision obj)
    {   
        if (obj.transform.tag == collider1.transform.tag)
        {
            effect1 = Instantiate(explosioneffect1, transform.position, transform.rotation);
            Destroy(obj.gameObject);
            Destroy(gameObject);
            Destroy(effect1, 1f);
        }

        else if(obj.transform.tag == "Ground")
        {
            effect1 = Instantiate(explosioneffect2, transform.position, transform.rotation);
            Destroy (gameObject);
            Destroy (effect1, 1f);
        }

        else if(obj.transform.tag == collider2.transform.tag)
        {
            healthbar1=obj.gameObject.GetComponent<Healthbar>();
            healthbar1.slider.value=obj.gameObject.GetComponent<Healthbar>().slider.value;
            effect2 = Instantiate(explosioneffect2, obj.transform.position, obj.transform.rotation);
            Destroy(effect2, 1f);
            Destroy(gameObject);
            healthbar1.curhealth=healthbar1.slider.value;
            healthbar1.curhealth -= damage;
            healthbar1.sethealth(healthbar1.curhealth);
            if(healthbar1.slider.value <= 0)
            {
                effect4 = Instantiate(effect, obj.transform.position, obj.transform.rotation);
                Destroy(effect3, 1f);
                Destroy(gameObject);
                effect1 = Instantiate(explosioneffect1, transform.position, transform.rotation);
                FindObjectOfType<AudioManager>().Play(sound);
                Destroy(effect4, 2f);
                Destroy(obj.gameObject);
                gameover = obj.gameObject.GetComponent<Gameover>();
                gameover.setscreen((int)FindObjectOfType<Playertankcontroller>().maxscore, "Theme", "Tanktrack");
            }
        }

        else
        {
            Destroy(gameObject, 8f);
        }
    }
    #endregion
}
