
public enum EnemyStatus
{ 
    NONE,
    STOP,
    PATROL,
    RETURN
}

public enum PlayerAnimation
{
    NONE,
    IDLE,
    RUN,
    DIE
}

public enum RoomType
{
    Battle,
    Store,
    Event,
    Exit
}

public enum ItemType
{
    ITEM_STUNGUN,       // 스턴건
    ITEM_INVISI,        // 투명망토
    ITEM_EXPLOTRAP,     // 폭발트랩
    ITEM_DUMMYTRAP,     // 더미트랩
    ITEM_MAX
}

public enum EnemyType
{
    ENEMY_A,
    ENEMY_B,
    ENEMY_C,
    ENEMY_D,
    ENEMY_E
}

public enum AIType
{
    IDLE,
    STOP,
    USEITEM,
    GETBOX,
    ATTACK,
    RUN,
    STUN,
    HIT
}

