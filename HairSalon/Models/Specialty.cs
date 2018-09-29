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

        public List<Stylist> GetStylists()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT stylists.* FROM specialties
          JOIN specialties_stylists ON (specialties.id = specialties_stylists.specialty_id)
          JOIN stylists ON (specialties_stylists.stylist_id = stylists.id)
          WHERE specialties.id = @specialytId;";

          MySqlParameter specialytIdParameter = new MySqlParameter();
          specialytIdParameter.ParameterName = "@specialytId";
          specialytIdParameter.Value = _id;
          cmd.Parameters.Add(specialytIdParameter);

          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          List<Stylist> specialty = new List<Stylist>{};

          while(rdr.Read())
          {
            int id = rdr.GetInt32(0);
            string hire = rdr.GetString(2);
            string desctiption = rdr.GetString(1);

            Stylist newStylist = new Stylist(desctiption, hire, id);
            specialty.Add(newStylist);
          }
          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
          return specialty;
        }

        public void AddStylist(Stylist newStylist)
            {
                MySqlConnection conn = DB.Connection();
                conn.Open();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO stylists_clients (specialty_id, stylist_id) VALUES (@specialtyId, @stylistId);";

                MySqlParameter specialtyId = new MySqlParameter();
                specialtyId.ParameterName = "@specialtyId";
                specialtyId.Value = _id;
                cmd.Parameters.Add(specialtyId);

                MySqlParameter stylistId = new MySqlParameter();
                stylistId.ParameterName = "@stylistId";
                stylistId.Value = newStylist.GetId();
                cmd.Parameters.Add(stylistId);

                cmd.ExecuteNonQuery();
                conn.Close();
                if (conn != null)
                {
                  conn.Dispose();
                }
            }
    }
}
