using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    [SerializeField] private GameObject _spell;
    private SpellSettings _spellSettings;
    
    void Start()
    {
        _spellSettings = _spell.GetComponent<SpellSettings>();
    }

    void Update()
    {
        if (_spellSettings)
        {
            if (_spellSettings.RapidFire)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Instantiate(_spell, transform.position, transform.rotation);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(_spell, transform.position, transform.rotation);
                }
            }
        }
    }
}
