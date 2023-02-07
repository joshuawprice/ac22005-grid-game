namespace Match3 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Random rng = new Random();

            // Setup grid of buttons
            Button[,] Buttons = new Button[9, 9];

            for (int i = 0; i < Buttons.GetLength(0); i++) {
                for (int j = 0; j < Buttons.GetLength(1); j++) {
                    Buttons[i, j] = new Button();
                    Buttons[i, j].SetBounds(60 * i, 60 * j, 60, 60);
                    Buttons[i, j].BackColor = Color.FromArgb(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
                    Controls.Add(Buttons[i, j]);
                }
            }


            // Add link to the event handler to use when clicked
            //btn.Click += new EventHandler(btnEvent_Click);
        }
        void btnEvent_Click(object sender, EventArgs e) {
            //btn.BackColor = Color.Red;
        }
    }
}