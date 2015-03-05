/*
 * This is a hack for league of legends I threw together.
 * This code is old and hacky. Beware.
 * Use at will.
 * -Chris Caruso
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;
using System.IO;

namespace ChampSelector
{

    public partial class ChampSelect : Form
    {

        

        #region DllImports
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();
        #endregion

        #region Private Variables
        const string processName = "LoLClient";
        Point mouseLocation;
        InputSimulator inputSim;
        Size screenSize;
        Process lolProcess;
        RECT rect;
        bool gameStarted;
        bool acceptedGame;
        KeyboardHook startStopHotKeyHook;
        KeyboardHook forceRunHotKeyHook;
        KeyboardHook randomLockInHotKeyHook;
        bool run;
        Thread watcherThread;
        bool justClosed;
        bool justStarted;
        bool hasBeenClosed;
        Icon runningIcon;
        Icon stoppedIcon;
        Random random;
        string savePath;
        string settingsFilename;
        int autoSaveDelay;
        bool autoSaving;
        bool checkForGameAccept;

        int clientCheckFreq;
        int initialDelay;
        int sendChatMessageDelay;
        int lockInDelay;
        int pickChampionDelay;

        int totalTime;

        string[] champions = new string[] 
        {
            "Aatrox",
            "Ahri",
"Akali",
"Alistar",
"Amumu",
"Anivia",
"Annie",
"Ashe",
"Blitzcrank",
"Brand",
"Caitlyn",
"Cassiopeia",
"Cho'Gath",
"Corki",
"Darius",
"Diana",
"Dr. Mundo",
"Draven",
"Elise",
"Evelynn",
"Ezreal",
"Fiddlesticks",
"Fiora",
"Fizz",
"Galio",
"Gangplank",
"Garen",
"Gragas",
"Graves",
"Hecarim",
"Heimerdinger",
"Irelia",
"Janna",
"Jarvan IV",
"Jax",
"Jayce",
"Jinx",
"Karma",
"Karthus",
"Kassadin",
"Katarina",
"Kayle",
"Kennen",
"Kha'Zix",
"Kog'Maw",
"LeBlanc",
"Lee Sin",
"Leona",
"Lissandra",
"Lucian",
"Lulu",
"Lux",
"Malphite",
"Malzahar",
"Maokai",
"Master Yi",
"Miss Fortune",
"Mordekaiser",
"Morgana",
"Nami",
"Nasus",
"Nautilus",
"Nidalee",
"Nocturne",
"Nunu",
"Olaf",
"Orianna",
"Pantheon",
"Poppy",
"Quinn",
"Rammus",
"Renekton",
"Rengar",
"Riven",
"Rumble",
"Ryze",
"Sejuani",
"Shaco",
"Shen",
"Shyvana",
"Singed",
"Sion",
"Sivir",
"Skarner",
"Sona",
"Soraka",
"Swain",
"Syndra",
"Talon",
"Taric",
"Teemo",
"Thresh",
"Tristana",
"Trundle",
"Tryndamere",
"Twisted Fate",
"Twitch",
"Udyr",
"Urgot",
"Varus",
"Vayne",
"Veigar",
"Vi",
"Viktor",
"Vladimir",
"Volibear",
"Warwick",
"Wukong",
"Xerath",
"Xin Zhao",
"Yorick",
"Zac",
"Zed",
"Ziggs",
"Zilean",
"Zyra"
        };
        #endregion

        public ChampSelect()
        {
            
                
            InitializeComponent();
            mouseLocation = MousePosition;
            inputSim = new InputSimulator();
            screenSize = Screen.PrimaryScreen.Bounds.Size;
            startStopHotKeyHook = new KeyboardHook();
            startStopHotKeyHook.RegisterHotKey(ChampSelector.ModifierKeys.Control, Keys.S);
            startStopHotKeyHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(StartStopHotKeyPressed);
            forceRunHotKeyHook = new KeyboardHook();
            forceRunHotKeyHook.RegisterHotKey(ChampSelector.ModifierKeys.Control, Keys.A);
            forceRunHotKeyHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(ForceRunHotKeyPressed);
            randomLockInHotKeyHook = new KeyboardHook();
            randomLockInHotKeyHook.RegisterHotKey(ChampSelector.ModifierKeys.Control, Keys.R);
            randomLockInHotKeyHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(RandomLockInHotKeyPressed);
            run = false;
            clientCheckFreq = 1;
            sendChatMessageDelay = 300;
            lockInDelay = 400;
            initialDelay = 1750;
            watcherThread = new Thread(new ThreadStart(Watcher));
            stoppedIcon = Properties.Resources.injectionorange;
            runningIcon = Properties.Resources.injectiongreen;
            hasBeenClosed = true;
            for (int i = 0; i < champions.Length; i++)
            {
                championsComboBox.Items.Add(champions[i]);
                limitChampionsCheckedListBox.Items.Add(champions[i]);
            }
            championsComboBox.SelectedIndex = 0;
            random = new Random(((DateTime.Now.Millisecond + 1) * (DateTime.Now.Minute + 1)) + ((DateTime.Now.Millisecond + 1) % ((DateTime.Now.Minute + 1) / (DateTime.Now.Second + 1) + 1)) - DateTime.Now.Hour);
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ChampSelector\\";
            settingsFilename = "settings.dat";
            autoSaveDelay = 5000;
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            else
                LoadFromSave();
        }

        #region Form Events
        private void ChampSelect_Load(object sender, EventArgs e)
        {
            CheckForLoLClient();
            watcherThread.Start();
        }

        private void ChampSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Save();
        }

        private void ChampSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
            notifyIcon.ShowBalloonTip(100, "ChampSelector", "I'm down here now!", ToolTipIcon.Info);
        }

        private void initialDelayTrackBar_Scroll(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this.initialDelayTrackBar, initialDelayTrackBar.Value.ToString());
            initialDelay = this.initialDelayTrackBar.Value;
            AutoSave();
        }

        private void clientCheckFreqTrackBar_Scroll(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this.clientCheckFreqTrackBar, clientCheckFreqTrackBar.Value.ToString());
            clientCheckFreq = this.clientCheckFreqTrackBar.Value;
            AutoSave();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            run = false;
        }

        private void randomLockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lolProcess != null && !lolProcess.HasExited)
            {
                SetForegroundWindow(lolProcess.MainWindowHandle);
                GetWindowRect(lolProcess.MainWindowHandle, ref rect);
                RandomPick();
                LockIn();
            }
        }

        private void sendChatDelayTrackBar_Scroll(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this.sendChatDelayTrackBar, sendChatDelayTrackBar.Value.ToString());
            sendChatMessageDelay = sendChatDelayTrackBar.Value;
            AutoSave();
        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            StartStop();
            AutoSave();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Maximized;
                SetForegroundWindow(this.Handle);
                this.Show();
            }
        }

        private void selectChampionDelayTrackBar_Scroll(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this.selectChampionDelayTrackBar, selectChampionDelayTrackBar.Value.ToString());
            pickChampionDelay = selectChampionDelayTrackBar.Value;
            AutoSave();
        }

        private void lockInDelayTrackBar_Scroll(object sender, EventArgs e)
        {
            this.toolTip.SetToolTip(this.lockInDelayTrackBar, lockInDelayTrackBar.Value.ToString());
            lockInDelay = lockInDelayTrackBar.Value;
            AutoSave();
        }

        private void randompickCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                limitedRandomPickCheckBox.Checked = false;
                pickChampionCheckBox.Checked = false;
                AutoSave();
            }
        }

        private void limitedRandomPickCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                randompickCheckBox.Checked = false;
                pickChampionCheckBox.Checked = false;
                AutoSave();
            }
        }

        private void pickChampionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                randompickCheckBox.Checked = false;
                limitedRandomPickCheckBox.Checked = false;
                AutoSave();
            }
        }

        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            watcherThread.Abort();
            startStopHotKeyHook.Dispose();
            Save();
            Application.ExitThread();
            Application.Exit();
        }

        private void sendChatMessageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoSave();
        }

        private void sendChatMessageTextBox_TextChanged(object sender, EventArgs e)
        {
            AutoSave();
        }

        private void championsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoSave();
        }

        private void limitChampionsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoSave();
        }

        private void lockInCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoSave();
        }

        private void acceptGameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoSave();
            checkForGameAccept = acceptGameCheckBox.Checked;
        }
        #endregion

        #region HotKey Events
        private void StartStopHotKeyPressed(object sender, KeyPressedEventArgs e)
        {
            StartStop();
        }

        private void ForceRunHotKeyPressed(object sender, KeyPressedEventArgs e)
        {
            PerformRoutine();
        }

        private void RandomLockInHotKeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (lolProcess != null && !lolProcess.HasExited)
            {
                SetForegroundWindow(lolProcess.MainWindowHandle);
                GetWindowRect(lolProcess.MainWindowHandle, ref rect);
                RandomPick();
                LockIn();
            }
        }
        #endregion

        #region Utilities
        private void AutoSave()
        {
            autoSaveDelay = 5;
            if (!autoSaving)
            {
                Thread autoSaveThread = new Thread(new ThreadStart(AutoSaveHolder));
                autoSaveThread.Start();
            }
        }
        private void AutoSaveHolder()
        {
            bool go = true;
            autoSaving = true;
            while (go)
            {
                if (autoSaveDelay <= 0)
                {
                    if (this.InvokeRequired)
                        this.Invoke(new Action(Save), null);
                    else
                        Save();
                    go = false;
                    autoSaving = false;
                }
                else
                {
                    autoSaveDelay -= 1;
                    Thread.Sleep(1000);
                }
            }
        }

        private void Watcher()
        {
            while (true)
            {
                if (lolProcess != null && !lolProcess.HasExited)
                {
                    if (justStarted)
                    {
                        justStarted = false;
                        hasBeenClosed = false;
                    }
                    if (run && (int)lolProcess.MainWindowHandle == GetForegroundWindow())
                    {
                        GetWindowRect(lolProcess.MainWindowHandle, ref rect);
                        if (rect.Width - rect.X >= 1024 && rect.Height - rect.Y >= 640)
                        {
                            if (checkForGameAccept)
                                CheckForAccept();
                            CheckForGame();
                        }
                    }
                }
                else
                    CheckForLoLClient();
                Thread.Sleep(clientCheckFreq);
            }
        }

        private void CheckForGame()
        {
            Color pixel = GetPixelColor(
                    (int)((0.746646795827124 * (rect.Width - rect.X)) + rect.X),
                    (int)((0.170441001191895 * (rect.Height - rect.Y)) + rect.Y));

            if ((pixel.R == 255 && pixel.G == 255 && pixel.B == 255))
            {
                if (!gameStarted)
                {
                    totalTime = 0;
                    Thread.Sleep(initialDelay);
                    totalTime += initialDelay;
                    if (this.InvokeRequired)
                        this.Invoke(new PerformRoutineDel(PerformRoutine), null);
                    else
                        PerformRoutine();
                    gameStarted = true;
                }
            }
            else
                gameStarted = false;
        }

        private void CheckForAccept()
        {
            Color pixel = GetPixelColor(
                    (int)((0.49375 * (rect.Width - rect.X)) + rect.X),
                    (int)((0.51375 * (rect.Height - rect.Y)) + rect.Y));
            
            if (!acceptedGame && (pixel.R == 255 && pixel.G == 255 && pixel.B == 255))
            {
                AcceptGame();
                acceptedGame = true;
            }
            else
            {
                acceptedGame = (pixel.R == 255 && pixel.G == 255 && pixel.B == 255);
            }
        }

        delegate void PerformRoutineDel();
        private void PerformRoutine()
        {
            if (acceptGameCheckBox.Checked)
                CheckForAccept();

            if (sendChatMessageCheckBox.Checked)
                SendChatMessage(sendChatMessageTextBox.Text);
                
            if (pickChampionCheckBox.Checked)
                PickChampion((string)championsComboBox.SelectedItem);
            else if (randompickCheckBox.Checked)
            {
                Thread.Sleep(pickChampionDelay);
                totalTime += pickChampionDelay;
                RandomPick();
            }
            else if (limitedRandomPickCheckBox.Checked)
            {
                var checkedChampions = limitChampionsCheckedListBox.CheckedItems;
                if (checkedChampions.Count > 0)
                {
                    PickChampion((string)checkedChampions[random.Next(0, checkedChampions.Count - 1)]);
                }
            }

            if ((pickChampionCheckBox.Checked || randompickCheckBox.Checked || limitedRandomPickCheckBox.Checked) && lockInCheckBox.Checked)
                LockIn();
                    
        }

        private void CheckForLoLClient()
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                lolProcess = processes[0];
                if (!justStarted && hasBeenClosed)
                {
                    justStarted = true;
                    NotifyStatus();
                }
            }
            else if (!justClosed && !hasBeenClosed)
            {
                justClosed = true;
                NotifyStatus();
            }
            else if (justClosed)
            {
                justClosed = false;
                hasBeenClosed = true;
            }
        }

        private void MoveMouseAdjusted(double x, double y)
        {
            MoveMouseAbsolute(x * (rect.Width - rect.X) + rect.X, y * (rect.Height - rect.Y) + rect.Y);
        }

        private void MoveMouseAbsolute(double x, double y)
        {
            inputSim.Mouse.MoveMouseTo(((double)x / screenSize.Width) * 65535, ((double)y / screenSize.Height) * 65535);
            
        }

        public Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                         (int)(pixel & 0x0000FF00) >> 8,
                         (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        const int MINSENDCHATTIME = 550;
        private void SendChatMessage(string message)
        {
            if (message != "")
            {
                Thread.Sleep(sendChatMessageDelay);
                totalTime += sendChatMessageDelay;
                if (totalTime < MINSENDCHATTIME)
                    Thread.Sleep(MINSENDCHATTIME - totalTime);
                MoveMouseAdjusted(0.23203125, 0.92125); //Chat Box
                inputSim.Mouse.LeftButtonDoubleClick();       //Enable Text Field
                inputSim.Keyboard.TextEntry(message);   //Enter Message
                inputSim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN); //Hit Enter to send message
            }
        }

        private void PickChampion(string name)
        {
            if (name != "")
            {
                Thread.Sleep(pickChampionDelay);
                totalTime += pickChampionDelay;
                MoveMouseAdjusted(0.697769732078204, 0.166859791425261); //Champion Search Text Box
                inputSim.Mouse.LeftButtonDoubleClick();
                Thread.Sleep(10);
                totalTime += 10;
                inputSim.Keyboard.TextEntry(name);
                Thread.Sleep(700);
                totalTime += 700;
                MoveMouseAdjusted(0.252715423606083, 0.258400926998841); //Click on 1st search result
                inputSim.Mouse.LeftButtonDoubleClick();
            }
        }

        private void LockIn()
        {
            Thread.Sleep(lockInDelay);
            totalTime += lockInDelay;
            MoveMouseAdjusted(0.674873280231716, 0.632676709154114); //Lock in button
            inputSim.Mouse.LeftButtonDoubleClick();
        }

        private void RandomPick()
        {
            MoveMouseAdjusted(0.252715423606083, 0.258400926998841); //Click on 1st search result
            inputSim.Mouse.LeftButtonDoubleClick();
        }

        private void AcceptGame()
        {
            MoveMouseAdjusted(0.4234375, 0.5575); //Accept button
            inputSim.Mouse.LeftButtonDoubleClick();
        }

        private void NotifyStatus()
        {
            notifyIcon.ShowBalloonTip(500,
                "ChampSelector",
                (run && lolProcess != null && !lolProcess.HasExited ? "Started" : "Stopped") +
                (run && justClosed ? " because LoLClient is closed" : (run && justStarted ? " because LoLClient is now open" : "")),
                ToolTipIcon.Info);
            notifyIcon.Text = (run ? "Running" : "Stopped");
            if (run && lolProcess != null && !lolProcess.HasExited)
            {
                this.Invoke(new SetIconSafeDel(SetIconSafe), new object[] { runningIcon });
                notifyIcon.Icon = runningIcon;
            }
            else
            {
                this.Invoke(new SetIconSafeDel(SetIconSafe), new object[] { stoppedIcon });
                notifyIcon.Icon = stoppedIcon;
            }

        }

        delegate void SetIconSafeDel(Icon icon);
        private void SetIconSafe(Icon icon)
        {
            this.Icon = icon;
        }

        private void StartStop()
        {
            run = !run;
            if (run)
                startStopButton.Text = "Stop (Ctrl + S)";
            else
                startStopButton.Text = "Start (Ctrl + S)";
            NotifyStatus();
        }

        private void Save()
        {
            StringBuilder sB = new StringBuilder();
            sB.Append(clientCheckFreqTrackBar.Value + "|");
            sB.Append(initialDelayTrackBar.Value + "|");
            sB.Append(sendChatMessageCheckBox.Checked ? "1|" : "0|");
            sB.Append(sendChatMessageTextBox.Text + "|");
            sB.Append(sendChatDelayTrackBar.Value + "|");
            sB.Append(pickChampionCheckBox.Checked ? "1|" : "0|");
            sB.Append((string)championsComboBox.SelectedItem + "|");
            sB.Append(randompickCheckBox.Checked ? "1|" : "0|");
            sB.Append(limitedRandomPickCheckBox.Checked ? "1|" : "0|");
            var checkedChamps = limitChampionsCheckedListBox.CheckedItems;
            for (int i = 0; i < checkedChamps.Count - 1; i++)
                sB.Append((string)checkedChamps[i] + ",");
            if (checkedChamps.Count > 0)
                sB.Append((string)checkedChamps[checkedChamps.Count - 1] + "|");
            else
                sB.Append("|");
            sB.Append(selectChampionDelayTrackBar.Value + "|");
            sB.Append(lockInCheckBox.Checked ? "1|" : "0|");
            sB.Append(lockInDelayTrackBar.Value + "|");
            sB.Append(run ? "1|" : "0|");
            sB.Append(checkForGameAccept ? "1" : "0");
            File.WriteAllText(savePath + settingsFilename, sB.ToString());
        }

        private void LoadFromSave()
        {
            if (File.Exists(savePath + settingsFilename))
            {
                string[] settings = File.ReadAllText(savePath + settingsFilename).Split('|');
                if (settings.Length >= 14)
                {
                    autoSaving = true;
                    int temp0 = int.Parse(settings[0]);
                    clientCheckFreqTrackBar.Value = temp0;
                    clientCheckFreq = temp0;
                    int temp1 = int.Parse(settings[1]);
                    initialDelayTrackBar.Value = temp1;
                    initialDelay = temp1;
                    sendChatMessageCheckBox.Checked = settings[2] == "1";
                    sendChatMessageTextBox.Text = settings[3];
                    int temp3 = int.Parse(settings[4]);
                    sendChatDelayTrackBar.Value = temp3;
                    sendChatMessageDelay = temp3;
                    pickChampionCheckBox.Checked = settings[5] == "1";
                    for (int i = 0; i < champions.Length; i++)
                        if (champions[i] == settings[6])
                            championsComboBox.SelectedIndex = i;
                    randompickCheckBox.Checked = settings[7] == "1";
                    limitedRandomPickCheckBox.Checked = settings[8] == "1";
                    if (settings[9] != "")
                    {
                        string[] temp4 = settings[9].Split(',');
                        for (int i = 0; i < temp4.Length; i++)
                            for (int j = 0; j < champions.Length; j++)
                                if (champions[j] == temp4[i])
                                {
                                    limitChampionsCheckedListBox.SetItemChecked(j, true);
                                    break;
                                }
                    }
                    int temp5 = int.Parse(settings[10]);
                    selectChampionDelayTrackBar.Value = temp5;
                    pickChampionDelay = temp5;
                    lockInCheckBox.Checked = settings[11] == "1";
                    int temp6 = int.Parse(settings[12]);
                    lockInDelayTrackBar.Value = temp6;
                    lockInDelay = temp6;
                    run = settings[13] == "1";
                    if (run)
                        startStopButton.Text = "Stop (Ctrl + S)";
                    if (settings.Length >= 15)
                        checkForGameAccept = acceptGameCheckBox.Checked = settings[14] == "1";
                    autoSaving = false;
                }
            }
        }
        #endregion

        
    }
}