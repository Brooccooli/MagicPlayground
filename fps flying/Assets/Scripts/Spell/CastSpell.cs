using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastSpell : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spells;
    [SerializeField] private Text _spellName;
    private GameObject _equippedSpell;
    private SpellSettings _spellSettings;
    private int _spellIndex = 0;
    private int _amountOfSpells;
    
    
    void Start()
    {
        _amountOfSpells = _spells.Count - 1;
        _equippedSpell = _spells[_spellIndex];
        _spellSettings = _equippedSpell.GetComponent<SpellSettings>();
        if (_spellSettings)
        {
            _spellName.text = _spellSettings.name;
        }
    }

    void Update()
    {
        _controlls();
    }

    private void _controlls()
    {
        // Casting
        if (_spellSettings)
        {
            if (_spellSettings.RapidFire)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Instantiate(_equippedSpell, transform.position, transform.rotation);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(_equippedSpell, transform.position, transform.rotation);
                }
            }
        }
        
        // Spell switching
        if (Input.mouseScrollDelta.y > 0)
        {
            if (_spellIndex + 1 > _amountOfSpells)
            {
                _spellIndex = 0;
            }
            else
            {
                _spellIndex++;
            }
            _switchSpell();
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (_spellIndex - 1 < 0)
            {
                _spellIndex = _amountOfSpells;
            }
            else
            {
                _spellIndex--;
            }
            _switchSpell();
        }
    }

    private void _switchSpell()
    {
        _equippedSpell = _spells[_spellIndex];
        _spellSettings = _equippedSpell.GetComponent<SpellSettings>();
        if (_spellSettings)
        {
            _spellName.text = _spellSettings.name;
        }
    }
}
