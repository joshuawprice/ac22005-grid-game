namespace Match_Mania {
    public partial class Match_Mania : Form {
        Tile? SelectedTile { get; set; } = null;

        public Match_Mania() {
            InitializeComponent();
            Random rng = new Random();

            // Setup grid of buttons
            Tile[,] Tiles = new Tile[9, 9];

            for (int i = 0; i < Tiles.GetLength(0); i++)
            {
                for (int j = 0; j < Tiles.GetLength(1); j++)
                {
                    Tiles[i, j] = new Tile(new Point(i, j));
                    Tiles[i, j].Click += new EventHandler(TileEvent_Click);
                    Controls.Add(Tiles[i, j]);
                }
            }
        }

        //private bool IsAdjacent()

        void TileEvent_Click(object sender, EventArgs e) {
            if (SelectedTile == null) {
                SelectedTile = ((Tile)sender);
                return;
            }


        }
    }
}