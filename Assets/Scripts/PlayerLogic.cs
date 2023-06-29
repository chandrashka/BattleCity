using System;
using UnityEngine;

public class PlayerLogic : TankMovement
{
    private WeaponLogic _weaponLogic;

    private void Start()
    {
        _weaponLogic = GetComponent<WeaponLogic>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalMove = Input.GetAxisRaw("Horizontal");
        var verticalMove = Input.GetAxisRaw("Vertical");
        var isFired = Input.GetKeyDown(KeyCode.Space);

        if (isFired) _weaponLogic.Fire();
        if (horizontalMove != 0) MoveHorizontal(horizontalMove);
        else if (verticalMove != 0) MoveVertical(verticalMove);
    }
}