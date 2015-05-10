using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using SudokuGJ.Properties;
using System.IO;

namespace SudokuGJ
{
    public partial class Board : Form
    {
        public char[][] levelMap = new char[100][];
        public char[][] pom = new char[100][];
        public int sokoPosX, sokoPosY;
        public int nasoka; // 0-gore 1-desno 2-dole 3-levo
        public int packagesongoal = 0;
        public int numpackages = 0;
        public int nummoves = 0;
        public int pushes = 0;
        public Boolean sokobanongoal = false;
        public List<String> listMoves;

        public String name;
        public int vkpushes;
        public int vkmoves;

        public List<String> nivoa;
        public int nivo = 0;

        public int levelHeight = 7;
        public int levelWidth = 10;

        public int movesToSave = 5;

        public Board(String name, int level, int pushes, int moves)
        {
            InitializeComponent();

            this.name = name;
            this.nivo = level;
            this.vkpushes = pushes;
            this.vkmoves = moves;

            this.DoubleBuffered = true;
        }

        private void Board_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            nivoa = new List<String>();

            nivoa.Add("3 6~#######.$ @#######");
            nivoa.Add("8 8~==###=====#.#=====# #######$ $.##. $@#######$#=====#.#=====###==");
            nivoa.Add("9 9~#####====#@  #====# $$#=#### $ #=#.#### ###.#=##    .#=#   #  #=#   ####=#####===");
            nivoa.Add("8 10~########==# @ #  #==#      #==#####$ #======#  ###=##=#$ ..#=##=#  ###====####==");
            nivoa.Add("7 10~=#######===#     #####$###   ## @ $  $ ## ..# $ ####..#   #==########=");
            nivoa.Add("9 10~#####=====#   ####==# # # .#==#    $ ###### #$.  ##   #@   ## # #######   #=====#####=====");
            nivoa.Add("9 9~==####=====#  #=====# $#######. .  ## $ # $ ##  . .#######$ #=====# @#=====####==");
            nivoa.Add("8 8~=####====#@ ###==# $  #=### # ###.# #  ##.$  # ##. $   #########");
            nivoa.Add("11 13~===#######===####     #===#   .### #===# # #    ##==# # $ $#. #==# #  *  # #==# .#$ $ # #==##    # # ###=# ###.    @#=#     ##   #=############");
            nivoa.Add("8 10~===#######==##  # @#==#   #  #==#$ $ $ #==# $## #=### $ # ###.....  #=#########=");
            nivoa.Add("9 9~=##=#######=## . ##=## $. #=## $   ### $@ #### $  ##==#.. ##=###   #=##=#####=#==");
            nivoa.Add("9 13~############=#          #=# ####### @### #         ## #  $   #  ## $$ #####  ####  #=# ...#==####=#    #=======######");
            nivoa.Add("10 13~==###########=##     #  @#### $ $$#   ## ##$    $$ ##  #  $ #   ####### #######.. ..$ #*##=# ..    ###==#  ..#####===#########====");

            enterLevel(nivoa[nivo++]);

            groupBox1.BackColor = Color.FromArgb(102, 47, 10);
            Podatoci.BackColor = Color.FromArgb(102, 47, 10);
            groupBox1.ForeColor = Color.Yellow;

            nasoka = 1;
            packagesongoal = 0;
            numpackages = 0;
            nummoves = 0;

            //ova treba da se smeni
            vkpushes = 0;
            vkmoves = 0;
            pushes = 0;


            listMoves = new List<String>();
        }


        private void Board_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(102, 47, 10));

            Podatoci.Location = new Point((levelWidth + 3) * 38, 0);

            numpackages = 0;
            packagesongoal = 0;

            //moves.Text = this
            pushesLabel.Text = pushes.ToString();
            moves.Text = nummoves.ToString();
            levelLabel.Text = nivo.ToString();
            levelLabel.BackColor = Color.Yellow;
            player.Text = this.name;

            int i, j;
            Image img = null;
            for (i = 0; i < levelHeight; i++)
                for (j = 0; j < levelWidth; j++)
                {
                    if (levelMap[i][j] == '=') img = Resources.space;
                    else
                        if (levelMap[i][j] == '#') img = Resources.wall;
                        else
                            if (levelMap[i][j] == '$')
                            {
                                img = Resources.package;
                            }
                            else
                                if (levelMap[i][j] == '.')
                                {
                                    img = Resources.goal;
                                    numpackages++;
                                }
                                else
                                    if (levelMap[i][j] == '@')
                                    {
                                        sokoPosX = i;
                                        sokoPosY = j;

                                        if (pom[i][j] != '.')
                                        {
                                            if (nasoka == 0) img = Resources.soko_up;
                                            else
                                                if (nasoka == 1) img = Resources.soko_right;
                                                else
                                                    if (nasoka == 2) img = Resources.soko_down;
                                                    else
                                                        if (nasoka == 3) img = Resources.soko_left;
                                        }
                                        else
                                        {
                                            if (nasoka == 0) img = Resources.soko_goal_up;
                                            else
                                                if (nasoka == 1) img = Resources.soko_goal_right;
                                                else
                                                    if (nasoka == 2) img = Resources.soko_goal_down;
                                                    else
                                                        if (nasoka == 3) img = Resources.soko_goal_left;
                                        }
                                        //pom[j][i] = ' ';
                                    }
                                    else
                                        if (levelMap[i][j] == '*')
                                        {
                                            packagesongoal++;
                                            img = Resources.package_goal;
                                        }
                                        else
                                            if (levelMap[i][j] == '+') img = Resources.soko_goal_up;
                                            else
                                                if (levelMap[i][j] == ' ') img = Resources.floor;
                                                else
                                                {
                                                    img = Resources.floor;
                                                    levelMap[i][j] = ' ';
                                                }

                    g.DrawImageUnscaled(img, (j + 1) * 38, (i + 1) * 38, 0, 0);
                }

            img = Resources.space;
            for (i = 0; i < levelWidth + 2; i++) g.DrawImageUnscaled(img, i * 38, 0, 0, 0);
            for (i = 0; i < levelWidth + 2; i++) g.DrawImageUnscaled(img, i * 38, (levelHeight + 1) * 38, 0, 0);

            for (i = 0; i < levelHeight; i++) g.DrawImageUnscaled(img, 0, (i + 1) * 38, 0, 0);
            for (i = 0; i < levelHeight; i++) g.DrawImageUnscaled(img, (levelWidth + 1) * 38, (i + 1) * 38, 0, 0);


            if (numpackages == 0 && pom[sokoPosX][sokoPosY] != '.' && nummoves > 0)
            {
                //for (i = 0; i < bazaDataSet3.Igrac.Rows.Count; i++)
                {
                    /*bazaDataSet3.IgracRow k = (bazaDataSet3.IgracRow)bazaDataSet3.Igrac.Rows[i];

                    if (k.name == this.name) // go najdovme vo baza, updatirame
                    {
                        k.moves = this.vkmoves + nummoves;
                        k.pushes = this.vkpushes + pushes;
                        k.level = this.nivo + 1;
                        //k.updat
                    }*/

                    //MessageBox.Show(bazaDataSet3.Igrac.Rows.Count.ToString());
                }

                /*bazaDataSet3.IgracRow knew = bazaDataSet3.Igrac.NewIgracRow();

                bazaDataSet3.Igrac.Rows.Add(knew);
                bazaDataSet3TableAdapters.IgracTableAdapter k1 = new bazaDataSet3TableAdapters.IgracTableAdapter();
                k1.Update(this.bazaDataSet3.Igrac);

                this.igracTableAdapter.Fill(this.bazaDataSet3.Igrac);*/

                if (nivoa.Count == nivo)
                {
                    MessageBox.Show("Успешно ја завршивте играта ! :)");
                    Board.ActiveForm.Close();
                }
                else
                {
                    Invalidate();
                    enterLevel(nivoa[nivo++]);
                }
            }
        }

        public void enterLevel(String s)
        {
            int i, j;

            packagesongoal = 0;
            numpackages = 0;
            nummoves = 0;
            pushes = 0;


            int prazno = -1;
            for (i = 0; i < s.Length; i++)
                if (s[i] == '~')
                {
                    break;
                }
                else
                    if (s[i] == ' ' && prazno == -1)
                    {
                        prazno = i;
                    }
            String t = s.Substring(0, i);
            s = s.Substring(i + 1, s.Length - i - 1);

            //MessageBox.Show(t.Substring(prazno+1, t.Length-prazno-1));

            int n = 0, m = 0;
            Int32.TryParse(t.Substring(0, prazno), out n);
            Int32.TryParse(t.Substring(prazno + 1, t.Length - prazno - 1), out m);

            levelHeight = n;
            levelWidth = m;

            levelMap = new char[100][];
            pom = new char[100][];

            for (i = 0; i < levelHeight; i++)
            {
                levelMap[i] = new char[levelWidth];
                pom[i] = new char[levelWidth];
            }

            sokoPosX = 0;
            sokoPosY = 0;

            for (i = 0; i < levelHeight; i++)
                for (j = 0; j < levelWidth; j++)
                {
                    levelMap[i][j] = s[levelWidth * i + j];
                    if (levelMap[i][j] != '@') pom[i][j] = levelMap[i][j];
                    else pom[i][j] = ' ';
                }
        }

        /*
         *  # - wall
         *  = - space
         *  $ - package
         *  . - goal
         *  @ - sokoban non goal
         *  * - package_goal
         *  + - sokoban on goal
         * ' ' - floor
         * 
         * */

        private void moveUp()
        {
            if (sokoPosX < 0 || sokoPosY < 0) return;
            nasoka = 0;
            if (levelMap[sokoPosX - 1][sokoPosY] == ' ') // minuvanje na prazno pole
            {
                nummoves++;
                levelMap[sokoPosX - 1][sokoPosY] = '@';
                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                else levelMap[sokoPosX][sokoPosY] = ' ';
            }
            else
                if (levelMap[sokoPosX - 1][sokoPosY] == '.')
                { // minuvame po celno pole
                    nummoves++;
                    levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                    levelMap[sokoPosX - 1][sokoPosY] = '@';
                }
                else
                    if (levelMap[sokoPosX - 1][sokoPosY] == '$') // ima paket nad sokobanot
                    {
                        storeMove();
                        if (levelMap[sokoPosX - 2][sokoPosY] == '.') // celta e nad paketot
                        {
                            nummoves++;
                            packagesongoal++;
                            levelMap[sokoPosX - 2][sokoPosY] = '*';
                            levelMap[sokoPosX - 1][sokoPosY] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                        else
                            if (levelMap[sokoPosX - 2][sokoPosY] == ' ') // nad paketot ima prazno mesto
                            {
                                nummoves++;
                                levelMap[sokoPosX - 2][sokoPosY] = '$';
                                levelMap[sokoPosX - 1][sokoPosY] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
                    }
                    else
                        if (levelMap[sokoPosX - 1][sokoPosY] == '*') // ima paket na cel nad sokobanot
                        {
                            storeMove();
                            if (levelMap[sokoPosX - 2][sokoPosY] == '.') // celta e nad paketot
                            {
                                pushes++;
                                nummoves++;
                                levelMap[sokoPosX - 2][sokoPosY] = '*';
                                levelMap[sokoPosX - 1][sokoPosY] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
                            else
                                if (levelMap[sokoPosX - 2][sokoPosY] == ' ') // nad paketot ima prazno mesto
                                {
                                    pushes++;
                                    nummoves++;
                                    packagesongoal--;
                                    sokobanongoal = true;
                                    levelMap[sokoPosX - 2][sokoPosY] = '$';
                                    levelMap[sokoPosX - 1][sokoPosY] = '@';
                                    if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                    else levelMap[sokoPosX][sokoPosY] = ' ';
                                }
                        }
                        else
                            if (levelMap[sokoPosX - 1][sokoPosY] == '.') // ima cel na pat
                            {
                                nummoves++;
                                levelMap[sokoPosX - 1][sokoPosY] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
        }

        private void moveDown()
        {
            if (sokoPosX <= 0 || sokoPosY <= 0) return;
            nasoka = 2;
            if (levelMap[sokoPosX + 1][sokoPosY] == ' ') // minuvanje na prazno pole
            {
                nummoves++;
                levelMap[sokoPosX + 1][sokoPosY] = '@';
                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                else levelMap[sokoPosX][sokoPosY] = ' ';
            }
            else
                if (levelMap[sokoPosX + 1][sokoPosY] == '.') // minuvame po celno pole
                {
                    nummoves++;
                    levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                    levelMap[sokoPosX + 1][sokoPosY] = '@';
                }
                else
                    if (levelMap[sokoPosX + 1][sokoPosY] == '$') // ima paket nad sokobanot
                    {
                        storeMove();
                        if (levelMap[sokoPosX + 2][sokoPosY] == '.') // celta e nad paketot
                        {
                            pushes++;
                            nummoves++;
                            packagesongoal++;
                            levelMap[sokoPosX + 2][sokoPosY] = '*';
                            levelMap[sokoPosX + 1][sokoPosY] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                        if (levelMap[sokoPosX + 2][sokoPosY] == ' ') // pod paketot ima prazno mesto
                        {
                            pushes++;
                            nummoves++;
                            levelMap[sokoPosX + 2][sokoPosY] = '$';
                            levelMap[sokoPosX + 1][sokoPosY] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                    }
                    else
                        if (levelMap[sokoPosX + 1][sokoPosY] == '*') // ima paket na cel pod sokobanot
                        {
                            storeMove();
                            if (levelMap[sokoPosX + 2][sokoPosY] == '.') // celta e pod paketot
                            {
                                pushes++;
                                nummoves++;
                                levelMap[sokoPosX + 2][sokoPosY] = '*';
                                levelMap[sokoPosX + 1][sokoPosY] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
                            else
                                if (levelMap[sokoPosX + 2][sokoPosY] == ' ') // pod paketot ima prazno mesto
                                {
                                    pushes++;
                                    nummoves++;
                                    packagesongoal--;
                                    sokobanongoal = true;
                                    levelMap[sokoPosX + 2][sokoPosY] = '$';
                                    levelMap[sokoPosX + 1][sokoPosY] = '@';
                                    if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                    else levelMap[sokoPosX][sokoPosY] = ' ';
                                }
                        }
                        else
                            if (levelMap[sokoPosX + 1][sokoPosY] == '.') // ima cel na pat
                            {
                                nummoves++;
                                levelMap[sokoPosX + 1][sokoPosY] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
        }

        private void moveLeft()
        {
            if (sokoPosX <= 0 || sokoPosY <= 0) return;
            nasoka = 3;
            if (levelMap[sokoPosX][sokoPosY - 1] == ' ') // minuvanje na prazno pole
            {
                nummoves++;
                levelMap[sokoPosX][sokoPosY - 1] = '@';
                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                else levelMap[sokoPosX][sokoPosY] = ' ';
            }
            else
                if (levelMap[sokoPosX][sokoPosY - 1] == '$') // ima paket levo od sokobanot
                {
                    storeMove();
                    if (levelMap[sokoPosX][sokoPosY - 2] == '.') // celta e levo od paketot
                    {
                        pushes++;
                        nummoves++;
                        packagesongoal++;
                        levelMap[sokoPosX][sokoPosY - 2] = '*';
                        levelMap[sokoPosX][sokoPosY - 1] = '@';
                        if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                        else levelMap[sokoPosX][sokoPosY] = ' ';
                    }
                    else
                        if (levelMap[sokoPosX][sokoPosY - 2] == ' ') // levo od paketot ima prazno mesto
                        {
                            pushes++;
                            nummoves++;
                            levelMap[sokoPosX][sokoPosY - 2] = '$';
                            levelMap[sokoPosX][sokoPosY - 1] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                }
                else
                    if (levelMap[sokoPosX][sokoPosY - 1] == '*') // ima paket na cel levo od sokobanot
                    {
                        storeMove();
                        if (levelMap[sokoPosX][sokoPosY - 2] == '.') // celta e levo paketot
                        {
                            pushes++;
                            nummoves++;
                            levelMap[sokoPosX][sokoPosY - 2] = '*';
                            levelMap[sokoPosX][sokoPosY - 1] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                        else
                            if (levelMap[sokoPosX][sokoPosY - 2] == ' ') // pod paketot ima prazno mesto
                            {
                                pushes++;
                                nummoves++;
                                packagesongoal--;
                                sokobanongoal = true;
                                levelMap[sokoPosX][sokoPosY - 2] = '$';
                                levelMap[sokoPosX][sokoPosY - 1] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
                    }
                    else
                        if (levelMap[sokoPosX][sokoPosY - 1] == '.') // ima cel na pat
                        {
                            nummoves++;
                            levelMap[sokoPosX][sokoPosY - 1] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
        }

        private void moveRight()
        {
            if (sokoPosX < 0 || sokoPosY < 0) return;
            nasoka = 1;
            if (levelMap[sokoPosX][sokoPosY + 1] == ' ') // minuvanje na prazno pole
            {
                nummoves++;
                levelMap[sokoPosX][sokoPosY + 1] = '@';
                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                else levelMap[sokoPosX][sokoPosY] = ' ';
            }
            else
                if (levelMap[sokoPosX][sokoPosY + 1] == '$') // ima paket desno od sokobanot
                {
                    storeMove();
                    if (levelMap[sokoPosX][sokoPosY + 2] == '.') // celta e desno od paketot
                    {
                        pushes++;
                        nummoves++;
                        packagesongoal++;
                        levelMap[sokoPosX][sokoPosY + 2] = '*';
                        levelMap[sokoPosX][sokoPosY + 1] = '@';
                        if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                        else levelMap[sokoPosX][sokoPosY] = ' ';
                    }
                    else
                        if (levelMap[sokoPosX][sokoPosY + 2] == ' ') // desno od paketot ima prazno mesto
                        {
                            pushes++;
                            nummoves++;
                            levelMap[sokoPosX][sokoPosY + 2] = '$';
                            levelMap[sokoPosX][sokoPosY + 1] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                }
                else
                    if (levelMap[sokoPosX][sokoPosY + 1] == '*') // ima paket na cel desno od sokobanot
                    {
                        storeMove();
                        if (levelMap[sokoPosX][sokoPosY + 2] == '.') // celta e levo paketot
                        {
                            pushes++;
                            nummoves++;
                            levelMap[sokoPosX][sokoPosY + 2] = '*';
                            levelMap[sokoPosX][sokoPosY + 1] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
                        else
                            if (levelMap[sokoPosX][sokoPosY + 2] == ' ') // pod paketot ima prazno mesto
                            {
                                pushes++;
                                nummoves++;
                                packagesongoal--;
                                sokobanongoal = true;
                                levelMap[sokoPosX][sokoPosY + 2] = '$';
                                levelMap[sokoPosX][sokoPosY + 1] = '@';
                                if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                                else levelMap[sokoPosX][sokoPosY] = ' ';
                            }
                    }
                    else
                        if (levelMap[sokoPosX][sokoPosY + 1] == '.') // ima cel na pat
                        {
                            nummoves++;
                            levelMap[sokoPosX][sokoPosY + 1] = '@';
                            if (pom[sokoPosX][sokoPosY] != '$') levelMap[sokoPosX][sokoPosY] = pom[sokoPosX][sokoPosY];
                            else levelMap[sokoPosX][sokoPosY] = ' ';
                        }
        }

        private void getPreviousMove()
        {
            String s = String.Empty;
            if (listMoves.Count - 1 > 0)
            {
                s = listMoves[listMoves.Count - 1];
                listMoves.RemoveAt(listMoves.Count - 1);
            }

            if (s != String.Empty)
            {
                int i, j;
                for (i = 0; i < levelHeight; i++)
                    for (j = 0; j < levelWidth; j++) levelMap[i][j] = s[i * levelWidth + j];
            }
        }

        private void storeMove()
        {
            String s = "";
            int i, j;
            for (i = 0; i < levelHeight; i++)
                for (j = 0; j < levelWidth; j++) s += levelMap[i][j];

            if (listMoves.Count + 1 == movesToSave)
            {
                listMoves.RemoveAt(0);
            }
            listMoves.Add(s);
        }

        private void Board_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                moveUp();
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                moveDown();
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                moveLeft();
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                moveRight();
            }

            if (e.KeyCode == Keys.U)
            {
                getPreviousMove();
            }

            if (e.KeyCode == Keys.P)
            {
                String r = "";
                int i, j;
                for (i = 0; i < levelHeight; i++)
                {
                    for (j = 0; j < levelWidth; j++) r += pom[i][j];
                    r += "\n";
                }
                MessageBox.Show(r);
            }

            if (e.KeyCode == Keys.O)
            {
                String r = "";
                int i, j;
                for (i = 0; i < levelHeight; i++)
                {
                    for (j = 0; j < levelWidth; j++) r += levelMap[i][j];
                    r += "\n";
                }
                MessageBox.Show(r);
            }

            if (e.KeyCode == Keys.B)
            {

                enterLevel(nivoa[nivo++]);
            }


            Invalidate();
        }

        private void Board_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter sw = File.AppendText("Writetext.txt");
            sw.WriteLine(name+","+nivo+",0,0");

            sw.Close();
        }
    }
}
