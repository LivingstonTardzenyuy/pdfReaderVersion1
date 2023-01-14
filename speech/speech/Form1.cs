using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
namespace speech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SpeechSynthesizer reader = new SpeechSynthesizer();
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != null)
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Please enter some text first!!!","Status update",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking) ;
                reader.Pause();
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused) ;
                reader.Resume();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dailog = new OpenFileDialog();
                dailog.ShowDialog();
                String file = dailog.FileName;
                richTextBox1.LoadFile(file, RichTextBoxStreamType.RichText);
            }
            catch(Exception u)
            {
                richTextBox1.Text = u.ToString();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

       
    
    }
}
