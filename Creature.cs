using UnityEngine;
using Creatures.States;
using System.Collections.Generic;

namespace Creatures
{
    internal class Creature : MonoBehaviour
    {
        [SerializeField] internal Model GetModel;

        protected State CurrentState;
        protected Dictionary<string, State> States = new Dictionary<string, State>();

        internal void ChangeState(string newState)
        {
            CurrentState?.OnExit();

            CurrentState = States[newState];
            Debug.Log(CurrentState);

            CurrentState?.OnEnter();
        }

        protected virtual void Start() { }

        protected virtual void Update()
            => CurrentState.Tick();

        [System.Serializable]
        internal class Model
        {
            [SerializeField] internal float Speed;
            [SerializeField] internal float JumpForce;
            [SerializeField] internal LayerMask GroundLayer;
        }
    }
}