namespace ElevatorControlSystem.ElevatorStates
{
    public interface ElevatorState
    {
        void MoveTo(Elevator context, int targetFloor);
        void OpenDoor(Elevator context);
        void CloseDoor(Elevator context);
    }
}