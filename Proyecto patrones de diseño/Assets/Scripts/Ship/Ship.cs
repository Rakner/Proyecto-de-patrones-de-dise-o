using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Variables
    [SerializeField] private float _speed;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _marginTop = 0.97f;
    [SerializeField] private float _marginDown = 0.03f;
    private Transform _myTransform;
    private Camera _camera;

    // Methods

    // Asigna la posicion inicial
    private void Awake()
    {
        _myTransform = transform;
        _camera = Camera.main;
    }

    // Mueve la nava cada segundo
    private void Update()
    {
        // Recoge la direccion en funcion del input
        var direction = GetDirection();
        // Mueve la nave con la direccion dada
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (_speed * Time.deltaTime));
        ClampFinalPosition();
    }

    private void ClampFinalPosition()
    {
        var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
        viewportPoint.x = Mathf.Clamp(viewportPoint.x, _marginDown, _marginTop);
        viewportPoint.y = Mathf.Clamp(viewportPoint.y, _marginDown, _marginTop);
        _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
    }

    // Devuelve un Vector2 de direccion en funcion del input
    private Vector2 GetDirection()
    {
        return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        var horizontalDir = Input.GetAxis("Horizontal");
        var verticalDir = Input.GetAxis("Vertical");
        //return new Vector2(horizontalDir, verticalDir);
    }
}
