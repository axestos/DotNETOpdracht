namespace WcfServiceLibrary1
{
    partial class Shop
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
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.inventoryListBox = new System.Windows.Forms.ListBox();
            this.productsListBox = new System.Windows.Forms.ListBox();
            this.productsLabel = new System.Windows.Forms.Label();
            this.moneyLeftLabel = new System.Windows.Forms.Label();
            this.eurosLabel = new System.Windows.Forms.Label();
            this.buyButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.AutoSize = true;
            this.inventoryLabel.Location = new System.Drawing.Point(45, 43);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(66, 17);
            this.inventoryLabel.TabIndex = 0;
            this.inventoryLabel.Text = "Inventory";
            // 
            // inventoryListBox
            // 
            this.inventoryListBox.FormattingEnabled = true;
            this.inventoryListBox.ItemHeight = 16;
            this.inventoryListBox.Location = new System.Drawing.Point(48, 73);
            this.inventoryListBox.Name = "inventoryListBox";
            this.inventoryListBox.Size = new System.Drawing.Size(233, 164);
            this.inventoryListBox.TabIndex = 1;
            // 
            // productsListBox
            // 
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.ItemHeight = 16;
            this.productsListBox.Location = new System.Drawing.Point(350, 73);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(233, 164);
            this.productsListBox.TabIndex = 2;
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Location = new System.Drawing.Point(347, 43);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(64, 17);
            this.productsLabel.TabIndex = 3;
            this.productsLabel.Text = "Products";
            // 
            // moneyLeftLabel
            // 
            this.moneyLeftLabel.AutoSize = true;
            this.moneyLeftLabel.Location = new System.Drawing.Point(45, 273);
            this.moneyLeftLabel.Name = "moneyLeftLabel";
            this.moneyLeftLabel.Size = new System.Drawing.Size(89, 17);
            this.moneyLeftLabel.TabIndex = 4;
            this.moneyLeftLabel.Text = "Money left: €";
            // 
            // eurosLabel
            // 
            this.eurosLabel.AutoSize = true;
            this.eurosLabel.Location = new System.Drawing.Point(128, 273);
            this.eurosLabel.Name = "eurosLabel";
            this.eurosLabel.Size = new System.Drawing.Size(44, 17);
            this.eurosLabel.TabIndex = 5;
            this.eurosLabel.Text = "euros";
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(350, 289);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(75, 23);
            this.buyButton.TabIndex = 6;
            this.buyButton.Text = "Buy";
            this.buyButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(508, 289);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 7;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 399);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.eurosLabel);
            this.Controls.Add(this.moneyLeftLabel);
            this.Controls.Add(this.productsLabel);
            this.Controls.Add(this.productsListBox);
            this.Controls.Add(this.inventoryListBox);
            this.Controls.Add(this.inventoryLabel);
            this.Name = "Shop";
            this.Text = "Shop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.ListBox inventoryListBox;
        private System.Windows.Forms.ListBox productsListBox;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.Label moneyLeftLabel;
        private System.Windows.Forms.Label eurosLabel;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button refreshButton;
    }
}