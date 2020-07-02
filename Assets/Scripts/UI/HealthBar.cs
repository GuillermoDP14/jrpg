using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{


    private CharacterStats stats;

    private Image barImage;

    private void Start()
    {
        stats = GameObject.Find("PlayerUnit").GetComponent<PlayerStats>();
        barImage = transform.Find("Bar").GetComponent<Image>();
       
    }

    private void Update() {
        
        barImage.fillAmount = stats.CurrentHealth/stats.MaxHealth;
    }

}
