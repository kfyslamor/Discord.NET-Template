
using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

using System.IO;
using System.Diagnostics;
using CrewGangSim.GameElements.UserElements;
using CrewGangSim.GameElements.FactionElements;

namespace CrewGangSim.Modules.Database
{
    public partial class MySQLConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        //Constructor
        //Initialize values
        public MySQLConnection()
        {
            this.server = "localhost";
            this.database = "crewgame";
            this.uid = "root";
            this.password = "Rootkfy2000#";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            this.connection = new MySqlConnection(connectionString);
        }

        //Initialize values for players using a different server.
        public MySQLConnection(string server)
        {
            this.server = server;
            database = "crewgame";
            uid = "root";
            password = "Rootkfy2000#";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                //DEBUG MessageBox.Show("Connection Established.");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /*public bool UserInsert(string tableName, Player pl1)
        {
            try
            {
                string query = "INSERT INTO " + tableName + " (UserID,PlayerName,Experience,Money) VALUES(" + pl1.UserID + ",'" + pl1.PlayerName + "'," + pl1.Experience + "," + pl1.Money + ");";
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }*/

        //Player Insert Statement
        /*
         *This method inserts the following info to the users table.
         *UserID,forumname,password,playername,experience,money
         *Returns true on successfully inserting the player to the table else returns false.
         *TODO 
         */
        public bool PlayerInsert(string tableName, Player pl1)
        {
            try
            {
                string query = $"INSERT INTO `crewgame_bot`.`users_table` (`discordID`, `discordTag`, `experience`, `money`, `faction_table_factionID`)" +
                    $" VALUES('{pl1.DiscordID}', '{pl1.DiscordTag}', '{pl1.Experience}', '{pl1.Money}', '{1}');";
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        //Player Select statement
        /*
         *This method selects the following info from the users table.
         *Everything inside the table.
         *Returns a List of players.
         *TODO 
         */
        /*public List<Player> PlayerSelect(string tableName)
        {
            const int PLAYER_AMOUNT = 1000;
            string query = "SELECT * FROM " + tableName + ";";
            //Create lists to store the values of players and npc tables.
            List<Player> playerList = new List<Player>(PLAYER_AMOUNT);



            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = null;
                //MySqlDataReader factionTableDataReader = null;
                try
                {
                    dataReader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\nPLEASE TAKE A SCREENSHOT OF THIS ERROR AND SEND TO THIS ADDRESS : 21kfy#8274");
                }
                finally
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n<------------------------------------- User List Output ------------------------------------->");
                    int i = 0;
                    //Read the data and store them
                    while (dataReader.Read())
                    {
                        playerList.Add(new Player(dataReader.GetUInt32(0), dataReader.GetString(1), dataReader.GetString(2),
                            dataReader.GetString(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5), new Faction(dataReader.GetUInt32(6))));
                        Console.WriteLine(i++ + " " + new Player(dataReader.GetUInt32(0), dataReader.GetString(1), dataReader.GetString(2),
                            dataReader.GetString(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5), new Faction(dataReader.GetUInt32(6))));
                        //make the list
                        //UserID,ForumName,Password,PlayerName,Experience,Money,npcTableID
                    }
                }
                //Read the data and store them in the list

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return playerList;
            }
            else
            {
                return playerList;
            }
        }*/
        //Faction Select Statement
        /*
         *This method selects the following info from the faction_table.
         *Everything inside the table.
         *Returns a List of factions.
         *TODO 
         */
        public List<Faction> FactionSelect(string tableName)
        {
            string query = "SELECT * FROM " + tableName + ";";
            const int PLAYER_AMOUNT = 1000;
            List<Faction> factionList = new List<Faction>(PLAYER_AMOUNT / 4);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = null;
                try
                {
                    dataReader = cmd.ExecuteReader();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message + "\nPLEASE TAKE A SCREENSHOT OF THIS ERROR AND SEND TO THIS ADDRESS : 21kfy#8274");
                }
                finally
                {
                    //Read the data and store them
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n<------------------------------------- Faction List Output ------------------------------------->");
                    while (dataReader.Read())
                    {
                        factionList.Add(new Faction(dataReader.GetUInt32(0), dataReader.GetString(1), dataReader.GetUInt32(2),
                            dataReader.GetUInt32(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5)));
                        Console.WriteLine(new Faction(dataReader.GetUInt32(0), dataReader.GetString(1), dataReader.GetUInt32(2),
                            dataReader.GetUInt32(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5)));
                        //make the list
                        //idCrew,nameCrew,factionMoneyCrew,factionPointsCrew,gunPointsCrew,memberSlotCrew
                    }
                    Console.WriteLine("Returning factionList element amount:" + factionList.Count);
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed

                }
                //MessageBox.Show("Returning factionList element amount:" + factionList.Count); //DEBUG
                return factionList;
            }
            else
            {
                Console.WriteLine("Returning Null");
                return null;
            }


        }
        //Player Delete Statement
        /*
        *This method deletes the following user from the users table.
         *Everything inside the table.
         *Returns true on success, returns false on exceptions and connection isn't established.
         *TODO 
         */
        public bool PlayerDelete(string tableName, Player pl1)
        {
            try
            {
                string query = "DELETE FROM " + tableName + " WHERE discordID=\"" + pl1.DiscordID + "\" LIMIT 1;";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        //Player Update Statement
        /*
         *This method updates the following info in the users table.
         *Money and experience attributes WHERE UserID condition is met.
         *Returns void.
         *TODO 
         */
        public void PlayerUpdate(string tableName, Player pl1)
        {
            string query = "UPDATE " + tableName + " SET money=" + pl1.Money + ", experience=" + pl1.Experience + " WHERE UserID=" + pl1.DiscordID + ";";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Faction Update Statement
        /*
         *This method updates the following info inside the faction_table.
         *faction money, faction points and faction gun stock WHERE UserID condition is met.
         *Returns void.
         *TODO 
         */
        public void FactionUpdate(string tableName, Faction faction1)
        {
            string query = "UPDATE " + tableName + " SET factionMoneyCrew = " + (int)faction1.Fmoney + ",factionPointsCrew =" + (int)faction1.Fpoints + ",gunPointsCrew=" + (int)faction1.Fstock + " WHERE idCrew = " + (int)faction1.Fid + ";";
            //string query = "UPDATE " + tableName + " SET factionMoneyCrew=" + faction1.Fmoney + "WHERE idCrew = " + faction1.Fid + ";";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }



        //Backup
        public void Backup()
        {
            try
            {
                //Build a string that stores the file-name as the current date.
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error , unable to backup!");
            }
        }
        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error , unable to Restore!");
            }
        }
    }
}