using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject panelJoystick, panelAttacks, panelHP;
    public GameObject textJoystick, textAttacks, textHP;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("FirstTime") != 5)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            PlayerPrefs.SetInt("FirstTime", 5);
        }
        if(PlayerPrefs.GetInt("Tutorial") == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            panelJoystick.SetActive(true);
            textJoystick.SetActive(true);

        }
    }

    public void PressedJoystick()
    {
        panelJoystick.SetActive(false);
        textJoystick.SetActive(false);
        textAttacks.SetActive(true);
        panelAttacks.SetActive(true);
    }
    public void PressedAttack()
    {
        panelAttacks.SetActive(false);
        textAttacks.SetActive(false);
        textHP.SetActive(true);
        panelHP.SetActive(true);
    }
    public void PressedHP()
    {
        panelHP.SetActive(false);
        textHP.SetActive(false);
        gameObject.SetActive(false);
        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().canSpawn = true;
    }
}
