using System;
using Interfaces;
using Unity.Cinemachine;
using UnityEngine;

namespace Dependencies
{
    public class CameraService : MonoBehaviour, ICameraService
    {
        [SerializeField] private CinemachineCamera _camera;
        
        public CinemachineCamera CurrentCamera { get; private set; }
        
        private void Awake()
        {
            CurrentCamera = _camera;
        }
    }
}