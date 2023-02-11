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


        void SwapTiles(Tile tile1, Tile tile2) {
            (Tiles[tile1.Position.Y, tile1.Position.X], Tiles[tile2.Position.Y, tile2.Position.X]) = (Tiles[tile2.Position.Y, tile2.Position.X], Tiles[tile1.Position.Y, tile1.Position.X]);
            (tile1.Position, tile2.Position) = (tile2.Position, tile1.Position);
            SelectedTile = null;
        }


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


        void TileEvent_Click(object sender, EventArgs e) {
            if (SelectedTile == null
                    || !((Tile)sender).IsAdjacent(SelectedTile)) {
                SelectedTile = ((Tile)sender);
                return;
            }

            SwapTiles((Tile)sender, SelectedTile);

            bool HasMatched = true;
            while (HasMatched) { 
                HasMatched = false;

                List<Tile> MatchedTiles;
                while ((MatchedTiles = MatchHTiles()).Count != 0) {
                    HasMatched = true;
                    foreach (Tile tile in MatchedTiles) {
                        Controls.Remove(tile);
                        AddTile(tile.Position);
                    }
                }

                while ((MatchedTiles = MatchVTiles()).Count != 0) {
                    HasMatched = true;
                    foreach (Tile tile in MatchedTiles) {
                        Controls.Remove(tile);
                        AddTile(tile.Position);
                    }
                }
            }
        }
    }
}