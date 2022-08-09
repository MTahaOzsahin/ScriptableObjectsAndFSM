using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] BaseState _initialState;
        
        Dictionary<Type, Component> _cachedComponents;

        public BaseState CurrentState { get; set; }
        public enum EnemyType { Guard,Patrol,Common}
        public EnemyType enemyType;
        private void Awake()
        {
            CurrentState = _initialState;
            _cachedComponents = new Dictionary<Type, Component>();
        }
        private void Start()
        {
            CurrentState.OnEnterExecute(this);
        }
        private void Update()
        {
            CurrentState.MainExecute(this);
        }
        public void OnStateChange(BaseState newState)
        {
            CurrentState.OnExitExecute(this);
            newState.OnEnterExecute(this);
            CurrentState = newState;
        }
        public new T GetComponent<T>() where T : Component
        {
            if (_cachedComponents.ContainsKey(typeof(T)))
                return _cachedComponents[typeof(T)] as T;

            var component = base.GetComponent<T>();
            if (component != null)
            {
                _cachedComponents.Add(typeof(T), component);
            }
            return component;
        }
    }
}
