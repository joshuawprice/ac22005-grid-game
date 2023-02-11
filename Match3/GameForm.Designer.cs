namespace Match_Mania
{
    partial class MatchMania
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.ScoreHeadingLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe Print", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(13, 9);
            this.Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(720, 252);
            this.Title.TabIndex = 0;
            this.Title.Text = "Match 3";
            // 
            // ScoreHeadingLabel
            // 
            this.ScoreHeadingLabel.AutoSize = true;
            this.ScoreHeadingLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreHeadingLabel.Location = new System.Drawing.Point(899, 9);
            this.ScoreHeadingLabel.Name = "ScoreHeadingLabel";
            this.ScoreHeadingLabel.Size = new System.Drawing.Size(109, 48);
            this.ScoreHeadingLabel.TabIndex = 1;
            this.ScoreHeadingLabel.Text = "Score";
            this.ScoreHeadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreLabel.Location = new System.Drawing.Point(899, 57);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(32, 38);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "0";
            this.ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MatchMania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 1452);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.ScoreHeadingLabel);
            this.Controls.Add(this.Title);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MatchMania";
            this.Text = "Match Mania";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Title;
        private Label ScoreHeadingLabel;
        private Label ScoreLabel;
    }
}