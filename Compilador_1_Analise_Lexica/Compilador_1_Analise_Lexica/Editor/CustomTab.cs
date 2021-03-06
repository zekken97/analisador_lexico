﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador_1_Analise_Lexica.Editor
{
    public partial class CustomTab : TabPage
    {
        public LineNumbers.LineNumbers_For_RichTextBox LineNumberTextBox = new LineNumbers.LineNumbers_For_RichTextBox();
        public RichTextBox richTextBox;
        public PanelError panelError;
        private string filePath;

        public CustomTab(string title, string text, string _filePath, TextEditor textError)
            : base(title)
        {
            filePath = _filePath;

            #region RichTextBox

            richTextBox = new RichTextBox();
            Controls.Add(richTextBox);

            richTextBox.BackColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            richTextBox.ForeColor = Color.White;
            richTextBox.Location = new Point(30, 3);
            richTextBox.Name = "richTextBox";
            richTextBox.TabIndex = 1;
            richTextBox.Size = new Size(800, 700);
            richTextBox.Text = text;
            richTextBox.AcceptsTab = true;
            richTextBox.Dock = DockStyle.Right;
            richTextBox.TextChanged += new EventHandler(this.richTextBox_TextChanged);
            richTextBox.MouseClick += new MouseEventHandler(this.richTextBox_MouseClick);

            #endregion

            #region Panel Error

            panelError = new PanelError();
            Controls.Add(panelError);

            this.panelError.Dock = DockStyle.Bottom;
            this.panelError.Location = new Point(0, 510);
            this.panelError.Name = "panelError";
            this.panelError.Size = new Size(827, 195);
            this.panelError.TabIndex = 0;
            panelError.AutoSize = true; 

            #endregion

            CreateLineNumberRichTextBox();

            checkAllKeywords();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            //checkAllKeywords();
        }

        private void richTextBox_MouseClick(object sender, EventArgs e)
        {
            panelError.hidePanels();
        }

        private void CreateLineNumberRichTextBox()
        {
            #region LineNumberTextBox

            LineNumberTextBox = new LineNumbers.LineNumbers_For_RichTextBox();
            Controls.Add(LineNumberTextBox);

            LineNumberTextBox._SeeThroughMode_ = false;
            LineNumberTextBox.AutoSizing = true;
            LineNumberTextBox.BackgroundGradient_AlphaColor = System.Drawing.Color.Empty;
            LineNumberTextBox.BackgroundGradient_BetaColor = System.Drawing.Color.Empty;
            LineNumberTextBox.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            LineNumberTextBox.BorderLines_Color = System.Drawing.Color.Empty;
            LineNumberTextBox.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot;
            LineNumberTextBox.BorderLines_Thickness = 1F;
            LineNumberTextBox.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            LineNumberTextBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LineNumberTextBox.GridLines_Color = System.Drawing.Color.Empty;
            LineNumberTextBox.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            LineNumberTextBox.GridLines_Thickness = 1F;
            LineNumberTextBox.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            LineNumberTextBox.LineNrs_AntiAlias = true;
            LineNumberTextBox.LineNrs_AsHexadecimal = false;
            LineNumberTextBox.LineNrs_ClippedByItemRectangle = true;
            LineNumberTextBox.LineNrs_LeadingZeroes = true;
            LineNumberTextBox.LineNrs_Offset = new System.Drawing.Size(0, 0);
            LineNumberTextBox.Location = new Point(3, 3);
            LineNumberTextBox.Margin = new System.Windows.Forms.Padding(0);
            LineNumberTextBox.MarginLines_Color = System.Drawing.Color.Empty;
            LineNumberTextBox.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            LineNumberTextBox.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            LineNumberTextBox.MarginLines_Thickness = 1F;
            LineNumberTextBox.Name = "LineNumberTextBox";
            LineNumberTextBox.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            LineNumberTextBox.ParentRichTextBox = richTextBox;
            LineNumberTextBox.Show_BackgroundGradient = true;
            LineNumberTextBox.Show_BorderLines = true;
            LineNumberTextBox.Show_GridLines = true;
            LineNumberTextBox.Show_LineNrs = true;
            LineNumberTextBox.Show_MarginLines = true;
            LineNumberTextBox.Size = new Size(40, 695);
            LineNumberTextBox.TabIndex = 0;

            #endregion
        }

        public RichTextBox getRichTextBox()
        {
            return richTextBox;
        }

        public string getFilePath()
        {
            return filePath;
        }

        private void checkAllKeywords()
        {
            Color color = ColorTranslator.FromHtml("#D3B833");

            CheckKeyword("program ", color, 0);
            CheckKeyword("if ", color, 0);
            CheckKeyword("else ", color, 0);
            CheckKeyword("while ", color, 0);
            CheckKeyword("write ", color, 0);
            CheckKeyword("read ", color, 0);
            CheckKeyword("string ", color, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox.SelectionStart;

                while ((index = this.richTextBox.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox.Select((index + startIndex), word.Length);
                    this.richTextBox.SelectionColor = color;
                    this.richTextBox.Select(selectStart, 0);
                    this.richTextBox.SelectionColor = richTextBox.ForeColor;
                }
            }
        }

        public void OpenError()
        {
            panelError.Show();
        }
    }
}
