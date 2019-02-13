using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bulls_and_CowsUI
{
    public class LineButton : Form
    {
        private const int k_LegthOfOneEdgeSquere = 35;
        private const int k_LengthOfTheSolution = 4;
        List<Button> m_ListOfButtons;
        List<Button> m_New4ResultButtons = new List<Button>();
        GameForm m_OriginalForm;
        Button m_Arrow;
        bool m_EnableButtons;
        int m_StartHight;

        public LineButton(GameForm i_OriginalBoard, int i_HeightToStart)
        {
            m_ListOfButtons = new List<Button>();
            m_New4ResultButtons = new List<Button>();
            m_StartHight = i_HeightToStart;
            m_OriginalForm = i_OriginalBoard;
            m_EnableButtons = false;
            MakeChooseColorButten(i_HeightToStart);
            MakeArrowButton();
            Make4ResultButtons();
        }

        public int StartHigh
        {
            set { m_StartHight = value; }

            get { return m_StartHight; }
        }

        public bool EnableButtons
        {
            set
            {
                m_EnableButtons = value;
                UpdateButtonEnable(value);
            }
            get { return m_EnableButtons; }
        }

        private void UpdateButtonEnable(bool i_ValueButten)
        {
            foreach (Button button in m_ListOfButtons)
            {
                button.Enabled = i_ValueButten;
            }
        }

        private void MakeChooseColorButten(int i_HeightToStart)
        {
            Button newButton;

            for (int buttonCounter = 0; buttonCounter < k_LengthOfTheSolution; buttonCounter++)
            {
                newButton = new Button();
                newButton.Size = new Size(k_LegthOfOneEdgeSquere, k_LegthOfOneEdgeSquere);
                newButton.Enabled = m_EnableButtons;
                if (buttonCounter == 0)
                {
                    newButton.Location = new Point(m_OriginalForm.Location.X + 10, i_HeightToStart);
                }
                else
                {
                    newButton.Location = new Point(m_ListOfButtons[buttonCounter - 1].Location.X + k_LegthOfOneEdgeSquere + 5, i_HeightToStart);
                }
                m_ListOfButtons.Add(newButton);
                newButton.Visible = true;
                m_OriginalForm.Controls.Add(newButton);
                newButton.Click += new EventHandler(ChooseColorButtonClicked);
            }
        }

        private void MakeArrowButton()
        {
            Button newArrowButton = new Button();
            newArrowButton.Text = "->>";
            newArrowButton.Enabled = false;
            newArrowButton.Size = new Size(45, 17);
            newArrowButton.Location = new Point(m_ListOfButtons[3].Location.X + 45, m_ListOfButtons[3].Location.Y + 8);
            m_Arrow = newArrowButton;
            m_OriginalForm.Controls.Add(m_Arrow);
            m_Arrow.Click += new EventHandler(ArrowClicked);
        }

        private void Make4ResultButtons()
        {
            for (int counterOfResultButtons = 0; counterOfResultButtons < k_LengthOfTheSolution; counterOfResultButtons++)
            {
                Button newResultButton = new Button();
                newResultButton.Enabled = false;
                newResultButton.Size = new Size(17, 17);
                m_OriginalForm.Controls.Add(newResultButton);
                m_New4ResultButtons.Add(newResultButton);
            }
            m_New4ResultButtons[0].Location = new Point(m_Arrow.Location.X + 45 + 15, m_Arrow.Location.Y - 10);
            m_New4ResultButtons[1].Location = new Point(m_New4ResultButtons[0].Location.X + 5 + 15, m_Arrow.Location.Y - 10);
            m_New4ResultButtons[2].Location = new Point(m_Arrow.Location.X + 45 + 15, m_New4ResultButtons[0].Location.Y + 21);
            m_New4ResultButtons[3].Location = new Point(m_New4ResultButtons[0].Location.X + 5 + 15, m_New4ResultButtons[0].Location.Y + 21);
        }

        private void ArrowClicked(object sender, EventArgs e)
        {
            int index = 0;
            List<Color> result;
            bool correctResult = false;
            result = m_OriginalForm.GameLogics.CheckedSolution(ref correctResult, m_ListOfButtons[0].BackColor, m_ListOfButtons[1].BackColor, m_ListOfButtons[2].BackColor, m_ListOfButtons[3].BackColor);
            foreach (Button buttonToChnge in m_New4ResultButtons)
            {
                buttonToChnge.BackColor = result[index];
                index++;
            }
            if (!correctResult)
            {
                m_OriginalForm.ValideNextLine();
            }
            else
            {
                m_OriginalForm.ShowAnswer();
            }
            UpdateButtonEnable(false);
            m_Arrow.Enabled = false;
        }

        private void ChooseColorButtonClicked(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            ChooseColorForm chooseColorForm = new ChooseColorForm(sender as Button);
            chooseColorForm.ShowDialog();
            CheckIfAllButtonsHaveColor();
        }

        public void CheckIfAllButtonsHaveColor()
        {
            bool allPressed = true; 
            foreach( Button buttonInLine in m_ListOfButtons)
            {
                if(buttonInLine.BackColor.Equals(Button.DefaultBackColor))
                {
                    allPressed = false;
                }
            }
            if(allPressed)
            {
                m_Arrow.Enabled = true;
            }
        }
    }
}
