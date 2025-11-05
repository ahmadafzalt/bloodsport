using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Blood_Sport
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Initial Declarations
        int TargetValue;
        int P1PunchProgress = 0;
        int P1KickProgress = 0;
        int P1RushAttackProgress = 0;
        int P1DodgeProgress = 0;
        int P2PunchProgress = 0;
        int P2KickProgress = 0;
        int P2RushAttackProgress = 0;
        int P2DodgeProgress = 0;

        int P1Health = 100;
        int P2Health = 100;

        int StrengthValue = 0;
        int AccuracyValue = 0;
        int AngleValue = 0;
        bool AnglePeak = false;

        int CallingPlayer;
        string CallingAction;

        string P1Name;
        string P2Name;

        bool P1DodgeActivation = false;
        int P1DodgeValue;
        bool P2DodgeActivation = false;
        int P2DodgeValue;

        int ET = 0;

        #endregion

        private void FormLoad(object sender, EventArgs e)
        {
            StrengthBar.Hide();
            StrengthPointer.Hide();
            StrengthLabel.Hide();

            AccuracyBar.Hide();
            AccuracyPointer.Hide();
            AccuracyLabel.Hide();

            AngleBox.Hide();
            AngleLabel.Hide();
            AnglePointer.Hide();

            P1Cover.BringToFront();
            P2Cover.BringToFront();
            P1CoverLabel.BringToFront();
            P2CoverLabel.BringToFront();
            P1CoverTurn.BringToFront();
            P2CoverTurn.BringToFront();

            P1Cover.Hide();
            P1CoverLabel.Hide();
            P1CoverTurn.Hide();

            P1DodgeActivationLabel.Hide();
            P2DodgeActivationLabel.Hide();

            FrontCover.BringToFront();
            P1NameInput.BringToFront();
            P1NameInputLabel.BringToFront();
            P2NameInput.BringToFront();
            P2NameInputLabel.BringToFront();
            PlayButton.BringToFront();

            PlayerWinLabel.Hide();
            Exit.Hide();
        }

        #region Health Bar

        private void ChangeHealthBarValue(int player, int value)
        {
            TargetValue = value;
            if (player == 1)
            {
                P1HCTimer.Enabled = true;
            }
            if (player == 2)
            {
                P2HCTimer.Enabled = true;
            }
        }
        private void P1HCTimerTick(object sender, EventArgs e)
        {
            if (P1HealthBar.Width > (TargetValue * 3))
            {
                P1HealthBar.Width -= 3;

            }
            if (P1HealthBar.Width < (TargetValue * 3))
            {
                P1HealthBar.Width += 3;

            }
            if (P1HealthBar.Width == (TargetValue * 3))
            {
                P1HCTimer.Enabled = false;
            }
        }
        private void P2HCTimerTick(object sender, EventArgs e)
        {
            if (P2HealthBar.Width > (TargetValue * 3))
            {
                P2HealthBar.Width -= 3;

            }
            if (P2HealthBar.Width < (TargetValue * 3))
            {
                P2HealthBar.Width += 3;

            }
            if (P2HealthBar.Width == (TargetValue * 3))
            {
                P2HCTimer.Enabled = false;
            }
        }

        #endregion

        #region Parameters
        private int PunchStrengthParameters(int value)
        {
            if (value <= 32)
            {
                return 2;
            }
            else if (value <= 38)
            {
                return 4;
            }
            else if(value <= 43)
            {
                return 8;
            }
            else if (value <= 47)
            {
                return 12;
            }
            else if (value <= 53)
            {
                return 16;
            }
            else if (value <= 57)
            {
                return 12;
            }
            else if (value <= 62)
            {
                return 8;
            }
            else if (value <= 68)
            {
                return 4;
            }
            else if (value <= 100)
            {
                return 2;
            }

            return value;
        }
        private int KickStrengthParameters(int value)
        {
            if (value <= 36)
            {
                return 1;
            }
            else if (value <= 41)
            {
                return 3;
            }
            else if (value <= 45)
            {
                return 5;
            }
            else if (value <= 48)
            {
                return 8;
            }
            else if (value <= 52)
            {
                return 12;
            }
            else if (value <= 55)
            {
                return 8;
            }
            else if (value <= 59)
            {
                return 5;
            }
            else if (value <= 64)
            {
                return 3;
            }
            else if (value <= 100)
            {
                return 1;
            }

            return value;
        } 
        private int KickAccuracyParameters(int value)
        {
            if (value <= 46)
            {
                return 1;
            }
            else if (value <= 49)
            {
                return 2;
            }
            else if (value <= 52)
            {
                return 3;
            }
            else if (value <= 55)
            {
                return 5;
            }
            else if (value <= 58)
            {
                return 7;
            }
            else if (value <= 62)
            {
                return 10;
            }
            else if (value <= 65)
            {
                return 7;
            }
            else if (value <= 68)
            {
                return 5;
            }
            else if (value <= 71)
            {
                return 3;
            }
            else if (value <= 74)
            {
                return 2;
            }
            else if (value <= 80)
            {
                return 1;
            }

            return value;
        }
        private int RushAttackStrengthParameters(int value)
        {
            if (value <= 42)
            {
                return 1;
            }
            else if (value <= 45)
            {
                return 4;
            }
            else if (value <= 47)
            {
                return 8;
            }
            else if (value <= 49)
            {
                return 13;
            }
            else if (value <= 51)
            {
                return 18;
            }
            else if (value <= 53)
            {
                return 13;
            }
            else if (value <= 55)
            {
                return 8;
            }
            else if (value <= 58)
            {
                return 4;
            }
            else if (value <= 100)
            {
                return 1;
            }

            return value;
        }
        private int RushAttackAccuracyParameters(int value)
        {
            if (value <= 50)
            {
                return 1;
            }
            else if (value <= 53)
            {
                return 3;
            }
            else if (value <= 55)
            {
                return 5;
            }
            else if (value <= 57)
            {
                return 7;
            }
            else if (value <= 59)
            {
                return 9;
            }
            else if (value <= 61)
            {
                return 12;
            }
            else if (value <= 63)
            {
                return 9;
            }
            else if (value <= 65)
            {
                return 7;
            }
            else if (value <= 67)
            {
                return 5;
            }
            else if (value <= 70)
            {
                return 3;
            }
            else if (value <= 80)
            {
                return 1;
            }

            return value;
        }
        private int DodgeStrengthParameters(int value)
        {
            if (value <= 38)
            {
                return 10;
            }
            else if (value <= 42)
            {
                return 20;
            }
            else if (value <= 45)
            {
                return 30;
            }
            else if (value <= 48)
            {
                return 50;
            }
            else if (value <= 52)
            {
                return 80;
            }
            else if (value <= 55)
            {
                return 50;
            }
            else if (value <= 58)
            {
                return 30;
            }
            else if (value <= 62)
            {
                return 20;
            }
            else if (value <= 100)
            {
                return 10;
            }

            return value;
        }
        #endregion 

        #region Actions
        private void Punch(int player)
        {
            if (player == 1)
            {
                if (P1PunchProgress == 0)
                {
                    P1Kick.Hide();
                    P1RushAttack.Hide();
                    P1Dodge.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(64, 220);
                    StrengthBar.Image = Properties.Resources.PunchStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(64, 220);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(58, 247);
                    StrengthValue = 0;
                    CallingPlayer = 1;
                    CallingAction = "Punch";
                    StrengthBarPlay.Enabled = true;
                    P1PunchProgress = 1;
                }
                else if (P1PunchProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    P1PunchProgress = 0;
                    int TotalPower = PunchStrengthParameters(StrengthValue);
                    if (P2DodgeActivation == true)
                    {
                        float TPower = (float)TotalPower / 100;
                        P2DodgeValue = 100 - P2DodgeValue;
                        TPower = TPower * P2DodgeValue;
                        TotalPower = (int)(TPower + 0.5f);
                        ChangeHealth(2, TotalPower);
                    }
                    else
                    {
                        ChangeHealth(2, TotalPower);
                    }    
                    Thread.Sleep(2000);
                    StrengthBar.Hide();                  
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();
                    P1Kick.Show();
                    P1RushAttack.Show();
                    P1Dodge.Show();
                    P1Cover.Show();
                    P1CoverLabel.Show();
                    P1CoverTurn.Show();
                    P2Cover.Hide();
                    P2CoverLabel.Hide();
                    P2CoverTurn.Hide();
                    CheckGameOver();
                    P2DodgeActivation = false;
                    P2DodgeValue = 0;
                    P2DodgeActivationLabel.Hide();
                }
            }
            if (player == 2)
            {
                if (P2PunchProgress == 0)
                {
                    P2Kick.Hide();
                    P2RushAttack.Hide();
                    P2Dodge.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(316, 220);
                    StrengthBar.Image = Properties.Resources.PunchStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(316, 220);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(310, 247);
                    StrengthValue = 0;
                    CallingPlayer = 2;
                    CallingAction = "Punch";
                    StrengthBarPlay.Enabled = true;
                    P2PunchProgress = 1;
                }
                else if (P2PunchProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    P2PunchProgress = 0;
                    int TotalPower = PunchStrengthParameters(StrengthValue);
                    if (P1DodgeActivation == true)
                    {
                        float TPower = (float)TotalPower / 100;
                        P1DodgeValue = 100 - P1DodgeValue;
                        TPower = TPower * P1DodgeValue;
                        TotalPower = (int)(TPower + 0.5f);
                        ChangeHealth(1, TotalPower);
                    }
                    else
                    {
                        ChangeHealth(1, TotalPower);
                    }
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();
                    P2Kick.Show();
                    P2RushAttack.Show();
                    P2Dodge.Show();             
                    P2Cover.Show();
                    P2CoverLabel.Show();
                    P2CoverTurn.Show();
                    P1Cover.Hide();
                    P1CoverLabel.Hide();
                    P1CoverTurn.Hide();
                    CheckGameOver();
                    P1DodgeActivation = false;
                    P1DodgeValue = 0;
                    P1DodgeActivationLabel.Hide();
                }
            }
        }
        private void Kick(int player)
        {
            if (player == 1)
            {
                if (P1KickProgress == 0)
                {
                    P1Punch.Hide();
                    P1RushAttack.Hide();
                    P1Dodge.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(64, 261);
                    StrengthBar.Image = Properties.Resources.KickStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(64, 261);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(58, 288);
                    StrengthValue = 0;
                    CallingPlayer = 1;
                    CallingAction = "Kick";
                    StrengthBarPlay.Enabled = true;
                    P1KickProgress = 1;
                }
                else if (P1KickProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);                    
                    Thread.Sleep(1000);
                    AccuracyBar.Show();
                    AccuracyBar.Location = new Point(22, 188);
                    AccuracyBar.Image = Properties.Resources.KickAccuracyBar;
                    AccuracyPointer.Show();
                    AccuracyPointer.Location = new Point(22, 345);
                    AccuracyLabel.Show();
                    AccuracyLabel.Location = new Point(10, 171);
                    AccuracyValue = 0;
                    CallingPlayer = 1;
                    CallingAction = "Kick";
                    AccuracyBarPlay.Enabled = true;
                    P1KickProgress = 2;
                }
                else if (P1KickProgress == 2)
                {
                    AccuracyBarPlay.Enabled = false;
                    AccuracyValue += 2;
                    Console.WriteLine(AccuracyValue);
                    P1KickProgress = 0;
                    int TotalPower = (KickStrengthParameters(StrengthValue)) + (KickAccuracyParameters(AccuracyValue));
                    if (P2DodgeActivation == true)
                    {
                        float TPower = (float)TotalPower / 100;
                        P2DodgeValue = 100 - P2DodgeValue;
                        TPower = TPower * P2DodgeValue;
                        TotalPower = (int)(TPower + 0.5f);
                        ChangeHealth(2, TotalPower);
                    }
                    else
                    {
                        ChangeHealth(2, TotalPower);
                    }
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();
                    AccuracyBar.Hide();
                    AccuracyPointer.Hide();
                    AccuracyLabel.Hide();
                    P1Punch.Show();
                    P1RushAttack.Show();
                    P1Dodge.Show();
                    P1Cover.Show();
                    P1CoverLabel.Show();
                    P1CoverTurn.Show();
                    P2Cover.Hide();
                    P2CoverLabel.Hide();
                    P2CoverTurn.Hide();
                    CheckGameOver();
                    P2DodgeActivation = false;
                    P2DodgeValue = 0;
                    P2DodgeActivationLabel.Hide();
                }
            }
            if (player == 2)
            {
                if (P2KickProgress == 0)
                {
                    P2Punch.Hide();
                    P2RushAttack.Hide();
                    P2Dodge.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(316, 261);
                    StrengthBar.Image = Properties.Resources.KickStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(316, 261);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(310, 288);
                    StrengthValue = 0;
                    CallingPlayer = 2;
                    CallingAction = "Kick";
                    StrengthBarPlay.Enabled = true;
                    P2KickProgress = 1;
                }
                else if (P2KickProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    Thread.Sleep(1000);
                    AccuracyBar.Show();
                    AccuracyBar.Location = new Point(533, 188);
                    AccuracyBar.Image = Properties.Resources.KickAccuracyBar;
                    AccuracyPointer.Show();
                    AccuracyPointer.Location = new Point(533, 345);
                    AccuracyLabel.Show();
                    AccuracyLabel.Location = new Point(521, 171);
                    AccuracyValue = 0;
                    CallingPlayer = 2;
                    CallingAction = "Kick";
                    AccuracyBarPlay.Enabled = true;
                    P2KickProgress = 2;
                }
                else if (P2KickProgress == 2)
                {
                    AccuracyBarPlay.Enabled = false;
                    AccuracyValue += 2;
                    Console.WriteLine(AccuracyValue);
                    P2KickProgress = 0;
                    int TotalPower = (KickStrengthParameters(StrengthValue)) + (KickAccuracyParameters(AccuracyValue));
                    if (P1DodgeActivation == true)
                    {
                        float TPower = (float)TotalPower / 100;
                        P1DodgeValue = 100 - P1DodgeValue;
                        TPower = TPower * P1DodgeValue;
                        TotalPower = (int)(TPower + 0.5f);
                        ChangeHealth(1, TotalPower);
                    }
                    else
                    {
                        ChangeHealth(1, TotalPower);
                    }
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();
                    AccuracyBar.Hide();
                    AccuracyPointer.Hide();
                    AccuracyLabel.Hide();
                    P2Punch.Show();
                    P2RushAttack.Show();
                    P2Dodge.Show();
                    P2Cover.Show();
                    P2CoverLabel.Show();
                    P2CoverTurn.Show();
                    P1Cover.Hide();
                    P1CoverLabel.Hide();
                    P1CoverTurn.Hide();
                    CheckGameOver();
                    P1DodgeActivation = false;
                    P1DodgeValue = 0;
                    P1DodgeActivationLabel.Hide();
                }
            }
        }
        private void RushAttack(int player)
        {
            if (player == 1)
            {
                if (P1RushAttackProgress == 0)
                {
                    P1Punch.Hide();
                    P1Kick.Hide();
                    P1Dodge.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(64, 302);
                    StrengthBar.Image = Properties.Resources.RushAttackStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(64, 302);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(58, 329);
                    StrengthValue = 0;
                    CallingPlayer = 1;
                    CallingAction = "RushAttack";
                    StrengthBarPlay.Enabled = true;
                    P1RushAttackProgress = 1;
                }
                else if (P1RushAttackProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    Thread.Sleep(1000);
                    AccuracyBar.Show();
                    AccuracyBar.Location = new Point(22, 188);
                    AccuracyBar.Image = Properties.Resources.RushAttackAccuracyBar;
                    AccuracyPointer.Show();
                    AccuracyPointer.Location = new Point(22, 345);
                    AccuracyLabel.Show();
                    AccuracyLabel.Location = new Point(10, 171);
                    AccuracyValue = 0;
                    CallingPlayer = 1;
                    CallingAction = "RushAttack";
                    AccuracyBarPlay.Enabled = true;
                    P1RushAttackProgress = 2;
                }
                else if (P1RushAttackProgress == 2)
                {
                    AccuracyBarPlay.Enabled = false;
                    AccuracyValue += 2;
                    Console.WriteLine(AccuracyValue);
                    Thread.Sleep(1000);
                    AngleBox.Show();
                    AngleBox.Location = new Point(197, 188);
                    AngleLabel.Show();
                    AngleLabel.Location = new Point(158, 223);
                    AnglePointer.Show();
                    AnglePointer.Location = new Point(216, 220);
                    AnglePeak = false;
                    AngleValue = 40;
                    CallingPlayer = 1;
                    CallingAction = "RushAttack";
                    AngleBoxPlay.Enabled = true;
                    P1RushAttackProgress = 3;
                }
                else if (P1RushAttackProgress == 3)
                {
                    AngleBoxPlay.Enabled = false;
                    Console.WriteLine(AngleValue);
                    P1RushAttackProgress = 0;
                    float Power = (RushAttackStrengthParameters(StrengthValue)) + (RushAttackAccuracyParameters(AccuracyValue));
                    Power = (Power / 100) * AngleValue;
                    int TotalPower = (int)(Power+0.5f);
                    if (P2DodgeActivation == true)
                    {
                        float TPower = (float)TotalPower / 100;
                        P2DodgeValue = 100 - P2DodgeValue;
                        TPower = TPower * P2DodgeValue;
                        TotalPower = (int)(TPower + 0.5f);
                        ChangeHealth(2, TotalPower);
                    }
                    else
                    {
                        ChangeHealth(2, TotalPower);
                    }
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();
                    AccuracyBar.Hide();
                    AccuracyPointer.Hide();
                    AccuracyLabel.Hide();
                    AngleBox.Hide();
                    AnglePointer.Hide();
                    AngleLabel.Hide();
                    P1Punch.Show();
                    P1Kick.Show();
                    P1Dodge.Show();
                    P1Cover.Show();
                    P1CoverLabel.Show();
                    P1CoverTurn.Show();
                    P2Cover.Hide();
                    P2CoverLabel.Hide();
                    P2CoverTurn.Hide();
                    CheckGameOver();
                    P2DodgeActivation = false;
                    P2DodgeValue = 0;
                    P2DodgeActivationLabel.Hide();
                }
            }
            if (player == 2)
            {
                if (P2RushAttackProgress == 0)
                {
                    P2Punch.Hide();
                    P2Kick.Hide();
                    P2Dodge.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(316, 302);
                    StrengthBar.Image = Properties.Resources.RushAttackStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(316, 302);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(310, 329);
                    StrengthValue = 0;
                    CallingPlayer = 2;
                    CallingAction = "RushAttack";
                    StrengthBarPlay.Enabled = true;
                    P2RushAttackProgress = 1;
                }
                else if (P2RushAttackProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    Thread.Sleep(1000);
                    AccuracyBar.Show();
                    AccuracyBar.Location = new Point(533, 188);
                    AccuracyBar.Image = Properties.Resources.RushAttackAccuracyBar;
                    AccuracyPointer.Show();
                    AccuracyPointer.Location = new Point(533, 345);
                    AccuracyLabel.Show();
                    AccuracyLabel.Location = new Point(521, 171);
                    AccuracyValue = 0;
                    CallingPlayer = 2;
                    CallingAction = "RushAttack";
                    AccuracyBarPlay.Enabled = true;
                    P2RushAttackProgress = 2;
                }
                else if (P2RushAttackProgress == 2)
                {
                    AccuracyBarPlay.Enabled = false;
                    AccuracyValue += 2;
                    Console.WriteLine(AccuracyValue);
                    Thread.Sleep(1000);
                    AngleBox.Show();
                    AngleBox.Location = new Point(316, 188);
                    AngleLabel.Show();
                    AngleLabel.Location = new Point(385, 223);
                    AnglePointer.Show();
                    AnglePointer.Location = new Point(335, 220);
                    AnglePeak = false;
                    AngleValue = 40;
                    CallingPlayer = 2;
                    CallingAction = "RushAttack";
                    AngleBoxPlay.Enabled = true;
                    P2RushAttackProgress = 3;
                }
                else if (P2RushAttackProgress == 3)
                {
                    AngleBoxPlay.Enabled = false;
                    Console.WriteLine(AngleValue);
                    P2RushAttackProgress = 0;
                    float Power = (RushAttackStrengthParameters(StrengthValue)) + (RushAttackAccuracyParameters(AccuracyValue));
                    Power = (Power / 100) * AngleValue;
                    int TotalPower = (int)(Power + 0.5f);
                    if (P1DodgeActivation == true)
                    {
                        float TPower = (float)TotalPower / 100;
                        P1DodgeValue = 100 - P1DodgeValue;
                        TPower = TPower * P1DodgeValue;
                        TotalPower = (int)(TPower + 0.5f);
                        ChangeHealth(1, TotalPower);
                    }
                    else
                    {
                        ChangeHealth(1, TotalPower);
                    }
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();
                    AccuracyBar.Hide();
                    AccuracyPointer.Hide();
                    AccuracyLabel.Hide();
                    AngleBox.Hide();
                    AnglePointer.Hide();
                    AngleLabel.Hide();
                    P2Punch.Show();
                    P2Kick.Show();
                    P2Dodge.Show();
                    P2Cover.Show();
                    P2CoverLabel.Show();
                    P2CoverTurn.Show();
                    P1Cover.Hide();
                    P1CoverLabel.Hide();
                    P1CoverTurn.Hide();
                    CheckGameOver();
                    P1DodgeActivation = false;
                    P1DodgeValue = 0;
                    P1DodgeActivationLabel.Hide();
                }
            }
        }
        private void Dodge(int player)
        {
            if (player == 1)
            {
                if (P1DodgeProgress == 0)
                {
                    P1Kick.Hide();
                    P1RushAttack.Hide();
                    P1Punch.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(64, 271);
                    StrengthBar.Image = Properties.Resources.DodgeStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(64, 271);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(57, 255);
                    StrengthValue = 0;
                    CallingPlayer = 1;
                    CallingAction = "Dodge";
                    StrengthBarPlay.Enabled = true;
                    P1DodgeProgress = 1;
                }
                else if (P1DodgeProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    int DodgePower = DodgeStrengthParameters(StrengthValue);
                    Console.WriteLine(DodgePower);
                    P1DodgeProgress = 0;
                    P1DodgeActivation = true;
                    P1DodgeValue = DodgePower;
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();

                    P1Kick.Show();
                    P1RushAttack.Show();
                    P1Punch.Show();
                    
                    P1Cover.Show();
                    P1CoverLabel.Show();
                    P1CoverTurn.Show();

                    P2Cover.Hide();
                    P2CoverLabel.Hide();
                    P2CoverTurn.Hide();

                    P1DodgeActivationLabel.BringToFront();
                    P1DodgeActivationLabel.Show();
                    P2DodgeActivationLabel.Hide();

                    P2DodgeActivation = false;
                    P2DodgeValue = 0;
                }
            }
            if (player == 2)
            {
                if (P2DodgeProgress == 0)
                {
                    P2Kick.Hide();
                    P2RushAttack.Hide();
                    P2Punch.Hide();
                    StrengthBar.Show();
                    StrengthBar.Location = new Point(316, 271);
                    StrengthBar.Image = Properties.Resources.DodgeStrengthBar;
                    StrengthPointer.Show();
                    StrengthPointer.Location = new Point(316, 271);
                    StrengthLabel.Show();
                    StrengthLabel.Location = new Point(309, 255);
                    StrengthValue = 0;
                    CallingPlayer = 2;
                    CallingAction = "Dodge";
                    StrengthBarPlay.Enabled = true;
                    P2DodgeProgress = 1;
                }
                else if (P2DodgeProgress == 1)
                {
                    StrengthBarPlay.Enabled = false;
                    StrengthValue += 2;
                    Console.WriteLine(StrengthValue);
                    int DodgePower = DodgeStrengthParameters(StrengthValue);
                    Console.WriteLine(DodgePower);
                    P2DodgeProgress = 0;
                    P2DodgeActivation = true;
                    P2DodgeValue = DodgePower;
                    Thread.Sleep(2000);
                    StrengthBar.Hide();
                    StrengthPointer.Hide();
                    StrengthLabel.Hide();

                    P2Kick.Show();
                    P2RushAttack.Show();
                    P2Punch.Show();

                    P2Cover.Show();
                    P2CoverLabel.Show();
                    P2CoverTurn.Show();

                    P1Cover.Hide();
                    P1CoverLabel.Hide();
                    P1CoverTurn.Hide();

                    P1DodgeActivationLabel.Hide();
                    P1DodgeActivation = false;
                    P1DodgeValue = 0;

                    P2DodgeActivationLabel.BringToFront();
                    P2DodgeActivationLabel.Show();
                    
                }
            }
        }
        #endregion

        #region Moves Hovers and Clicks
        private void P1PunchEnter(object sender, EventArgs e)
        {
            P1Punch.Image = Properties.Resources.PunchColor;
        }
        private void P1PunchLeave(object sender, EventArgs e)
        {
            P1Punch.Image = Properties.Resources.PunchPlain;
        }
        private void P1KickEnter(object sender, EventArgs e)
        {
            P1Kick.Image = Properties.Resources.KickColor;
        }
        private void P1KickLeave(object sender, EventArgs e)
        {
            P1Kick.Image = Properties.Resources.KickPlain;
        }
        private void P1RushAttackEnter(object sender, EventArgs e)
        {
            P1RushAttack.Image = Properties.Resources.RushAttackColor;
        }
        private void P1RushAttackLeave(object sender, EventArgs e)
        {
            P1RushAttack.Image = Properties.Resources.RushAttackPlain;
        }
        private void P1DodgeEnter(object sender, EventArgs e)
        {
            P1Dodge.Image = Properties.Resources.DodgeColor;
        }
        private void P1DodgeLeave(object sender, EventArgs e)
        {
            P1Dodge.Image = Properties.Resources.DodgePlain;
        }
        private void P2PunchEnter(object sender, EventArgs e)
        {
            P2Punch.Image = Properties.Resources.PunchColor;
        }
        private void P2PunchLeave(object sender, EventArgs e)
        {
            P2Punch.Image = Properties.Resources.PunchPlain;
        }
        private void P2KickEnter(object sender, EventArgs e)
        {
            P2Kick.Image = Properties.Resources.KickColor;
        }
        private void P2KickLeave(object sender, EventArgs e)
        {
            P2Kick.Image = Properties.Resources.KickPlain;
        }
        private void P2RushAttackEnter(object sender, EventArgs e)
        {
            P2RushAttack.Image = Properties.Resources.RushAttackColor;
        }
        private void P2RushAttackLeave(object sender, EventArgs e)
        {
            P2RushAttack.Image = Properties.Resources.RushAttackPlain;
        }
        private void P2DodgeEnter(object sender, EventArgs e)
        {
            P2Dodge.Image = Properties.Resources.DodgeColor;
        }
        private void P2DodgeLeave(object sender, EventArgs e)
        {
            P2Dodge.Image = Properties.Resources.DodgePlain;
        }
        #endregion

        #region Events    
        private void CloseIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void P1PunchClick(object sender, EventArgs e)
        {
            Punch(1);
        }
        private void P1KickClick(object sender, EventArgs e)
        {
            Kick(1);
        }
        private void P1RushAttackClick(object sender, EventArgs e)
        {
            RushAttack(1);
        }
        private void P1DodgeClick(object sender, EventArgs e)
        {
            Dodge(1);
        }
        private void P2PunchClick(object sender, EventArgs e)
        {
            Punch(2);
        }
        private void P2KickClick(object sender, EventArgs e)
        {
            Kick(2);
        }
        private void P2RushAttackClick(object sender, EventArgs e)
        {
            RushAttack(2);
        }
        private void P2DodgeClick(object sender, EventArgs e)
        {
            Dodge(2);
        }
        private void PlayClick(object sender, EventArgs e)
        {
            if (P1NameInput.Text != "" & P2NameInput.Text != "")
            {
                P1NameInput.Hide();
                P1NameInputLabel.Hide();
                P2NameInput.Hide();
                P2NameInputLabel.Hide();
                PlayButton.Hide();

                P1Name = P1NameInput.Text;
                P2Name = P2NameInput.Text;

                Player1Label.Text = P1Name;
                Player2Label.Text = P2Name;
                Player2Label.Location = new Point(564 - Player2Label.Width, 360);

                P1CoverLabel.Text = P2Name + "'s";
                P1CoverLabel.Location = new Point(270 - P1CoverLabel.Width, 224);
                P2CoverLabel.Text = P1Name + "'s";

                FrontCover.Hide();
            }

        }
        private void EndTick(object sender, EventArgs e)
        {     
            if (ET == 1)
            {
                if (P1Health == 0)
                {
                    FrontCover.Show();
                    PlayerWinLabel.Text = P2Name + " Wins!";
                    PlayerWinLabel.Left = ((ClientSize.Width - PlayerWinLabel.Width) / 2) + 4;
                    PlayerWinLabel.Show();
                    PlayerWinLabel.BringToFront();
                    Exit.Show();
                    Exit.BringToFront();
                }
                if (P2Health == 0)
                {
                    FrontCover.Show();
                    PlayerWinLabel.Text = P1Name + " Wins!";
                    PlayerWinLabel.Left = ((ClientSize.Width - PlayerWinLabel.Width) / 2) + 4;
                    PlayerWinLabel.Show();
                    PlayerWinLabel.BringToFront();
                    Exit.Show();
                    Exit.BringToFront();
                }
            }
            ET += 1;
        }
        #endregion

        #region Bars
        private void StrengthBarPlayTick(object sender, EventArgs e)
        {
            StrengthPointer.Left += 2;
            StrengthValue += 1;
            if (StrengthValue == 98)
            {
                StrengthBarPlay.Enabled = false;
                if (CallingPlayer == 1)
                {
                    if (CallingAction == "Punch")
                    {
                        Punch(1);
                    }
                    else if (CallingAction == "Kick")
                    {
                        Kick(1);
                    }
                    else if (CallingAction == "RushAttack")
                    {
                        RushAttack(1);
                    }
                    else if (CallingAction == "Dodge")
                    {
                        Dodge(1);
                    }
                }
                else if (CallingPlayer == 2)
                {
                    if (CallingAction == "Punch")
                    {
                        Punch(2);
                    }
                    else if (CallingAction == "Kick")
                    {
                        Kick(2);
                    }
                    else if (CallingAction == "Dodge")
                    {
                        Dodge(2);
                    }
                }    
            }
        }
        private void AccuracyBarPlayTick(object sender, EventArgs e)
        {
            AccuracyPointer.Top -= 2;
            AccuracyValue += 1;
            if (AccuracyValue == 78)
            {
                AccuracyBarPlay.Enabled = false;
                if (CallingPlayer == 1)
                {
                    if (CallingAction == "Kick")
                    {
                        Kick(1);
                    }
                    else if (CallingAction == "RushAttack")
                    {
                        RushAttack(1);
                    }
                }
                else if (CallingPlayer == 2)
                {
                    if (CallingAction == "Kick")
                    {
                        Kick(2);
                    }
                    else if (CallingAction == "RushAttack")
                    {
                        RushAttack(2);
                    }
                }
            }
        }
        private void AngleBoxPlayTick(object sender, EventArgs e)
        {
            if (AnglePeak == false)
            {
                AngleValue += 1;
                AnglePointer.Text = AngleValue + "%";
            }
            if (AnglePeak == true)
            {
                AngleValue -= 1;
                AnglePointer.Text = AngleValue + "%";
            }
            if (AngleValue == 100)
            {
                AnglePointer.Text = AngleValue.ToString();
                AnglePeak = true;
            }
            if (AngleValue == 20)
            {
                AnglePointer.Text = AngleValue + "%";
                if (CallingPlayer == 1)
                {
                    RushAttack(1);
                }
                if (CallingPlayer == 2)
                {
                    RushAttack(2);
                }
            }
            

        }
        #endregion

        #region Others
        private void ChangeHealth(int player, int value)
        {
            if (player == 1)
            {
                if ((value) > P1Health)
                {
                    P1Health = 0;
                }
                else
                {
                    P1Health -= value;
                }
                ChangeHealthBarValue(1, P1Health);
                Console.WriteLine("Player 1 Health Changed: " + value);
                Console.WriteLine("Player 1 Health Now: " + P1Health);
                Console.WriteLine("--------------------------------");
            }
            if (player == 2)
            {
                if ((value) > P2Health)
                {
                    P2Health = 0;
                }
                else
                {
                    P2Health -= value;
                }
                ChangeHealthBarValue(2, P2Health);
                Console.WriteLine("Player 2 Health Changed: " + value);
                Console.WriteLine("Player 2 Health Now: " + P2Health);
                Console.WriteLine("--------------------------------");
            }
        }
        private void CheckGameOver()
        {
            if (P1Health == 0)
            {
                EndTimer.Enabled = true;
                P1Cover.Show();
                P2Cover.Show();
                P1CoverLabel.Hide();
                P2CoverLabel.Hide();
                P1CoverTurn.Hide();
                P2CoverTurn.Hide();
            }
            if (P2Health == 0)
            {
                EndTimer.Enabled = true;
                P1Cover.Show();
                P2Cover.Show();
                P1CoverLabel.Hide();
                P2CoverLabel.Hide();
                P1CoverTurn.Hide();
                P2CoverTurn.Hide();
            }
        }
        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


    }
}