using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

  [Serializable]
public class SpellScript
    {
    [SerializeField]
    private string name;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float castTime;
    [SerializeField]
    private GameObject spellPrefab;
    [SerializeField]
    private Color barColor;

    public string Name 
    {
        get => name; 
    }

    public int Damage 
    { 
        get => damage;
        
    }

    public Sprite Icon 
    { 
        get => icon;
    }

    public float Speed
    {
        get => speed;
    }

    public float CastTime 
    { 
        get => castTime;
    }

    public GameObject SpellPrefab 
    { 
        get => spellPrefab;
    }

    public Color BarColor 
    {
        get => barColor;
    }

}

