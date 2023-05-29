using System.Diagnostics;
using System.Net.Sockets;
using System.Numerics;
using SysBot.Base;
using ToTKLIE.Vision;

namespace ToTKLIE
{
    public partial class RamViewer : Form
    {
        public RamViewer()
        {
            InitializeComponent();
        }
        public static SwitchConnectionConfig Config = new SwitchConnectionConfig() { Protocol = SwitchProtocol.WiFi, Port = 6000 };
        public static SwitchSocketAsync SwitchConnection;
        public IReadOnlyList<long> TestPointer2 { get; } = new long[] { 0x472C1D8, 0x678, 0x260, 0x2C4, 0x4C, 0x0C };


        private ulong TestOffset2;

        private ulong CurrentOffset;
        private async void button1_Click(object sender, EventArgs e)
        {
            Config.IP = textBox1.Text;
            SwitchConnection = new SwitchSocketAsync(Config);
            try
            {
                SwitchConnection.Connect();
                TestOffset2 = await SwitchConnection.PointerAll(Offsets.WeaponFusionPointer, CancellationToken.None);

                CurrentOffset = TestOffset2;
                Debug.WriteLine(CurrentOffset);
                textBox2.Text = CurrentOffset.ToString("X");
                Debug.WriteLine("connected");
            }
            catch (SocketException err)
            {
                MessageBox.Show("No Switch Was Found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchConnection.Disconnect();
                Debug.WriteLine("disconnected");
            }
            catch (SocketException err)
            {
                MessageBox.Show("No Switch Connected");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var test = await SwitchConnection.ReadBytesAbsoluteAsync((ulong)Convert.ToInt64(textBox2.Text, 16), (int)numericUpDown1.Value, CancellationToken.None);
            richTextBox1.Text = BitConverter.ToString(test).Replace("-", " ");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var test2 = BigInteger.Parse(richTextBox1.Text.Replace(" ", ""), System.Globalization.NumberStyles.HexNumber).ToByteArray().Reverse().ToArray();
            await SwitchConnection.WriteBytesAbsoluteAsync(test2, (ulong)Convert.ToInt64(textBox2.Text, 16), CancellationToken.None);
        }
    }
}
