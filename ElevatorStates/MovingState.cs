using System.Windows.Forms;

namespace ElevatorControlSystem.ElevatorStates
{
    public class MovingState : ElevatorState
    {
        public void MoveTo(Elevator context, int targetFloor)
        {
            MessageBox.Show("Elevator is already moving! Please wait.", "Elevator Control");
        }

        public void OpenDoor(Elevator context)
        {
            MessageBox.Show("Cannot open door while moving!", "Safety Warning");
        }

        public void CloseDoor(Elevator context)
        {
            MessageBox.Show("Door already closed during movement.", "Elevator Control");
        }
    }
}