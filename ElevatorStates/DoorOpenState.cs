using System.Windows.Forms;

namespace ElevatorControlSystem.ElevatorStates
{
    public class DoorOpenState : ElevatorState
    {
        public void MoveTo(Elevator context, int targetFloor)
        {
            MessageBox.Show("Please close door before moving!", "Safety Warning");
        }

        public void OpenDoor(Elevator context)
        {
            MessageBox.Show("Door is already open!", "Elevator Control");
        }

        public void CloseDoor(Elevator context)
        {
            try
            {
                context.SetState(new DoorClosedState());
                context.LogOperation("Door closed at " + (context.CurrentFloor == 1 ? "Ground Floor" : "First Floor"), context.CurrentFloor);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Elevator Control");
            }
        }
    }
}