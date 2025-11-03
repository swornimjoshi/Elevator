using System;
using System.Drawing;
using System.Windows.Forms;

namespace ElevatorControlSystem
{
    public partial class MainForm : Form
    {
        private Elevator elevator;
        private Button btnSoundToggle;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            elevator = new Elevator
            {
                LiftPanel = panelLift,
                DoorLeft = panelDoorLeft,
                DoorRight = panelDoorRight,
                StatusLabel = labelStatus,
                FloorIndicator = labelFloor,
                DirectionLabel = labelDirection,
                LogGrid = dataGridViewLogs,
                BtnControlG = btnControlG,
                BtnControl1 = btnControl1,
                BtnControlOpen = btnControlOpen,
                BtnControlClose = btnControlClose,
                DisplayLabel = displayLabel,
                DisplayFloor = displayFloor,
                DisplayStatus = displayStatus,
                LightPanel = panelLight,
                BtnCallUp = btnCallUp,
                BtnCallDown = btnCallDown
            };

            elevator.InitializeShaft(panelShaft.Top, panelShaft.Bottom, panelLift.Height);
            elevator.LoadLogs();

            // Assign control panel button events with sound
            btnControlG.Click += (s, ev) => { SoundManager.PlayButtonPress(); elevator.MoveToFloor(1); };
            btnControl1.Click += (s, ev) => { SoundManager.PlayButtonPress(); elevator.MoveToFloor(2); };
            btnControlOpen.Click += (s, ev) => elevator.OpenDoor();
            btnControlClose.Click += (s, ev) => elevator.CloseDoor();

            // Assign call button events with sound
            btnCallUp.Click += (s, ev) => { SoundManager.PlayButtonPress(); elevator.MoveToFloor(2); };
            btnCallDown.Click += (s, ev) => { SoundManager.PlayButtonPress(); elevator.MoveToFloor(1); };

            // Assign other buttons
            btnViewLogs.Click += (s, ev) => elevator.LoadLogs();
            btnClearLogs.Click += (s, ev) => elevator.ClearLogs();
            btnEmergency.Click += (s, ev) => elevator.EmergencyStop();

            // Add sound toggle button
            AddSoundToggleButton();
        }

        private void AddSoundToggleButton()
        {
            btnSoundToggle = new Button();
            btnSoundToggle.Text = "🔊 Sounds ON";
            btnSoundToggle.Size = new Size(100, 25);
            btnSoundToggle.Location = new Point(820, 100);
            btnSoundToggle.BackColor = Color.LightGreen;
            btnSoundToggle.FlatStyle = FlatStyle.Flat;
            btnSoundToggle.Font = new Font("Arial", 8);
            btnSoundToggle.Click += (s, ev) => ToggleSounds();

            this.Controls.Add(btnSoundToggle);
        }

        private void ToggleSounds()
        {
            SoundManager.ToggleSounds();
            if (SoundManager.AreSoundsEnabled())
            {
                btnSoundToggle.Text = "🔊 Sounds ON";
                btnSoundToggle.BackColor = Color.LightGreen;
                SoundManager.PlayButtonPress(); // Play sound to confirm
            }
            else
            {
                btnSoundToggle.Text = "🔇 Sounds OFF";
                btnSoundToggle.BackColor = Color.LightCoral;
            }
        }

        // [Rest of the painting methods remain the same...]
        private void PanelBuilding_Paint(object sender, PaintEventArgs e)
        {
            DrawBrickWall(e.Graphics, panelBuilding.ClientRectangle);
        }

        private void PanelLift_Paint(object sender, PaintEventArgs e)
        {
            DrawMetallicFinish(e.Graphics, panelLift.ClientRectangle, Color.FromArgb(200, 200, 200), Color.FromArgb(120, 120, 120));
        }

        private void PanelControl_Paint(object sender, PaintEventArgs e)
        {
            DrawMetallicFinish(e.Graphics, panelControl.ClientRectangle, Color.FromArgb(180, 180, 180), Color.FromArgb(100, 100, 100));
        }

        private void DrawBrickWall(Graphics g, Rectangle rect)
        {
            int brickWidth = 40;
            int brickHeight = 20;
            Color brickColor = Color.FromArgb(180, 60, 60);
            Color mortarColor = Color.FromArgb(150, 80, 80);

            using (SolidBrush mortarBrush = new SolidBrush(mortarColor))
            {
                g.FillRectangle(mortarBrush, rect);
            }

            using (SolidBrush brickBrush = new SolidBrush(brickColor))
            using (Pen brickPen = new Pen(Color.FromArgb(120, 40, 40), 1))
            {
                for (int y = rect.Top; y < rect.Bottom; y += brickHeight)
                {
                    bool offset = ((y - rect.Top) / brickHeight) % 2 == 1;
                    int startX = offset ? rect.Left - brickWidth / 2 : rect.Left;

                    for (int x = startX; x < rect.Right; x += brickWidth)
                    {
                        Rectangle brickRect = new Rectangle(x, y, brickWidth, brickHeight);
                        if (rect.IntersectsWith(brickRect))
                        {
                            g.FillRectangle(brickBrush, brickRect);
                            g.DrawRectangle(brickPen, brickRect);
                        }
                    }
                }
            }
        }

        private void DrawMetallicFinish(Graphics g, Rectangle rect, Color lightColor, Color darkColor)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect, lightColor, darkColor, 45f))
            {
                g.FillRectangle(brush, rect);
            }

            using (Pen highlightPen = new Pen(Color.FromArgb(100, 255, 255, 255), 2))
            {
                g.DrawRectangle(highlightPen, rect);
            }
        }
    }
}