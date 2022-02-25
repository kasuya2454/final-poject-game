using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    //not call these variables _xxx
    private float _hp;

    [Header("Player Stat")]
    [SerializeField] private float MAX_HP;
    [SerializeField] private float MIN_HP;

    [Header("Reletive GameObject")]
    [SerializeField] private Slider HpBar;
    [SerializeField] private Text HpText;

    [SerializeField] private GameObject fillAreaObject;

    [HideInInspector]
    public float Hp
    {
        get => _hp;
        set
        {
            if (value < MIN_HP) _hp = MIN_HP;
            else if (value > MAX_HP) _hp = MAX_HP;
            else _hp = value;
        }
    }
    public static Hpbar instance;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Hp = MAX_HP;
        HpText.text = $"HP:  {Hp}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamagePlayer(float damageAmount)
    {
        if (Hp > MIN_HP)
        {
            Hp -= damageAmount;
            HpBar.value = Hp;
            HpText.text = $"HP:  {Hp}";
            if (Hp == MIN_HP) fillAreaObject.SetActive(false);
        }
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