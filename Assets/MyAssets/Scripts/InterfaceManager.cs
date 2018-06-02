using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour {
    public static InterfaceManager instance;
    public Text powerText;
    public Text hpText;
    public Image powerBar;
    List<Image> healthList = new List<Image>();
    public Image powerImage;
    public Image powerBackground;
    public float basePower;

    public int interfaceHP;

    public Image HP1;
    public Image HP2;
    public Image HP3;

    bool isUsingPower;
    // Use this for initialization


    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        healthList.Add(HP1);
        healthList.Add(HP2);
        healthList.Add(HP3);

       // SwitchPower(false);

      //  print("Health List Count: " + healthList.Count);
        //DontDestroyOnLoad(gameObject);
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //basePower = player.GetComponent<PlayerController>().basePower;        
    }
    
    public void PowerChange (float newPower)
    {
        powerText.text = newPower.ToString();
        //print("Fill Amount: " +  newPower / basePower + ", New Power: " + newPower + ", base Power: " + basePower);
        powerBar.fillAmount = newPower / basePower;
    }
    public void HPChange(int HP)
    {

        print("Health given: " + HP + ", Interface healt: " + interfaceHP);
        if (HP > interfaceHP)
        {
            if (HP > 0)
            {
                healthList[HP - 1].enabled = true;
                interfaceHP = HP;
            }
            else if (HP == 0) {
                return;
            }


        }
        else if (HP < interfaceHP)
        {
            healthList[HP].enabled = false;
            interfaceHP = HP;
        }

    }
    public void ResetHP()
    {
        foreach (Image item in healthList)
        {
            item.enabled = true;
        }
    }

    public void SwitchPower(bool isUsing)
    {
            powerBar.enabled = isUsing;
            powerText.enabled = isUsing;
            powerBackground.enabled = isUsing;
            powerImage.enabled = isUsing;
    }

}
