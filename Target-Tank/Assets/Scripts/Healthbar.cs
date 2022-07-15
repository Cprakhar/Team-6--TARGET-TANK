using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[ExecuteInEditMode]
public class Healthbar : MonoBehaviour
{
    #region Variables
    public Slider slider;
    public float maxhealth;
    public Image visualcolor;
    public TextMeshProUGUI mytext;
    //public Gradient gradient;
    public float curhealth=0f;
    float lerpSpeed=10f;
    #endregion
    #region Methods
    public void Start()
    {
        curhealth = maxhealth;
        slider.maxValue = curhealth;
        slider.value = curhealth;
    }
    
    public void sethealth(float health)
    {
         slider.value = health;
        
        mytext.text = "Health: " + (int)((health / maxhealth) * 100f) +"%";
        visualcolor.fillAmount  = Mathf.Lerp(visualcolor.fillAmount, health / maxhealth, lerpSpeed);
        
        Color healthcolor = Color.Lerp(Color.red, Color.green, health / maxhealth);
        visualcolor.color = healthcolor;
    }
    #endregion
}
