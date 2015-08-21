namespace WeatherServiceClient
{
    partial class Form1
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
            this.CountryDropDownList = new System.Windows.Forms.ComboBox();
            this.CityDropDownList = new System.Windows.Forms.ComboBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // CountryDropDownList
            // 
            this.CountryDropDownList.FormattingEnabled = true;
            this.CountryDropDownList.Location = new System.Drawing.Point(61, 6);
            this.CountryDropDownList.Name = "CountryDropDownList";
            this.CountryDropDownList.Size = new System.Drawing.Size(121, 21);
            this.CountryDropDownList.TabIndex = 0;
            this.CountryDropDownList.SelectedIndexChanged += new System.EventHandler(this.CountryDropDownList_SelectedIndexChanged);
            // 
            // CityDropDownList
            // 
            this.CityDropDownList.FormattingEnabled = true;
            this.CityDropDownList.Location = new System.Drawing.Point(61, 33);
            this.CityDropDownList.Name = "CityDropDownList";
            this.CityDropDownList.Size = new System.Drawing.Size(121, 21);
            this.CityDropDownList.TabIndex = 1;
            this.CityDropDownList.SelectedIndexChanged += new System.EventHandler(this.CityDropDownList_SelectedIndexChanged);
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(9, 9);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(46, 13);
            this.labelCountry.TabIndex = 2;
            this.labelCountry.Text = "Country:";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(9, 36);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(27, 13);
            this.labelCity.TabIndex = 3;
            this.labelCity.Text = "City:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 60);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(490, 238);
            this.webBrowser1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(514, 306);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.CityDropDownList);
            this.Controls.Add(this.CountryDropDownList);
            this.Name = "Form1";
            this.Text = "Weather Service Client - webservicex.net";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CountryDropDownList;
        private System.Windows.Forms.ComboBox CityDropDownList;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.WebBrowser webBrowser1;


    }
}

