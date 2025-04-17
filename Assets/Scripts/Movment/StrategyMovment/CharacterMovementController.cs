using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour inputSourceMono;
    private ICommandSource inputSource;

    [SerializeField] private List<MonoBehaviour> strategiesMono;
    private List<ICharacterMovement> strategies;

    private ICharacterMovement activeStrategy;

    private void Awake()
    {
        inputSource = inputSourceMono as ICommandSource;
        strategies = new List<ICharacterMovement>();
        foreach (var monoBehaviour in strategiesMono)
        {
            
            if (monoBehaviour is ICharacterMovement movement)
            {
                strategies.Add(movement);
               
            }
        }
    }

    private void Update()
    {
        foreach (var strategy in strategies)
        {
            strategy.ActionRequest(
                inputSource.GetMoveInput(),
                inputSource.GetJumpPressed(),
                inputSource.GetDashPressed()
                );

        }

        activeStrategy = strategies
        .Where(s => s.WantsControl)
        .OrderByDescending(s => s.Priority)
        .FirstOrDefault();

    }

    private void FixedUpdate()
    {
            activeStrategy?.ActionLogic();
        //Debug.Log(activeStrategy);
        
    }
}
