using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSelector : MonoBehaviour
{
    public GameObject spellRing;
    public Sprite[] spellsSprite;
    public GameObject playerModel;
    public GameObject spellUI;

    void Start()
    {
        spellRing.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey("q"))
        {
            spellRing.SetActive(true);
            switch (Input.inputString)
            {
                case "1":
                    playerModel.GetComponent<SpellCast>().spellSelector = 0;
                    spellUI.GetComponent<Image>().sprite = spellsSprite[0];
                    break;
                case "2":
                    playerModel.GetComponent<SpellCast>().spellSelector = 1;
                    spellUI.GetComponent<Image>().sprite = spellsSprite[1];
                    break;
                case "3":
                    playerModel.GetComponent<SpellCast>().spellSelector = 2;
                    spellUI.GetComponent<Image>().sprite = spellsSprite[2];
                    break;
                case "4":
                    playerModel.GetComponent<SpellCast>().spellSelector = 3;
                    spellUI.GetComponent<Image>().sprite = spellsSprite[3];
                    break;
                case "5":
                    playerModel.GetComponent<SpellCast>().spellSelector = 4;
                    spellUI.GetComponent<Image>().sprite = spellsSprite[4];
                    break;
            }
        }
        else
        {
            spellRing.SetActive(false);
        }
    }
}
