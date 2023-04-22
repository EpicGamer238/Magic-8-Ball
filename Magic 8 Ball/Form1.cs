/* HEADER:
 * Author: Simon Wunderlich
 * For Unit 1 & 2 Computing
 * Date of last edit: 22/04/23
 *
 * SUMMARY: Application that outputs a string of text pulled randomly from a randomly selected word list of either positive, negativ, or neutral answers
 */

/*PSUEDOCODE
 * START
 * LIST positiveWords <- ...
 * LIST neutralWords <- ...
 * LIST negativeWords <- ...
 *
 * LIST wordBank ADD positiveWords, neutralWords, negativeWords
 * LIST frequencies ADD 30, 90, 100
 *
 * NUMERICAL rand <- RANDOM NUMBER FROM 0 TO 100
 *
 * FOR x <- COUNT 3
 *  IF frequencies[x] => rand THEN
 *      DISPLAY RANDOM ITEM FROM wordBank[x]
 */

namespace Magic_8_Ball
{
    public partial class Form1 : Form
    {
        //List of the previous 4 responses
        List<string> current = new List<string>();

        //Word banks seperated based on whether they positive, negaive, or neutral
        string[] _posList =
        {
        "It is certain",
        "It is decidedly so",
        "Without a doubt",
        "Yes, definitely",
        "You may rely on it",
        "As is see it, yes",
        "Most likely",
        "Outlook good",
        "Yes",
        "Signs point to yes"
        };
        string[] _medList =
        {
            "Reply hazy, try again",
            "Ask again later",
            "Better not tell you now",
            "Cannot predict now",
            "Concentrate and ask again"
        };

        string[] _negList =
        {
            "Don't count on it",
            "My reply is no",
            "My sources say no",
            "Outlook not so good",
            "It is doubtful"
        };

        //One big list compiling the three seprate word lists
        List<string[]> _wordBank;

        //List of frequencies, consecutively added onto the previous frequency
        int[] freq = { 10, 40, 100 };

        //Total range of freq list
        int total = 100;

        public Form1()
        {
            InitializeComponent();

            //Adds 4 place holder strings to current so that the list will only ever be able to store 4 elements
            current.Add("PLACEHOLDER");
            current.Add("PLACEHOLDER");
            current.Add("PLACEHOLDER");
            current.Add("PLACEHOLDER");

            //Defines wordbank with the three wordlists
            _wordBank = new List<string[]> { _negList, _posList, _medList };
        }

        public void magic()
        {
            //Adds current magic 8 ball text to 'current' and removes the first element  
            current.Add(label1.Text);
            current.RemoveAt(0);

            //Checks if the new randomly generated text has been used in the past 4 cycles
            while (current.Contains(label1.Text))

                //Generates new word
                label1.Text = word();

        }

        public string word()
        {
            //Creaates new random number generator
            Random rng = new Random();

            //Assigns value to a random number from 0 to 100
            int value = rng.Next(total + 1);

            //Iterates through the word banks' frequencies until it finds a frequency less than value. It then returns a random string from the corresponding word list
            for (int x = 0; x < freq.Length; x++)
            {

                //Checks if currently iterating frequency is greater than value
                if (value <= freq[x])
                {
                    //Returns random string from word list with the same index position as the frequency
                    return _wordBank[x][rng.Next(_wordBank[x].Length)];
                }
            }
            //If the for loop doesn't find a frequency less than value, then it returns 'whoops'
            return "Whoops";
        }

        //When the label is clicked, a new word is generated
        private void label1_Click(object sender, EventArgs e)
        {
            magic();
        }
    }
}