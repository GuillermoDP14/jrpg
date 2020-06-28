using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{

    public CharacterStats stats;
    private Image barImage;



    private void Awake()
    {
        stats = GameObject.Find("PlayerUnit").GetComponent<PlayerStats>();
        barImage = transform.Find("Bar").GetComponent<Image>();       
    }

    private void Update() {
        stats = GameObject.Find("PlayerUnit").GetComponent<PlayerStats>();
        barImage.fillAmount = stats.CurrentMana/stats.MaxMana;
    }


}
