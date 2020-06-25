namespace SimpleDataBase
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.enterAuthorOrTitleLabel = new System.Windows.Forms.Label();
            this.enterAuthorOrTitleTextBox = new System.Windows.Forms.TextBox();
            this.closeSearchFormButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterAuthorOrTitleLabel
            // 
            this.enterAuthorOrTitleLabel.AutoSize = true;
            this.enterAuthorOrTitleLabel.BackColor = System.Drawing.Color.AliceBlue;
            this.enterAuthorOrTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterAuthorOrTitleLabel.Location = new System.Drawing.Point(85, 47);
            this.enterAuthorOrTitleLabel.Name = "enterAuthorOrTitleLabel";
            this.enterAuthorOrTitleLabel.Size = new System.Drawing.Size(261, 18);
            this.enterAuthorOrTitleLabel.TabIndex = 13;
            this.enterAuthorOrTitleLabel.Text = "Введите название или автора книги:";
            // 
            // enterAuthorOrTitleTextBox
            // 
            this.enterAuthorOrTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enterAuthorOrTitleTextBox.Location = new System.Drawing.Point(53, 95);
            this.enterAuthorOrTitleTextBox.Name = "enterAuthorOrTitleTextBox";
            this.enterAuthorOrTitleTextBox.Size = new System.Drawing.Size(334, 22);
            this.enterAuthorOrTitleTextBox.TabIndex = 19;
            // 
            // closeSearchFormButton
            // 
            this.closeSearchFormButton.BackColor = System.Drawing.Color.ForestGreen;
            this.closeSearchFormButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeSearchFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeSearchFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeSearchFormButton.Location = new System.Drawing.Point(366, 11);
            this.closeSearchFormButton.Name = "closeSearchFormButton";
            this.closeSearchFormButton.Size = new System.Drawing.Size(69, 24);
            this.closeSearchFormButton.TabIndex = 21;
            this.closeSearchFormButton.Text = "Выйти";
            this.closeSearchFormButton.UseVisualStyleBackColor = false;
            this.closeSearchFormButton.Click += new System.EventHandler(this.closeSearchFormButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.ForestGreen;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchButton.Location = new System.Drawing.Point(152, 153);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(114, 36);
            this.searchButton.TabIndex = 20;
            this.searchButton.Text = "Найти";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(447, 239);
            this.Controls.Add(this.closeSearchFormButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.enterAuthorOrTitleTextBox);
            this.Controls.Add(this.enterAuthorOrTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Поиск по названию или автору книги";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterAuthorOrTitleLabel;
        private System.Windows.Forms.TextBox enterAuthorOrTitleTextBox;
        private System.Windows.Forms.Button closeSearchFormButton;
        private System.Windows.Forms.Button searchButton;
    }
}