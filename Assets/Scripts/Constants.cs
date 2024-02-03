namespace ShootEmUp
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }
    
    public enum PhysicsLayer
    {
        CHARACTER = 10,
        ENEMY = 11,
        ENEMY_BULLET = 13,
        PLAYER_BULLET = 14
    }
}