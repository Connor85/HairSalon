using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Specialty
    {
        private string _description;
        private int _id;

        public Specialty(string description, int id = 0)
        {
            _description = description;
            _id = id;
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherSpecialty;
                bool areIdsEqual = (this.GetId() == newSpecialty.GetId());
                bool areNamesEqual = (this.GetDescription() == newSpecialty.GetDescription());
                return (areIdsEqual && areNamesEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (description) VALUES (@description);";

            MySqlParameter description = new MySqlParameter();
            description.ParameterName = "@description";
            description.Value = this._description;
            cmd.Parameters.Add(description);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialtys = new List<Specialty> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int SpecialtyId = rdr.GetInt32(0);
                string SpecialtyDescription = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(SpecialtyDescription, SpecialtyId);
                allSpecialtys.Add(newSpecialty);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialtys;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int stylistId = 0;
            string description = "";
            while(rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                description = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(description, stylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

        // public void AddStylist(Stylist newStylist)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"INSERT INTO stylists_clients (sty, client_id) VALUES (@stylistId, @clientId);";
        //
        //     MySqlParameter  = new MySqlParameter();
        //     .ParameterDescription = "@stylistId";
        //     .Value = newStylist.GetId();
        //     cmd.Parameters.Add();
        //
        //     MySqlParameter client_id = new MySqlParameter();
        //     client_id.ParameterDescription = "@clientId";
        //     client_id.Value = _id;
        //     cmd.Parameters.Add(client_id);
        //
        //     cmd.ExecuteNonQuery();
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }
        // public List<Stylist> GetStylists()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT stylists.* FROM clients
        //     JOIN stylists_clients ON (client.id = stylists_clients.client_id)
        //     JOIN stylists ON (stylists_clients. = stylists.id)
        //     WHERE stylists.id = @stylistId;";
        //
        //     MySqlParameter stylistIdParameter = new MySqlParameter();
        //     stylistIdParameter.ParameterDescription = "@stylistId";
        //     stylistIdParameter.Value = _id;
        //     cmd.Parameters.Add(stylistIdParameter);
        //
        //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     List<Stylist> stylists = new List<Stylist>{};
        //
        //     while(rdr.Read())
        //     {
        //         int recipeId = rdr.GetInt32(0);
        //         string recipeDescription = rdr.GetString(1);
        //
        //         Stylist newStylist = new Stylist(recipeDescription, recipeId);
        //         stylists.Add(newStylist);
        //     }
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        //     return stylists;
        // }
    }
}
