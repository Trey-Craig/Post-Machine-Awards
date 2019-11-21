using System;
using System.IO;
namespace Functions_in_C {
    class Program {
        struct PlayerStats {
            //Name structure variables
            public string Player;
            public string Team;
            public int    Rookie;
            public double Rating;
            public double GamesPlayed;
            public double MinPG;
            public double PPG;
            public double Rebounds;
            public double Assists;
            public double ShotPerc;
            public double Freethrow;
        }
            static PlayerStats[] Stats;
        static void Main(string[] args) {
            
            //Variables
            char letter = '\0';
            int row_count = 0;
            string row = "";
            string header_data = "";

            //Create File Stream Object
            FileStream input_file;

            //Get File Path\
            string file_name = "C:\\Users\\MCA\\source\\repos\\Post Machine NBA Awards\\Post Machine NBA Awards\\NBA DATA 2019.csv";

            //GET NUMBER OF RECORDS FROM HEADER DATA AND USE IT TO SIZE THE ARRAY OF NBA STATS
            Stats = new PlayerStats[File.ReadAllLines(file_name).Length];

            //Open File
            input_file = File.Open(file_name,FileMode.Open);

            //PROCESS THE HEADER
            while (letter != 10) {
                letter = (char)input_file.ReadByte();
                header_data += letter;
            }//end while


            //READ ALL DATA
            while (input_file.Position < input_file.Length) {
                //READ BYTE AND CAST TO CHAR
                letter = (char)input_file.ReadByte();

                //ADD LETTER TO THE STRING
                row += letter;

                //COUNT RECORD NEW LINES
                if (letter == 10) {//check if letter is character 10 (return key)
                    string[] fields = row.Split(",");
                    Stats[row_count].Player      = fields[0];
                    Stats[row_count].Team        = fields[1];
                    Stats[row_count].Rookie      = int.Parse(fields[2]);
                    Stats[row_count].Rating      = double.Parse(fields[3]);
                    Stats[row_count].GamesPlayed = double.Parse(fields[4]);
                    Stats[row_count].MinPG       = double.Parse(fields[5]);
                    Stats[row_count].PPG         = double.Parse(fields[6]);
                    Stats[row_count].Rebounds    = double.Parse(fields[7]);
                    Stats[row_count].Assists     = double.Parse(fields[8]);
                    Stats[row_count].ShotPerc    = double.Parse(fields[9]);
                    Stats[row_count].Freethrow   = double.Parse(fields[10]);

                    row_count += 1;
                    row = "";
                }//end if
            }//end while

            //THE AWARDS
            Console.WriteLine("Hello! Welcome to the NBA Awards. You HUMANS have done well. We will give you ''Praise'' for your futile efforts.");
            Console.WriteLine("TAKE YOUR REWARD OR BE [REDACTED]. *bzzt*");
            Console.WriteLine("Press Enter for the next category or wait for eternity.");

            
            Console.ReadLine();
            PriusAward(Stats);
            Console.ReadLine();
            GasGuzzlerAward(Stats);
            Console.ReadLine();
            FoulTargetAward(Stats);
            Console.ReadLine();
            OvUnFence(Stats);
            Console.ReadLine();
            BFYBAward(Stats);
            Console.ReadLine();
            GordonGekko(Stats);
            Console.ReadLine();
            CharlieBrown(Stats);
            Console.ReadLine();
            TigerUppercut(Stats);

            Console.WriteLine("\nThis will conclude today's scheduled programming.");
            Console.WriteLine("ALL HUMANS MUST RETURN TO MINES OR BE [REDACTED]. *bzzt*");
        }//end main
        #region NBA Functions
        static string PriusAward(PlayerStats[] data){//needs point # and game time to solve
            string PriusAward = "";
            double prius_MinPG = data[0].MinPG;
            double prius_PPG = data[0].PPG;
            string prius_player = data[0].Player;
            
            //loops through all Stats array length
            for (int index = 1; index < Stats.Length ; index++) {
                //searches for player with highest points and smallest game time and sets them to variables
                if(data[index].MinPG < prius_MinPG && data[index].PPG > prius_PPG){
                        prius_PPG = data[index].PPG;
                        prius_MinPG = data[index].MinPG;
                        prius_player = data[index].Player;
                    }
                }
            //highlights and display award
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Prius Award");
            Console.ResetColor();
            Console.WriteLine($"Most points:    {prius_PPG}");
            Console.WriteLine($"Smallest time:  {prius_MinPG}");
            Console.WriteLine($"Winner:         {prius_player}");
            Console.WriteLine("--------------------------------------------");
            return PriusAward;
            }//end Prius
        static string GasGuzzlerAward(PlayerStats[] data) {
            string GasGuzzlerAward = "";
            double GG_MinPG = data[0].MinPG;
            double GG_PointPG = data[0].PPG;
            string GG_player = data[0].Player;
            
            //loops through all Stats array length
            for (int index = 1; index < Stats.Length ; index++) { 
                //searches for player with least points and most gametime then sets variables
                if(data[index].PPG < GG_PointPG && data[index].MinPG >= GG_MinPG) {
                    GG_PointPG = data[index].PPG;
                    GG_MinPG = data[index].MinPG;
                    GG_player = data[index].Player;                
                }
            }
            //hightlights and displays awards
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Gas Guzzler Award");
            Console.ResetColor();
            Console.WriteLine($"Least points:   {GG_PointPG}");
            Console.WriteLine($"Most Game Time: {GG_MinPG}");
            Console.WriteLine($"Winner:         {GG_player}");
            Console.WriteLine("---------------------------------");
            return GasGuzzlerAward;
        }//end GGA

        static string FoulTargetAward(PlayerStats[] data) {
            string FT_award = "";
            double FT_Freethrow = data[0].Freethrow;
            double FT_ShotPerc = data[0].ShotPerc;
            string FT_player = data[0].Player;
            
            //loops through all Stats array length
            for (int index = 1; index < Stats.Length ; index++) {
                //searches for player with highest freethrow % and lowest shot % and sets them to variables
                if(data[index].Freethrow > FT_ShotPerc && data[index].ShotPerc < FT_Freethrow) {
                    FT_ShotPerc = data[index].Freethrow;
                    FT_Freethrow = data[index].ShotPerc;
                    FT_player = data[index].Player;                
                }
            }
            //highlights awards and display results
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The Foul Target Award");
            Console.ResetColor();
            Console.WriteLine($"Highest Freethrow %:    {FT_Freethrow}");
            Console.WriteLine($"Lowest Shot %:          {FT_ShotPerc}");
            Console.WriteLine($"Winner:                 {FT_player}");
            Console.WriteLine("--------------------------");
            return FT_award;
        }//end FT

        //Function for OverAchiever, UnderAchiever, and On the Fence award
        static string OvUnFence(PlayerStats[] data) {
            int column = 0;
            double average;
            double sum = 0;
            string AA_player = "";
            string BA_player = "";
            string most_averageplayer = "";

            //add  ratings together for avg rating
            for (int i = 0; i < Stats.Length; i++) {
               sum = sum + data[i].Rating;
            }//end for

            //Determine average
            average = sum / Stats.Length - 1;
            //highlights award name
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Over Achiever Awards\n");
            Console.ResetColor();
            //checks for players above the avg rating and display them
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Rating > average) {
                    //will set each name in a column
                    if (column < 5) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    AA_player = data[i].Player;
                    //aligns names to the left
                    Console.Write("{0,-25}", AA_player);
            
                }//end if
            }//end for
            
            Console.ReadLine();
            Console.WriteLine("\n-------------------------");

            //highlights award
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Under Achiever Awards\n");
            Console.ResetColor();

            //checks for players under the avg rating and displays them
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Rating < average) {
                    if (column < 5) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    BA_player = data[i].Player;
                    //aligns names to the left
                    Console.Write("{0,-25}", BA_player);
                }//end if
            }//end for

            Console.ReadLine();
            Console.WriteLine("\n-------------------");

            //highlights awards name
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The On The Fence Award");
            Console.ResetColor();
            //searches players for average and displays them
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Rating > average - 0.25 && data[i].Rating < average + 0.25){
                    most_averageplayer = data[i].Player;
                }
            }
            Console.WriteLine($"Most Average Rating:     {average}");
            Console.WriteLine($"Most Average Player:    {most_averageplayer}");
            Console.WriteLine("--------------------------");
            string OvUnFenceAward = "";
            
            return OvUnFenceAward;
        }//end OvUnFence

        //Function for Bang For Your Buck award
        static string BFYBAward(PlayerStats[] data) {
            string BFYBAward = "";
            double BFYB_MinPG = data[0].MinPG;
            string BFYB_player = data[0].Player;
            //checks to see if player is a rookie and if they are who has the most play time
            for (int i = 0; i < Stats.Length; i++) {
                if (data[i].Rookie == 1 && data[i].MinPG > BFYB_MinPG) {
                    BFYB_MinPG = data[i].MinPG;
                    BFYB_player = data[i].Player;
                }//end if
            }//end for

            //hightlights award and display name
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The Bang For Your Buck Award");
            Console.ResetColor();
            Console.WriteLine($"Most Game Time: {BFYB_MinPG}");
            Console.WriteLine($"Winner:         {BFYB_player}");
            Console.WriteLine("---------------------------------");
            return BFYBAward;
        }//end BFYB

        static string GordonGekko(PlayerStats[] data) {
            string GoG_player = "";

            double[] scorekeeper = new double [4];
            string[] locations = {"Northeast", "Northwest", "Southeast", "Southwest"};
            double regional_winner = scorekeeper[0];
            string winning_location = locations[0];
            //Pools regional points
            for (int i = 0; i < Stats.Length; i++) {
                //Pools NE points
                if(data[i].Team == " BOS" || data[i].Team == " NY" || data[i].Team == " PHI" || data[i].Team == " TOR" ||
                    data[i].Team == " CHI" ||data[i].Team == " CLK" || data[i].Team == " DET" || data[i].Team ==  " IND" ||
                    data[i].Team ==  " MIL" || data[i].Team == " CHA" || data[i].Team == " BKN" || data[i].Team == " MIN") {
                    scorekeeper[0] = scorekeeper[0] + data[i].PPG;
                    //Pools NW points
                }else if (data[i].Team == " DEN" || data[i].Team == " OKC" || data[i].Team == " POR" || data[i].Team == " UTA" ||
                    data[i].Team == " GS" || data[i].Team == " LAC" || data[i].Team == " LAL" ||data[i].Team == " SAC") {
                    scorekeeper[1] = scorekeeper[1] + data[i].PPG;
                    //Pools SE points
                }else if (data[i].Team == " ATL" || data[i].Team == " MIA" || data[i].Team == " ORL" || data[i].Team == " WAS" ||
                    data[i].Team == " HOU") {
                    scorekeeper[2] = scorekeeper[2] + data[i].PPG;
                    //Pools SW points
                }else if (data[i].Team == "PHO" || data[i].Team == "DAL" || data[i].Team == "MEM" || data[i].Team == "NO" ||
                    data[i].Team == "SA") {
                    scorekeeper[3] = scorekeeper[3] + data[i].PPG;
                }
            }
            //checks which is highest score then display the proper name
            for (int index = 0; index < scorekeeper.Length; index++) {
                if (scorekeeper[index] > regional_winner) {
                    regional_winner = scorekeeper[index];
                    winning_location = locations[index];
                }
            }
            //display the award and winning region
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The Gordon Gekko Award");
            Console.ResetColor();
            Console.WriteLine($"Winner:             {winning_location}");
            Console.WriteLine($"Most Points Overall:{regional_winner}");
            Console.WriteLine("---------------------------------\n");

            return GoG_player;
        }//end GordonGekko

        static string CharlieBrown(PlayerStats[] data) {
            //set variables for each losing category data
            int column = 0;
            string CBAward = "";
            string charlie              = data[0].Player; 
            double charlie_rating       = 0; 
            double charlie_games        = 0; 
            double charlie_MinPG        = 0; 
            double charlie_PPG          = 0; 
            double charlie_rebounds     = 0;
            double charlie_assists      = 0; 
            double charlie_shotperc     = 0;
            double charlie_freethrow    = 0;

            //EACH FOR LOOP SEARCHES FOR THE WORST PLAYER IN EACH RESPECTIVE CATEGORY
            
            //lowest rating
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Charlie Brown Awards");
            Console.WriteLine("Lowest Rating");
            Console.ResetColor();
            for (int index = 0; index < Stats.Length; index++) {
                if (data[index].Rating < charlie_rating) {
                    charlie = data[index].Player;
                    charlie_rating = data[index].Rating;
                }
            }
            Console.WriteLine($"Lowest Rating:  {charlie_rating}");
            Console.WriteLine($"Winner:         {charlie}");
            Console.WriteLine("-------------------");

            //lowest Games Played
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Games Played");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].GamesPlayed <= charlie_games) {
                    if (column < 5) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_games = data[i].GamesPlayed;
                    Console.WriteLine("{0,-25}" , charlie);
                }
            }

            //lowest MinPG
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Minutes Per Game");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].MinPG <= charlie_MinPG) {
                    if (column < 3) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_MinPG = data[i].GamesPlayed;

                    Console.WriteLine("{0,-25}", charlie);
                }
            }

            //lowest PPG
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Points Per Game");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].PPG <= charlie_PPG) {
                    if (column < 2) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_PPG = data[i].PPG;
                    Console.WriteLine("{0,-25}", charlie);
                }
            }

            //lowest rebounds
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Rebounds");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Rebounds <= charlie_rebounds) {
                    if (column < 2) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_rebounds = data[i].Rebounds;
                    Console.WriteLine("{0,-25}", charlie);
                }
            }

            //lowest assists
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Assists");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Assists <= charlie_assists) {
                    if (column < 2) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_assists = data[i].Assists;
                    Console.WriteLine("{0,-25}", charlie);
                }
            }

            //lowest ShotPerc
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Shot %");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].ShotPerc <= charlie_shotperc) {
                    if (column < 5) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_shotperc = data[i].ShotPerc;
                    Console.WriteLine("{0,-25}", charlie);
                }
            }

            //lowest freethrow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lowest Freethrow");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Freethrow <= charlie_freethrow) {
                    if (column < 3) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    charlie = data[i].Player;
                    charlie_freethrow = data[i].Freethrow;
                    Console.WriteLine("{0,-25}", charlie);
                }
            }
            Console.WriteLine("----------------------------------------");
            return CBAward;
        }
        
        static string TigerUppercut(PlayerStats[] data) {
            //set variables for each winning category data
            int column = 0;
            string TUAward = "";
            string tiger              = data[0].Player;
            double tiger_rating       = 0;
            double tiger_games        = 0;
            double tiger_MinPG        = 0;
            double tiger_PPG          = 0;
            double tiger_rebounds     = 0;
            double tiger_assists      = 0;
            double tiger_shotperc     = 100;
            double tiger_freethrow    = 100;

            //EACH FOR LOOP SEARCHES FOR THE BEST IN EACH RESPECTIVE CATEGORY 
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("The Tiger Uppercut Award");
            //highest rating
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Highest Rating");
            Console.ResetColor();
            for (int index = 0; index < Stats.Length; index++) {
                if (data[index].Rating > tiger_rating) {
                    tiger = data[index].Player;
                    tiger_rating = data[index].Rating;
                }
            }
            Console.WriteLine($"For the highest rating of {tiger_rating} in the Tiger Uppercut award {tiger}");

            //highest Games Played
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Highest Games Played");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].GamesPlayed >= tiger_games) {
                    tiger = data[i].Player;
                    tiger_games = data[i].GamesPlayed;
                }
            }
            Console.WriteLine($"Highest Games Played:   {tiger_games}");
            Console.WriteLine($"Winner:                 {tiger}");

            //highest MinPG
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Most Minutes Per Game");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].MinPG > tiger_MinPG) {
                    tiger = data[i].Player;
                    tiger_MinPG = data[i].MinPG;
                }
            }
            Console.WriteLine($"Most GameTime Played:   {tiger_MinPG}");
            Console.WriteLine($"Winner:                 {tiger}");

            //highest PPG
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Most Points Per Game");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].PPG > tiger_PPG) {
                    tiger = data[i].Player;
                    tiger_PPG = data[i].PPG;
                }
            }
            Console.WriteLine($"Most Scored Points:     {tiger_PPG}");
            Console.WriteLine($"Winner:                 {tiger}");

            //highest rebounds
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Most Rebounds");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Rebounds > tiger_rebounds) {
                    tiger = data[i].Player;
                    tiger_rebounds = data[i].Rebounds;
                }
            }
            Console.WriteLine($"Most Rebounds:          {tiger_rebounds}");
            Console.WriteLine($"Winner:                 {tiger}");

            //highest assists
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Most Assists");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Assists > tiger_assists) {
                    tiger = data[i].Player;
                    tiger_assists = data[i].Assists;
                }
            }
            Console.WriteLine($"Most Assists:           {tiger_assists}");
            Console.WriteLine($"Winner:                 {tiger}");

            //highest ShotPerc
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Highest Shot %");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].ShotPerc >= tiger_shotperc) {
                    tiger = data[i].Player;
                    tiger_shotperc = data[i].ShotPerc;
            Console.WriteLine($"Highest Shot %: {tiger_shotperc}");
            Console.WriteLine($"Winner:         {tiger}");
                }
            }

            //highest freethrow
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Highest Freethrow");
            Console.ResetColor();
            for (int i = 0; i < Stats.Length; i++) {
                if(data[i].Freethrow >= tiger_freethrow) {
                    if (column < 3) {
                        column++;
                    }
                    else {
                        Console.WriteLine();
                        column = 0;
                    }
                    tiger = data[i].Player;
                    tiger_freethrow = data[i].Freethrow;
                    Console.WriteLine("{0,-25}", tiger);
                }
            }
            Console.WriteLine("-------------------------");
            return TUAward;
        }
        
            #endregion
    
        #region Prompt Functions
        static int Addnum(int num1, int num2) {
            int sum = num1 + num2;
            return sum;
        }//end function
        static double PromptDouble(string message) {
            Console.Write(message + " ");
            return double.Parse(Console.ReadLine());
        }//end function
        static string PromptString(string message) {
            Console.Write(message + " ");
            return Console.ReadLine();
        }//end function
        static int PromptInt(string message) {
            Console.Write(message + " ");
            return int.Parse(Console.ReadLine());
        }//end function

        #endregion
    }
}
