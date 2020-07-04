using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CreatePlayerStats : MonoBehaviour
{

    private PlayerStats newPlayer;
    private string playerName;
    public Text  nameText;
    public Text  levelText;
    public Text  experienceText;
    public Text  healthText;
    public Text  manaText;
    public Text strengthText;
    public Text magicText;
    public Text agilityText;
    public Text armorText;
    public Text damageText;
    public Text pointsText;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private ManaBar manaBar;


    private void Start() {

        GameObject p = GameObject.Find("PlayerUnit");
        newPlayer = p.GetComponent<PlayerStats>();
        newPlayer.PlayerClass = new PlayerClass1();
        
        UpdateUI();
    }

    private void Update() {
        
        //Debug.Log(newPlayer.agility.BaseValue);
        //Debug.Log(newPlayer.agility.Value);
        //ebug.Log(newPlayer.Agility);
        UpdateUI();
    }

    public void CreateNewPLayer()
    {
        //SetClass1();        
        
        newPlayer.CharacterLevel = 1;
        newPlayer.Experience = 0;
        //newPlayer.CharacterName = playerName;

        GameInfo.PlayerLevel = newPlayer.CharacterLevel;
        GameInfo.Experience = newPlayer.Experience;
        GameInfo.PlayerName = newPlayer.CharacterName;

        GameInfo.Agility = newPlayer.Agility;
        GameInfo.Magic = newPlayer.Magic;

        GameInfo.Damage = newPlayer.Armor;
        GameInfo.Armor = newPlayer.Damage;  
        GameInfo.Strength = newPlayer.Strength;

        GameInfo.CurrentHealth = newPlayer.CurrentHealth;
        GameInfo.CurrentMana = newPlayer.CurrentMana;

        GameInfo.MaxHealth = newPlayer.MaxHealth;
        GameInfo.MaxMana = newPlayer.MaxMana;
    
        GameInfo.SpendPoints = newPlayer.SpendPoints;

        SaveInfo.SaveAllInfo();

        //SceneManager.LoadScene("Menu");
    }

    public void SetClass1()
    {
        newPlayer.SpendPoints = 2;       
        newPlayer.PlayerClass = new PlayerClass1();
        newPlayer.Strength = newPlayer.PlayerClass.Strength;
        newPlayer.Agility = newPlayer.PlayerClass.Agility;
        newPlayer.Magic = newPlayer.PlayerClass.Magic;
        newPlayer.Armor = newPlayer.PlayerClass.Armor;
        newPlayer.Damage = newPlayer.PlayerClass.Damage;
        newPlayer.MaxHealth = newPlayer.PlayerClass.Health;
        newPlayer.MaxMana = newPlayer.PlayerClass.Mana;
        UpdateUI();   
    }

    void UpdateUI()
    {
        //nameText.text = newPlayer.CharacterName.ToString();

        strengthText.text = newPlayer.Strength.ToString();
        magicText.text = newPlayer.Magic.ToString();
        agilityText.text = newPlayer.agility.Value.ToString();

        armorText.text = newPlayer.Armor.ToString();
        damageText.text = newPlayer.Damage.ToString();

        pointsText.text = newPlayer.SpendPoints.ToString();

        experienceText.text = newPlayer.Experience.ToString();
        levelText.text = newPlayer.CharacterLevel.ToString();

        healthText.text = newPlayer.currentHealth.ToString() + "/" + newPlayer.MaxHealth.ToString();
        manaText.text = newPlayer.currentMana.ToString() + "/" +  newPlayer.MaxMana.ToString();

        //healthBar.SetSize(newPlayer.currentHealth/(int) newPlayer.maxHealth.BaseValue);
        //manaBar.SetSize(newPlayer.currentMana/(int) newPlayer.maxMana.BaseValue);

    }

    public void SetStrength(int amount)
    {
        if(newPlayer.PlayerClass != null){
        
            if(amount > 0 && newPlayer.SpendPoints > 0)
            {
                newPlayer.Strength += amount;
                newPlayer.SpendPoints -= 1;
                UpdateUI();            
            }
            else if (amount < 0 && newPlayer.Strength > newPlayer.playerClass.Strength)
            {
                newPlayer.Strength += amount;
                newPlayer.SpendPoints +=1;
                UpdateUI();
            }     
        } 
        else
        {
            Debug.Log("No Class Choosen!");
        }     
    }

    public void SetMagic(int amount)
    {
        if(newPlayer.PlayerClass != null){
        
            if(amount > 0 && newPlayer.SpendPoints > 0)
            {
                newPlayer.Magic += amount;
                newPlayer.SpendPoints -= 1;
                UpdateUI();            
            }
            else if (amount < 0 && newPlayer.Magic > newPlayer.playerClass.Magic)
            {
                newPlayer.Magic += amount;
                newPlayer.SpendPoints +=1;
                UpdateUI();
            }     
        } 
        else
        {
            Debug.Log("No Class Choosen!");
        }  
    }

    public void SetAgility(int amount)
    {
        if(newPlayer.PlayerClass != null){
        
            if(amount > 0 && newPlayer.SpendPoints > 0)
            {
                newPlayer.Agility += amount;
                newPlayer.SpendPoints -= 1;
                UpdateUI();            
            }
            else if (amount < 0 && newPlayer.Agility > newPlayer.playerClass.Agility)
            {
                newPlayer.Agility += amount;
                newPlayer.SpendPoints +=1;
                UpdateUI();
            }     
        } 
        else
        {
            Debug.Log("No Class Choosen!");
        }  
    }

    public void LoadStuff()
    {
        LoadInfo.LoadAllInfo();   

        newPlayer.CharacterLevel = GameInfo.PlayerLevel;
        newPlayer.CharacterName = GameInfo.PlayerName;
 
        newPlayer.Strength = GameInfo.Strength;
        newPlayer.Magic = GameInfo.Magic;
        newPlayer.Agility = GameInfo.Agility;

        newPlayer.Experience = GameInfo.Experience;

        newPlayer.MaxHealth = GameInfo.MaxHealth;
        newPlayer.MaxMana = GameInfo.MaxMana;
        
        newPlayer.CurrentHealth = GameInfo.CurrentHealth;
        newPlayer.CurrentMana = GameInfo.CurrentMana;

        newPlayer.Damage = GameInfo.Damage;
        newPlayer.Armor = GameInfo.Armor;     

        UpdateUI();
    }


}