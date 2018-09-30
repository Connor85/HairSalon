using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        private string _name;
        private string _hireDate;
        private int _id;

        public Stylist(string name, string hireDate, int stylistId = 0)
        {
            _name = name;
            _hireDate = hireDate;
            _id = stylistId;

        }
        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool areNamesEqual = (this.GetName() == newStylist.GetName());
                bool areHireDateEqual = (this.GetHireDate() == newStylist.GetHireDate());
                return (areNamesEqual && areHireDateEqual);
            }
        }

        public override int GetHashCode()
        {
            string allHash = this.GetName() + this.GetHireDate();
            return allHash.GetHashCode();
        }

        public string GetName()
        {
            return _name;
        }

        public string GetHireDate()
        {
            return _hireDate;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (name, hire_date) VALUES (@name, @hireDate);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);

            MySqlParameter hireDate = new MySqlParameter();
            hireDate.ParameterName = "@hireDate";
            hireDate.Value = this._hireDate;
            cmd.Parameters.Add(hireDate);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int StylistId = rdr.GetInt32(0);
                string StylistName = rdr.GetString(1);
                string hireDate = rdr.GetString(2);
                Stylist newStylist = new Stylist(StylistName, hireDate, StylistId);
                allStylists.Add(newStylist);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public List<Client> GetClients()
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @id;";

            MySqlParameter clientId = new MySqlParameter();
            clientId.ParameterName = "@id";
            clientId.Value = this.GetId();
            cmd.Parameters.Add(clientId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int id = 0;
            string name = "";
            int stylist_id = 0;
            while(rdr.Read())
            {
                id = rdr.GetInt32(0);
                name = rdr.GetString(1);
                stylist_id = rdr.GetInt32(2);
                Client newClient = new Client(name, id, stylist_id);
                allClients.Add(newClient);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static List<Client> GetAllClients()
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int ClientId = rdr.GetInt32(0);
                string ClientName = rdr.GetString(1);
                Client newClient = new Client(ClientName, ClientId);
                allClients.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete () {
            MySqlConnection conn = DB.Connection ();
            conn.Open ();
            var cmd = conn.CreateCommand () as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @stylistId;";

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylistId";
            stylistId.Value = _id;
            cmd.Parameters.Add(stylistId);

            cmd.ExecuteNonQuery ();
            if (conn != null) {
                conn.Close ();
            }
        }

        public void Edit(string stylistName)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE stylists SET name = @newName WHERE id = @searchId;";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = this._id;
          cmd.Parameters.Add(searchId);

          MySqlParameter newName = new MySqlParameter();
            newName.ParameterName = "@newName";
            newName.Value = stylistName;
            cmd.Parameters.Add(newName);

            cmd.ExecuteNonQuery();
            _name = stylistName;

          conn.Close();
          if (conn != null)
          {
            conn.Dispose();
          }
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@stylistId);";

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylistId";
            stylistId.Value = id;
            cmd.Parameters.Add(stylistId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int StylistId = 0;
            string StylistName = "";
            string HireDate = "";
            while(rdr.Read())
            {
                StylistId = rdr.GetInt32(0);
                StylistName = rdr.GetString(1);
                HireDate = rdr.GetString(2);
            }
            Stylist newStylist = new Stylist(StylistName, HireDate, StylistId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newStylist;
        }

        public void AddClient(Client newClient)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@stylistId, @clientId);";

            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterName = "@stylistId";
            stylist_id.Value = newClient.GetId();
            cmd.Parameters.Add(stylist_id);

            MySqlParameter client_id = new MySqlParameter();
            client_id.ParameterName = "@clientId";
            client_id.Value = _id;
            cmd.Parameters.Add(client_id);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public List<Stylist> GetStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT clients.* FROM stylists
            JOIN stylists_clients ON (clients.id = stylists_clients.client_id)
            JOIN clients ON (stylists_clients.clientt_id = clients.id)
            WHERE clients.id = @clientId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@clientId";
            stylistIdParameter.Value = _id;
            cmd.Parameters.Add(stylistIdParameter);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> stylists = new List<Stylist>{};

            while(rdr.Read())
            {
                int recipeId = rdr.GetInt32(0);
                string recipeName = rdr.GetString(1);
                string hireDate = rdr.GetString(2);

                Stylist newStylist = new Stylist(recipeName, hireDate, recipeId);
                stylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylists;
        }

        public void AddSpecialty(Specialty newSpecialty)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties_stylists (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

            MySqlParameter SpecialtyId = new MySqlParameter();
            SpecialtyId.ParameterName = "@specialtyId";
            SpecialtyId.Value = newSpecialty.GetId();
            cmd.Parameters.Add(SpecialtyId);

            MySqlParameter StylistId = new MySqlParameter();
            StylistId.ParameterName = "@stylistId";
            StylistId.Value = _id;
            cmd.Parameters.Add(StylistId);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Specialty> GetSpecialtys()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT specialties.* FROM stylists
      JOIN specialties_stylists ON (stylists.id = specialties_stylists.stylist_id)
      JOIN specialties ON (specialties_stylists.specialty_id = specialties.id)
      WHERE stylists.id = @StylistId;";

            MySqlParameter stylistIdParameter = new MySqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = _id;
            cmd.Parameters.Add(stylistIdParameter);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Specialty> specialties = new List<Specialty>{};

            while(rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyName = rdr.GetString(1);

                Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
                specialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return specialties;
        }
    }
}
