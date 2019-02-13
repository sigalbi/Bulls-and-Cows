using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bulls_and_CowsUI
{
    class ChooseColorForm : Form
    {
        private const int k_NumberOneLineColor = 4;
        private const int k_LegthOfOneEdgeSquere = 35;
        List<Button> m_ListOfLine1ColorButtons;
        List<Button> m_ListOfLine2ColorButtons;
        Button m_OperatorButton;

        public ChooseColorForm(Button i_OperatorButton)
        {
            m_ListOfLine1ColorButtons = new List<Button>();
            m_ListOfLine2ColorButtons = new List<Button>();

            this.Text = "Pick A Color:";
            this.StartPosition = FormStartPosition.CenterScreen; 
            this.Size = new Size(190, 130);
            m_OperatorButton = i_OperatorButton;
            Make1LineOfColorButtons();
            Make2LineOfColorButtons();
        }

        public Button OperatorButton
        {
            get { return m_OperatorButton; }
            set { m_OperatorButton = value; }
        }

        private void Make1LineOfColorButtons()
        {
            Button newColorButton;

            for (int counterOfColors = 0; counterOfColors < k_NumberOneLineColor; counterOfColors++)
            {
                newColorButton = new Button();
                newColorButton.Size = new Size(k_LegthOfOneEdgeSquere, k_LegthOfOneEdgeSquere);
                newColorButton.Enabled = true;
                if (counterOfColors == 0)
                {
                    newColorButton.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
                }
                else
                {
                    newColorButton.Location = new Point(m_ListOfLine1ColorButtons[counterOfColors - 1].Location.X + k_LegthOfOneEdgeSquere + 5, this.Location.Y + 10);
                }
                m_ListOfLine1ColorButtons.Add(newColorButton);
                newColorButton.Visible = true;
                this.Controls.Add(newColorButton);
                newColorButton.Click += new EventHandler(ColorButtonClicked);
            }
            m_ListOfLine1ColorButtons[0].BackColor = Color.Fuchsia;
            m_ListOfLine1ColorButtons[1].BackColor = Color.Red;
            m_ListOfLine1ColorButtons[2].BackColor = Color.LawnGreen;
            m_ListOfLine1ColorButtons[3].BackColor = Color.Cyan;
        }

        private void Make2LineOfColorButtons()
        {
            Button newColorButton;

            for (int counterOfColors = 0; counterOfColors < k_NumberOneLineColor; counterOfColors++)
            {
                newColorButton = new Button();
                newColorButton.Size = new Size(k_LegthOfOneEdgeSquere, k_LegthOfOneEdgeSquere);
                newColorButton.Enabled = true;
                if (counterOfColors == 0)
                {
                    newColorButton.Location = new Point(this.Location.X + 10, m_ListOfLine1ColorButtons[0].Location.Y + k_LegthOfOneEdgeSquere + 5);
                }
                else
                {
                    newColorButton.Location = new Point(m_ListOfLine2ColorButtons[counterOfColors - 1].Location.X + k_LegthOfOneEdgeSquere + 5, m_ListOfLine1ColorButtons[0].Location.Y + k_LegthOfOneEdgeSquere + 5);
                }
                m_ListOfLine2ColorButtons.Add(newColorButton);
                newColorButton.Visible = true;
                this.Controls.Add(newColorButton);
                newColorButton.Click += new EventHandler(ColorButtonClicked);
            }
            m_ListOfLine2ColorButtons[0].BackColor = Color.Blue;
            m_ListOfLine2ColorButtons[1].BackColor = Color.Yellow;
            m_ListOfLine2ColorButtons[2].BackColor = Color.DarkRed;
            m_ListOfLine2ColorButtons[3].BackColor = Color.White;
        }

        private void ColorButtonClicked(object sender, EventArgs e)
        {
            m_OperatorButton.BackColor = (sender as Button).BackColor;
            this.Hide();
            this.Close();
        }
    }
}
