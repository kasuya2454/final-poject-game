using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField] private Slider HpBar;
    [SerializeField] private Text HpText;
    [SerializeField] private float HpPlayer = 100f;
    public static Hpbar instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HpBar.value = HpPlayer;
        HpText.text = "HP" + HpPlayer;
    }

    public void DamagePlayer(float damageAmount)
    {
        HpPlayer -= damageAmount;
    }

    /*public void HealPlayer(float heal)
    {
        HpPlayer += heal;
        if (HpPlayer > 100f)
        {
            HpPlayer = 100f;
        }
    }*/
}