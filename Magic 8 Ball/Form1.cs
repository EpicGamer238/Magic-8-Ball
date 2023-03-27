namespace Magic_8_Ball
{
    public partial class Form1 : Form
    {
        List<string> current = new List<string>();
        string[] _wordList = {
            "Piss yourself",
             "uuuuuuuuuuh",
             "Cry about it",
             "Yes",
             "No",
             "Perhaps",
             "idk man",
             "Maybe?",
             "Try again",
             "Whats So Funny?",
             "epic fail crinnge XDD",
             "That sounds like a you problem"
        };
        public Form1()
        {
            InitializeComponent();
            current.Add("PLACEHOLDER");
            current.Add("PLACEHOLDER");
        }

        public void magic()
        {
            var rand = new Random();
            current.Add(label1.Text);
            current.RemoveAt(0);
            while ((current[0] == label1.Text || current[1] == label1.Text) && current[1] != "Try again")
                label1.Text = _wordList[rand.Next(_wordList.Length)];
            if(label1.Text == "Whats So Funny?")
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C start https://www.youtube.com/watch?v=oZYJIs5tGCU";
                process.StartInfo = startInfo;
                process.Start();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            magic();
        }
    }
}