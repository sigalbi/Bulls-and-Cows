using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Bulls_and_CowsLogic;
namespace Bulls_and_CowsUI
{
    public class GameForm : Form
    {
        private const int k_LengthOfTheSolution = 4;
        private const int k_LegthOfOneEdgeSquere = 35;
        Button[] m_BlackButtons = new Button[k_LengthOfTheSolution];
        List<LineButton> m_ListOfAllLines;
        int m_NumberOfLine=0;
        GameLogic m_GameLogic;

        public GameForm(int i_NumberOfChances)
        {
            m_GameLogic = new GameLogic();
            this.Text = "Bool Pgia";
            this.StartPosition = FormStartPosition.CenterScreen;
            m_ListOfAllLines = new List<LineButton>();
            BuildGameFrom(i_NumberOfChances);
        }

        public GameLogic GameLogics
        {
            get { return m_GameLogic; }
        }

        public static int K_LegthOfOneEdgeSquere => k_LegthOfOneEdgeSquere;

        public Button[] BlackButtons { get => m_BlackButtons; set => m_BlackButtons = value; }

        private void BuildGameFrom(int i_NumberOfChances)
        {
            this.Size = new Size(300, 45*(i_NumberOfChances+1) + 55 );
            AddBlackButtons();
            AddLineOfButtons(i_NumberOfChances);
        }

        private void AddBlackButtons()
        {
            for(int buttonCounter = 0; buttonCounter < k_LengthOfTheSolution; buttonCounter++ )
            {
                m_BlackButtons[buttonCounter] = new Button();
                m_BlackButtons[buttonCounter].Size = new Size(K_LegthOfOneEdgeSquere, K_LegthOfOneEdgeSquere);
                m_BlackButtons[buttonCounter].BackColor = Color.Black;
                m_BlackButtons[buttonCounter].Enabled = false;
                if (buttonCounter == 0)
                {
                    m_BlackButtons[buttonCounter].Location = new Point(this.Location.X + 10, this.Location.Y + 15);
                }
                else
                {
                    m_BlackButtons[buttonCounter].Location = new Point(m_BlackButtons[buttonCounter - 1].Location.X + K_LegthOfOneEdgeSquere + 5, this.Location.Y + 15);
                }
                this.Controls.Add(m_BlackButtons[buttonCounter]);
            }
        }

        private void AddLineOfButtons(int i_NumberOfChances)
        {
            LineButton newLineOfButtons;

            for(int lineCounter = 0; lineCounter < i_NumberOfChances; lineCounter++)
            {
                if (lineCounter == 0)
                {
                    newLineOfButtons = new LineButton(this, m_BlackButtons[1].Location.Y + m_BlackButtons[1].Height + 10);
                    newLineOfButtons.EnableButtons = true;
                }
                else
                {
                    newLineOfButtons = new LineButton(this, m_ListOfAllLines[lineCounter-1].StartHigh + m_BlackButtons[1].Height + 10);
                }
                m_ListOfAllLines.Add(newLineOfButtons);
            }
        }

        public void ValideNextLine()
        {
            m_NumberOfLine++;
            if (m_NumberOfLine < m_ListOfAllLines.Count)
            {
                m_ListOfAllLines[m_NumberOfLine].EnableButtons = true;
            }
            else
            {
                ShowAnswer();
            }
        }

        public void ShowAnswer()
        {
            List<Color> answer;
            answer = m_GameLogic.GetAnswer();
            for (int i = 0; i < k_LengthOfTheSolution; i++)
            {
                m_BlackButtons[i].BackColor = answer[i];
            }
        }
    }
}
