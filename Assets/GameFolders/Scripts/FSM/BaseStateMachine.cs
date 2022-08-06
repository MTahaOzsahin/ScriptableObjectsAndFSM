using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectsAndFSM.FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] BaseState _initialState;
        [SerializeField,Tooltip("if wanted to use fixed state and fixed transitions")] bool isFixedState;
        
        Dictionary<Type, Component> _cachedComponents;

        public BaseState CurrentState { get; set; }
        public bool IsFixedState { get; set; }
        private void Awake()
        {
            CurrentState = _initialState;
            IsFixedState = isFixedState;
            _cachedComponents = new Dictionary<Type, Component>();
        }
        
        
        private void Update()
        {
            CurrentState.Execute(this);
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
