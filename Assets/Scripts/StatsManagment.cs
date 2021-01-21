using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManagment : MonoBehaviour
{
    public GameObject health;
    public GameObject mana;
    public GameObject player;
    public GameObject cam;

    void Start()
    {
        
    }

    void Update()
    {
        if (mana.GetComponent<Slider>().value != 100f)
            mana.GetComponent<Slider>().value += 0.1f;

        if (health.GetComponent<Slider>().value <= 20f && !player.GetComponent<AudioSource>().isPlaying)
            player.GetComponent<AudioSource>().Play();

        if (health.GetComponent<Slider>().value > 20f && player.GetComponent<AudioSource>().isPlaying)
            player.GetComponent<AudioSource>().Stop();

        if (Input.GetKeyDown(KeyCode.Backspace))
            Damaged();
    }

    private IEnumerator GetMana()
    {
        yield return new WaitForSeconds(10);
        mana.GetComponent<Slider>().value += 10;
    }

    public void ReduceManaBySpell()
    {
        mana.GetComponent<Slider>().value -= 20;
    }

    public void Damaged()
    {
        health.GetComponent<Slider>().value -= 10f;
    }
}
