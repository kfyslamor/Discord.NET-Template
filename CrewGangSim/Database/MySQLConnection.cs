using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

using System.IO;
using System.Diagnostics;
using CrewGangSim.GameElements.UserElements;
using CrewGangSim.GameElements.FactionElements;
using CrewGangSim.GameElements.NPCElements;
using CrewGangSim.GameElements.LocationElements;
using CrewGangSim.GameElements.VehicleElements;
using CrewGangSim.GameElements.VehicleElements.Template;
using CrewGangSim.GameElements.LocationElements;

namespace CrewGangSim.Modules.Database
{
    public partial class MySQLConnection
    {
        /*
         * Get crew_table's name and also player info.
         * execute a query that returns the npcs of a specific user chosen by the userID.
         * return the list of the player's crew, as a List<NPC>.
         */

        /*public List<NPC> CrewSelect(string tableName, Player player)
        {
            string query = "SELECT * FROM " + tableName + " WHERE = " + player.UserID + ";";
            //Use Count method to create the list.
            List<NPC> npcTable = new List<NPC>(new MySQLConnection().Count(tableName));
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    npcTable.Add(new NPC(dataReader.GetUInt32(0), dataReader.GetString(1), dataReader.GetUInt32(2), dataReader.GetUInt32(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5)));
                    Console.WriteLine(new NPC(dataReader.GetUInt32(0), dataReader.GetString(1), dataReader.GetUInt32(2), dataReader.GetUInt32(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5)).ToString());
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return npcTable;
            }
            else
            {
                return npcTable;
            }
        }*/

        /*
* Gets crew_table's name and also player info.
* executes a query that inserts an enforcer to the crew_table.
* returns void.
*/
        public bool CrewInsert(Player player, NPC npc)
        {
            string query = "INSERT INTO `crewgame`.`npc_table` (`npcID`, `npcName`, `npcLoyalty`, `npcProduction`, `npcAttack`, `npcDefense`, `users_userID`) VALUES (DEFAULT, '" + npc.NpcName + "', '" + npc.NpcLoyalty + "'" +
                ", '" + npc.ProductionPoint + "', '" + npc.AttackPoint + "', '" + npc.DefensePoint + "');";
            try
            {
                if (this.OpenConnection())
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //close datareader
                    dataReader.Close();
                    //close Connection
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Source + " " + exception.Message);
                return false;
            }
        }
        /*
         * Gets location_table where the player's factions are a match with the location.
         * 
         */
        /*public List<Location> LocationSelect(string tableName, Player player)
        {
            string query = "SELECT * FROM " + tableName + " WHERE faction_table_idCrew= " + player.PlayerFaction.Fid + ";";
            //Use Count method to create the list.
            List<Location> locationTable = new List<Location>(new MySQLConnection().Count(tableName));
            try
            {
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        locationTable.Add(new Location(dataReader.GetUInt32(0), dataReader.GetUInt32(1), dataReader.GetUInt32(2), dataReader.GetString(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5), dataReader.GetUInt32(6), dataReader.GetString(7)));
                        Console.WriteLine(new Location(dataReader.GetUInt32(0), dataReader.GetUInt32(1), dataReader.GetUInt32(2), dataReader.GetString(3), dataReader.GetUInt32(4), dataReader.GetUInt32(5), dataReader.GetUInt32(6), dataReader.GetString(7)));
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                    return locationTable;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }*/

        public List<House> HouseSelect(string tableName, Location location)
        {
            string query = "SELECT * FROM " + tableName + " WHERE location_table_locationID= " + location.LocationID + ";";


            //Use Count method to create the list.

            List<House> houseList = new List<House>(new MySQLConnection().Count(tableName));
            List<Storage> storageList = new List<Storage>(new MySQLConnection().Count("storage_table"));
            try
            {
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        houseList.Add(new House(dataReader.GetUInt32(0), dataReader.GetString(1)));
                        Console.WriteLine(new House(dataReader.GetUInt32(0), dataReader.GetString(1)).ToString());
                    }
                    //Close the datareader to start it again with a different cmd
                    dataReader.Close();
                    //Change the command for storage
                    string queryStorage = "SELECT * FROM storage_table WHERE house_table_houseID= " + houseList[0].HouseID + "";
                    cmd = new MySqlCommand(queryStorage, connection);

                    //Change the data reader and execute the cmd.
                    dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        storageList.Add(new Storage(dataReader.GetInt32(0), dataReader.GetUInt32(1), dataReader.GetUInt32(2), dataReader.GetUInt32(3)
                            , dataReader.GetUInt32(4), dataReader.GetUInt32(5), dataReader.GetUInt32(6)));
                        Console.WriteLine(new Storage(dataReader.GetInt32(0), dataReader.GetUInt32(1), dataReader.GetUInt32(2), dataReader.GetUInt32(3)
                            , dataReader.GetUInt32(4), dataReader.GetUInt32(5), dataReader.GetUInt32(6)).ToString());
                    }
                    for (int i = 0; i < houseList.Count && i < storageList.Count; i++)
                    {
                        if (houseList[i].HouseID == storageList[i].StorageID)
                        {
                            houseList[i].Storage = storageList[i];
                        }//If the house ID matches storageID, update the houseList's storage.
                    }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                    return houseList;
                }
                else
                {
                    return houseList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /*
         * Inserts a house to the house_table and then inserts a storage.
         * Returns true on success, false on fail.
         *
         */

        /*
         * Gets the location and the tableName as parameters, then gets the houseList from the selected location. Inserts it to the said tableName.
         * Returns true on success, false on fail.
         */
        public bool HouseInsert(string tableName, Location location)
        {
            House house = location.HouseList[0];
            Storage storage = house.Storage;
            string query = "INSERT INTO `crewgame`.`house_table` (`houseID`, `houseName`, `location_table_locationID`) VALUES ('DEFAULT', '" + house.HouseName + "', '" + location.LocationID + "');";
            string queryStorage = "INSERT INTO `crewgame`.`storage_table` (`storageID`, `storageDirtyMoney`, `storageGunMaterials`, `storageHeroin`, `storageCocain`, `storageLSD`, `storageWeed`, `house_table_houseID`)" +
                " VALUES ('" + storage.StorageID + "', '" + storage.DirtyMoney + "', '" + storage.GunMaterials + "', '" + storage.Heroin + "', '" + storage.Cocain + "', '" + storage.Lsd + "', '" + storage.Weed + "', '" + house.HouseID + "');";

            try
            {
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //close datareader
                    dataReader.Close();
                    //Change command
                    cmd = new MySqlCommand(queryStorage, connection);
                    //Start the datareader and execute the command.
                    dataReader = cmd.ExecuteReader();


                    //close Connection
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

        /*
         * Gets the location and the tableName as parameters, then gets the houseList from the selected location. Inserts it to the said tableName.
         * Returns true on success, false on fail.
         */

        public bool HouseUpdate(string tableName, Location location)
        {
            //Get house and house's storage, update both of them.

            House house = location.HouseList[0];
            Storage storage = house.Storage;
            Console.WriteLine(house.Storage.ToString());
            string query = "UPDATE `crewgame`.`house_table` SET `houseName` = '" + house.HouseName + "', `location_table_locationID` = '" + location.LocationID + "' WHERE (`houseID` = '" + house.HouseID + "');";

            string queryStorage = "UPDATE `crewgame`.`storage_table` SET `storageDirtyMoney` = '" + storage.DirtyMoney + "', `storageGunMaterials` = '" + storage.GunMaterials + "'," +
                " `storageHeroin` = '" + storage.Heroin + "', `storageCocain` = '" + storage.Cocain + "', `storageLSD` = '" + storage.Lsd + "', `storageWeed` = '" + storage.Weed + "' WHERE(`storageID` = '" + storage.StorageID + "');";
            try
            {
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Close and re-initiate the datareader.
                    dataReader.Close();

                    //Create command
                    cmd = new MySqlCommand(queryStorage, connection);
                    //Use the data reader again.
                    dataReader = cmd.ExecuteReader();

                    //close datareader
                    dataReader.Close();
                    //close Connection
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
        /*
         * Get list of cars from db, get list of trunk from db, match them.
         */
        public List<Car> CarSelect(string tableName, Player player)
        {
            List<Car> listOfCars = new List<Car>(); // Initalized with empty storages.
            List<Trunk> listOfTrunks = new List<Trunk>();
            string query = "SELECT * FROM " + tableName + " WHERE " + player.DiscordID + " = 0;";

            try
            {
                if (this.OpenConnection() == true)
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //Get cars
                    while (dataReader.Read())
                    {
                        listOfCars.Add(new Car(dataReader.GetInt32("carID"), dataReader.GetString("carName"),
                            dataReader.GetInt32("numberOfWheels"), dataReader.GetString("colorOfCarHex"),
                            dataReader.GetUInt32("trunkCapacity"), dataReader.GetUInt32("crewCapacity"), dataReader.GetInt32("users_userID")));
                    }
                    //Close and re-initiate the datareader.
                    dataReader.Close();

                    //Create command
                    string queryStorage = "SELECT * FROM trunk_table WHERE car_table_carID= " + listOfCars[0].CarID + "";
                    cmd = new MySqlCommand(queryStorage, connection);
                    //Use the data reader again.
                    dataReader = cmd.ExecuteReader();
                    //Get trunks
                    while (dataReader.Read())
                    {
                        listOfTrunks.Add(new Trunk(dataReader.GetInt32("storageID"), dataReader.GetUInt32("storageDirtyMoney"),
                            dataReader.GetUInt32(2), dataReader.GetUInt32(3),
                            dataReader.GetUInt32(4), dataReader.GetUInt32(5), dataReader.GetUInt32(6), dataReader.GetInt32(7)));
                    }
                    //close datareader
                    dataReader.Close();
                    //close Connection
                    this.CloseConnection();
                    //Match the car and trunk.
                    listOfCars[0].Trunk = listOfTrunks[0];

                    return listOfCars;
                }
                else
                {
                    return listOfCars;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }







        /*
         * Gets a tableName returns the count of the rows as int.
         */
        public int Count(string tablename)
        {
            string query = "SELECT Count(*) FROM " + tablename + ";";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public bool TurfInsert(Turf turf)
        {
            string query = $"INSERT INTO `crewgame_bot`.`turf_table` (`turfName`, `turfPops`, `turfGuns`, `users_table_discordID`) VALUES ('{turf.Name}', '{turf.Pops}', '{turf.Guns}', '{turf.DiscordID}');";

            try
            {
                if (this.OpenConnection())
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    //close datareader
                    dataReader.Close();
                    //close Connection
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Source + " " + exception.Message);
                return false;
            }
        }
    }
}