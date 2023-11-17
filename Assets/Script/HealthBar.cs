using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class Health : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private TMP_Text _healthbarText;
    private float _reduceSpeed = 2;
    private float _target = 1;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;

        // Convert pourcentage to int and display it in the text
        _healthbarText.text = Mathf.RoundToInt(_healthbarSprite.fillAmount * 100) + "%";

        // Change color of the healthbar depending on the current health
        if (_healthbarSprite.fillAmount > 0.5f)
        {
            _healthbarSprite.color = Color.green;
        }
        else if (_healthbarSprite.fillAmount > 0.25f)
        {
            _healthbarSprite.color = Color.yellow;
        }
        else
        {
            _healthbarSprite.color = Color.red;
        }
    }

    // Every space click, remove 10 health
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _camera.transform.position);    }
}
