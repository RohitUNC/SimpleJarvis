using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Create a new SpeechRecognitionEngine instance.
            SpeechRecognitionEngine recognizer =
                new SpeechRecognitionEngine();

            // Create a simple grammar that recognizes "red", "green", or "blue".
            Choices colors = new Choices();
            colors.Add(new string[] { "switch", "off", "on", "tv", "lights", "fan"});

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(new GrammarBuilder(gb, 0, 4));
            recognizer.LoadGrammar(g);
            
            // Assign input to the recognizer.
            recognizer.SetInputToDefaultAudioDevice();
            
            
            // Register a handler for the SpeechRecognized event.            
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            recognizer.RecognizeAsync(RecognizeMode.Multiple);          
            

        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {            
                MessageBox.Show("Recognized: " + e.Result.Text);            
        }
    }
}