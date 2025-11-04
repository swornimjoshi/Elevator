using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElevatorControlSystem.ElevatorStates;
using ElevatorControlSystem.Database;

namespace ElevatorControlSystem
{
    public class Elevator
    {
        // UI Components
        public Panel LiftPanel { get; set; }
        public Panel DoorLeft { get; set; }
        public Panel DoorRight { get; set; }
        public Label StatusLabel { get; set; }
        public Label FloorIndicator { get; set; }
        public Label DirectionLabel { get; set; }
        public DataGridView LogGrid { get; set; }

        // Control Panel Components
        public Button BtnControlG { get; set; }
        public Button BtnControl1 { get; set; }
        public Button BtnControlOpen { get; set; }
        public Button BtnControlClose { get; set; }

        // Display Components
        public Label DisplayLabel { get; set; }
        public Label DisplayFloor { get; set; }
        public Label DisplayStatus { get; set; }

        // Lift Lights
        public Panel LightPanel { get; set; }

        // Call Buttons
        public Button BtnCallUp { get; set; }
        public Button BtnCallDown { get; set; }

        public int CurrentFloor { get; private set; } = 1;
        public string CurrentDirection { get; private set; } = "STOP";
        public string CurrentStatus { get; private set; } = "IDLE";

        private int totalFloors = 2;
        private int[] floorYPositions;
        private ElevatorState _state;
        private bool isMoving = false;
        private BackgroundWorker logWorker;

        // Animation settings
        private const int MoveSteps = 50;
        private const int DoorSteps = 25;
        private const int MoveDelay = 20;
        private const int DoorDelay = 12;

        public Elevator()
        {
            _state = new IdleState();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            logWorker = new BackgroundWorker();
            logWorker.DoWork += LogWorker_DoWork;
            logWorker.RunWorkerCompleted += LogWorker_RunWorkerCompleted;
        }

        public void InitializeShaft(int shaftTop, int shaftBottom, int liftHeight)
        {
            try
            {
                floorYPositions = new int[totalFloors + 1];

                // Calculate floor positions
                int groundFloorY = shaftBottom - liftHeight;
                int firstFloorY = shaftTop;

                floorYPositions[1] = groundFloorY;
                floorYPositions[2] = firstFloorY;

                // Set initial position
                LiftPanel.Location = new Point(LiftPanel.Location.X, groundFloorY-50);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                LogOperation($"Error initializing shaft: {ex.Message}", CurrentFloor);
            }
        }

        public void SetState(ElevatorState state)
        {
            _state = state;
            UpdateLights();
        }

        public void MoveToFloor(int floor)
        {
            if (floor < 1 || floor > totalFloors)
            {
                MessageBox.Show($"Invalid floor! Please select G or 1.", "Elevator Control");
                return;
            }

            if (!isMoving)
                _state.MoveTo(this, floor);
        }

        public async Task MoveLift(int targetFloor)
        {
            try
            {
                isMoving = true;
                CurrentStatus = "MOVING";

                // Set direction
                if (targetFloor > CurrentFloor)
                {
                    CurrentDirection = "UP";
                    UpdateStatus($"Moving UP to Floor {(targetFloor == 1 ? "G" : "1")}");
                }
                else
                {
                    CurrentDirection = "DOWN";
                    UpdateStatus($"Moving DOWN to Floor {(targetFloor == 1 ? "G" : "1")}");
                }

                UpdateDirectionDisplay();
                UpdateDisplay();
                UpdateLights();

                LogOperation($"Moving to {(targetFloor == 1 ? "Ground Floor" : "First Floor")}", targetFloor);

                int startY = LiftPanel.Location.Y;
                int targetY = floorYPositions[targetFloor];
                int distance = targetY - startY;
                int stepSize = distance / MoveSteps;

                for (int i = 1; i <= MoveSteps; i++)
                {
                    if (!isMoving) break;

                    int newY = startY + (stepSize * i)-55;
                    SafeInvoke(() => LiftPanel.Location = new Point(LiftPanel.Location.X, newY));
                    await Task.Delay(MoveDelay);
                }

                // Ensure exact position
                //SafeInvoke(() => LiftPanel.Location = new Point(LiftPanel.Location.X, targetY));

                CurrentFloor = targetFloor;
                CurrentDirection = "STOP";
                CurrentStatus = "ARRIVED";
                UpdateFloorDisplay();
                UpdateStatus("Arrived");
                UpdateDirectionDisplay();
                UpdateDisplay();
                UpdateLights();

                // Auto open doors after arrival
                if (isMoving)
                {
                    await AutoOpenDoors();
                }

                isMoving = false;
            }
            catch (Exception ex)
            {
                LogOperation($"Movement error: {ex.Message}", CurrentFloor);
                isMoving = false;
                CurrentDirection = "STOP";
                CurrentStatus = "ERROR";
                UpdateDirectionDisplay();
                UpdateDisplay();
                UpdateLights();
                SetState(new IdleState());
            }
        }

        private async Task AutoOpenDoors()
        {
            try
            {
                // Auto open doors
                await AnimateDoors(true);
                SetState(new DoorOpenState());
                CurrentStatus = "DOOR OPEN";
                UpdateDisplay();
                UpdateLights();

                // Wait 3 seconds then auto close
                await Task.Delay(3000);

                if (_state is DoorOpenState)
                {
                    await AnimateDoors(false);
                    SetState(new DoorClosedState());
                    CurrentStatus = "READY";
                    UpdateDisplay();
                    UpdateLights();
                }
            }
            catch (Exception ex)
            {
                LogOperation($"Auto door error: {ex.Message}", CurrentFloor);
            }
        }

        private void SafeInvoke(Action action)
        {
            try
            {
                if (LiftPanel.InvokeRequired)
                {
                    LiftPanel.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SafeInvoke error: {ex.Message}");
            }
        }

        private async Task AnimateDoors(bool open)
        {
            try
            {
                int doorWidth = LiftPanel.Width / 2;
                int maxOffset = doorWidth / 2;
                int stepSize = maxOffset / DoorSteps;

                for (int i = 0; i <= DoorSteps; i++)
                {
                    int offset = stepSize * i;

                    SafeInvoke(() =>
                    {
                        if (open)
                        {
                            DoorLeft.Location = new Point(-offset-25, 0);
                            DoorRight.Location = new Point(doorWidth + offset + 20, 0);
                        }
                        else
                        {
                            DoorLeft.Location = new Point(-maxOffset + offset + 10, 0);
                            DoorRight.Location = new Point(doorWidth + maxOffset - offset - 10, 0);
                        }
                    });
                    await Task.Delay(DoorDelay);
                }
            }
            catch (Exception ex)
            {
                LogOperation($"Door animation error: {ex.Message}", CurrentFloor);
            }
        }

        public async void OpenDoor()
        {
            if (!isMoving)
            {
                await AnimateDoors(true);
                SetState(new DoorOpenState());
                CurrentStatus = "DOOR OPEN";
                UpdateDisplay();
                UpdateLights();
                LogOperation("Door opened", CurrentFloor);
            }
            else
            {
                MessageBox.Show("Cannot open door while moving!", "Safety Warning");
            }
        }

        public async void CloseDoor()
        {
            if (!isMoving)
            {
                await AnimateDoors(false);
                SetState(new DoorClosedState());
                CurrentStatus = "READY";
                UpdateDisplay();
                UpdateLights();
                LogOperation("Door closed", CurrentFloor);
            }
            else
            {
                MessageBox.Show("Cannot close door while moving!", "Safety Warning");
            }
        }

        private void UpdateLights()
        {
            try
            {
                if (LightPanel != null)
                {
                    SafeInvoke(() =>
                    {
                        if (_state is DoorOpenState)
                        {
                            LightPanel.BackColor = Color.LightGreen;
                        }
                        else if (_state is MovingState)
                        {
                            LightPanel.BackColor = Color.Yellow;
                        }
                        else
                        {
                            LightPanel.BackColor = Color.White;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Light update error: {ex.Message}");
            }
        }

        public void LogOperation(string operation, int floor)
        {
            try
            {
                if (!logWorker.IsBusy)
                {
                    logWorker.RunWorkerAsync(new LogData { Operation = operation, Floor = floor });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Log error: {ex.Message}");
            }
        }

        public void LoadLogs()
        {
            try
            {
                if (!logWorker.IsBusy)
                {
                    logWorker.RunWorkerAsync(new LogData { LoadLogs = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading logs: {ex.Message}", "Elevator Control");
            }
        }

        public void ClearLogs()
        {
            try
            {
                if (!logWorker.IsBusy)
                {
                    logWorker.RunWorkerAsync(new LogData { ClearLogs = true });
                }
                MessageBox.Show("Logs cleared successfully!", "Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing logs: {ex.Message}", "Elevator Control");
            }
        }

        private void LogWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var logData = e.Argument as LogData;
                if (logData == null) return;

                if (logData.ClearLogs)
                {
                    bool success = DatabaseHelper.ClearLogs();
                    e.Result = new WorkerResult { Success = success, DataTable = DatabaseHelper.GetLogs() };
                }
                else if (logData.LoadLogs)
                {
                    e.Result = new WorkerResult { Success = true, DataTable = DatabaseHelper.GetLogs() };
                }
                else
                {
                    bool success = DatabaseHelper.InsertLog(logData.Operation, logData.Floor);
                    e.Result = new WorkerResult { Success = success, DataTable = DatabaseHelper.GetLogs() };
                }
            }
            catch (Exception ex)
            {
                e.Result = new WorkerResult { Success = false, Error = ex.Message };
            }
        }

        private void LogWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show($"Database Error: {e.Error.Message}", "Elevator Control");
                    return;
                }

                if (e.Result is WorkerResult result)
                {
                    if (result.DataTable != null && LogGrid != null)
                    {
                        SafeInvoke(() =>
                        {
                            LogGrid.DataSource = result.DataTable;
                            LogGrid.ClearSelection();
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing operation: {ex.Message}", "Elevator Control");
            }
        }

        private void UpdateStatus(string status)
        {
            SafeInvoke(() =>
            {
                if (StatusLabel != null)
                    StatusLabel.Text = $"Status: {status}";
            });
        }

        private void UpdateFloorDisplay()
        {
            SafeInvoke(() =>
            {
                if (FloorIndicator != null)
                    FloorIndicator.Text = $"Floor: {(CurrentFloor == 1 ? "G" : "1")}";
            });
        }

        private void UpdateDirectionDisplay()
        {
            SafeInvoke(() =>
            {
                if (DirectionLabel != null)
                {
                    switch (CurrentDirection)
                    {
                        case "UP":
                            DirectionLabel.Text = "▲";
                            DirectionLabel.ForeColor = Color.Green;
                            break;
                        case "DOWN":
                            DirectionLabel.Text = "▼";
                            DirectionLabel.ForeColor = Color.Red;
                            break;
                        default:
                            DirectionLabel.Text = "•";
                            DirectionLabel.ForeColor = Color.Blue;
                            break;
                    }
                }
            });
        }

        private void UpdateDisplay()
        {
            SafeInvoke(() =>
            {
                if (DisplayLabel != null && DisplayFloor != null && DisplayStatus != null)
                {
                    DisplayFloor.Text = $"FLOOR: {(CurrentFloor == 1 ? "G" : "1")}";
                    DisplayStatus.Text = $"STATUS: {CurrentStatus}";

                    switch (CurrentDirection)
                    {
                        case "UP":
                            DisplayLabel.Text = "▲ MOVING ▲";
                            DisplayLabel.ForeColor = Color.Green;
                            break;
                        case "DOWN":
                            DisplayLabel.Text = "▼ MOVING ▼";
                            DisplayLabel.ForeColor = Color.Red;
                            break;
                        default:
                            DisplayLabel.Text = "ELEVATOR";
                            DisplayLabel.ForeColor = Color.Yellow;
                            break;
                    }
                }
            });
        }

        public void EmergencyStop()
        {
            try
            {
                isMoving = false;
                CurrentDirection = "STOP";
                CurrentStatus = "EMERGENCY";
                SetState(new DoorClosedState());
                UpdateStatus("Emergency Stop");
                UpdateDirectionDisplay();
                UpdateDisplay();
                UpdateLights();
                LogOperation("EMERGENCY STOP ACTIVATED", CurrentFloor);
                MessageBox.Show("Emergency stop activated!", "Emergency Stop");
            }
            catch (Exception ex)
            {
                LogOperation($"Emergency stop error: {ex.Message}", CurrentFloor);
            }
        }
    }

    public class LogData
    {
        public string Operation { get; set; }
        public int Floor { get; set; }
        public bool LoadLogs { get; set; }
        public bool ClearLogs { get; set; }
    }

    public class WorkerResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public DataTable DataTable { get; set; }
    }
}