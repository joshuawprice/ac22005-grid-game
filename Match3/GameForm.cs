using System.Diagnostics;
using System.Globalization;
using System.Media;

namespace Match_Mania {
    public partial class MatchMania : Form {
        // Fields and properties to be stored.
        Tile[,] Tiles = new Tile[9, 9];
        Tile? SelectedTile { get; set; } = null;
        SoundPlayer player;

        int _score = 0;
        int Score { 
            get { return _score; }
            set {
                _score = value;
                ScoreLabel.Text = _score.ToString();
            }
        }


        // Initialise form.
        public MatchMania() {
            InitializeComponent();
            // Setup grid of tiles
            for (int i = 0; i < Tiles.GetLength(0); i++) {
                for (int j = 0; j < Tiles.GetLength(1); j++) {
                    AddTile(new Point(j, i));
                }
            }

            // Remove all possible matches to begin.
            while (MatchTiles() != 0);

            // Play Music
            // Play short tune by Jonathan Wandag
            player = new SoundPlayer("../../../assets/music.wav");
            player.PlayLooping();
        }


        // Adds Tile to grid of Tiles in specified position.
        void AddTile(Point p) {
            Tiles[p.Y, p.X] = new Tile(p);
            Tiles[p.Y, p.X].Click += new EventHandler(TileEvent_Click);
            Controls.Add(Tiles[p.Y, p.X]);
        }


        // Swap two tiles in the grid.
        void SwapTiles(Tile tile1, Tile tile2) {
            (Tiles[tile1.Position.Y, tile1.Position.X], Tiles[tile2.Position.Y, tile2.Position.X])
                = (Tiles[tile2.Position.Y, tile2.Position.X], Tiles[tile1.Position.Y, tile1.Position.X]);
            (tile1.Position, tile2.Position) = (tile2.Position, tile1.Position);
            SelectedTile = null;
        }


        // Match tiles horizontally and return a list of the tiles which need to be replaced.
        List<Tile> MatchHTiles() {
            List<Tile> MatchedTiles = new List<Tile>();

            for (int i = 0; i < Tiles.GetLength(0); i++) {
                for (int j = 0; j < Tiles.GetLength(1) - 2; j++) {
                    for (int SearchOffset = 1; j + SearchOffset < Tiles.GetLength(1); SearchOffset++) {
                        if (Tiles[i, j].Color != Tiles[i, j + SearchOffset].Color
                                || MatchedTiles.Contains(Tiles[i, j + SearchOffset])) {
                            break;
                        }

                        if (SearchOffset >= 2) {
                            if (SearchOffset == 2) {
                                MatchedTiles.Add(Tiles[i, j]);
                                MatchedTiles.Add(Tiles[i, j + 1]);
                            }

                             MatchedTiles.Add(Tiles[i, j + SearchOffset]);
                        }
                    }
                }
            }

            return MatchedTiles;
        }


        // Match tiles vertically and return a list of the tiles which need to be replaced.
        List<Tile> MatchVTiles() {
            List<Tile> MatchedTiles = new List<Tile>();

            for (int i = 0; i < Tiles.GetLength(0); i++) {
                for (int j = 0; j < Tiles.GetLength(1) - 2; j++) {
                    for (int SearchOffset = 1; j + SearchOffset < Tiles.GetLength(1); SearchOffset++) {
                        if (Tiles[j, i].Color != Tiles[j + SearchOffset, i].Color
                                || MatchedTiles.Contains(Tiles[j + SearchOffset, i])) {
                            break;
                        }

                        if (SearchOffset >= 2) {
                            if (SearchOffset == 2) {
                                MatchedTiles.Add(Tiles[j, i]);
                                MatchedTiles.Add(Tiles[j + 1, i]);
                            }

                            MatchedTiles.Add(Tiles[j + SearchOffset, i]);
                        }
                    }
                }
            }

            return MatchedTiles;
        }


        // Matches tiles and then returns a score based on how many were matched.
        int MatchTiles() {
            int score = 0;
            // Remove horizontal tiles.
            List<Tile> MatchedTiles;
            while ((MatchedTiles = MatchHTiles()).Count != 0) {
                foreach (Tile tile in MatchedTiles) {
                    Controls.Remove(tile);
                    AddTile(tile.Position);
                    score++;
                }
            }

            // Remove vertical tiles.
            while ((MatchedTiles = MatchVTiles()).Count != 0) {
                foreach (Tile tile in MatchedTiles) {
                    Controls.Remove(tile);
                    AddTile(tile.Position);
                    score++;
                }
            }

            return score;
        }


        // Shared event for tiles.
        void TileEvent_Click(object sender, EventArgs e) {
            if (SelectedTile == null
                    || !((Tile)sender).IsAdjacent(SelectedTile)) {
                SelectedTile = ((Tile)sender);
                return;
            }

            SwapTiles((Tile)sender, SelectedTile);

            // Repeat until there's no more tiles that need removing.
            bool HasMatched = true;
            while (HasMatched) { 
                HasMatched = false;

                int score = 0;
                if ((score = MatchTiles()) != 0) {
                    HasMatched = true;
                    Score += score;
                }
            }
        }
    }
}