using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CharecterCombatController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour combatSourceMono;
    private ICommandCombatSource combatSource;


    [SerializeField] private List<MonoBehaviour> characterAttacksMono;
    private List<ICharacterAction> characterAttacks;

    private ICharacterAction characterActiveAttack;

    //[SerializeField] private Hero _hero;

    private void Awake()
    {
        characterAttacks = new List<ICharacterAction>();
        foreach (var attack in characterAttacksMono)
        {
            if (attack is ICharacterAction att)
            {
                characterAttacks.Add(att);

            }
        }
        combatSource = combatSourceMono as ICommandCombatSource;

    }

    private void Update()
    {
        foreach (var attack in characterAttacks)
        {
            attack.ActionRequest(0, combatSource.MeleeAttack(), combatSource.RangeAttack());
        }

        characterActiveAttack = characterAttacks
        .Where(s => s.WantsControl)
        .OrderByDescending(s => s.Priority)
        .FirstOrDefault();
    }

    private void FixedUpdate()
    {
        characterActiveAttack?.ActionLogic();
    }
}