using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bulls_and_CowsUI
{
    public class NumberOfChancesForm : Form
    {
        private Button m_NumberOfChances;
        private Button m_Strat;
        private int m_NumberOfChancesCounter = 4;

        public NumberOfChancesForm()
        {
            this.Text = "Bool Pgia";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(300, 150);
            MakeNumberOfChancesButton();
            MakeStartButton();
        }

        private void MakeNumberOfChancesButton()
        {
            m_NumberOfChances = new Button();
            m_NumberOfChances.Text = "Number of chances: 4";
            m_NumberOfChances.Location = new Point( this.Location.X + 20   , this.Location.Y +15);
            m_NumberOfChances.Size = new Size(250, 22);
            m_NumberOfChances.Visible = true;
            this.Controls.Add(m_NumberOfChances);
            m_NumberOfChances.Click += new EventHandler(NumberOfChancesClicked);
        }

        private void MakeStartButton()
        {
            m_Strat = new Button();
            m_Strat.Text = "Start";
            m_Strat.Location = new Point(this.Location.X + this.Width - 130, this.Location.Y + this.Height - 70);
            m_Strat.Size = new Size(100, 22);
            m_Strat.Visible = true;
            this.Controls.Add(m_Strat);
            m_Strat.Click += new EventHandler(StartButtonClicked);
        }

        private void NumberOfChancesClicked(object sender , EventArgs e)
        {
            if (m_NumberOfChancesCounter < 10)
            {
                m_NumberOfChancesCounter++;
                m_NumberOfChances.Text = string.Format("Number of chances: {0}" , m_NumberOfChancesCounter.ToString());
            }
            else
            {
                m_NumberOfChancesCounter = 4;
                m_NumberOfChances.Text = string.Format("Number of chances: {0}" , m_NumberOfChancesCounter.ToString());
            }
        }

        private void StartButtonClicked(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            GameForm gameForm = new GameForm(m_NumberOfChancesCounter);
            gameForm.ShowDialog();
        }
    }
}
