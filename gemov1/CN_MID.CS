using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
namespace gemov1
{
    class CN_MID
    {
        public MySqlConnection con = new MySqlConnection();
        //POUR CHAQUE TABLE
        public DataRow NewLigne;
        public MySqlCommandBuilder CmdBuild;
        public MySqlDataAdapter dtadapter = new MySqlDataAdapter();
        public DataSet dtset = new DataSet();

        public DataRow CNewLigne;
        public MySqlCommandBuilder CCmdBuild;
        public MySqlDataAdapter Cdtadapter = new MySqlDataAdapter();
        public DataSet Cdtset = new DataSet();

        public DataRow UNewLigne;
        public MySqlCommandBuilder UCmdBuild;
        public MySqlDataAdapter Udtadapter = new MySqlDataAdapter();
        public DataSet Udtset = new DataSet();

        public DataRow GNewLigne;
        public MySqlCommandBuilder GCmdBuild;
        public MySqlDataAdapter Gdtadapter = new MySqlDataAdapter();
        public DataSet Gdtset = new DataSet();

    

        public DataRow PNewLigne;
        public MySqlCommandBuilder PCmdBuild;
        public MySqlDataAdapter Pdtadapter = new MySqlDataAdapter();
        public DataSet Pdtset = new DataSet();

        public MySqlCommandBuilder PrevCmdBuild;
        public MySqlDataAdapter Prevadapter = new MySqlDataAdapter();
        public DataSet PrevdataSet = new DataSet();
        public DataRow PREVNewLigne;

        public MySqlCommandBuilder PaiCmdBuild;
        public MySqlDataAdapter Paiadapter = new MySqlDataAdapter();
        public DataSet PaidataSet = new DataSet();
        public DataRow PaiNewLigne;


        public MySqlDataAdapter FilteredPaiadapter = new MySqlDataAdapter();
        public DataSet FilteredPaidataSet = new DataSet();
        public MySqlCommandBuilder FilteredPaiCmdBuild;

        //Méthode Connecter
        public void CONNECTER()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                //con.ConnectionString = @"Data Source=DESKTOP-PK1SDO9;Initial Catalog=Nom BD;Integrated Security=True";
                //Exemple 
                con.ConnectionString = @"Server=localhost;port=3306;Database=gemodb;UID=root;Password= ";
                con.Open();
            }
        }
        //Méthode Déconnecter
        public void DECONNECTER()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }



        public int GenerateNextId()
        {
            int nextId = 1;

            Prevadapter.Fill(PrevdataSet);

            if (PrevdataSet.Tables[0].Rows.Count > 0)
            {
                nextId = (int)PrevdataSet.Tables[0].Rows[PrevdataSet.Tables[0].Rows.Count - 1]["IDPrev"] + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }


        public long GenerateNextIdCreator()
        {
            long nextId = 1;

            Cdtadapter.Fill(Cdtset);

            if (Cdtset.Tables[0].Rows.Count > 0)
            {
                nextId = (long)Cdtset.Tables[0].Rows[Cdtset.Tables[0].Rows.Count - 1]["id"] + 1;
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }

        public ulong GenerateNextIdUser()
        {
            ulong nextId = 1;

            Udtadapter.Fill(Cdtset);

            if (Udtset.Tables[0].Rows.Count > 0)
            {
                nextId = (ulong)Udtset.Tables[0].Rows[Udtset.Tables[0].Rows.Count - 1]["id"] + 1; 
            }
            else
            {
                nextId = 1;
            }

            return nextId;
        }

        public long GenerateNextIdGames()
        {
            long nextIdg = 1;

            Gdtadapter.Fill(Cdtset);

            if (Gdtset.Tables[0].Rows.Count > 0)
            {
                nextIdg = (long)Gdtset.Tables[0].Rows[Gdtset.Tables[0].Rows.Count - 1]["idg"] + 1;
            }
            else
            {
                nextIdg = 1;
            }

            return nextIdg;
        }

        public long GenerateNextIdPack()
        {
            long nextIdp = 1;

            Pdtadapter.Fill(Cdtset);

            if (Pdtset.Tables[0].Rows.Count > 0)
            {
                nextIdp = (long)Pdtset.Tables[0].Rows[Pdtset.Tables[0].Rows.Count - 1]["id_pack"] + 1;
            }
            else
            {
                nextIdp = 1;
            }

            return nextIdp;
        }

        public long GenerateNextIdPai()
        {
            long nextIdCP = 1;

            Paiadapter.Fill(Cdtset);

            if (PaidataSet.Tables[0].Rows.Count > 0)
            {
                nextIdCP = (long)PaidataSet.Tables[0].Rows[PaidataSet.Tables[0].Rows.Count - 1]["ID_CP"] + 1;
            }
            else
            {
                nextIdCP = 1;
            }

            return nextIdCP;
        }



  

        public bool IsValidEmail(string email)
        {
            try
            {
                // Attempt to create a MailAddress instance
                MailAddress mailAddress = new MailAddress(email);
                return true; // If successful, the email address is valid
            }
            catch
            {
                return false; // If an exception is thrown, the email address is invalid
            }
        }


        public bool IsUsernameExists(string username)
        {
            
            string query = "SELECT COUNT(*) FROM users WHERE username = @Username";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@Username", username);

           
            int count = Convert.ToInt32(command.ExecuteScalar());
            

            return count > 0;
        }

        public bool IsPackNomExists(string PackNom)
        {
            string query = "SELECT COUNT(*) FROM packs WHERE Nom_Pack = @PackNom";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@PackNom", PackNom);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }



        public bool IsStudioNomExists(string StudioNom)
        {
            string query = "SELECT COUNT(*) FROM creators WHERE Studio_Nom = @StudioNom";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@StudioNom", StudioNom);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }


        public bool IsCreatorEmailExists(string CreatorEmail)
        {
            string query = "SELECT COUNT(*) FROM creators WHERE email = @CreatorEmail";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@CreatorEmail", CreatorEmail);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }

        public bool IsTitleGameExists(string TitleGame)
        {
            string query = "SELECT COUNT(*) FROM games WHERE Title = @TitleGame";
            MySqlCommand command = new MySqlCommand(query, con);
            command.Parameters.AddWithValue("@TitleGame", TitleGame);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }



        public bool IsValidUrl(string url)
        {

            return url.StartsWith("http://") || url.StartsWith("https://");
        }


    }
}

