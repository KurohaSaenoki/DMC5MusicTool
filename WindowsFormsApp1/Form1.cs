using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainWindow : Form
    {
        public byte[] StreamingFileText;
        public byte[] OffsetFileText;
        public byte[] LoopsFileText;
        public string StreamingPath = "";
        public string OffsetPath = "";
        public string LoopsPath = "";
        public bool isStreamCorrect = false;
        public bool isOffsetCorrect = false;
        public bool isLoopsCorrect = false;
        public bool StreamingAKPK = false;
        public bool StreamingRIFF = false;
        public bool OffsetAKPK = false;
        public bool OffsetRIFF = false;
        public bool LoopsBKHD = false;
        public List<byte> StreamingArray = new List<byte>();
        public string StreamingMessageBox = "";
        public double NegativeStart = 0;
        public double Start = 0;
        public double NegativeAfterA = 0;
        public double Length = 0;
        public double SizeofA = 0;
        public double NegativeSizeofA = 0;
        public double NegativeAfterB = 0;
        public double SizeofB = 0;
        public int WEMIDCountFileChecker = 0;
        public int WEMIDCount = 0;
        public int HOIDCount = 0;
        public int FilesSavedCount = 0;
        public bool LoopsFileSaved = false;
        public bool HowToUseBool = false;
        public bool PublicEnemyBool = false;
        
    public MainWindow()
        {
            InitializeComponent();
            WEMComboBox.Text = "";
            StartNumeric.Text = "";
            LoopStartNumeric.Text = "";
            LoopEndNumeric.Text = "";
            LengthNumeric.Text = "";
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;
            SaveAsButton.Enabled = false;
            WEMLabel.Enabled = false;
            WEMComboBox.Enabled = false;
            StartLabel.Enabled = false;
            StartNumeric.Enabled = false;
            LoopStartLabel.Enabled = false;
            LoopStartNumeric.Enabled = false;
            LoopEndLabel.Enabled = false;
            LoopEndNumeric.Enabled = false;
            LengthLabel.Enabled = false;
            LengthNumeric.Enabled = false;
            SectionCheckbox.Enabled = false;
            WEMIDCountFileChecker = 0;
            WEMIDCount = 0;
            HOIDCount = 0;

            NegativeStart = 0;
            Start = 0;
            NegativeAfterA = 0;
            Length = 0;
            SizeofA = 0;
            NegativeSizeofA = 0;
            NegativeAfterB = 0;
            SizeofB = 0;

            WEMComboBox.Text = "";
            StartNumeric.Text = "";
            LoopStartNumeric.Text = "";
            LoopEndNumeric.Text = "";
            LengthNumeric.Text = "";

            SectionCheckbox.Checked = false;

            StreamingAKPK = false;
            StreamingRIFF = false;
            isStreamCorrect = false;
            OffsetAKPK = false;
            OffsetRIFF = false;
            isOffsetCorrect = false;
            LoopsBKHD = false;
            isLoopsCorrect = false;

            OpenFileDialog OpenDialogStreaming = new OpenFileDialog();
            OpenDialogStreaming.Title = "Open from: natives/x64/streaming/sound/wwise/<filename>.pck.3.x64";
            OpenDialogStreaming.Filter = "(*.pck.3.x64)|*.pck.3.x64|(*.pck)|*.pck|All files (*.*)|*.*";
            OpenDialogStreaming.CheckFileExists = true;
            OpenDialogStreaming.CheckPathExists = true;
            OpenDialogStreaming.RestoreDirectory = true;
            if (OpenDialogStreaming.ShowDialog() == DialogResult.OK)
            {
                StreamingFileText = File.ReadAllBytes(OpenDialogStreaming.FileName);
                StreamingPath = OpenDialogStreaming.FileName;

                // Finds 'AKPKp' and 'RIFF' to make sure it's the correct file
                for (int x = 0; x < StreamingFileText.Length - 4; x++)
                {
                    if ((char)StreamingFileText[x] == 'A' && (char)StreamingFileText[x + 1] == 'K' && (char)StreamingFileText[x + 2] == 'P' && (char)StreamingFileText[x + 3] == 'K' && (char)StreamingFileText[x + 4] == 'p')
                    {
                        StreamingAKPK = true;
                        //MessageBox.Show("AKPK = true;");
                    }
                }
                for (int y = 0; y < StreamingFileText.Length - 4; y++)
                {
                    if ((char)StreamingFileText[y] == 'R' && (char)StreamingFileText[y + 1] == 'I' && (char)StreamingFileText[y + 2] == 'F' && (char)StreamingFileText[y + 3] == 'F')
                    {
                        StreamingRIFF = true;
                        //MessageBox.Show("RIFF = true;");
                    }
                }
                if (StreamingAKPK == true && StreamingRIFF == true)
                {
                    isStreamCorrect = true;
                    //MessageBox.Show("isStreamCorrect = true;");
                }
                if (StreamingAKPK == false | StreamingRIFF == false)
                {
                    StreamingAKPK = false;
                    StreamingRIFF = false;
                    isStreamCorrect = false;
                    //MessageBox.Show("isStreamCorrect = false;");
                    MessageBox.Show("This is not a valid streaming.pck.3.x64 file." + "\n" + "You can find a compatible file at: natives/x64/streaming/sound/wwise/");
                }
            }

            if (isStreamCorrect == true)
            {
                OpenFileDialog OpenDialogOffset = new OpenFileDialog();
                OpenDialogOffset.Title = "Open from: natives/x64/sound/wwise/<filename>.pck.3.x64";
                OpenDialogOffset.Filter = "(*.pck.3.x64)|*.pck.3.x64|(*.pck)|*.pck|All files (*.*)|*.*";
                OpenDialogOffset.CheckFileExists = true;
                OpenDialogOffset.CheckPathExists = true;
                OpenDialogOffset.RestoreDirectory = true;
                if (OpenDialogOffset.ShowDialog() == DialogResult.OK)
                {
                    OffsetFileText = File.ReadAllBytes(OpenDialogOffset.FileName);
                    OffsetPath = OpenDialogOffset.FileName;

                    // Finds 'AKPKp' is found and 'RIFF' is NOT to make sure it's the correct file
                    for (int x = 0; x < OffsetFileText.Length - 4; x++)
                    {
                        if ((char)OffsetFileText[x] == 'A' && (char)OffsetFileText[x + 1] == 'K' && (char)OffsetFileText[x + 2] == 'P' && (char)OffsetFileText[x + 3] == 'K' && (char)OffsetFileText[x + 4] == 'p')
                        {
                            OffsetAKPK = true;
                            //MessageBox.Show("AKPK = true;");
                        }
                    }
                    for (int y = 0; y < OffsetFileText.Length - 4; y++)
                    {
                        if ((char)OffsetFileText[y] == 'R' && (char)OffsetFileText[y + 1] == 'I' && (char)OffsetFileText[y + 2] == 'F' && (char)OffsetFileText[y + 3] == 'F')
                        {
                            OffsetRIFF = true;
                            //MessageBox.Show("RIFF = true;");
                        }
                    }
                    if (OffsetAKPK == true && OffsetRIFF == false)
                    {
                        isOffsetCorrect = true;
                        //MessageBox.Show("isOffsetCorrect = true;");
                    }
                    if (OffsetAKPK == false && OffsetRIFF == true)
                    {
                        OffsetAKPK = false;
                        OffsetRIFF = false;
                        isOffsetCorrect = false;
                        //MessageBox.Show("isOffsetCorrect = false;");
                        MessageBox.Show("This is not a valid sound.pck.3.x64 file." + "\n" + "You can find a compatible file at: natives/x64/sound/wwise/");
                    }
                    if (OffsetAKPK == false && OffsetRIFF == false)
                    {
                        OffsetAKPK = false;
                        OffsetRIFF = false;
                        isOffsetCorrect = false;
                        //MessageBox.Show("isOffsetCorrect = false;");
                        MessageBox.Show("This is not a valid sound.pck.3.x64 file." + "\n" + "You can find a compatible file at: natives/x64/sound/wwise/");
                    }
                    if (OffsetAKPK == true && OffsetRIFF == true)
                    {
                        OffsetAKPK = false;
                        OffsetRIFF = false;
                        isOffsetCorrect = false;
                        //MessageBox.Show("isOffsetCorrect = false;");
                        MessageBox.Show("This is not a valid sound.pck.3.x64 file." + "\n" + "You can find a compatible file at: natives/x64/sound/wwise/");
                    }
                }
            }

            if (isStreamCorrect == true && isOffsetCorrect == true)
            {
                OpenFileDialog OpenDialogLoops = new OpenFileDialog();
                OpenDialogLoops.Title = "Open from: natives/x64/sound/wwise/<filename>.bnk.2.x64";
                OpenDialogLoops.Filter = "(*.bnk.2.x64)|*.bnk.2.x64|(*.pck)|*.pck|All files (*.*)|*.*";
                OpenDialogLoops.CheckFileExists = true;
                OpenDialogLoops.CheckPathExists = true;
                OpenDialogLoops.RestoreDirectory = true;

                if (OpenDialogLoops.ShowDialog() == DialogResult.OK)
                {
                    LoopsFileText = File.ReadAllBytes(OpenDialogLoops.FileName);
                    LoopsPath = OpenDialogLoops.FileName;

                    // Finds 'BKHD'to make sure it's the correct file
                    for (int x = 0; x < LoopsFileText.Length - 4; x++)
                    {
                        if ((char)LoopsFileText[x] == 'B' && (char)LoopsFileText[x + 1] == 'K' && (char)LoopsFileText[x + 2] == 'H' && (char)LoopsFileText[x + 3] == 'D')
                        {
                            LoopsBKHD = true;
                            //MessageBox.Show("BKHD = true;");
                        }
                    }
                    if (LoopsBKHD == true)
                    {
                        isLoopsCorrect = true;
                        //MessageBox.Show("isLoopsCorrect = true;");
                    }
                    if (LoopsBKHD == false)
                    {
                        LoopsBKHD = false;
                        isLoopsCorrect = false;
                        //MessageBox.Show("isLoopsCorrect = false;");
                        MessageBox.Show("This is not a valid loop.bnk.2.x64 file." + "\n" + "You can find a compatible file at: natives/x64/sound/wwise/");
                    }
                }
            }

            if (StreamingPath != "" && OffsetPath != "" && LoopsPath != "" && isStreamCorrect == true && isOffsetCorrect == true && isLoopsCorrect == true)
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;

                FilesOpenedLabel.Visible = true;

                var t = new Timer();
                t.Interval = 3000; // it will Tick in 3 seconds
                t.Tick += (s, f) =>
                {
                    FilesOpenedLabel.Hide();
                    t.Stop();
                };
                t.Start();

                if (FilesOpenedLabel.Visible == true)
                {
                    FilesSavedLabel.Hide();
                }

                WEMLabel.Enabled = true;
                WEMComboBox.Enabled = true;
                StartLabel.Enabled = true;
                StartNumeric.Enabled = true;
                LoopStartLabel.Enabled = true;
                LoopStartNumeric.Enabled = true;
                LoopEndLabel.Enabled = true;
                LoopEndNumeric.Enabled = true;
                LengthLabel.Enabled = true;
                LengthNumeric.Enabled = true;
                SectionCheckbox.Enabled = true;
                int actualIndex = 0;
                int riffIndex = -1;

                //Used for copying the header of the Streaming sound file and pasting it over the Offset sound file.
                while (actualIndex < StreamingFileText.Length - 4 && riffIndex == -1)
                {
                    if (StreamingFileText[actualIndex] == 'R' && StreamingFileText[actualIndex + 1] == 'I' && StreamingFileText[actualIndex + 2] == 'F' && StreamingFileText[actualIndex + 3] == 'F')
                    {
                        riffIndex = actualIndex;
                    }
                    else
                    {
                        actualIndex = actualIndex + 1;
                    }
                }

                for (int x = 0; x < riffIndex; x++)
                {
                    StreamingArray.Add(StreamingFileText[x]);
                }

                if (riffIndex == -1)
                {
                    //MessageBox.Show("Not found");
                }

                if (riffIndex != -1)
                {
                    for (int x = 0; x < StreamingArray.Count; x++)
                    {
                        StreamingMessageBox = StreamingMessageBox + StreamingArray[x].ToString("X2");
                    }
                    //MessageBox.Show(StreamingMessageBox);
                }

                if (WEMComboBox.Text != "" && StartNumeric.Text != "" && LoopStartNumeric.Text != "" && LoopEndNumeric.Text != "" && LengthNumeric.Text != "")
                {
                    SaveButton.Enabled = true;
                    SaveAsButton.Enabled = true;
                }

            }

            if (StreamingPath == "" | OffsetPath == "" | LoopsPath == "" | isStreamCorrect == false | isOffsetCorrect == false | isLoopsCorrect == false)
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
                WEMLabel.Enabled = false;
                WEMComboBox.Enabled = false;
                StartLabel.Enabled = false;
                StartNumeric.Enabled = false;
                LoopStartLabel.Enabled = false;
                LoopStartNumeric.Enabled = false;
                LoopEndLabel.Enabled = false;
                LoopEndNumeric.Enabled = false;
                LengthLabel.Enabled = false;
                LengthNumeric.Enabled = false;
                SectionCheckbox.Enabled = false;

                WEMComboBox.Text = "";
                StartNumeric.Text = "";
                LoopStartNumeric.Text = "";
                LoopEndNumeric.Text = "";
                LengthNumeric.Text = "";
                SectionCheckbox.Checked = false;

                WEMIDCountFileChecker = 0;
                WEMIDCount = 0;
                HOIDCount = 0;
                NegativeStart = 0;
                Start = 0;
                NegativeAfterA = 0;
                Length = 0;
                SizeofA = 0;
                NegativeSizeofA = 0;
                NegativeAfterB = 0;
                SizeofB = 0;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (StreamingPath != "" && OffsetPath != "" && LoopsPath != "" && isStreamCorrect == true && isOffsetCorrect == true && isLoopsCorrect == true)
            {
                WEMIDCountFileChecker = 0;
                WEMIDCount = 0;
                HOIDCount = 0;
                NegativeStart = 0;
                Start = 0;
                NegativeAfterA = 0;
                Length = 0;
                SizeofA = 0;
                NegativeSizeofA = 0;
                NegativeAfterB = 0;
                SizeofB = 0;
                LoopsFileSaved = false;

                if (WEMComboBox.Text == "Public Enemy")
                {
                    WEMComboBox.Text = "409499718";
                }

                if (WEMComboBox.Text == "Ultra Violet")
                {
                    WEMComboBox.Text = "51877771";
                }

                if (WEMComboBox.Text == "Lock and Load")
                {
                    WEMComboBox.Text = "393680703";
                }

                if (WEMComboBox.Text == "Fire Away")
                {
                    WEMComboBox.Text = "62179196";
                }

                if (WEMComboBox.Text == "Wings of the GUARDIAN")
                {
                    WEMComboBox.Text = "500567106";
                }

                if (WEMComboBox.Text == "Shoot the Works")
                {
                    WEMComboBox.Text = "373347928";
                }

                if (WEMComboBox.Text == "Taste the Blood")
                {
                    WEMComboBox.Text = "513281663";
                }

                if (WEMComboBox.Text == "Vergil Battle-2")
                {
                    WEMComboBox.Text = "564871137";
                }

                if (WEMComboBox.Text == "Devils Never Cry")
                {
                    WEMComboBox.Text = "156523713";
                }

                if (WEMComboBox.Text == "The Time Has Come")
                {
                    WEMComboBox.Text = "263004481";
                }

                if (WEMComboBox.Text == "Lock and Load -Blackened Angel mix-")
                {
                    WEMComboBox.Text = "357057684";
                }

                if (WEMComboBox.Text == "Sworn Through Swords")
                {
                    WEMComboBox.Text = "975171463";
                }

                byte[] WEMNumericBytes = BitConverter.GetBytes(int.Parse(WEMComboBox.Text));
                int StartNumericInt = Convert.ToInt32(StartNumeric.Text);
                int LoopStartNumericInt = Convert.ToInt32(LoopStartNumeric.Text);
                int LoopEndNumericInt = Convert.ToInt32(LoopEndNumeric.Text);
                int LengthNumericInt = Convert.ToInt32(LengthNumeric.Text);

                NegativeStart = (StartNumericInt - StartNumericInt - StartNumericInt);
                byte[] NegativeStartArray = BitConverter.GetBytes(NegativeStart);
                //MessageBox.Show("Negative Start of Song:" + NegativeStart.ToString());

                Start = (StartNumericInt);
                byte[] StartArray = BitConverter.GetBytes(Start);
                //MessageBox.Show("Start of Song:" + Start.ToString());

                NegativeAfterA = (LoopStartNumericInt - LengthNumericInt);
                byte[] NegativeAfterAArray = BitConverter.GetBytes(NegativeAfterA);
                //MessageBox.Show("Negative Size of everything after end of A:" + NegativeAfterAString.ToString());

                Length = (LengthNumericInt);
                byte[] LengthArray = BitConverter.GetBytes(Length);
                //MessageBox.Show("Length:" + Length.ToString());

                SizeofA = (LoopStartNumericInt - StartNumericInt);
                byte[] SizeofAArray = BitConverter.GetBytes(SizeofA);
                //MessageBox.Show("Total size of A:" + SizeofAString.ToString());

                NegativeSizeofA = (StartNumericInt - LoopStartNumericInt);
                byte[] NegativeSizeofAArray = BitConverter.GetBytes(NegativeSizeofA);
                //MessageBox.Show("Negative Total size of A:" + NegativeSizeofAString.ToString());

                NegativeAfterB = (LoopEndNumericInt - LengthNumericInt);
                byte[] NegativeAfterBArray = BitConverter.GetBytes(NegativeAfterB);
                //MessageBox.Show("Negative Size of everything after end of B:" + NegativeAfterBString.ToString());ng

                SizeofB = (LoopEndNumericInt - LoopStartNumericInt);
                byte[] SizeofBArray = BitConverter.GetBytes(SizeofB);
                //MessageBox.Show("Total size of B:" + SizeofBString.ToString());

                for (int a = 0; a < LoopsFileText.Length - 4; a++)
                {
                    if (LoopsFileText[a] == WEMNumericBytes[0] && LoopsFileText[a + 1] == WEMNumericBytes[1] && LoopsFileText[a + 2] == WEMNumericBytes[2] && LoopsFileText[a + 3] == WEMNumericBytes[3])
                    {
                        WEMIDCountFileChecker = WEMIDCountFileChecker + 1;
                    }
                }

                if (WEMIDCountFileChecker == 4 && SectionCheckbox.Checked == false)
                {
                    for (int a = 0; a < LoopsFileText.Length - 4; a++)
                    {
                        if (LoopsFileText[a] == WEMNumericBytes[0] && LoopsFileText[a + 1] == WEMNumericBytes[1] && LoopsFileText[a + 2] == WEMNumericBytes[2] && LoopsFileText[a + 3] == WEMNumericBytes[3])
                        {
                            WEMIDCount = WEMIDCount + 1;
                            //MessageBox.Show("WEMIDCount: " + WEMIDCount.ToString());
                            if (WEMIDCount == 1)
                            {
                                LoopsFileText[a + 0x15] = NegativeStartArray[0];
                                LoopsFileText[a + 0x16] = NegativeStartArray[1];
                                LoopsFileText[a + 0x17] = NegativeStartArray[2];
                                LoopsFileText[a + 0x18] = NegativeStartArray[3];
                                LoopsFileText[a + 0x19] = NegativeStartArray[4];
                                LoopsFileText[a + 0x1A] = NegativeStartArray[5];
                                LoopsFileText[a + 0x1B] = NegativeStartArray[6];
                                LoopsFileText[a + 0x1C] = NegativeStartArray[7];

                                LoopsFileText[a + 0x1D] = StartArray[0];
                                LoopsFileText[a + 0x1E] = StartArray[1];
                                LoopsFileText[a + 0x1F] = StartArray[2];
                                LoopsFileText[a + 0x20] = StartArray[3];
                                LoopsFileText[a + 0x21] = StartArray[4];
                                LoopsFileText[a + 0x22] = StartArray[5];
                                LoopsFileText[a + 0x23] = StartArray[6];
                                LoopsFileText[a + 0x24] = StartArray[7];

                                LoopsFileText[a + 0x25] = NegativeAfterAArray[0];
                                LoopsFileText[a + 0x26] = NegativeAfterAArray[1];
                                LoopsFileText[a + 0x27] = NegativeAfterAArray[2];
                                LoopsFileText[a + 0x28] = NegativeAfterAArray[3];
                                LoopsFileText[a + 0x29] = NegativeAfterAArray[4];
                                LoopsFileText[a + 0x2A] = NegativeAfterAArray[5];
                                LoopsFileText[a + 0x2B] = NegativeAfterAArray[6];
                                LoopsFileText[a + 0x2C] = NegativeAfterAArray[7];

                                LoopsFileText[a + 0x2D] = LengthArray[0];
                                LoopsFileText[a + 0x2E] = LengthArray[1];
                                LoopsFileText[a + 0x2F] = LengthArray[2];
                                LoopsFileText[a + 0x30] = LengthArray[3];
                                LoopsFileText[a + 0x31] = LengthArray[4];
                                LoopsFileText[a + 0x32] = LengthArray[5];
                                LoopsFileText[a + 0x33] = LengthArray[6];
                                LoopsFileText[a + 0x34] = LengthArray[7];
                            }
                            if (WEMIDCount == 3)
                            {
                                LoopsFileText[a + 0x15] = NegativeSizeofAArray[0];
                                LoopsFileText[a + 0x16] = NegativeSizeofAArray[1];
                                LoopsFileText[a + 0x17] = NegativeSizeofAArray[2];
                                LoopsFileText[a + 0x18] = NegativeSizeofAArray[3];
                                LoopsFileText[a + 0x19] = NegativeSizeofAArray[4];
                                LoopsFileText[a + 0x1A] = NegativeSizeofAArray[5];
                                LoopsFileText[a + 0x1B] = NegativeSizeofAArray[6];
                                LoopsFileText[a + 0x1C] = NegativeSizeofAArray[7];

                                LoopsFileText[a + 0x1D] = SizeofAArray[0];
                                LoopsFileText[a + 0x1E] = SizeofAArray[1];
                                LoopsFileText[a + 0x1F] = SizeofAArray[2];
                                LoopsFileText[a + 0x20] = SizeofAArray[3];
                                LoopsFileText[a + 0x21] = SizeofAArray[4];
                                LoopsFileText[a + 0x22] = SizeofAArray[5];
                                LoopsFileText[a + 0x23] = SizeofAArray[6];
                                LoopsFileText[a + 0x24] = SizeofAArray[7];

                                LoopsFileText[a + 0x25] = NegativeAfterBArray[0];
                                LoopsFileText[a + 0x26] = NegativeAfterBArray[1];
                                LoopsFileText[a + 0x27] = NegativeAfterBArray[2];
                                LoopsFileText[a + 0x28] = NegativeAfterBArray[3];
                                LoopsFileText[a + 0x29] = NegativeAfterBArray[4];
                                LoopsFileText[a + 0x2A] = NegativeAfterBArray[5];
                                LoopsFileText[a + 0x2B] = NegativeAfterBArray[6];
                                LoopsFileText[a + 0x2C] = NegativeAfterBArray[7];

                                LoopsFileText[a + 0x2D] = LengthArray[0];
                                LoopsFileText[a + 0x2E] = LengthArray[1];
                                LoopsFileText[a + 0x2F] = LengthArray[2];
                                LoopsFileText[a + 0x30] = LengthArray[3];
                                LoopsFileText[a + 0x31] = LengthArray[4];
                                LoopsFileText[a + 0x32] = LengthArray[5];
                                LoopsFileText[a + 0x33] = LengthArray[6];
                                LoopsFileText[a + 0x34] = LengthArray[7];
                            }
                        }
                    }
                    int startindex = 0;
                    int foundoffset = -1;

                    while (startindex < LoopsFileText.Length - 4 && foundoffset == -1)
                    {
                        if (LoopsFileText[startindex] == WEMNumericBytes[0] && LoopsFileText[startindex + 1] == WEMNumericBytes[1] && LoopsFileText[startindex + 2] == WEMNumericBytes[2] && LoopsFileText[startindex + 3] == WEMNumericBytes[3])
                        {
                            foundoffset = startindex;
                            //MessageBox.Show("First WEM ID Offset:" + foundoffset.ToString("X2"));
                        }
                        else
                        {
                            startindex = startindex + 1;
                        }
                    }
                    for (int b = foundoffset; b < LoopsFileText.Length; b++)
                    {
                        if (LoopsFileText[b] == 0x48 && LoopsFileText[b + 1] == 0xD6 && LoopsFileText[b + 2] == 0xBB && LoopsFileText[b + 3] == 0x5B)
                        {
                            HOIDCount = HOIDCount + 1;
                            //MessageBox.Show("HO Count: " + HOIDCount.ToString());

                            if (HOIDCount == 1)
                            {
                                LoopsFileText[b + 0x04] = SizeofAArray[0];
                                LoopsFileText[b + 0x05] = SizeofAArray[1];
                                LoopsFileText[b + 0x06] = SizeofAArray[2];
                                LoopsFileText[b + 0x07] = SizeofAArray[3];
                                LoopsFileText[b + 0x08] = SizeofAArray[4];
                                LoopsFileText[b + 0x09] = SizeofAArray[5];
                                LoopsFileText[b + 0x0A] = SizeofAArray[6];
                                LoopsFileText[b + 0x0B] = SizeofAArray[7];

                                LoopsFileText[b - 0x1C] = SizeofAArray[0];
                                LoopsFileText[b - 0x1B] = SizeofAArray[1];
                                LoopsFileText[b - 0x1A] = SizeofAArray[2];
                                LoopsFileText[b - 0x19] = SizeofAArray[3];
                                LoopsFileText[b - 0x18] = SizeofAArray[4];
                                LoopsFileText[b - 0x17] = SizeofAArray[5];
                                LoopsFileText[b - 0x16] = SizeofAArray[6];
                                LoopsFileText[b - 0x15] = SizeofAArray[7];
                            }
                            if (HOIDCount == 2)
                            {
                                LoopsFileText[b + 0x04] = SizeofBArray[0];
                                LoopsFileText[b + 0x05] = SizeofBArray[1];
                                LoopsFileText[b + 0x06] = SizeofBArray[2];
                                LoopsFileText[b + 0x07] = SizeofBArray[3];
                                LoopsFileText[b + 0x08] = SizeofBArray[4];
                                LoopsFileText[b + 0x09] = SizeofBArray[5];
                                LoopsFileText[b + 0x0A] = SizeofBArray[6];
                                LoopsFileText[b + 0x0B] = SizeofBArray[7];

                                LoopsFileText[b - 0x1C] = SizeofBArray[0];
                                LoopsFileText[b - 0x1B] = SizeofBArray[1];
                                LoopsFileText[b - 0x1A] = SizeofBArray[2];
                                LoopsFileText[b - 0x19] = SizeofBArray[3];
                                LoopsFileText[b - 0x18] = SizeofBArray[4];
                                LoopsFileText[b - 0x17] = SizeofBArray[5];
                                LoopsFileText[b - 0x16] = SizeofBArray[6];
                                LoopsFileText[b - 0x15] = SizeofBArray[7];
                            }
                        }
                    }
                }

                if (WEMIDCountFileChecker == 4 && SectionCheckbox.Checked == true)
                {
                    for (int a = 0; a < LoopsFileText.Length - 4; a++)
                    {
                        if (LoopsFileText[a] == WEMNumericBytes[0] && LoopsFileText[a + 1] == WEMNumericBytes[1] && LoopsFileText[a + 2] == WEMNumericBytes[2] && LoopsFileText[a + 3] == WEMNumericBytes[3])
                        {
                            WEMIDCount = WEMIDCount + 1;
                            //MessageBox.Show("WEMIDCount: " + WEMIDCount.ToString());
                            if (WEMIDCount == 1)
                            {
                                LoopsFileText[a + 0x15] = NegativeSizeofAArray[0];
                                LoopsFileText[a + 0x16] = NegativeSizeofAArray[1];
                                LoopsFileText[a + 0x17] = NegativeSizeofAArray[2];
                                LoopsFileText[a + 0x18] = NegativeSizeofAArray[3];
                                LoopsFileText[a + 0x19] = NegativeSizeofAArray[4];
                                LoopsFileText[a + 0x1A] = NegativeSizeofAArray[5];
                                LoopsFileText[a + 0x1B] = NegativeSizeofAArray[6];
                                LoopsFileText[a + 0x1C] = NegativeSizeofAArray[7];

                                LoopsFileText[a + 0x1D] = SizeofAArray[0];
                                LoopsFileText[a + 0x1E] = SizeofAArray[1];
                                LoopsFileText[a + 0x1F] = SizeofAArray[2];
                                LoopsFileText[a + 0x20] = SizeofAArray[3];
                                LoopsFileText[a + 0x21] = SizeofAArray[4];
                                LoopsFileText[a + 0x22] = SizeofAArray[5];
                                LoopsFileText[a + 0x23] = SizeofAArray[6];
                                LoopsFileText[a + 0x24] = SizeofAArray[7];

                                LoopsFileText[a + 0x25] = NegativeAfterBArray[0];
                                LoopsFileText[a + 0x26] = NegativeAfterBArray[1];
                                LoopsFileText[a + 0x27] = NegativeAfterBArray[2];
                                LoopsFileText[a + 0x28] = NegativeAfterBArray[3];
                                LoopsFileText[a + 0x29] = NegativeAfterBArray[4];
                                LoopsFileText[a + 0x2A] = NegativeAfterBArray[5];
                                LoopsFileText[a + 0x2B] = NegativeAfterBArray[6];
                                LoopsFileText[a + 0x2C] = NegativeAfterBArray[7];

                                LoopsFileText[a + 0x2D] = LengthArray[0];
                                LoopsFileText[a + 0x2E] = LengthArray[1];
                                LoopsFileText[a + 0x2F] = LengthArray[2];
                                LoopsFileText[a + 0x30] = LengthArray[3];
                                LoopsFileText[a + 0x31] = LengthArray[4];
                                LoopsFileText[a + 0x32] = LengthArray[5];
                                LoopsFileText[a + 0x33] = LengthArray[6];
                                LoopsFileText[a + 0x34] = LengthArray[7];
                            }
                            if (WEMIDCount == 3)
                            {
                                LoopsFileText[a + 0x15] = NegativeStartArray[0];
                                LoopsFileText[a + 0x16] = NegativeStartArray[1];
                                LoopsFileText[a + 0x17] = NegativeStartArray[2];
                                LoopsFileText[a + 0x18] = NegativeStartArray[3];
                                LoopsFileText[a + 0x19] = NegativeStartArray[4];
                                LoopsFileText[a + 0x1A] = NegativeStartArray[5];
                                LoopsFileText[a + 0x1B] = NegativeStartArray[6];
                                LoopsFileText[a + 0x1C] = NegativeStartArray[7];

                                LoopsFileText[a + 0x1D] = StartArray[0];
                                LoopsFileText[a + 0x1E] = StartArray[1];
                                LoopsFileText[a + 0x1F] = StartArray[2];
                                LoopsFileText[a + 0x20] = StartArray[3];
                                LoopsFileText[a + 0x21] = StartArray[4];
                                LoopsFileText[a + 0x22] = StartArray[5];
                                LoopsFileText[a + 0x23] = StartArray[6];
                                LoopsFileText[a + 0x24] = StartArray[7];

                                LoopsFileText[a + 0x25] = NegativeAfterAArray[0];
                                LoopsFileText[a + 0x26] = NegativeAfterAArray[1];
                                LoopsFileText[a + 0x27] = NegativeAfterAArray[2];
                                LoopsFileText[a + 0x28] = NegativeAfterAArray[3];
                                LoopsFileText[a + 0x29] = NegativeAfterAArray[4];
                                LoopsFileText[a + 0x2A] = NegativeAfterAArray[5];
                                LoopsFileText[a + 0x2B] = NegativeAfterAArray[6];
                                LoopsFileText[a + 0x2C] = NegativeAfterAArray[7];

                                LoopsFileText[a + 0x2D] = LengthArray[0];
                                LoopsFileText[a + 0x2E] = LengthArray[1];
                                LoopsFileText[a + 0x2F] = LengthArray[2];
                                LoopsFileText[a + 0x30] = LengthArray[3];
                                LoopsFileText[a + 0x31] = LengthArray[4];
                                LoopsFileText[a + 0x32] = LengthArray[5];
                                LoopsFileText[a + 0x33] = LengthArray[6];
                                LoopsFileText[a + 0x34] = LengthArray[7];
                            }
                        }
                    }
                    int startindex = 0;
                    int foundoffset = -1;

                    while (startindex < LoopsFileText.Length - 4 && foundoffset == -1)
                    {
                        if (LoopsFileText[startindex] == WEMNumericBytes[0] && LoopsFileText[startindex + 1] == WEMNumericBytes[1] && LoopsFileText[startindex + 2] == WEMNumericBytes[2] && LoopsFileText[startindex + 3] == WEMNumericBytes[3])
                        {
                            foundoffset = startindex;
                            //MessageBox.Show("First WEM ID Offset:" + foundoffset.ToString("X2"));
                        }
                        else
                        {
                            startindex = startindex + 1;
                        }
                    }
                    for (int b = foundoffset; b < LoopsFileText.Length; b++)
                    {
                        if (LoopsFileText[b] == 0x48 && LoopsFileText[b + 1] == 0xD6 && LoopsFileText[b + 2] == 0xBB && LoopsFileText[b + 3] == 0x5B)
                        {
                            HOIDCount = HOIDCount + 1;
                            //MessageBox.Show("HO Count: " + HOIDCount.ToString());

                            if (HOIDCount == 1)
                            {
                                LoopsFileText[b + 0x04] = SizeofBArray[0];
                                LoopsFileText[b + 0x05] = SizeofBArray[1];
                                LoopsFileText[b + 0x06] = SizeofBArray[2];
                                LoopsFileText[b + 0x07] = SizeofBArray[3];
                                LoopsFileText[b + 0x08] = SizeofBArray[4];
                                LoopsFileText[b + 0x09] = SizeofBArray[5];
                                LoopsFileText[b + 0x0A] = SizeofBArray[6];
                                LoopsFileText[b + 0x0B] = SizeofBArray[7];

                                LoopsFileText[b - 0x1C] = SizeofBArray[0];
                                LoopsFileText[b - 0x1B] = SizeofBArray[1];
                                LoopsFileText[b - 0x1A] = SizeofBArray[2];
                                LoopsFileText[b - 0x19] = SizeofBArray[3];
                                LoopsFileText[b - 0x18] = SizeofBArray[4];
                                LoopsFileText[b - 0x17] = SizeofBArray[5];
                                LoopsFileText[b - 0x16] = SizeofBArray[6];
                                LoopsFileText[b - 0x15] = SizeofBArray[7];
                            }
                            if (HOIDCount == 2)
                            {
                                LoopsFileText[b + 0x04] = SizeofAArray[0];
                                LoopsFileText[b + 0x05] = SizeofAArray[1];
                                LoopsFileText[b + 0x06] = SizeofAArray[2];
                                LoopsFileText[b + 0x07] = SizeofAArray[3];
                                LoopsFileText[b + 0x08] = SizeofAArray[4];
                                LoopsFileText[b + 0x09] = SizeofAArray[5];
                                LoopsFileText[b + 0x0A] = SizeofAArray[6];
                                LoopsFileText[b + 0x0B] = SizeofAArray[7];

                                LoopsFileText[b - 0x1C] = SizeofAArray[0];
                                LoopsFileText[b - 0x1B] = SizeofAArray[1];
                                LoopsFileText[b - 0x1A] = SizeofAArray[2];
                                LoopsFileText[b - 0x19] = SizeofAArray[3];
                                LoopsFileText[b - 0x18] = SizeofAArray[4];
                                LoopsFileText[b - 0x17] = SizeofAArray[5];
                                LoopsFileText[b - 0x16] = SizeofAArray[6];
                                LoopsFileText[b - 0x15] = SizeofAArray[7];
                            }
                        }
                    }
                }

                //MessageBox.Show("WEM Count:" + WEMIDCountFileChecker.ToString());
                if (WEMIDCountFileChecker > 4)
                {
                    MessageBox.Show("Unexpected Error" + "More than 4 WEM IDs somehow?");
                }
                if (WEMIDCountFileChecker < 4)
                {
                    MessageBox.Show("This WEM ID has apparently has no loop to it?" + "Too few WEM IDs inside the file.");
                }
                
                File.WriteAllBytes(StreamingPath, StreamingFileText);
                File.WriteAllBytes(OffsetPath, StreamingArray.ToArray());
                File.WriteAllBytes(LoopsPath, LoopsFileText);
                LoopsFileSaved = true;

                if (LoopsFileSaved == true)
                {
                    StreamingFileText = File.ReadAllBytes(StreamingPath);
                    OffsetFileText = File.ReadAllBytes(OffsetPath);
                    LoopsFileText = File.ReadAllBytes(LoopsPath);
                }

        FilesSavedLabel.Visible = true;

                var t = new Timer();
                t.Interval = 3000; // it will Tick in 3 seconds
                t.Tick += (s, f) =>
                {
                    FilesSavedLabel.Hide();
                    t.Stop();
                };
                t.Start();

                if (FilesSavedLabel.Visible == true)
                {
                    FilesOpenedLabel.Hide();
                }
            }
        }
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            if (StreamingPath != "" && OffsetPath != "" && LoopsPath != "" && isStreamCorrect == true && isOffsetCorrect == true && isLoopsCorrect == true)
            {

                if (StreamingPath != "" && OffsetPath != "" && LoopsPath != "" && isStreamCorrect == true && isOffsetCorrect == true && isLoopsCorrect == true)
                {
                    WEMIDCountFileChecker = 0;
                    WEMIDCount = 0;
                    HOIDCount = 0;
                    NegativeStart = 0;
                    Start = 0;
                    NegativeAfterA = 0;
                    Length = 0;
                    SizeofA = 0;
                    NegativeSizeofA = 0;
                    NegativeAfterB = 0;
                    SizeofB = 0;
                    LoopsFileSaved = false;

                    if (WEMComboBox.Text == "Public Enemy")
                    {
                        WEMComboBox.Text = "409499718";
                    }

                    if (WEMComboBox.Text == "Ultra Violet")
                    {
                        WEMComboBox.Text = "51877771";
                    }

                    if (WEMComboBox.Text == "Lock and Load")
                    {
                        WEMComboBox.Text = "393680703";
                    }

                    if (WEMComboBox.Text == "Fire Away")
                    {
                        WEMComboBox.Text = "62179196";
                    }

                    if (WEMComboBox.Text == "Wings of the GUARDIAN")
                    {
                        WEMComboBox.Text = "500567106";
                    }

                    if (WEMComboBox.Text == "Shoot the Works")
                    {
                        WEMComboBox.Text = "373347928";
                    }

                    if (WEMComboBox.Text == "Taste the Blood")
                    {
                        WEMComboBox.Text = "513281663";
                    }

                    if (WEMComboBox.Text == "Vergil Battle-2")
                    {
                        WEMComboBox.Text = "564871137";
                    }

                    if (WEMComboBox.Text == "Devils Never Cry")
                    {
                        WEMComboBox.Text = "156523713";
                    }

                    if (WEMComboBox.Text == "The Time Has Come")
                    {
                        WEMComboBox.Text = "263004481";
                    }

                    if (WEMComboBox.Text == "Lock and Load -Blackened Angel mix-")
                    {
                        WEMComboBox.Text = "357057684";
                    }

                    if (WEMComboBox.Text == "Sworn Through Swords")
                    {
                        WEMComboBox.Text = "975171463";
                    }

                    byte[] WEMNumericBytes = BitConverter.GetBytes(int.Parse(WEMComboBox.Text));
                    int StartNumericInt = Convert.ToInt32(StartNumeric.Text);
                    int LoopStartNumericInt = Convert.ToInt32(LoopStartNumeric.Text);
                    int LoopEndNumericInt = Convert.ToInt32(LoopEndNumeric.Text);
                    int LengthNumericInt = Convert.ToInt32(LengthNumeric.Text);

                    NegativeStart = (StartNumericInt - StartNumericInt - StartNumericInt);
                    byte[] NegativeStartArray = BitConverter.GetBytes(NegativeStart);
                    //MessageBox.Show("Negative Start of Song:" + NegativeStart.ToString());

                    Start = (StartNumericInt);
                    byte[] StartArray = BitConverter.GetBytes(Start);
                    //MessageBox.Show("Start of Song:" + Start.ToString());

                    NegativeAfterA = (LoopStartNumericInt - LengthNumericInt);
                    byte[] NegativeAfterAArray = BitConverter.GetBytes(NegativeAfterA);
                    //MessageBox.Show("Negative Size of everything after end of A:" + NegativeAfterAString.ToString());

                    Length = (LengthNumericInt);
                    byte[] LengthArray = BitConverter.GetBytes(Length);
                    //MessageBox.Show("Length:" + Length.ToString());

                    SizeofA = (LoopStartNumericInt - StartNumericInt);
                    byte[] SizeofAArray = BitConverter.GetBytes(SizeofA);
                    //MessageBox.Show("Total size of A:" + SizeofAString.ToString());

                    NegativeSizeofA = (StartNumericInt - LoopStartNumericInt);
                    byte[] NegativeSizeofAArray = BitConverter.GetBytes(NegativeSizeofA);
                    //MessageBox.Show("Negative Total size of A:" + NegativeSizeofAString.ToString());

                    NegativeAfterB = (LoopEndNumericInt - LengthNumericInt);
                    byte[] NegativeAfterBArray = BitConverter.GetBytes(NegativeAfterB);
                    //MessageBox.Show("Negative Size of everything after end of B:" + NegativeAfterBString.ToString());ng

                    SizeofB = (LoopEndNumericInt - LoopStartNumericInt);
                    byte[] SizeofBArray = BitConverter.GetBytes(SizeofB);
                    //MessageBox.Show("Total size of B:" + SizeofBString.ToString());

                    for (int a = 0; a < LoopsFileText.Length - 4; a++)
                    {
                        if (LoopsFileText[a] == WEMNumericBytes[0] && LoopsFileText[a + 1] == WEMNumericBytes[1] && LoopsFileText[a + 2] == WEMNumericBytes[2] && LoopsFileText[a + 3] == WEMNumericBytes[3])
                        {
                            WEMIDCountFileChecker = WEMIDCountFileChecker + 1;
                        }
                    }

                    if (WEMIDCountFileChecker == 4 && SectionCheckbox.Checked == false)
                    {
                        for (int a = 0; a < LoopsFileText.Length - 4; a++)
                        {
                            if (LoopsFileText[a] == WEMNumericBytes[0] && LoopsFileText[a + 1] == WEMNumericBytes[1] && LoopsFileText[a + 2] == WEMNumericBytes[2] && LoopsFileText[a + 3] == WEMNumericBytes[3])
                            {
                                WEMIDCount = WEMIDCount + 1;
                                //MessageBox.Show("WEMIDCount: " + WEMIDCount.ToString());
                                if (WEMIDCount == 1)
                                {
                                    LoopsFileText[a + 0x15] = NegativeStartArray[0];
                                    LoopsFileText[a + 0x16] = NegativeStartArray[1];
                                    LoopsFileText[a + 0x17] = NegativeStartArray[2];
                                    LoopsFileText[a + 0x18] = NegativeStartArray[3];
                                    LoopsFileText[a + 0x19] = NegativeStartArray[4];
                                    LoopsFileText[a + 0x1A] = NegativeStartArray[5];
                                    LoopsFileText[a + 0x1B] = NegativeStartArray[6];
                                    LoopsFileText[a + 0x1C] = NegativeStartArray[7];

                                    LoopsFileText[a + 0x1D] = StartArray[0];
                                    LoopsFileText[a + 0x1E] = StartArray[1];
                                    LoopsFileText[a + 0x1F] = StartArray[2];
                                    LoopsFileText[a + 0x20] = StartArray[3];
                                    LoopsFileText[a + 0x21] = StartArray[4];
                                    LoopsFileText[a + 0x22] = StartArray[5];
                                    LoopsFileText[a + 0x23] = StartArray[6];
                                    LoopsFileText[a + 0x24] = StartArray[7];

                                    LoopsFileText[a + 0x25] = NegativeAfterAArray[0];
                                    LoopsFileText[a + 0x26] = NegativeAfterAArray[1];
                                    LoopsFileText[a + 0x27] = NegativeAfterAArray[2];
                                    LoopsFileText[a + 0x28] = NegativeAfterAArray[3];
                                    LoopsFileText[a + 0x29] = NegativeAfterAArray[4];
                                    LoopsFileText[a + 0x2A] = NegativeAfterAArray[5];
                                    LoopsFileText[a + 0x2B] = NegativeAfterAArray[6];
                                    LoopsFileText[a + 0x2C] = NegativeAfterAArray[7];

                                    LoopsFileText[a + 0x2D] = LengthArray[0];
                                    LoopsFileText[a + 0x2E] = LengthArray[1];
                                    LoopsFileText[a + 0x2F] = LengthArray[2];
                                    LoopsFileText[a + 0x30] = LengthArray[3];
                                    LoopsFileText[a + 0x31] = LengthArray[4];
                                    LoopsFileText[a + 0x32] = LengthArray[5];
                                    LoopsFileText[a + 0x33] = LengthArray[6];
                                    LoopsFileText[a + 0x34] = LengthArray[7];
                                }
                                if (WEMIDCount == 3)
                                {
                                    LoopsFileText[a + 0x15] = NegativeSizeofAArray[0];
                                    LoopsFileText[a + 0x16] = NegativeSizeofAArray[1];
                                    LoopsFileText[a + 0x17] = NegativeSizeofAArray[2];
                                    LoopsFileText[a + 0x18] = NegativeSizeofAArray[3];
                                    LoopsFileText[a + 0x19] = NegativeSizeofAArray[4];
                                    LoopsFileText[a + 0x1A] = NegativeSizeofAArray[5];
                                    LoopsFileText[a + 0x1B] = NegativeSizeofAArray[6];
                                    LoopsFileText[a + 0x1C] = NegativeSizeofAArray[7];

                                    LoopsFileText[a + 0x1D] = SizeofAArray[0];
                                    LoopsFileText[a + 0x1E] = SizeofAArray[1];
                                    LoopsFileText[a + 0x1F] = SizeofAArray[2];
                                    LoopsFileText[a + 0x20] = SizeofAArray[3];
                                    LoopsFileText[a + 0x21] = SizeofAArray[4];
                                    LoopsFileText[a + 0x22] = SizeofAArray[5];
                                    LoopsFileText[a + 0x23] = SizeofAArray[6];
                                    LoopsFileText[a + 0x24] = SizeofAArray[7];

                                    LoopsFileText[a + 0x25] = NegativeAfterBArray[0];
                                    LoopsFileText[a + 0x26] = NegativeAfterBArray[1];
                                    LoopsFileText[a + 0x27] = NegativeAfterBArray[2];
                                    LoopsFileText[a + 0x28] = NegativeAfterBArray[3];
                                    LoopsFileText[a + 0x29] = NegativeAfterBArray[4];
                                    LoopsFileText[a + 0x2A] = NegativeAfterBArray[5];
                                    LoopsFileText[a + 0x2B] = NegativeAfterBArray[6];
                                    LoopsFileText[a + 0x2C] = NegativeAfterBArray[7];

                                    LoopsFileText[a + 0x2D] = LengthArray[0];
                                    LoopsFileText[a + 0x2E] = LengthArray[1];
                                    LoopsFileText[a + 0x2F] = LengthArray[2];
                                    LoopsFileText[a + 0x30] = LengthArray[3];
                                    LoopsFileText[a + 0x31] = LengthArray[4];
                                    LoopsFileText[a + 0x32] = LengthArray[5];
                                    LoopsFileText[a + 0x33] = LengthArray[6];
                                    LoopsFileText[a + 0x34] = LengthArray[7];
                                }
                            }
                        }
                        int startindex = 0;
                        int foundoffset = -1;

                        while (startindex < LoopsFileText.Length - 4 && foundoffset == -1)
                        {
                            if (LoopsFileText[startindex] == WEMNumericBytes[0] && LoopsFileText[startindex + 1] == WEMNumericBytes[1] && LoopsFileText[startindex + 2] == WEMNumericBytes[2] && LoopsFileText[startindex + 3] == WEMNumericBytes[3])
                            {
                                foundoffset = startindex;
                                //MessageBox.Show("First WEM ID Offset:" + foundoffset.ToString("X2"));
                            }
                            else
                            {
                                startindex = startindex + 1;
                            }
                        }
                        for (int b = foundoffset; b < LoopsFileText.Length; b++)
                        {
                            if (LoopsFileText[b] == 0x48 && LoopsFileText[b + 1] == 0xD6 && LoopsFileText[b + 2] == 0xBB && LoopsFileText[b + 3] == 0x5B)
                            {
                                HOIDCount = HOIDCount + 1;
                                //MessageBox.Show("HO Count: " + HOIDCount.ToString());

                                if (HOIDCount == 1)
                                {
                                    LoopsFileText[b + 0x04] = SizeofAArray[0];
                                    LoopsFileText[b + 0x05] = SizeofAArray[1];
                                    LoopsFileText[b + 0x06] = SizeofAArray[2];
                                    LoopsFileText[b + 0x07] = SizeofAArray[3];
                                    LoopsFileText[b + 0x08] = SizeofAArray[4];
                                    LoopsFileText[b + 0x09] = SizeofAArray[5];
                                    LoopsFileText[b + 0x0A] = SizeofAArray[6];
                                    LoopsFileText[b + 0x0B] = SizeofAArray[7];

                                    LoopsFileText[b - 0x1C] = SizeofAArray[0];
                                    LoopsFileText[b - 0x1B] = SizeofAArray[1];
                                    LoopsFileText[b - 0x1A] = SizeofAArray[2];
                                    LoopsFileText[b - 0x19] = SizeofAArray[3];
                                    LoopsFileText[b - 0x18] = SizeofAArray[4];
                                    LoopsFileText[b - 0x17] = SizeofAArray[5];
                                    LoopsFileText[b - 0x16] = SizeofAArray[6];
                                    LoopsFileText[b - 0x15] = SizeofAArray[7];
                                }
                                if (HOIDCount == 2)
                                {
                                    LoopsFileText[b + 0x04] = SizeofBArray[0];
                                    LoopsFileText[b + 0x05] = SizeofBArray[1];
                                    LoopsFileText[b + 0x06] = SizeofBArray[2];
                                    LoopsFileText[b + 0x07] = SizeofBArray[3];
                                    LoopsFileText[b + 0x08] = SizeofBArray[4];
                                    LoopsFileText[b + 0x09] = SizeofBArray[5];
                                    LoopsFileText[b + 0x0A] = SizeofBArray[6];
                                    LoopsFileText[b + 0x0B] = SizeofBArray[7];

                                    LoopsFileText[b - 0x1C] = SizeofBArray[0];
                                    LoopsFileText[b - 0x1B] = SizeofBArray[1];
                                    LoopsFileText[b - 0x1A] = SizeofBArray[2];
                                    LoopsFileText[b - 0x19] = SizeofBArray[3];
                                    LoopsFileText[b - 0x18] = SizeofBArray[4];
                                    LoopsFileText[b - 0x17] = SizeofBArray[5];
                                    LoopsFileText[b - 0x16] = SizeofBArray[6];
                                    LoopsFileText[b - 0x15] = SizeofBArray[7];
                                }
                            }
                        }
                    }

                    if (WEMIDCountFileChecker == 4 && SectionCheckbox.Checked == true)
                    {
                        for (int a = 0; a < LoopsFileText.Length - 4; a++)
                        {
                            if (LoopsFileText[a] == WEMNumericBytes[0] && LoopsFileText[a + 1] == WEMNumericBytes[1] && LoopsFileText[a + 2] == WEMNumericBytes[2] && LoopsFileText[a + 3] == WEMNumericBytes[3])
                            {
                                WEMIDCount = WEMIDCount + 1;
                                //MessageBox.Show("WEMIDCount: " + WEMIDCount.ToString());
                                if (WEMIDCount == 1)
                                {
                                    LoopsFileText[a + 0x15] = NegativeSizeofAArray[0];
                                    LoopsFileText[a + 0x16] = NegativeSizeofAArray[1];
                                    LoopsFileText[a + 0x17] = NegativeSizeofAArray[2];
                                    LoopsFileText[a + 0x18] = NegativeSizeofAArray[3];
                                    LoopsFileText[a + 0x19] = NegativeSizeofAArray[4];
                                    LoopsFileText[a + 0x1A] = NegativeSizeofAArray[5];
                                    LoopsFileText[a + 0x1B] = NegativeSizeofAArray[6];
                                    LoopsFileText[a + 0x1C] = NegativeSizeofAArray[7];

                                    LoopsFileText[a + 0x1D] = SizeofAArray[0];
                                    LoopsFileText[a + 0x1E] = SizeofAArray[1];
                                    LoopsFileText[a + 0x1F] = SizeofAArray[2];
                                    LoopsFileText[a + 0x20] = SizeofAArray[3];
                                    LoopsFileText[a + 0x21] = SizeofAArray[4];
                                    LoopsFileText[a + 0x22] = SizeofAArray[5];
                                    LoopsFileText[a + 0x23] = SizeofAArray[6];
                                    LoopsFileText[a + 0x24] = SizeofAArray[7];

                                    LoopsFileText[a + 0x25] = NegativeAfterBArray[0];
                                    LoopsFileText[a + 0x26] = NegativeAfterBArray[1];
                                    LoopsFileText[a + 0x27] = NegativeAfterBArray[2];
                                    LoopsFileText[a + 0x28] = NegativeAfterBArray[3];
                                    LoopsFileText[a + 0x29] = NegativeAfterBArray[4];
                                    LoopsFileText[a + 0x2A] = NegativeAfterBArray[5];
                                    LoopsFileText[a + 0x2B] = NegativeAfterBArray[6];
                                    LoopsFileText[a + 0x2C] = NegativeAfterBArray[7];

                                    LoopsFileText[a + 0x2D] = LengthArray[0];
                                    LoopsFileText[a + 0x2E] = LengthArray[1];
                                    LoopsFileText[a + 0x2F] = LengthArray[2];
                                    LoopsFileText[a + 0x30] = LengthArray[3];
                                    LoopsFileText[a + 0x31] = LengthArray[4];
                                    LoopsFileText[a + 0x32] = LengthArray[5];
                                    LoopsFileText[a + 0x33] = LengthArray[6];
                                    LoopsFileText[a + 0x34] = LengthArray[7];
                                }
                                if (WEMIDCount == 3)
                                {
                                    LoopsFileText[a + 0x15] = NegativeStartArray[0];
                                    LoopsFileText[a + 0x16] = NegativeStartArray[1];
                                    LoopsFileText[a + 0x17] = NegativeStartArray[2];
                                    LoopsFileText[a + 0x18] = NegativeStartArray[3];
                                    LoopsFileText[a + 0x19] = NegativeStartArray[4];
                                    LoopsFileText[a + 0x1A] = NegativeStartArray[5];
                                    LoopsFileText[a + 0x1B] = NegativeStartArray[6];
                                    LoopsFileText[a + 0x1C] = NegativeStartArray[7];

                                    LoopsFileText[a + 0x1D] = StartArray[0];
                                    LoopsFileText[a + 0x1E] = StartArray[1];
                                    LoopsFileText[a + 0x1F] = StartArray[2];
                                    LoopsFileText[a + 0x20] = StartArray[3];
                                    LoopsFileText[a + 0x21] = StartArray[4];
                                    LoopsFileText[a + 0x22] = StartArray[5];
                                    LoopsFileText[a + 0x23] = StartArray[6];
                                    LoopsFileText[a + 0x24] = StartArray[7];

                                    LoopsFileText[a + 0x25] = NegativeAfterAArray[0];
                                    LoopsFileText[a + 0x26] = NegativeAfterAArray[1];
                                    LoopsFileText[a + 0x27] = NegativeAfterAArray[2];
                                    LoopsFileText[a + 0x28] = NegativeAfterAArray[3];
                                    LoopsFileText[a + 0x29] = NegativeAfterAArray[4];
                                    LoopsFileText[a + 0x2A] = NegativeAfterAArray[5];
                                    LoopsFileText[a + 0x2B] = NegativeAfterAArray[6];
                                    LoopsFileText[a + 0x2C] = NegativeAfterAArray[7];

                                    LoopsFileText[a + 0x2D] = LengthArray[0];
                                    LoopsFileText[a + 0x2E] = LengthArray[1];
                                    LoopsFileText[a + 0x2F] = LengthArray[2];
                                    LoopsFileText[a + 0x30] = LengthArray[3];
                                    LoopsFileText[a + 0x31] = LengthArray[4];
                                    LoopsFileText[a + 0x32] = LengthArray[5];
                                    LoopsFileText[a + 0x33] = LengthArray[6];
                                    LoopsFileText[a + 0x34] = LengthArray[7];
                                }
                            }
                        }
                        int startindex = 0;
                        int foundoffset = -1;

                        while (startindex < LoopsFileText.Length - 4 && foundoffset == -1)
                        {
                            if (LoopsFileText[startindex] == WEMNumericBytes[0] && LoopsFileText[startindex + 1] == WEMNumericBytes[1] && LoopsFileText[startindex + 2] == WEMNumericBytes[2] && LoopsFileText[startindex + 3] == WEMNumericBytes[3])
                            {
                                foundoffset = startindex;
                                //MessageBox.Show("First WEM ID Offset:" + foundoffset.ToString("X2"));
                            }
                            else
                            {
                                startindex = startindex + 1;
                            }
                        }
                        for (int b = foundoffset; b < LoopsFileText.Length; b++)
                        {
                            if (LoopsFileText[b] == 0x48 && LoopsFileText[b + 1] == 0xD6 && LoopsFileText[b + 2] == 0xBB && LoopsFileText[b + 3] == 0x5B)
                            {
                                HOIDCount = HOIDCount + 1;
                                //MessageBox.Show("HO Count: " + HOIDCount.ToString());

                                if (HOIDCount == 1)
                                {
                                    LoopsFileText[b + 0x04] = SizeofBArray[0];
                                    LoopsFileText[b + 0x05] = SizeofBArray[1];
                                    LoopsFileText[b + 0x06] = SizeofBArray[2];
                                    LoopsFileText[b + 0x07] = SizeofBArray[3];
                                    LoopsFileText[b + 0x08] = SizeofBArray[4];
                                    LoopsFileText[b + 0x09] = SizeofBArray[5];
                                    LoopsFileText[b + 0x0A] = SizeofBArray[6];
                                    LoopsFileText[b + 0x0B] = SizeofBArray[7];

                                    LoopsFileText[b - 0x1C] = SizeofBArray[0];
                                    LoopsFileText[b - 0x1B] = SizeofBArray[1];
                                    LoopsFileText[b - 0x1A] = SizeofBArray[2];
                                    LoopsFileText[b - 0x19] = SizeofBArray[3];
                                    LoopsFileText[b - 0x18] = SizeofBArray[4];
                                    LoopsFileText[b - 0x17] = SizeofBArray[5];
                                    LoopsFileText[b - 0x16] = SizeofBArray[6];
                                    LoopsFileText[b - 0x15] = SizeofBArray[7];
                                }
                                if (HOIDCount == 2)
                                {
                                    LoopsFileText[b + 0x04] = SizeofAArray[0];
                                    LoopsFileText[b + 0x05] = SizeofAArray[1];
                                    LoopsFileText[b + 0x06] = SizeofAArray[2];
                                    LoopsFileText[b + 0x07] = SizeofAArray[3];
                                    LoopsFileText[b + 0x08] = SizeofAArray[4];
                                    LoopsFileText[b + 0x09] = SizeofAArray[5];
                                    LoopsFileText[b + 0x0A] = SizeofAArray[6];
                                    LoopsFileText[b + 0x0B] = SizeofAArray[7];

                                    LoopsFileText[b - 0x1C] = SizeofAArray[0];
                                    LoopsFileText[b - 0x1B] = SizeofAArray[1];
                                    LoopsFileText[b - 0x1A] = SizeofAArray[2];
                                    LoopsFileText[b - 0x19] = SizeofAArray[3];
                                    LoopsFileText[b - 0x18] = SizeofAArray[4];
                                    LoopsFileText[b - 0x17] = SizeofAArray[5];
                                    LoopsFileText[b - 0x16] = SizeofAArray[6];
                                    LoopsFileText[b - 0x15] = SizeofAArray[7];
                                }
                            }
                        }
                    }

                    //MessageBox.Show("WEM Count:" + WEMIDCountFileChecker.ToString());
                    if (WEMIDCountFileChecker > 4)
                    {
                        MessageBox.Show("Unexpected Error" + "More than 4 WEM IDs somehow?");
                    }
                    if (WEMIDCountFileChecker < 4)
                    {
                        MessageBox.Show("This WEM ID has apparently has no loop to it?" + "Too few WEM IDs inside the file.");
                    }

                    SaveFileDialog SaveDialogStreaming = new SaveFileDialog();
                    SaveDialogStreaming.Title = "Save As: natives/x64/streaming/sound/wwise/<filename>.pck.3.x64";
                    SaveDialogStreaming.FileName = "Stream";
                    SaveDialogStreaming.Filter = "(*.pck.3.x64)|*.pck.3.x64|(*.pck)|*.pck|All files (*.*)|*.*";
                    SaveDialogStreaming.CheckPathExists = true;
                    SaveDialogStreaming.RestoreDirectory = true;
                    if (SaveDialogStreaming.ShowDialog() == DialogResult.OK)
                    {
                        FilesSavedCount = FilesSavedCount + 1;
                        File.WriteAllBytes(SaveDialogStreaming.FileName, StreamingFileText);
                    }

                    SaveFileDialog SaveDialogOffset = new SaveFileDialog();
                    SaveDialogOffset.Title = "Save As: natives/x64/sound/wwise/<filename>.pck.3.x64";
                    SaveDialogOffset.FileName = "Offset";
                    SaveDialogOffset.Filter = "(*.pck.3.x64)|*.pck.3.x64|(*.pck)|*.pck|All files (*.*)|*.*";
                    SaveDialogOffset.CheckPathExists = true;
                    SaveDialogOffset.RestoreDirectory = true;
                    if (SaveDialogOffset.ShowDialog() == DialogResult.OK)
                    {
                        FilesSavedCount = FilesSavedCount + 1;
                        File.WriteAllBytes(SaveDialogOffset.FileName, StreamingArray.ToArray());
                    }

                    SaveFileDialog SaveDialogLoops = new SaveFileDialog();
                    SaveDialogLoops.Title = "Save As: natives/x64/streaming/sound/wwise/<filename>.bnk.2.x64";
                    SaveDialogLoops.FileName = "Loop";
                    SaveDialogLoops.Filter = "(*.bnk.2.x64)|*.bnk.2.x64|(*.pck)|*.pck|All files (*.*)|*.*";
                    SaveDialogLoops.CheckPathExists = true;
                    SaveDialogLoops.RestoreDirectory = true;
                    if (SaveDialogLoops.ShowDialog() == DialogResult.OK)
                    {
                        FilesSavedCount = FilesSavedCount + 1;
                        LoopsFileSaved = true;
                        File.WriteAllBytes(SaveDialogLoops.FileName, LoopsFileText);
                    }
                    
                    if (LoopsFileSaved == true)
                    {
                        StreamingFileText = File.ReadAllBytes(StreamingPath);
                        OffsetFileText = File.ReadAllBytes(OffsetPath);
                        LoopsFileText = File.ReadAllBytes(LoopsPath);
                    }

                    if (FilesSavedCount >= 1)
                    {
                        FilesSavedLabel.Visible = true;

                        var t = new Timer();
                        t.Interval = 3000; // it will Tick in 3 seconds
                        t.Tick += (s, f) =>
                        {
                            FilesSavedLabel.Hide();
                            t.Stop();
                        };
                        t.Start();

                        if (FilesSavedLabel.Visible == true)
                        {
                            FilesOpenedLabel.Hide();
                        }
                    }
                }
            }
        }
        private void WEMComboBox_TextChanged(object sender, EventArgs e)
        {
            if (WEMComboBox.Text == "Public Enemy" | WEMComboBox.Text == "DMC1 Track 1" | WEMComboBox.Text == "409499718")
            {
                WEMComboBox.Text = "409499718";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(238, 40);
                WEMIDLabel.Text = "Public Enemy";
                WEMIDLabel.Visible = true;
                if (PublicEnemyBool == false)
                {
                    MessageBox.Show("Not sure if Public Enemy should have Swap Sections Enabled or not." + "\n" + "It looked weird in the code.");
                }
                PublicEnemyBool = true;
            }
            else if (WEMComboBox.Text != "51877771" | WEMComboBox.Text != "393680703" | WEMComboBox.Text != "409499718" | WEMComboBox.Text != "62179196" | WEMComboBox.Text != "373347928" | WEMComboBox.Text != "500567106" | WEMComboBox.Text != "156523713" | WEMComboBox.Text != "513281663" | WEMComboBox.Text != "564871137" | WEMComboBox.Text != "263004481" | WEMComboBox.Text != "357057684" | WEMComboBox.Text != "975171463")
            {
                WEMIDLabel.Text = "";
                WEMIDLabel.Visible = false;
            }

            if (WEMComboBox.Text == "Ultra Violet" | WEMComboBox.Text == "Nelo Angelo" | WEMComboBox.Text == "DMC1 Track 2" | WEMComboBox.Text == "51877771")
            {
                WEMComboBox.Text = "51877771";
                SectionCheckbox.Checked = false;
                WEMIDLabel.Location = new System.Drawing.Point(251, 40);
                WEMIDLabel.Text = "Ultra Violet";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Lock & Load" | WEMComboBox.Text == "Lock and Load" | WEMComboBox.Text == "DMC1 Lock & Load" | WEMComboBox.Text == "DMC1 Track 3" | WEMComboBox.Text == "393680703")
            {
                WEMComboBox.Text = "393680703";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(230, 40);
                WEMIDLabel.Text = "Lock and Load";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Fire Away" | WEMComboBox.Text == "DMC2 Track 1" | WEMComboBox.Text == "62179196")
            {
                WEMComboBox.Text = "62179196";
                SectionCheckbox.Checked = false;
                WEMIDLabel.Location = new System.Drawing.Point(256, 40);
                WEMIDLabel.Text = "Fire Away";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Wings of the GUARDIAN" | WEMComboBox.Text == "Wings of the Guardian" | WEMComboBox.Text == "Lucia" | WEMComboBox.Text == "DMC2 Track 2" | WEMComboBox.Text == "500567106")
            {
                WEMComboBox.Text = "500567106";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(182, 40);
                WEMIDLabel.Text = "Wings of the GUARDIAN";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Shoot the Works" | WEMComboBox.Text == "DMC2 Track 3" | WEMComboBox.Text == "373347928")
            {
                WEMComboBox.Text = "373347928";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(222, 40);
                WEMIDLabel.Text = "Shoot the Works";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Battle-1" | WEMComboBox.Text == "Battle 1" | WEMComboBox.Text == "Taste the Blood" | WEMComboBox.Text == "Taste The Blood" | WEMComboBox.Text == "DMC3 Track 1" | WEMComboBox.Text == "513281663")
            {
                WEMComboBox.Text = "513281663";
                SectionCheckbox.Checked = false;
                WEMIDLabel.Location = new System.Drawing.Point(266, 40);
                WEMIDLabel.Text = "Battle-1";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Vergil Battle-2" | WEMComboBox.Text == "Vergil" | WEMComboBox.Text == "Vergil Battle" | WEMComboBox.Text == "Vergil Battle 2" | WEMComboBox.Text == "DMC3 Track 2" | WEMComboBox.Text == "564871137")
            {
                WEMComboBox.Text = "564871137";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(237, 40);
                WEMIDLabel.Text = "Vergil Battle-2";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Devils Never Cry" | WEMComboBox.Text == "End Credits" | WEMComboBox.Text == "Credits" | WEMComboBox.Text == "DMC3 Track 3" | WEMComboBox.Text == "156523713")
            {
                WEMComboBox.Text = "156523713";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(223, 40);
                WEMIDLabel.Text = "Devils Never Cry";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "The Time Has Come" | WEMComboBox.Text == "DMC4 Track 1" | WEMComboBox.Text == "263004481")
            {
                WEMComboBox.Text = "263004481";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(205, 40);
                WEMIDLabel.Text = "The Time Has Come";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Lock and Load -Blackened Angel mix-" | WEMComboBox.Text == "Lock & Load -Blackened Angel mix-" | WEMComboBox.Text == "DMC4 Lock and Load" | WEMComboBox.Text == "DMC4 Lock & Load" | WEMComboBox.Text == "DMC4 Track 2" | WEMComboBox.Text == "357057684")
            {
                WEMComboBox.Text = "357057684";
                SectionCheckbox.Checked = false;
                WEMIDLabel.Location = new System.Drawing.Point(122, 40);
                WEMIDLabel.Text = "Lock and Load -Blackened Angel mix-";
                WEMIDLabel.Visible = true;
            }

            if (WEMComboBox.Text == "Sworn Through Swords" | WEMComboBox.Text == "DMC4 Track 3" | WEMComboBox.Text == "975171463")
            {
                WEMComboBox.Text = "975171463";
                SectionCheckbox.Checked = true;
                WEMIDLabel.Location = new System.Drawing.Point(191, 40);
                WEMIDLabel.Text = "Sworn Through Swords";
                WEMIDLabel.Visible = true;
            }
        }
        private void WEMComboBox_Click(object sender, EventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void WEMComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }

        }
        private void WEMComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }

        }
        private void StartNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void StartNumeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void StartNumeric_Click(object sender, EventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LoopStartNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LoopStartNumeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            { 
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LoopStartNumeric_Click(object sender, EventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LoopEndNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LoopEndNumeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            { 
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LoopEndNumeric_Click(object sender, EventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LengthNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LengthNumeric_KeyUp(object sender, KeyEventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void LengthNumeric_Click(object sender, EventArgs e)
        {
            if (WEMComboBox.Text == "" || WEMComboBox.Text == "0" || StartNumeric.Text == "" || LoopStartNumeric.Text == "" || LoopEndNumeric.Text == "" || LengthNumeric.Text == "")
            {
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
            }
            else
            {
                SaveButton.Enabled = true;
                SaveAsButton.Enabled = true;
            }
        }
        private void HowtoUseButton_Click(object sender, EventArgs e)
        {
            if (HowToUseBool == false)
            {
                HowToUseBool = true;
                OpenButton.Enabled = false;
                SaveButton.Enabled = false;
                SaveAsButton.Enabled = false;
                FilesOpenedLabel.Visible = false;
                FilesSavedLabel.Visible = false;
                WEMIDLabel.Visible = false;
                WEMLabel.Visible = false;
                WEMComboBox.Visible = false;
                StartLabel.Visible = false;
                StartNumeric.Visible = false;
                LoopStartLabel.Visible = false;
                LoopStartNumeric.Visible = false;
                LoopEndLabel.Visible = false;
                LoopEndNumeric.Visible = false;
                LengthLabel.Visible = false;
                LengthNumeric.Visible = false;
                SectionCheckbox.Visible = false;
                HowToUseTextbox.Visible = true;
                return;
            }
            else if (HowToUseBool == true)
            {
                HowToUseBool = false;
                HowToUseTextbox.Visible = false;
                OpenButton.Enabled = true;
                WEMLabel.Visible = true;
                WEMComboBox.Visible = true;
                StartLabel.Visible = true;
                StartNumeric.Visible = true;
                LoopStartLabel.Visible = true;
                LoopStartNumeric.Visible = true;
                LoopEndLabel.Visible = true;
                LoopEndNumeric.Visible = true;
                LengthLabel.Visible = true;
                LengthNumeric.Visible = true;
                SectionCheckbox.Visible = true;


                if (WEMComboBox.Text != "" && StartNumeric.Text != "" && LoopStartNumeric.Text != "" && LoopEndNumeric.Text != "" && LengthNumeric.Text != "")
                {
                    SaveButton.Enabled = true;
                    SaveAsButton.Enabled = true;
                }

                if (WEMComboBox.Text == "Public Enemy" | WEMComboBox.Text == "DMC1 Track 1" | WEMComboBox.Text == "409499718")
                {
                    WEMComboBox.Text = "409499718";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(238, 40);
                    WEMIDLabel.Text = "Public Enemy";
                    WEMIDLabel.Visible = true;
                }
                else if (WEMComboBox.Text != "51877771" | WEMComboBox.Text != "393680703" | WEMComboBox.Text != "409499718" | WEMComboBox.Text != "62179196" | WEMComboBox.Text != "373347928" | WEMComboBox.Text != "500567106" | WEMComboBox.Text != "156523713" | WEMComboBox.Text != "513281663" | WEMComboBox.Text != "564871137" | WEMComboBox.Text != "263004481" | WEMComboBox.Text != "357057684" | WEMComboBox.Text != "975171463")
                {
                    WEMIDLabel.Text = "";
                    WEMIDLabel.Visible = false;
                }

                if (WEMComboBox.Text == "Ultra Violet" | WEMComboBox.Text == "Nelo Angelo" | WEMComboBox.Text == "DMC1 Track 2" | WEMComboBox.Text == "51877771")
                {
                    WEMComboBox.Text = "51877771";
                    SectionCheckbox.Checked = false;
                    WEMIDLabel.Location = new System.Drawing.Point(251, 40);
                    WEMIDLabel.Text = "Ultra Violet";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Lock & Load" | WEMComboBox.Text == "Lock and Load" | WEMComboBox.Text == "DMC1 Lock & Load" | WEMComboBox.Text == "DMC1 Track 3" | WEMComboBox.Text == "393680703")
                {
                    WEMComboBox.Text = "393680703";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(230, 40);
                    WEMIDLabel.Text = "Lock and Load";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Fire Away" | WEMComboBox.Text == "DMC2 Track 1" | WEMComboBox.Text == "62179196")
                {
                    WEMComboBox.Text = "62179196";
                    SectionCheckbox.Checked = false;
                    WEMIDLabel.Location = new System.Drawing.Point(256, 40);
                    WEMIDLabel.Text = "Fire Away";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Wings of the GUARDIAN" | WEMComboBox.Text == "Wings of the Guardian" | WEMComboBox.Text == "Lucia" | WEMComboBox.Text == "DMC2 Track 2" | WEMComboBox.Text == "500567106")
                {
                    WEMComboBox.Text = "500567106";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(182, 40);
                    WEMIDLabel.Text = "Wings of the GUARDIAN";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Shoot the Works" | WEMComboBox.Text == "DMC2 Track 3" | WEMComboBox.Text == "373347928")
                {
                    WEMComboBox.Text = "373347928";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(222, 40);
                    WEMIDLabel.Text = "Shoot the Works";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Battle-1" | WEMComboBox.Text == "Battle 1" | WEMComboBox.Text == "Taste the Blood" | WEMComboBox.Text == "Taste The Blood" | WEMComboBox.Text == "DMC3 Track 1" | WEMComboBox.Text == "513281663")
                {
                    WEMComboBox.Text = "513281663";
                    SectionCheckbox.Checked = false;
                    WEMIDLabel.Location = new System.Drawing.Point(266, 40);
                    WEMIDLabel.Text = "Battle-1";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Vergil Battle-2" | WEMComboBox.Text == "Vergil" | WEMComboBox.Text == "Vergil Battle" | WEMComboBox.Text == "Vergil Battle 2" | WEMComboBox.Text == "DMC3 Track 2" | WEMComboBox.Text == "564871137")
                {
                    WEMComboBox.Text = "564871137";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(237, 40);
                    WEMIDLabel.Text = "Vergil Battle-2";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Devils Never Cry" | WEMComboBox.Text == "End Credits" | WEMComboBox.Text == "Credits" | WEMComboBox.Text == "DMC3 Track 3" | WEMComboBox.Text == "156523713")
                {
                    WEMComboBox.Text = "156523713";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(223, 40);
                    WEMIDLabel.Text = "Devils Never Cry";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "The Time Has Come" | WEMComboBox.Text == "DMC4 Track 1" | WEMComboBox.Text == "263004481")
                {
                    WEMComboBox.Text = "263004481";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(205, 40);
                    WEMIDLabel.Text = "The Time Has Come";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Lock and Load -Blackened Angel mix-" | WEMComboBox.Text == "Lock & Load -Blackened Angel mix-" | WEMComboBox.Text == "DMC4 Lock and Load" | WEMComboBox.Text == "DMC4 Lock & Load" | WEMComboBox.Text == "DMC4 Track 2" | WEMComboBox.Text == "357057684")
                {
                    WEMComboBox.Text = "357057684";
                    SectionCheckbox.Checked = false;
                    WEMIDLabel.Location = new System.Drawing.Point(122, 40);
                    WEMIDLabel.Text = "Lock and Load -Blackened Angel mix-";
                    WEMIDLabel.Visible = true;
                }

                if (WEMComboBox.Text == "Sworn Through Swords" | WEMComboBox.Text == "DMC4 Track 3" | WEMComboBox.Text == "975171463")
                {
                    WEMComboBox.Text = "975171463";
                    SectionCheckbox.Checked = true;
                    WEMIDLabel.Location = new System.Drawing.Point(191, 40);
                    WEMIDLabel.Text = "Sworn Through Swords";
                    WEMIDLabel.Visible = true;
                }
                return;
            }
        }
    }
}