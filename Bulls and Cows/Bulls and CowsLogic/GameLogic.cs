using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Bulls_and_CowsLogic
{
    public class GameLogic
    {
        private const int k_NumberOfColorsPossibel = 8;
        private Color [] m_AraayOfAllColors;
        private int[] m_ComputerChoice;
        public const int k_NumberOfLetterToRandom = 4;

        public GameLogic()
        {
            m_AraayOfAllColors = new Color[k_NumberOfColorsPossibel];
            m_ComputerChoice = new int[k_NumberOfLetterToRandom];
            UpdateTheArrayColor();
            StartLotteryComputerSelection();
        }

        private void UpdateTheArrayColor()
        {
            m_AraayOfAllColors[0] = Color.Fuchsia;
            m_AraayOfAllColors[1] = Color.Red;
            m_AraayOfAllColors[2] = Color.LawnGreen;
            m_AraayOfAllColors[3] = Color.Cyan; 
            m_AraayOfAllColors[4] = Color.Blue;
            m_AraayOfAllColors[5] = Color.Yellow;
            m_AraayOfAllColors[6] = Color.DarkRed;
            m_AraayOfAllColors[7] = Color.White;
        }

        public void StartLotteryComputerSelection()
        {
            int randomLetterInInt;
            Random rnd = new Random();

            for (int i = 0; i < k_NumberOfLetterToRandom; i++)
            {
                randomLetterInInt = rnd.Next(0,7);
                while (ChecckIfAlreadyChoosed(i, randomLetterInInt))
                {
                    randomLetterInInt = rnd.Next(0, 7);
                }
                m_ComputerChoice[i] = randomLetterInInt;
            }
        }

        private bool ChecckIfAlreadyChoosed(int i_LogicLengthOfArray, int i_TheNumberThatChoosed)
        {
            bool alreadyChoosed = false;

            for(int i = 0; i < i_LogicLengthOfArray; i++)
            {
                if(m_ComputerChoice[i] == i_TheNumberThatChoosed)
                {
                    alreadyChoosed = true;
                }
            }
            return alreadyChoosed;
        }

        public List<Color> CheckedSolution(ref bool io_CorrectResult ,params Color [] i_Solution)
        {
            int countOfX = 0;
            int countOfV = 0;

            if (i_Solution.Length!= m_ComputerChoice.Length)
            {
                throw new Exception();
            }
            for(int i = 0; i < m_ComputerChoice.Length; i++)
            {
                for(int j = 0 ; j < m_ComputerChoice.Length; j++)
                {
                    if (i_Solution[i].Equals(m_AraayOfAllColors[m_ComputerChoice[j]]) && i==j)
                    {
                        countOfV++;
                    }
                    if (i_Solution[i].Equals(m_AraayOfAllColors[m_ComputerChoice[j]]) && i != j)
                    {
                        countOfX++;
                    }
                }
            }
            if(countOfV == k_NumberOfLetterToRandom)
            {
                io_CorrectResult = true;
            }
            return BuildResultCalor(countOfV,countOfX);
        }
        
        public List<Color> BuildResultCalor(int i_NumberOfV, int i_NumberOfX)
        {
            List<Color> result = new List<Color>();

            for(int i = 0; i < i_NumberOfV; i++)
            {
                result.Add(Color.Black);
            }
            for (int i = 0; i < i_NumberOfX; i++)
            {
                result.Add(Color.Yellow);
            }
            for(int i=0; i < 4- i_NumberOfV- i_NumberOfX; i++)
            {
                result.Add(Button.DefaultBackColor);
            }
            return result;
        }

        public List<Color> GetAnswer()
        {
            List<Color> result = new List<Color>();

            for (int i = 0 ; i < 4; i++)
            {
                result.Add(m_AraayOfAllColors[m_ComputerChoice[i]]);
            }
            return result;
        }
    }
}
