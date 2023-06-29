public class EnemyAI : TankMovement
{
    private WeaponLogic _weaponLogic;
    private System.Random _random;
    private Direction _direction = Direction.Down;
    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Start()
    {
        _random = new System.Random();
        _weaponLogic = GetComponent<WeaponLogic>();
    }

    private void Update()
    {
        if (_random.Next(0,2) == 1) _weaponLogic.Fire();
        if(_random.Next(0,500) == 1) ChangeDirection();

        Move(_direction);
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveVertical(1);
                break;
            case Direction.Down:
                MoveVertical(-1);
                break;
            case Direction.Left:
                MoveHorizontal(-1);
                break;
            case Direction.Right:
                MoveHorizontal(1);
                break;
        }
    }

    private void OnCollisionEnter2D()
    {
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        var randomInt = _random.Next(0, 4);
        _direction = ChooseDirection(randomInt);
    }

    private static Direction ChooseDirection(int x)
    {
        return x switch
        {
            0 => Direction.Up,
            1 => Direction.Down,
            2 => Direction.Left,
            3 => Direction.Right,
            _ => Direction.Down
        };
    }
}
