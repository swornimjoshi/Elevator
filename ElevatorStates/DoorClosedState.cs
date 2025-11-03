using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorControlSystem.ElevatorStates
{
    public class DoorClosedState : ElevatorState
    {
        public async void MoveTo(Elevator context, int targetFloor)
        {
            try
            {
                if (context.CurrentFloor == targetFloor)
                {
                    MessageBox.Show("Already on this floor!", "Elevator Control");
                    return;
                }

                context.SetState(new MovingState());
                await context.MoveLift(targetFloor);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Elevator Control");
                context.SetState(new DoorClosedState());
            }
        }

        public void OpenDoor(Elevator context)
        {
            try
            {
                context.SetState(new DoorOpenState());
                context.LogOperation("Door opened at " + (context.CurrentFloor == 1 ? "Ground Floor" : "First Floor"), context.CurrentFloor);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Elevator Control");
            }
        }

        public void CloseDoor(Elevator context)
        {
            MessageBox.Show("Door is already closed.", "Elevator Control");
        }
    }
}