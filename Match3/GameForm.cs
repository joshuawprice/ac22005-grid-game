using System.Diagnostics;

namespace Match_Mania {
    public partial class MatchMania : Form {
        Tile[,] Tiles = new Tile[9, 9];
        Tile? SelectedTile { get; set; } = null;


        public MatchMania() {
            InitializeComponent();
            // Setup grid of tiles
            for (int i = 0; i < Tiles.GetLength(0); i++) {
                for (int j = 0; j < Tiles.GetLength(1); j++) {
                    AddTile(new Point(j, i));
                }
            }
        }


        void AddTile(Point p) {
            Tiles[p.Y, p.X] = new Tile(p);
            Tiles[p.Y, p.X].Click += new EventHandler(TileEvent_Click);
            Controls.Add(Tiles[p.Y, p.X]);
        }

        void RotateTiles90Degrees() {
            for (int i = 0; i < Tiles.GetLength(0) / 2; i++) {
                for (int j = i; j < Tiles.GetLength(1) - i - 1; j++) {
                    (Tiles[i, j], Tiles[Tiles.GetLength(0) - j - 1, i]) = (Tiles[Tiles.GetLength(0) - j - 1, i], Tiles[i, j]);
                    (Tiles[i, j], Tiles[Tiles.GetLength(0) - i - 1, Tiles.GetLength(1) - j - 1]) = (Tiles[Tiles.GetLength(0) - i - 1, Tiles.GetLength(1) - j - 1], Tiles[i, j]);
                    (Tiles[i, j], Tiles[j, Tiles.GetLength(1) - i - 1]) = (Tiles[j, Tiles.GetLength(1) - i - 1], Tiles[i, j]);
                }
            }
        }


        void SwapTiles(Tile tile1, Tile tile2) {
            (Tiles[tile1.Position.Y, tile1.Position.X], Tiles[tile2.Position.Y, tile2.Position.X]) = (Tiles[tile2.Position.Y, tile2.Position.X], Tiles[tile1.Position.Y, tile1.Position.X]);
            (tile1.Position, tile2.Position) = (tile2.Position, tile1.Position);
            SelectedTile = null;
        }


        List<Tile> MatchTiles() {
            List<Tile> MatchedTiles = new List<Tile>();

            for (int l = 0; l < 2; l++) {
                for (int i = 0; i < Tiles.GetLength(0); i++) {
                    for (int j = 0; j < Tiles.GetLength(1) - 2; j++) {
                        for (int SearchOffset = 1; j + SearchOffset < Tiles.GetLength(0); SearchOffset++) {
                            if (Tiles[i, j].Color != Tiles[i, j + SearchOffset].Color
                                    || MatchedTiles.Contains(Tiles[i, j + SearchOffset])) {
                break;
                            }

                        //Debug.WriteLine(MatchedTiles.Contains(Tiles[i, j + SearchOffset]));
                        //Debug.WriteLine(SearchOffset);

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

               // Rotate the grid 90 degrees on the second run so that code can be reused, then rotate back to beginning on 
               RotateTiles90Degrees();
                for (int j = 0; j < 2 * l; j++) {
                    RotateTiles90Degrees();
                }

            }

            return MatchedTiles;
        }


        void TileEvent_Click(object sender, EventArgs e) {
            if (SelectedTile == null
                    || !((Tile)sender).IsAdjacent(SelectedTile)) {
                SelectedTile = ((Tile)sender);
                return;
            }

            SwapTiles((Tile)sender, SelectedTile);

            List<Tile> MatchedTiles;
            Debug.WriteLine("h");
            while ((MatchedTiles = MatchTiles()).Count != 0) {
                Debug.WriteLine("here");
                foreach (Tile tile in MatchedTiles) {
                    Controls.Remove(tile);
                    AddTile(tile.Position);
                }
            }
        }
    }
}