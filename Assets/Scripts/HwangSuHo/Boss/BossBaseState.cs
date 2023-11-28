public abstract class BossBaseState
{
    public BossStateMachine StateMachine;
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Perform();
}
