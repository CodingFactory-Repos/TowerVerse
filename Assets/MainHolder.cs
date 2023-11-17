using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHolder : MonoBehaviour
{

    public static MainHolder instance;
    public GameObject playerPrefab;
    private GameObject player;
    public GameObject spawnPoint;
    public bool firstScene;
    public int currentScene=0;

    [Header("player State")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float attackRange;

    [NonSerialized] public float _maxHealth;
    [NonSerialized] public float _damage;
    [NonSerialized] public float _attackSpeed;
    [NonSerialized] public float _walkSpeed;
    [NonSerialized] public float _runSpeed;
    [NonSerialized] public float _attackRange;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        firstScene = false;
    }

    public void setValue()
    {
        _maxHealth = maxHealth;
         _damage = damage;
         _attackSpeed = attackSpeed;
         _walkSpeed = walkSpeed;
         _runSpeed = runSpeed;
         _attackRange = attackRange;
    }

    public void startStage(int index)
    {
        currentScene = index;
        if (index == 1)
        {
            setValue();
            firstScene = true;
        }else
        {
            firstScene = false;
        }
        SceneManager.LoadScene(index);
      //  player = GameObject.FindWithTag("Player");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
