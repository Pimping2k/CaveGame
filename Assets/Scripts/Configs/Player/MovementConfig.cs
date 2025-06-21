using CustomEditorAttributes;
using Data;
using UnityEngine;

namespace Configs.Player
{
    [CreateAssetMenu(menuName = Paths.PLAYER +"Movement Config", fileName = "Movement Config")]
    public class MovementConfig : ScriptableObject
    {
        [PimpingHeader("Movement Settings", HeaderColor.Purple, direction: GradientDirection.Horizontal)] 
        [SerializeField] private float _movementSpeed;
        [PimpingHeader("Camera Settings", HeaderColor.Purple, direction: GradientDirection.Horizontal)] 
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _cameraClampValue;
        
        public float CameraClampValue => _cameraClampValue;
        public float RotationSpeed => _rotationSpeed;
        public float MovementSpeed => _movementSpeed;
    }
}