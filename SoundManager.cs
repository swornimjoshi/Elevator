using System;
using System.Media;
using System.IO;
using System.Windows.Forms;

namespace ElevatorControlSystem
{
    public static class SoundManager
    {
        private static SoundPlayer doorOpenSound;
        private static SoundPlayer doorCloseSound;
        private static SoundPlayer movingSound;
        private static SoundPlayer arrivalSound;
        private static SoundPlayer buttonSound;
        private static SoundPlayer emergencySound;
        private static SoundPlayer floorBellSound;

        private static bool soundsEnabled = true;

        static SoundManager()
        {
            try
            {
                // Initialize sounds - using system sounds as fallback
                doorOpenSound = new SoundPlayer();
                doorCloseSound = new SoundPlayer();
                movingSound = new SoundPlayer();
                arrivalSound = new SoundPlayer();
                buttonSound = new SoundPlayer();
                emergencySound = new SoundPlayer();
                floorBellSound = new SoundPlayer();

                // Try to load custom sounds if available, otherwise use system sounds
                LoadSounds();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Sound manager initialization error: {ex.Message}");
            }
        }

        private static void LoadSounds()
        {
            try
            {
                // You can replace these with actual sound files by:
                // doorOpenSound.SoundLocation = @"sounds\door_open.wav";
                // doorOpenSound.LoadAsync();

                // For now, we'll use system sounds
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Sound loading error: {ex.Message}");
            }
        }

        public static void PlayDoorOpen()
        {
            if (!soundsEnabled) return;
            try
            {
                SystemSounds.Beep.Play(); // High beep for door open
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Door open sound error: {ex.Message}");
            }
        }

        public static void PlayDoorClose()
        {
            if (!soundsEnabled) return;
            try
            {
                SystemSounds.Beep.Play(); // Low beep for door close
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Door close sound error: {ex.Message}");
            }
        }

        public static void PlayMoving()
        {
            if (!soundsEnabled) return;
            try
            {
                // Simulate elevator motor sound with multiple beeps
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Moving sound error: {ex.Message}");
            }
        }

        public static void PlayArrival()
        {
            if (!soundsEnabled) return;
            try
            {
                SystemSounds.Asterisk.Play(); // Pleasant sound for arrival
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Arrival sound error: {ex.Message}");
            }
        }

        public static void PlayButtonPress()
        {
            if (!soundsEnabled) return;
            try
            {
                SystemSounds.Beep.Play(); // Short beep for button press
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Button sound error: {ex.Message}");
            }
        }

        public static void PlayEmergency()
        {
            if (!soundsEnabled) return;
            try
            {
                SystemSounds.Hand.Play(); // Alarm sound for emergency
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Emergency sound error: {ex.Message}");
            }
        }

        public static void PlayFloorBell()
        {
            if (!soundsEnabled) return;
            try
            {
                SystemSounds.Question.Play(); // Bell sound for floor arrival
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Floor bell sound error: {ex.Message}");
            }
        }

        public static void ToggleSounds()
        {
            soundsEnabled = !soundsEnabled;
        }

        public static bool AreSoundsEnabled()
        {
            return soundsEnabled;
        }
    }
}