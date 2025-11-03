using System.Drawing;
using System.Windows.Forms;

namespace ElevatorControlSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Main building components
        private System.Windows.Forms.Panel panelBuilding;
        private System.Windows.Forms.Panel panelShaft;
        private System.Windows.Forms.Panel panelLift;
        private System.Windows.Forms.Panel panelDoorLeft;
        private System.Windows.Forms.Panel panelDoorRight;
        private System.Windows.Forms.Panel panelLight;

        // Floor indicators
        private System.Windows.Forms.Label labelFirstFloor;
        private System.Windows.Forms.Label labelGroundFloor;

        // Call buttons
        private System.Windows.Forms.Button btnCallUp;
        private System.Windows.Forms.Button btnCallDown;

        // Control Panel (metallic)
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnControlG;
        private System.Windows.Forms.Button btnControl1;
        private System.Windows.Forms.Button btnControlOpen;
        private System.Windows.Forms.Button btnControlClose;
        private System.Windows.Forms.Label labelControlPanel;
        private System.Windows.Forms.Label labelDirection;

        // Display Components
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.Label displayFloor;
        private System.Windows.Forms.Label displayStatus;

        // Status and info
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelFloor;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.DataGridView dataGridViewLogs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelBuilding = new System.Windows.Forms.Panel();
            this.panelShaft = new System.Windows.Forms.Panel();
            this.panelLift = new System.Windows.Forms.Panel();
            this.panelDoorLeft = new System.Windows.Forms.Panel();
            this.panelDoorRight = new System.Windows.Forms.Panel();
            this.panelLight = new System.Windows.Forms.Panel();
            this.labelFirstFloor = new System.Windows.Forms.Label();
            this.labelGroundFloor = new System.Windows.Forms.Label();
            this.btnCallUp = new System.Windows.Forms.Button();
            this.btnCallDown = new System.Windows.Forms.Button();
            this.panelControl = new System.Windows.Forms.Panel();
            this.labelControlPanel = new System.Windows.Forms.Label();
            this.labelDirection = new System.Windows.Forms.Label();
            this.btnControlG = new System.Windows.Forms.Button();
            this.btnControl1 = new System.Windows.Forms.Button();
            this.btnControlOpen = new System.Windows.Forms.Button();
            this.btnControlClose = new System.Windows.Forms.Button();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.displayLabel = new System.Windows.Forms.Label();
            this.displayFloor = new System.Windows.Forms.Label();
            this.displayStatus = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelFloor = new System.Windows.Forms.Label();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.btnSoundToggle = new System.Windows.Forms.Button();
            this.panelBuilding.SuspendLayout();
            this.panelShaft.SuspendLayout();
            this.panelLift.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBuilding
            // 
            this.panelBuilding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.panelBuilding.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBuilding.Controls.Add(this.panelShaft);
            this.panelBuilding.Controls.Add(this.labelFirstFloor);
            this.panelBuilding.Controls.Add(this.labelGroundFloor);
            this.panelBuilding.Controls.Add(this.btnCallUp);
            this.panelBuilding.Controls.Add(this.btnCallDown);
            this.panelBuilding.Location = new System.Drawing.Point(30, 30);
            this.panelBuilding.Name = "panelBuilding";
            this.panelBuilding.Size = new System.Drawing.Size(314, 572);
            this.panelBuilding.TabIndex = 0;
            this.panelBuilding.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBuilding_Paint);
            // 
            // panelShaft
            // 
            this.panelShaft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelShaft.Controls.Add(this.panelLift);
            this.panelShaft.Location = new System.Drawing.Point(80, 49);
            this.panelShaft.Name = "panelShaft";
            this.panelShaft.Size = new System.Drawing.Size(140, 402);
            this.panelShaft.TabIndex = 0;
            // 
            // panelLift
            // 
            this.panelLift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.panelLift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLift.Controls.Add(this.panelDoorLeft);
            this.panelLift.Controls.Add(this.panelDoorRight);
            this.panelLift.Controls.Add(this.panelLight);
            this.panelLift.Location = new System.Drawing.Point(0, 200);
            this.panelLift.Name = "panelLift";
            this.panelLift.Size = new System.Drawing.Size(140, 200);
            this.panelLift.TabIndex = 0;
            this.panelLift.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelLift_Paint);
            // 
            // panelDoorLeft
            // 
            this.panelDoorLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panelDoorLeft.Location = new System.Drawing.Point(0, 0);
            this.panelDoorLeft.Name = "panelDoorLeft";
            this.panelDoorLeft.Size = new System.Drawing.Size(70, 200);
            this.panelDoorLeft.TabIndex = 0;
            // 
            // panelDoorRight
            // 
            this.panelDoorRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panelDoorRight.Location = new System.Drawing.Point(70, 0);
            this.panelDoorRight.Name = "panelDoorRight";
            this.panelDoorRight.Size = new System.Drawing.Size(70, 200);
            this.panelDoorRight.TabIndex = 1;
            // 
            // panelLight
            // 
            this.panelLight.BackColor = System.Drawing.Color.White;
            this.panelLight.Location = new System.Drawing.Point(10, 10);
            this.panelLight.Name = "panelLight";
            this.panelLight.Size = new System.Drawing.Size(120, 30);
            this.panelLight.TabIndex = 2;
            // 
            // labelFirstFloor
            // 
            this.labelFirstFloor.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstFloor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelFirstFloor.ForeColor = System.Drawing.Color.White;
            this.labelFirstFloor.Location = new System.Drawing.Point(220, 80);
            this.labelFirstFloor.Name = "labelFirstFloor";
            this.labelFirstFloor.Size = new System.Drawing.Size(92, 27);
            this.labelFirstFloor.TabIndex = 1;
            this.labelFirstFloor.Text = "FIRST FLOOR";
            // 
            // labelGroundFloor
            // 
            this.labelGroundFloor.BackColor = System.Drawing.Color.Transparent;
            this.labelGroundFloor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelGroundFloor.ForeColor = System.Drawing.Color.White;
            this.labelGroundFloor.Location = new System.Drawing.Point(220, 380);
            this.labelGroundFloor.Name = "labelGroundFloor";
            this.labelGroundFloor.Size = new System.Drawing.Size(118, 29);
            this.labelGroundFloor.TabIndex = 2;
            this.labelGroundFloor.Text = "GROUND FLOOR";
            // 
            // btnCallUp
            // 
            this.btnCallUp.BackColor = System.Drawing.Color.Gold;
            this.btnCallUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallUp.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnCallUp.ForeColor = System.Drawing.Color.Black;
            this.btnCallUp.Location = new System.Drawing.Point(230, 110);
            this.btnCallUp.Name = "btnCallUp";
            this.btnCallUp.Size = new System.Drawing.Size(40, 40);
            this.btnCallUp.TabIndex = 3;
            this.btnCallUp.Text = "▲";
            this.btnCallUp.UseVisualStyleBackColor = false;
            // 
            // btnCallDown
            // 
            this.btnCallDown.BackColor = System.Drawing.Color.Gold;
            this.btnCallDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallDown.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnCallDown.ForeColor = System.Drawing.Color.Black;
            this.btnCallDown.Location = new System.Drawing.Point(230, 330);
            this.btnCallDown.Name = "btnCallDown";
            this.btnCallDown.Size = new System.Drawing.Size(40, 40);
            this.btnCallDown.TabIndex = 4;
            this.btnCallDown.Text = "▼";
            this.btnCallDown.UseVisualStyleBackColor = false;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.panelControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelControl.Controls.Add(this.labelControlPanel);
            this.panelControl.Controls.Add(this.labelDirection);
            this.panelControl.Controls.Add(this.btnControlG);
            this.panelControl.Controls.Add(this.btnControl1);
            this.panelControl.Controls.Add(this.btnControlOpen);
            this.panelControl.Controls.Add(this.btnControlClose);
            this.panelControl.Location = new System.Drawing.Point(350, 240);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(150, 226);
            this.panelControl.TabIndex = 1;
            this.panelControl.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelControl_Paint);
            // 
            // labelControlPanel
            // 
            this.labelControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.labelControlPanel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelControlPanel.ForeColor = System.Drawing.Color.Black;
            this.labelControlPanel.Location = new System.Drawing.Point(10, 10);
            this.labelControlPanel.Name = "labelControlPanel";
            this.labelControlPanel.Size = new System.Drawing.Size(130, 20);
            this.labelControlPanel.TabIndex = 0;
            this.labelControlPanel.Text = "ELEVATOR CONTROL";
            this.labelControlPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDirection
            // 
            this.labelDirection.BackColor = System.Drawing.Color.Transparent;
            this.labelDirection.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.labelDirection.ForeColor = System.Drawing.Color.Blue;
            this.labelDirection.Location = new System.Drawing.Point(60, 35);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(30, 30);
            this.labelDirection.TabIndex = 1;
            this.labelDirection.Text = "•";
            this.labelDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnControlG
            // 
            this.btnControlG.BackColor = System.Drawing.Color.LightBlue;
            this.btnControlG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControlG.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnControlG.Location = new System.Drawing.Point(16, 75);
            this.btnControlG.Name = "btnControlG";
            this.btnControlG.Size = new System.Drawing.Size(50, 50);
            this.btnControlG.TabIndex = 2;
            this.btnControlG.Text = "G";
            this.btnControlG.UseVisualStyleBackColor = false;
            // 
            // btnControl1
            // 
            this.btnControl1.BackColor = System.Drawing.Color.LightBlue;
            this.btnControl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControl1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnControl1.Location = new System.Drawing.Point(72, 75);
            this.btnControl1.Name = "btnControl1";
            this.btnControl1.Size = new System.Drawing.Size(50, 50);
            this.btnControl1.TabIndex = 3;
            this.btnControl1.Text = "1";
            this.btnControl1.UseVisualStyleBackColor = false;
            // 
            // btnControlOpen
            // 
            this.btnControlOpen.BackColor = System.Drawing.Color.LightGreen;
            this.btnControlOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControlOpen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnControlOpen.Location = new System.Drawing.Point(6, 163);
            this.btnControlOpen.Name = "btnControlOpen";
            this.btnControlOpen.Size = new System.Drawing.Size(60, 40);
            this.btnControlOpen.TabIndex = 4;
            this.btnControlOpen.Text = "◄ ►";
            this.btnControlOpen.UseVisualStyleBackColor = false;
            // 
            // btnControlClose
            // 
            this.btnControlClose.BackColor = System.Drawing.Color.LightCoral;
            this.btnControlClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControlClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnControlClose.Location = new System.Drawing.Point(80, 163);
            this.btnControlClose.Name = "btnControlClose";
            this.btnControlClose.Size = new System.Drawing.Size(60, 40);
            this.btnControlClose.TabIndex = 5;
            this.btnControlClose.Text = "► ◄";
            this.btnControlClose.UseVisualStyleBackColor = false;
            // 
            // panelDisplay
            // 
            this.panelDisplay.BackColor = System.Drawing.Color.Black;
            this.panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDisplay.Controls.Add(this.displayLabel);
            this.panelDisplay.Controls.Add(this.displayFloor);
            this.panelDisplay.Controls.Add(this.displayStatus);
            this.panelDisplay.Location = new System.Drawing.Point(357, 129);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(143, 85);
            this.panelDisplay.TabIndex = 6;
            // 
            // displayLabel
            // 
            this.displayLabel.BackColor = System.Drawing.Color.Transparent;
            this.displayLabel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.displayLabel.ForeColor = System.Drawing.Color.Yellow;
            this.displayLabel.Location = new System.Drawing.Point(5, 5);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(100, 15);
            this.displayLabel.TabIndex = 0;
            this.displayLabel.Text = "ELEVATOR";
            this.displayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // displayFloor
            // 
            this.displayFloor.BackColor = System.Drawing.Color.Transparent;
            this.displayFloor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.displayFloor.ForeColor = System.Drawing.Color.Lime;
            this.displayFloor.Location = new System.Drawing.Point(5, 25);
            this.displayFloor.Name = "displayFloor";
            this.displayFloor.Size = new System.Drawing.Size(100, 15);
            this.displayFloor.TabIndex = 1;
            this.displayFloor.Text = "FLOOR: G";
            this.displayFloor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // displayStatus
            // 
            this.displayStatus.BackColor = System.Drawing.Color.Transparent;
            this.displayStatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.displayStatus.ForeColor = System.Drawing.Color.Cyan;
            this.displayStatus.Location = new System.Drawing.Point(5, 45);
            this.displayStatus.Name = "displayStatus";
            this.displayStatus.Size = new System.Drawing.Size(100, 15);
            this.displayStatus.TabIndex = 2;
            this.displayStatus.Text = "STATUS: IDLE";
            this.displayStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelStatus.Location = new System.Drawing.Point(520, 30);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(200, 20);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Status: Idle";
            // 
            // labelFloor
            // 
            this.labelFloor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelFloor.Location = new System.Drawing.Point(520, 60);
            this.labelFloor.Name = "labelFloor";
            this.labelFloor.Size = new System.Drawing.Size(150, 20);
            this.labelFloor.TabIndex = 3;
            this.labelFloor.Text = "Floor: G";
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.BackColor = System.Drawing.Color.SteelBlue;
            this.btnViewLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLogs.Font = new System.Drawing.Font("Arial", 8F);
            this.btnViewLogs.ForeColor = System.Drawing.Color.White;
            this.btnViewLogs.Location = new System.Drawing.Point(520, 100);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(80, 30);
            this.btnViewLogs.TabIndex = 4;
            this.btnViewLogs.Text = "View Logs";
            this.btnViewLogs.UseVisualStyleBackColor = false;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.BackColor = System.Drawing.Color.Orange;
            this.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLogs.Font = new System.Drawing.Font("Arial", 8F);
            this.btnClearLogs.ForeColor = System.Drawing.Color.White;
            this.btnClearLogs.Location = new System.Drawing.Point(610, 100);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(80, 30);
            this.btnClearLogs.TabIndex = 5;
            this.btnClearLogs.Text = "Clear Log";
            this.btnClearLogs.UseVisualStyleBackColor = false;
            // 
            // btnEmergency
            // 
            this.btnEmergency.BackColor = System.Drawing.Color.Red;
            this.btnEmergency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmergency.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnEmergency.ForeColor = System.Drawing.Color.White;
            this.btnEmergency.Location = new System.Drawing.Point(700, 100);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(100, 30);
            this.btnEmergency.TabIndex = 6;
            this.btnEmergency.Text = "EMERGENCY";
            this.btnEmergency.UseVisualStyleBackColor = false;
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.AllowUserToAddRows = false;
            this.dataGridViewLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLogs.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLogs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLogs.ColumnHeadersHeight = 46;
            this.dataGridViewLogs.Font = new System.Drawing.Font("Arial", 9F);
            this.dataGridViewLogs.Location = new System.Drawing.Point(520, 140);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.ReadOnly = true;
            this.dataGridViewLogs.RowHeadersVisible = false;
            this.dataGridViewLogs.RowHeadersWidth = 82;
            this.dataGridViewLogs.Size = new System.Drawing.Size(500, 350);
            this.dataGridViewLogs.TabIndex = 7;
            // 
            // btnSoundToggle
            // 
            this.btnSoundToggle.BackColor = System.Drawing.Color.LightGreen;
            this.btnSoundToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoundToggle.Font = new System.Drawing.Font("Arial", 8F);
            this.btnSoundToggle.Location = new System.Drawing.Point(820, 100);
            this.btnSoundToggle.Name = "btnSoundToggle";
            this.btnSoundToggle.Size = new System.Drawing.Size(100, 25);
            this.btnSoundToggle.TabIndex = 8;
            this.btnSoundToggle.Text = "🔊 Sounds ON";
            this.btnSoundToggle.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1187, 636);
            this.Controls.Add(this.panelBuilding);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelFloor);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.btnClearLogs);
            this.Controls.Add(this.btnEmergency);
            this.Controls.Add(this.dataGridViewLogs);
            this.Controls.Add(this.btnSoundToggle);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Realistic Elevator Control System - Complete Functionality";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelBuilding.ResumeLayout(false);
            this.panelShaft.ResumeLayout(false);
            this.panelLift.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            this.ResumeLayout(false);

        }
    }
}