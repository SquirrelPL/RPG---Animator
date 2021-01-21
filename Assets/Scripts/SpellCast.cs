using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCast : MonoBehaviour
{
    public GameObject spellGenerator;
    public GameObject[] spells;
    private GameObject castedSpells = null;
    private List<GameObject> releasedSpell = new List<GameObject>();
    [HideInInspector]
    public int spellSelector = 0;
    public GameObject gameManager;
    public GameObject spellUI;

    void Update()
    {
        if (castedSpells!=null)
        {
            castedSpells.transform.position = spellGenerator.transform.position;
        }

    }

    public void PrepareSpell()
    {
        if (gameManager.GetComponent<StatsManagment>().mana.GetComponent<Slider>().value >= 20)
            castedSpells = Instantiate(spells[spellSelector], spellGenerator.transform.position, Quaternion.identity);

    }

    public void ReleaseSpell()
    {
        if (gameManager.GetComponent<StatsManagment>().mana.GetComponent<Slider>().value >= 20)
        {
            releasedSpell.Add(castedSpells);
            castedSpells.GetComponent<SpellBehavior>().enabled = true;
            castedSpells = null;
            gameManager.GetComponent<StatsManagment>().ReduceManaBySpell();
        }

    }

    public void DestroySpell()
    {
        Destroy(castedSpells);
    } 

}
