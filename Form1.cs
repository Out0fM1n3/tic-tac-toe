using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class TicTacToe : Form
    {
        //Объявление переменных
        bool Turn = true;
        bool restart = false;
        int TurnCount = 0;
        int p1wins = 0;
        int p2wins = 0;
        public static List<Button> buttons = new List<Button>();
        public static List<Button> buttons9 = new List<Button>();
        public static List<Button> buttons16 = new List<Button>();
        public TicTacToe()
        {
            InitializeComponent();
        }

        //Обработка ходов
        private void ButtonOne_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                if (Turn)
                    button.Text = "×";
                else
                    button.Text = "○";
                Turn = !Turn;
                button.Enabled = false;
                TurnCount++;
                Motion.Text = "Ход номер:" + TurnCount;
                CheckWin();
            }
            catch
            {

            }
        }
        //Сброс игры
        private void Restart()
        {
            buttons.Add(A1);
            buttons.Add(A2);
            buttons.Add(A3);
            buttons.Add(A4);
            buttons.Add(A5);
            buttons.Add(B1);
            buttons.Add(B2);
            buttons.Add(B3);
            buttons.Add(B4);
            buttons.Add(B5);
            buttons.Add(C1);
            buttons.Add(C2);
            buttons.Add(C3);
            buttons.Add(C4);
            buttons.Add(C5);
            buttons.Add(D1);
            buttons.Add(D2);
            buttons.Add(D3);
            buttons.Add(D4);
            buttons.Add(D5);
            buttons.Add(E1);
            buttons.Add(E2);
            buttons.Add(E3);
            buttons.Add(E4);
            buttons.Add(E5);
            buttons16.Add(A5);
            buttons16.Add(B5);
            buttons16.Add(C5);
            buttons16.Add(D5);
            buttons16.Add(E5);
            buttons9.Add(A4);
            buttons9.Add(A5);
            buttons9.Add(B4);
            buttons9.Add(B5);
            buttons9.Add(C4);
            buttons9.Add(C5);
            buttons9.Add(D1);
            buttons9.Add(D2);
            buttons9.Add(D3);
            buttons9.Add(D4);
            buttons9.Add(D5);
            buttons9.Add(E1);
            buttons9.Add(E2);
            buttons9.Add(E3);
            buttons9.Add(E4);
            buttons9.Add(E5);
            if (Cells16.Checked == true)
            {
                foreach (Button button in buttons)
                {
                    button.Visible = true;
                }
                foreach (Button button16 in buttons16)
                {
                    button16.Visible = false;
                }
                Player2.Visible = true;
                Player1.Visible = true;
                Motion.Visible = true;
                Reset.Visible = true;
            }
            else if (Cells25.Checked == true)
            {
                foreach (Button button in buttons)
                {
                    button.Visible = true;
                }
                Player2.Visible = true;
                Player1.Visible = true;
                Motion.Visible = true;
                Reset.Visible = true;
            }
            else if (Cells9.Checked == true)
            {
                foreach (Button button in buttons)
                {
                    button.Visible = true;
                }
                foreach (Button button9 in buttons9)
                        {
                            button9.Visible = false;
                        }
                Player2.Visible = true;
                Player1.Visible = true;
                Motion.Visible = true;
                Reset.Visible = true;
            }
            foreach (Button button in buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }
            Motion.Text = "Ход номер: 0";
            TurnCount = 0;
            restart = !restart;
        }
        private void CheckWin()
        {
            bool win = false;
            if (Cells9.Checked == true)
            {
                //Горизонталь 9 клеток
                if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    win = true;
                else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    win = true;
                else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    win = true;
                //Вертикаль 9 клеток
                if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                    win = true;
                else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                    win = true;
                else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                    win = true;
                //Диагонали 9 клеток
                if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                    win = true;
                if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                    win = true;
            }
            else if (Cells16.Checked == true)
            {
                //Горизонталь 16 клеток
                if (A1.Text == A2.Text && A2.Text == A3.Text && A3.Text == A4.Text && !A1.Enabled)
                    win = true;
                else if (B1.Text == B2.Text && B2.Text == B3.Text && B3.Text == B4.Text && !B1.Enabled)
                    win = true;
                else if (C1.Text == C2.Text && C2.Text == C3.Text && C3.Text == C4.Text && !C1.Enabled)
                    win = true;
                else if (D1.Text == D2.Text && D2.Text == D3.Text && D3.Text == D4.Text && !D1.Enabled)
                    win = true;
                //Вертикаль 16 клеток
                if (A1.Text == B1.Text && B1.Text == C1.Text && C1.Text == D1.Text && !A1.Enabled)
                    win = true;
                else if (A2.Text == B2.Text && B2.Text == C2.Text && C2.Text == D2.Text && !A2.Enabled)
                    win = true;
                else if (A3.Text == B3.Text && B3.Text == C3.Text && C3.Text == D3.Text && !A3.Enabled)
                    win = true;
                else if (A4.Text == B4.Text && B4.Text == C4.Text && C4.Text == D4.Text && !A4.Enabled)
                    win = true;
                //Диагонали 16 клеток
                if (A1.Text == B2.Text && B2.Text == C3.Text && C3.Text == D4.Text && !A1.Enabled)
                    win = true;
                if (A4.Text == B3.Text && B3.Text == C2.Text && C2.Text == D1.Text && !A4.Enabled)
                    win = true;
            }
            else if (Cells25.Checked == true)
            {
                //Горизонталь 25 клеток
                if (A1.Text == A2.Text && A2.Text == A3.Text && A3.Text == A4.Text && A4.Text == A5.Text && !A1.Enabled)
                    win = true;
                else if (B1.Text == B2.Text && B2.Text == B3.Text && B3.Text == B4.Text && B4.Text == B5.Text && !B1.Enabled)
                    win = true;
                else if (C1.Text == C2.Text && C2.Text == C3.Text && C3.Text == C4.Text && C3.Text == C5.Text && !C1.Enabled)
                    win = true;
                else if (D1.Text == D2.Text && D2.Text == D3.Text && D3.Text == D4.Text && D4.Text == D5.Text && !D1.Enabled)
                    win = true;
                else if (E1.Text == E2.Text && E2.Text == E3.Text && E3.Text == E4.Text && E4.Text == E5.Text && !E1.Enabled)
                    win = true;
                //Вертикаль 25 клеток
                if (A1.Text == B1.Text && B1.Text == C1.Text && C1.Text == D1.Text && D1.Text == E1.Text && !A1.Enabled)
                    win = true;
                else if (A2.Text == B2.Text && B2.Text == C2.Text && C2.Text == D2.Text && D2.Text == E2.Text && !A2.Enabled)
                    win = true;
                else if (A3.Text == B3.Text && B3.Text == C3.Text && C3.Text == D3.Text && D3.Text == E3.Text && !A3.Enabled)
                    win = true;
                else if (A4.Text == B4.Text && B4.Text == C4.Text && C4.Text == D4.Text && D4.Text == E4.Text && !A4.Enabled)
                    win = true;
                else if (A5.Text == B5.Text && B5.Text == C5.Text && C5.Text == D5.Text && D5.Text == E5.Text && !A5.Enabled)
                    win = true;
                //Диагонали 25 клеток
                if (A1.Text == B2.Text && B2.Text == C3.Text && C3.Text == D4.Text && D4.Text==E5.Text && !A1.Enabled)
                    win = true;
                if (A5.Text==B4.Text && B4.Text==C3.Text && C3.Text == D2.Text && D2.Text==E1.Text && !A5.Enabled)
                    win = true;
            }

            //Победа
            if (win)
            {
                string winner = "";
                if (Turn == true)
                {
                    p1wins++;
                    winner = "Игрок за нолик выйграл!";
                    Player1.Text = "○ победы: " + p1wins;
                    Turn = true;

                }
                else
                {
                    p2wins++;
                    winner = "Игрок за крестики выйграл!";
                    Player2.Text = "× победы: " + p2wins;
                    Turn = false;
                }
                WinLabel.Text = winner;
                win = false;
                TurnCount = 0;
                Reset.Enabled = false;
                foreach (Button button in buttons)
                {
                    button.Visible = false;
                }
                buttons.Clear();
                NewGame.Visible = true;
                WinLabel.Visible = true;
            }
            //Если ничья
            else
            {
                int i = 0;
                if (Cells16.Checked == true)
                {
                    i = 16;
                }
                else if (Cells25.Checked == true)
                {
                    i = 25;
                }
                else if (Cells9.Checked == true)
                {
                    i = 9;
                }
                if (TurnCount == i)
                {
                    if (Cells16.Checked == true)
                    {
                        WinLabel.Location = new Point(145, 113);
                    }
                    else if (Cells25.Checked == true)
                    {
                        WinLabel.Location = new Point(210, 156);
                    }
                    else if (Cells9.Enabled == true)
                    {
                        WinLabel.Location = new Point(100, 65);
                    }
                    WinLabel.Text="Ничья!";
                    Reset.Enabled = false;
                    foreach (Button button in buttons)
                    {
                        button.Visible = false;
                    }
                    buttons.Clear();
                    NewGame.Visible = true;
                    WinLabel.Visible = true;
                    win = false;
                    Turn = !Turn;
                    TurnCount = 0;

                }
            }
        }
        //Сброс по кнопке
        private void Reset_Click(object sender, EventArgs e)
        {
            Restart();
            p1wins = 0;
            p2wins = 0;
            Player1.Text = "○ победы: 0";
            Player2.Text = "× победы: 0";
            Turn = true;
        }
        //Отрисовка при наведении
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Turn == true && button.Enabled == true)
            {
                button.ForeColor = Color.LightGray;
                button.Text = "×";
            }
            else if (Turn == false && button.Enabled == true)
            {
                button.ForeColor = Color.LightGray;
                button.Text = "○";
            }
        }
        //Сброс отрисовки при наведении
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled == true)
            {
                button.Text = "";
            }
        }
        //Алгоритм после победы
        private void NewGame_Click(object sender, EventArgs e)
        {
            Motion.Text = "Ход номер: 0";
            NewGame.Visible = false;
            WinLabel.Visible = false;
            Reset.Enabled = true;
        }

        private void Cells9_Click(object sender, EventArgs e)
        {
            StartMsg.Visible = false;
            Player1.Location = new Point(305, 31);
            Player2.Location = new Point(306, 55);
            Motion.Location = new Point(300, 79);
            Reset.Location = new Point(292, 130);
            Cells9.Location = new Point(314, 185);
            Cells16.Location = new Point(308, 208);
            Cells25.Location = new Point(308, 231);
            this.ClientSize= new Size(461, 267);
            NewGame.Location = new Point(32, 99);
            WinLabel.Location = new Point(18, 65);
            Restart();
        }

        private void Cells16_Click(object sender, EventArgs e)
        {
            StartMsg.Visible = false;
            Player1.Location = new Point(396, 31);
            Player2.Location = new Point(397, 55);
            Motion.Location = new Point(391, 79);
            Reset.Location = new Point(383, 130);
            Cells9.Location = new Point(405, 185);
            Cells16.Location = new Point(399, 208);
            Cells25.Location = new Point(399, 231);
            this.ClientSize = new Size(565, 355);
            NewGame.Location = new Point(75, 147);
            WinLabel.Location = new Point(61, 113);
            Restart();
        }

        private void Cells25_Click(object sender, EventArgs e)
        {
            StartMsg.Visible = false;
            Player1.Location = new Point(483, 31);
            Player2.Location = new Point(484, 55);
            Motion.Location = new Point(478, 79);
            Reset.Location = new Point(470, 130);
            Cells9.Location = new Point(492, 185);
            Cells16.Location = new Point(486, 208);
            Cells25.Location = new Point(486, 231);
            this.ClientSize = new Size(645, 445);
            NewGame.Location = new Point(140, 190);
            WinLabel.Location = new Point(120, 156);
            Restart();
        }
    }
}
