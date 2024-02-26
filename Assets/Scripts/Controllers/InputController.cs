using UnityEngine;
using Character;

public class InputController : MonoBehaviour
{
    [SerializeField] private CharacterModel _character;

    private readonly float _smoothTime = 0.1f;
    private Vector3 _currentMoveDirection = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        Move();
        // Fire();
        RotateTowardCursor();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character.fireRequest.Invoke();
        }
    }

    private void Move()
    {
        Vector3 targetDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            targetDirection += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            targetDirection += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            targetDirection += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            targetDirection += Vector3.right;
        }

        _character.moveDirection.Value = targetDirection;
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // 1. Событие FireRequest обрабытывается AnimatorController
            _character.fireRequest.Invoke();
        }
    }

    private void RotateTowardCursor()
    {
        var mousePosition = Input.mousePosition;

        var ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var targetPosition = hitInfo.point;
            _character.rotationTargetPoint.Value = targetPosition;
        }
    }
}