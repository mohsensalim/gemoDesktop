using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using MySql.Data.MySqlClient;
using BCrypt.Net;


namespace gemov1
{
    public partial class Form1 : Form
    {
        CN_MID BD = new CN_MID();

        string IDCP,CREMAIL; 
       
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            paneljeuxSideMenu.Visible = false;
            
            panelcreateurSideMenu.Visible = false;
        }
        private void hideSideMenu()
        {
            if (paneljeuxSideMenu.Visible == true)
                paneljeuxSideMenu.Visible = false;
            if (panelcreateurSideMenu.Visible == true)
                panelcreateurSideMenu.Visible = false;
        }
        private void showSideMenu(Panel sideMenu)
        {
            if (sideMenu.Visible == false)
            {
                hideSideMenu();
                sideMenu.Visible = true;
            }
            else
                sideMenu.Visible = false;
        }

        private void BTNemp_Click(object sender, EventArgs e)
        {
            EMPgroupbox.Visible = true;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            PaiementgroupBox.Visible = false;
        }

        private void BTNclt_Click(object sender, EventArgs e)
        {
            
            EMPgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            PaiementgroupBox.Visible = false;
            CLTgroupbox.Visible = true;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            
        }

        private void BTNjeux_Click(object sender, EventArgs e)
        {
            showSideMenu(paneljeuxSideMenu);
        } 

        private void BTNpacks_Click(object sender, EventArgs e)
        {
            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            PACKSgroupbox.Visible = true;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            PaiementgroupBox.Visible = false;
        } 

        

        private void guna2Button14_Click(object sender, EventArgs e)
        {
           
            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = true;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            PaiementgroupBox.Visible = false;
            hideSideMenu();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = true;
            PACKSgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            PaiementgroupBox.Visible = false;
            hideSideMenu();
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        
        private void BTNcreateur_Click(object sender, EventArgs e)
        {
            showSideMenu(panelcreateurSideMenu);
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = true;
            PaiementgroupBox.Visible = false;
            PACKSgroupbox.Visible = false;
            hideSideMenu();
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            CVgroupbox.Visible = true;
            PaiementgroupBox.Visible = false;
            CMgroupbox.Visible = false;
            hideSideMenu();
        }

        private void EMPpanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void JVpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSideMenu.Visible = false;
            PANELCONTROLER.Visible = false;
            

           
            
            pictureBox2.Image = pictureBox2.BackgroundImage;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;


            pictureBox3.Image = pictureBox3.BackgroundImage;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

            PPICTURE.Image = PPICTURE.BackgroundImage;
            PPICTURE.BackgroundImageLayout = ImageLayout.Stretch;


            GPM.Image = GPM.BackgroundImage;
            GPM.BackgroundImageLayout = ImageLayout.Stretch;


            GS1.Image = GS1.BackgroundImage;
            GS1.BackgroundImageLayout = ImageLayout.Stretch;


            GS2.Image = GS2.BackgroundImage;
            GS2.BackgroundImageLayout = ImageLayout.Stretch;


            GS3.Image = GS3.BackgroundImage;
            GS3.BackgroundImageLayout = ImageLayout.Stretch;


            BD.CONNECTER();
            BD.dtadapter = new MySqlDataAdapter("select * from employe", BD.con);
            BD.dtset = new DataSet();
            BD.dtadapter.Fill(BD.dtset, "employe"); 
            G1.DataSource = BD.dtset.Tables["employe"];

        

            BD.Paiadapter = new MySqlDataAdapter("select * from creatorpaiments", BD.con);
            BD.Paiadapter.Fill(BD.PaidataSet, "creatorpaiments");

            BD.FilteredPaiadapter = new MySqlDataAdapter("SELECT * FROM creatorpaiments WHERE Amount IS NOT NULL AND Etat_Paiment = 'inactif'"  , BD.con);
            BD.FilteredPaiadapter.Fill(BD.FilteredPaidataSet, "creatorpaiments");
            GCP.DataSource = BD.FilteredPaidataSet.Tables["creatorpaiments"];



            BD.Cdtadapter = new MySqlDataAdapter("select * from creators", BD.con);
            BD.Cdtset = new DataSet();
            BD.Cdtadapter.Fill(BD.Cdtset, "creators");
            GC.DataSource = BD.Cdtset.Tables["creators"];
            GCV.DataSource = BD.Cdtset.Tables["creators"];



            BD.Gdtadapter = new MySqlDataAdapter("select * from games", BD.con);
            BD.Gdtset = new DataSet();
            BD.Gdtadapter.Fill(BD.Gdtset, "games");
            GG.DataSource = BD.Gdtset.Tables["games"];
            GV1.DataSource = BD.Gdtset.Tables["games"];
            





            BD.Udtadapter = new MySqlDataAdapter("select * from users", BD.con);
            BD.Udtset = new DataSet();
            BD.Udtadapter.Fill(BD.Udtset, "users");
            G3.DataSource = BD.Udtset.Tables["users"];




            BD.Pdtadapter = new MySqlDataAdapter("select * from packs", BD.con);
            BD.Pdtset = new DataSet();
            BD.Pdtadapter.Fill(BD.Pdtset, "packs");
            G5.DataSource = BD.Pdtset.Tables["packs"];


            BD.Prevadapter = new MySqlDataAdapter("select * from Previlages", BD.con);
            BD.PrevdataSet = new DataSet();
            BD.Prevadapter.Fill(BD.PrevdataSet,"Previlages");



            

           
      
        }

        private void EMPgroupbox_Enter(object sender, EventArgs e)
        {
            
        }

        private void guna2Button44_Click(object sender, EventArgs e)
        {
            HideDash();
            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            PaiementgroupBox.Visible = true;
            //System.Console.WriteLine(PaiementgroupBox.Visible);
        }

        private void PaiementgroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void videogroupbox_Enter(object sender, EventArgs e)
        {
            ////string video = "C:\\Users\\TAHA\\Desktop\\project_gemo\\gemov1\\gemov1\\Resources\\Color.mp4";
            //axWindowsMediaPlayer1.URL = ".\\Resources\\Color.mp4";
            //axWindowsMediaPlayer1.Ctlcontrols.play();

        }

        

        private void Videogroupbox_Enter_1(object sender, EventArgs e)
        {

        }

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string genre = "";
            string ETAT = "";


            int sw = 0, s;
            for (s = 0; s <= this.G1.RowCount - 2; s++)
            {
                if (CCIN.Text == this.G1.Rows[s].Cells[0].Value.ToString())
                {
                    sw = 1;
                }
            }

      // Check Email/////////////////////////////////////////////////////////////
            if(!BD.IsValidEmail(TMAIL.Text))
            {
                MessageBox.Show("Invalid Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

     // Check Phone Number/////////////////////////////////////////////////////////////

            if (!Information.IsNumeric(TTEL.Text))
            {
                MessageBox.Show("Invalid Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            // Check if the age is under 18/////////////////////////////////////////////////////////////

            DateTime currentDate = DateTime.Now;

            int years = currentDate.Year - guna2DateTimePicker2.Value.Year;
            int months = currentDate.Month - guna2DateTimePicker2.Value.Month;
            int days = currentDate.Day - guna2DateTimePicker2.Value.Day;


            if (years < 18)
            {
                MessageBox.Show("Age is not valid (under 18 years old).");
                return;
            }
            else if (years == 18)
            {

                if (months < 0 || (months == 0 && days < 0))
                {
                    MessageBox.Show("Age is not valid (under 18 years old).");
                    return;
                }

            }



    //CHECK ETAT
            if (!RADIOEACTIF.Checked && !RADIOEINACTIF.Checked)
            {
                MessageBox.Show("Svp Slectioner Un Etat.");
                return;
            }


     //CHECK genre
            if (!RADIOEF.Checked && !RADIOEM.Checked)
            {
                MessageBox.Show("Svp Slectioner Un Genre.");
                return;
            }

            if (sw == 0)
            {
                if (CCIN.Text != "" && TNOM.Text != "" && TPRENOM.Text != "" && TMAIL.Text != "" && TTEL.Text != "" && TVILLE.Text != "")
                {

                    //CHECK EMPLOYE PREVILAGES**********************************************************
                    BD.PREVNewLigne = BD.PrevdataSet.Tables["Previlages"].NewRow();
                    BD.PREVNewLigne[0] = BD.GenerateNextId();
                    BD.PREVNewLigne[24] = CCIN.Text;


     //PREV EMP ***************************************************************************


                    //PREV AJ
                    if (EAJ.Checked)
                    {
                        BD.PREVNewLigne[1] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[1] = "inactif";
                    }

                    //PREV RECH
                    if (ERECH.Checked)
                    {
                        BD.PREVNewLigne[2] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[2] = "inactif";
                    }

                    //PREV MOD
                    if (EMOD.Checked)
                    {
                        BD.PREVNewLigne[3] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[3] = "inactif";
                    }

                    //PREV SUPP
                    if (ESUPP.Checked)
                    {
                        BD.PREVNewLigne[4] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[4] = "inactif";
                    }

    //PREV GAME ***************************************************************************



                    //PREV AJ
                    if (JAJ.Checked)
                    {
                        BD.PREVNewLigne[5] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[5] = "inactif";
                    }


                    //PREV RECH
                    if (JRECH.Checked)
                    {
                        BD.PREVNewLigne[6] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[6] = "inactif";
                    }


                    //PREV MOD
                    if (JMOD.Checked)
                    {
                        BD.PREVNewLigne[7] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[7] = "inactif";
                    }

                    //PREV SUPP
                    if (JSUPP.Checked)
                    {
                        BD.PREVNewLigne[8] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[8] = "inactif";
                    }

                    //PREV VAL
                    if (JVAL.Checked)
                    {
                        BD.PREVNewLigne[9] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[9] = "inactif";
                    }


    //PREV CREATOR ***************************************************************************


                    //PREV AJ
                    if (CAJ.Checked)
                    {
                        BD.PREVNewLigne[10] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[10] = "inactif";
                    }


                    //PREV RECH
                    if (CRECH.Checked)
                    {
                        BD.PREVNewLigne[11] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[11] = "inactif";
                    }


                    //PREV MOD
                    if (CMOD.Checked)
                    {
                        BD.PREVNewLigne[12] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[12] = "inactif";
                    }

                    //PREV SUPP
                    if (CSUPP.Checked)
                    {
                        BD.PREVNewLigne[13] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[13] = "inactif";
                    }

                    //PREV VAL
                    if (CVAL.Checked)
                    {
                        BD.PREVNewLigne[14] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[14] = "inactif";
                    }


       //PREV USER ***************************************************************************


                    //PREV AJ
                    if (UAJ.Checked)
                    {
                        BD.PREVNewLigne[15] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[15] = "inactif";
                    }


                    //PREV RECH
                    if (URECH.Checked)
                    {
                        BD.PREVNewLigne[16] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[16] = "inactif";
                    }


                    //PREV MOD
                    if (UMOD.Checked)
                    {
                        BD.PREVNewLigne[17] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[17] = "inactif";
                    }

                    //PREV SUPP
                    if (USUPP.Checked)
                    {
                        BD.PREVNewLigne[18] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[18] = "inactif";
                    }

     //PREV PACK ***************************************************************************


                    //PREV AJ
                    if (PAJ.Checked)
                    {
                        BD.PREVNewLigne[19] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[19] = "inactif";
                    }


                    //PREV RECH
                    if (PRECH.Checked)
                    {
                        BD.PREVNewLigne[20] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[20] = "inactif";
                    }


                    //PREV MOD
                    if (PMOD.Checked)
                    {
                        BD.PREVNewLigne[21] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[21] = "inactif";
                    }

                    //PREV SUPP
                    if (PSUPP.Checked)
                    {
                        BD.PREVNewLigne[22] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[22] = "inactif";
                    }



      //PREV PAIMENT ***************************************************************************


                    //PREV AJ
                    if (PAIMENT.Checked)
                    {
                        BD.PREVNewLigne[23] = "actif";
                    }
                    else
                    {
                        BD.PREVNewLigne[23] = "inactif";
                    }

                    //ECIN 
                    BD.PREVNewLigne[24] = CCIN.Text;


      //ETAT****************************************************

                    if(RADIOEACTIF.Checked)
                    {
                        ETAT = "actif";
                    }
                    else
                    {
                        ETAT = "inactif";
                    }
      //GENRE *******************************************************
                   

                    if (RADIOEF.Checked)
                    {
                        genre = "Female";
                    }
                    else
                    {
                        genre = "Man";
                    }


                    BD.NewLigne = BD.dtset.Tables["employe"].NewRow();
                    BD.NewLigne[0] = CCIN.Text;
                    BD.NewLigne[1] = TNOM.Text;
                    BD.NewLigne[2] = TPRENOM.Text;
                    BD.NewLigne[3] = imageToByteArray(this.pictureBox2.Image);
                    BD.NewLigne[4] = TMAIL.Text;
                    BD.NewLigne[6] = TTEL.Text;
                    BD.NewLigne[9] = TVILLE.Text;
                    BD.NewLigne[10] = ETAT;
                    BD.NewLigne[7] = genre;
                    BD.NewLigne[8] = guna2DateTimePicker2.Value;

                    Random rnd;
                    int number;
                    rnd = new Random();
                    number = rnd.Next(999, 10000);
                    BD.NewLigne[5] = number.ToString();

                    BD.dtset.Tables["employe"].Rows.Add(BD.NewLigne);
                    BD.CmdBuild = new MySqlCommandBuilder(BD.dtadapter);
                    BD.dtadapter.InsertCommand = BD.CmdBuild.GetInsertCommand();
                    BD.dtadapter.Update(BD.dtset, "employe");

                    //ADD THE PREVILAGES TO PREVILAGES TABLE **********************************************************
                    BD.PrevdataSet.Tables["Previlages"].Rows.Add(BD.PREVNewLigne);
                    BD.PrevCmdBuild = new MySqlCommandBuilder(BD.Prevadapter);
                    BD.Prevadapter.InsertCommand = BD.PrevCmdBuild.GetInsertCommand();
                    BD.Prevadapter.Update(BD.PrevdataSet, "Previlages");








                    /////////////////////////// email ///////////////////////////////////
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("tahahandi3@gmail.com", "mmqb tlzv qyha irzq");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(TMAIL.Text);
                    msg.From = new MailAddress("tahahandi3@gmail.com");
                    msg.Subject="Gemo";
                    msg.Body = "Votre Mote Passe Est : " + number.ToString();
                    client.Send(msg);
                    MessageBox.Show("Mail Envoyé");

                    ///////////////////////////////////end email//////////////////////////////////////

                    MessageBox.Show("Ajout Avec Succes");
                    // BD.DECONNECTER();
                }
                else
                {
                    MessageBox.Show("Vous Devez Remplir Tous Les Champs SVP");
                }
            }
            else
            {
                MessageBox.Show("Référence Existe Déjà");
            }
        }

    
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

       
        //private Size GetImageSize(string imagePath)
        //{
        //    using (Image image = Image.FromFile(imagePath))
        //    {
        //        return new Size(image.Width, image.Height);
        //    }
        //}

        private void BTN_RECHERCHE_Click(object sender, EventArgs e)
        {
            int sw = 0;
            if (CCIN.Text != "")
            {
                for (int s = 0; s <= this.G1.RowCount - 2; s++)
                {
                    if (CCIN.Text == this.G1.Rows[s].Cells[0].Value.ToString())
                    {
                        CCIN.Text = this.G1.Rows[s].Cells[0].Value.ToString();
                        TNOM.Text = this.G1.Rows[s].Cells[1].Value.ToString();
                        TPRENOM.Text = this.G1.Rows[s].Cells[2].Value.ToString();
                        MemoryStream ms = new MemoryStream((byte[])this.G1.Rows[s].Cells[3].Value);
                        pictureBox2.Image = Image.FromStream(ms);
                        TMAIL.Text = this.G1.Rows[s].Cells[4].Value.ToString();
                        TTEL.Text = this.G1.Rows[s].Cells[6].Value.ToString();
                        guna2DateTimePicker2.Value = Convert.ToDateTime(this.G1.Rows[s].Cells[8].Value.ToString());
                        TVILLE.Text = this.G1.Rows[s].Cells[9].Value.ToString();

                        if (this.G1.Rows[s].Cells[8].Value.ToString()=="Man")
                        {
                            RADIOEM.Checked = true;
                        }
                        else
                        {
                            RADIOEF.Checked = true;
                        }


                        if (this.G1.Rows[s].Cells[10].Value.ToString() == "actif")
                        {
                            RADIOEACTIF.Checked = true;
                        }
                        else
                        {
                            RADIOEINACTIF.Checked = true;
                        }



                        //CHECK PREV EMP INTERFACE *************************************************************************
                        for (int i = 0; i <= BD.PrevdataSet.Tables["Previlages"].Rows.Count - 1; i++)
                        {
                            if (CCIN.Text == BD.PrevdataSet.Tables["Previlages"].Rows[i][24].ToString())
                            { 

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][1].ToString() == "actif")
                            {
                                EAJ.Checked = true;
                            }
                            else
                            {
                                EAJ.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][2].ToString() == "actif")
                            {
                                ERECH.Checked = true;
                            }
                            else
                            {
                                ERECH.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][3].ToString() == "actif")
                            {
                                EMOD.Checked = true;
                            }
                            else
                            {
                                EMOD.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][4].ToString() == "actif")
                            {
                                ESUPP.Checked = true;
                            }
                            else
                            {
                                ESUPP.Checked = false;
                            }

                            //CHECK PREV JEUX INTERFACE ***********************************************************************                   

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][5].ToString() == "actif")
                            {
                                JAJ.Checked = true;
                            }
                            else
                            {
                                JAJ.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][6].ToString() == "actif")
                            {
                                JRECH.Checked = true;
                            }
                            else
                            {
                                JRECH.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][7].ToString() == "actif")
                            {
                                JMOD.Checked = true;
                            }
                            else
                            {
                                JMOD.Checked = false;
                            }
                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][8].ToString() == "actif")
                            {
                                JSUPP.Checked = true;
                            }
                            else
                            {
                                JSUPP.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][9].ToString() == "actif")
                            {
                                JVAL.Checked = true;
                            }
                            else
                            {
                                JVAL.Checked = false;
                            }

                            //CHECK PREV CREATOR INTERFACE ***********************************************************************    
                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][10].ToString() == "actif")
                            {
                                CAJ.Checked = true;
                            }
                            else
                            {
                                CAJ.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][11].ToString() == "actif")
                            {
                                CRECH.Checked = true;
                            }
                            else
                            {
                                CRECH.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][12].ToString() == "actif")
                            {
                                CMOD.Checked = true;
                            }
                            else
                            {
                                CMOD.Checked = false;
                            }
                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][13].ToString() == "actif")
                            {
                                CSUPP.Checked = true;
                            }
                            else
                            {
                                CSUPP.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][14].ToString() == "actif")
                            {
                                CVAL.Checked = true;
                            }
                            else
                            {
                                CVAL.Checked = false;
                            }



                            //CHECK PREV USER INTERFACE ***********************************************************************    
                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][15].ToString() == "actif")
                            {
                                UAJ.Checked = true;
                            }
                            else
                            {
                                UAJ.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][16].ToString() == "actif")
                            {
                                URECH.Checked = true;
                            }
                            else
                            {
                                URECH.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][17].ToString() == "actif")
                            {
                                UMOD.Checked = true;
                            }
                            else
                            {
                                UMOD.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][18].ToString() == "actif")
                            {
                                USUPP.Checked = true;
                            }
                            else
                            {
                                USUPP.Checked = false;
                            }

                            //CHECK PREV PACK INTERFACE ***********************************************************************    
                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][19].ToString() == "actif")
                            {
                                PAJ.Checked = true;
                            }
                            else
                            {
                                PAJ.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][20].ToString() == "actif")
                            {
                                PRECH.Checked = true;
                            }
                            else
                            {
                                PRECH.Checked = false;
                            }

                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][21].ToString() == "actif")
                            {
                                PMOD.Checked = true;
                            }
                            else
                            {
                                PMOD.Checked = false;
                            }


                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][22].ToString() == "actif")
                            {
                                PSUPP.Checked = true;
                            }
                            else
                            {
                                PSUPP.Checked = false;
                            }


                            //CHECK PREV PAIMAINT INTERFACE
                            if (BD.PrevdataSet.Tables["Previlages"].Rows[i][23].ToString() == "actif")
                            {


                                PAIMENT.Checked = true;
                            }
                            else
                            {
                                PAIMENT.Checked = false;
                            }
                            }

                        }

                        
                        sw = 1;
                    }


                }

                if (sw == 0)
                {
                    MessageBox.Show("ID Introuvable");
                }
            }
            else
            {
                string a;
                a = Interaction.InputBox("entrer l'id a rechercher");
                for (int s = 0; s <= this.G1.RowCount - 2; s++)
                {
                    if (a == this.G1.Rows[s].Cells[0].Value.ToString())
                    {
                        CCIN.Text = this.G1.Rows[s].Cells[0].Value.ToString();
                        TNOM.Text = this.G1.Rows[s].Cells[1].Value.ToString();
                        TPRENOM.Text = this.G1.Rows[s].Cells[2].Value.ToString();
                        MemoryStream ms = new MemoryStream((byte[])this.G1.Rows[s].Cells[3].Value);
                        pictureBox2.Image = Image.FromStream(ms);
                        sw = 1;
                    }
                }
                if (sw == 0)
                {
                    MessageBox.Show("ID Introuvable");
                }


            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
            {
                this.pictureBox2.ImageLocation = this.openFileDialog1.FileName;
                string filePath = this.openFileDialog1.FileName;
            }
              

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (CCIN.Text == "")
            {
                MessageBox.Show("Svp Saisir CIN");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.G1.RowCount - 2; i++)
            {
                if (CCIN.Text == this.G1.Rows[i].Cells[0].Value.ToString())
                {
                    SW = true;
                    BD.dtset.Tables["employe"].Rows[i].Delete();
                    BD.CmdBuild = new MySqlCommandBuilder(BD.dtadapter);
                    BD.dtadapter.DeleteCommand = BD.CmdBuild.GetDeleteCommand();
                    BD.dtadapter.Update(BD.dtset, "employe");
                    MessageBox.Show("Employe Supprimé Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("CIN NON VALIDE");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string genre = "";
            string ETAT = "";

            // Check Email/////////////////////////////////////////////////////////////
            if (!BD.IsValidEmail(TMAIL.Text))
            {
                MessageBox.Show("Invalid Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check Phone Number/////////////////////////////////////////////////////////////

            if (!Information.IsNumeric(TTEL.Text))
            {
                MessageBox.Show("Invalid Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            // Check if the age is under 18/////////////////////////////////////////////////////////////

            DateTime currentDate = DateTime.Now;

            int years = currentDate.Year - guna2DateTimePicker2.Value.Year;
            int months = currentDate.Month - guna2DateTimePicker2.Value.Month;
            int days = currentDate.Day - guna2DateTimePicker2.Value.Day;


            if (years < 18)
            {
                MessageBox.Show("Age is not valid (under 18 years old).");
                return;
            }
            else if (years == 18)
            {

                if (months < 0 || (months == 0 && days < 0))
                {
                    MessageBox.Show("Age is not valid (under 18 years old).");
                    return;
                }

            }



            //CHECK ETAT
            if (!RADIOEACTIF.Checked && !RADIOEINACTIF.Checked)
            {
                MessageBox.Show("Svp Slectioner Un Etat.");
                return;
            }


            //CHECK genre
            if (!RADIOEF.Checked && !RADIOEM.Checked)
            {
                MessageBox.Show("Svp Slectioner Un Genre.");
                return;
            }

            if (CCIN.Text == "" || TNOM.Text == "" || TPRENOM.Text == "")
            {
                MessageBox.Show("Merci de Remplir Tous Les Champs");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.G1.RowCount - 2; i++)
            {
                if (CCIN.Text == this.G1.Rows[i].Cells[0].Value.ToString())
                {

                    //ETAT****************************************************

                    if (RADIOEACTIF.Checked)
                    {
                        ETAT = "actif";
                    }
                    else
                    {
                        ETAT = "inactif";
                    }
                    //GENRE *******************************************************


                    if (RADIOEF.Checked)
                    {
                        genre = "Female";
                    }
                    else
                    {
                        genre = "Man";
                    }

                    //CHECK EMPLOYE PREVILAGES**********************************************************
                    BD.PREVNewLigne = BD.PrevdataSet.Tables["Previlages"].NewRow();
                    BD.PREVNewLigne[0] = BD.GenerateNextId();
                    BD.PREVNewLigne[24] = CCIN.Text;


                    //PREV EMP ***************************************************************************

                    for (int s = 0; s <= BD.PrevdataSet.Tables["Previlages"].Rows.Count - 1; s++)
                    {
                        if (CCIN.Text == BD.PrevdataSet.Tables["Previlages"].Rows[s][24].ToString())
                        { 
                        //PREV AJ
                        if (EAJ.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][1] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][1] = "inactif";
                        }

                        //PREV RECH
                        if (ERECH.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][2] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][2] = "inactif";
                        }

                        //PREV MOD
                        if (EMOD.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][3] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][3] = "inactif";
                        }

                        //PREV SUPP
                        if (ESUPP.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][4] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][4] = "inactif";
                        }

                        //PREV GAME ***************************************************************************

                        //PREV AJ
                        if (JAJ.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][5] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][5] = "inactif";
                        }


                        //PREV RECH
                        if (JRECH.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][6] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][6] = "inactif";
                        }


                        //PREV MOD
                        if (JMOD.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][7] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][7] = "inactif";
                        }

                        //PREV SUPP
                        if (JSUPP.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][8] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][8] = "inactif";
                        }

                        //PREV VAL
                        if (JVAL.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][9] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][9] = "inactif";
                        }


                        //PREV CREATOR ***************************************************************************


                        //PREV AJ
                        if (CAJ.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][10] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][10] = "inactif";
                        }


                        //PREV RECH
                        if (CRECH.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][11] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][11] = "inactif";
                        }


                        //PREV MOD
                        if (CMOD.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][12] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][12] = "inactif";
                        }

                        //PREV SUPP
                        if (CSUPP.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][13] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][13] = "inactif";
                        }

                        //PREV VAL
                        if (CVAL.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][14] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][14] = "inactif";
                        }


                        //PREV USER ***************************************************************************


                        //PREV AJ
                        if (UAJ.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][15] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][15] = "inactif";
                        }


                        //PREV RECH
                        if (URECH.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][16] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][16] = "inactif";
                        }


                        //PREV MOD
                        if (UMOD.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][17] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][17] = "inactif";
                        }

                        //PREV SUPP
                        if (USUPP.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][18] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][18] = "inactif";
                        }

                        //PREV PACK ***************************************************************************


                        //PREV AJ
                        if (PAJ.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][19] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][19] = "inactif";
                        }


                        //PREV RECH
                        if (PRECH.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][20] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][20] = "inactif";
                        }


                        //PREV MOD
                        if (PMOD.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][21] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][21] = "inactif";
                        }

                        //PREV SUPP
                        if (PSUPP.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][22] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][22] = "inactif";
                        }



                        //PREV PAIMENT ***************************************************************************


                        //PREV AJ
                        if (PAIMENT.Checked)
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][23] = "actif";
                        }
                        else
                        {
                            BD.PrevdataSet.Tables["Previlages"].Rows[s][23] = "inactif";
                        }

                    }
                    }

                    //ADD THE PREVILAGES TO PREVILAGES TABLE **********************************************************
                    BD.PrevCmdBuild = new MySqlCommandBuilder(BD.Prevadapter);
                    BD.Prevadapter.UpdateCommand = BD.PrevCmdBuild.GetUpdateCommand();
                    BD.Prevadapter.Update(BD.PrevdataSet, "Previlages");

                    //effectuer la modification
                    SW = true;
                    BD.dtset.Tables["employe"].Rows[i][1] = TNOM.Text;
                    BD.dtset.Tables["employe"].Rows[i][2] = TPRENOM.Text;
                    BD.dtset.Tables["employe"].Rows[i][3] = imageToByteArray(this.pictureBox2.Image);
                    BD.dtset.Tables["employe"].Rows[i][4] = TMAIL.Text;
                    BD.dtset.Tables["employe"].Rows[i][6] = TTEL.Text;
                    BD.dtset.Tables["employe"].Rows[i][7] = genre;
                    BD.dtset.Tables["employe"].Rows[i][8] = guna2DateTimePicker2.Value;
                    BD.dtset.Tables["employe"].Rows[i][9] = TVILLE.Text ;
                    BD.dtset.Tables["employe"].Rows[i][10] = ETAT;


                    BD.CmdBuild = new MySqlCommandBuilder(BD.dtadapter);
                    BD.dtadapter.UpdateCommand = BD.CmdBuild.GetUpdateCommand();
                    BD.dtadapter.Update(BD.dtset, "employe");
                    MessageBox.Show("Employé Modifié Avec Succès");
                    break;
                }

            }
            if (SW == false)
            {
                MessageBox.Show("ID NON VALIDE");
            }

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            CCIN.ResetText();
            TNOM.ResetText();
            TPRENOM.ResetText();
            TVILLE.ResetText();
            TTEL.ResetText();
            TMAIL.ResetText();
            JAJ.Checked = false;
            JMOD.Checked = false;
            JRECH.Checked = false;
            JSUPP.Checked = false;
            JVAL.Checked = false;
            PAIMENT.Checked = false;
            CAJ.Checked = false;
            CMOD.Checked = false;
            CRECH.Checked = false;
            CSUPP.Checked = false;
            CVAL.Checked = false;
            PAJ.Checked = false;
            PMOD.Checked = false;
            PRECH.Checked = false;
            PSUPP.Checked = false;
            EAJ.Checked = false;
            EMOD.Checked = false;
            ERECH.Checked = false;
            ESUPP.Checked = false;
            UAJ.Checked = false;
            UMOD.Checked = false;
            URECH.Checked = false;
            USUPP.Checked = false;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            EMPgroupbox.Visible = false;
        }

        private void guna2Button37_Click(object sender, EventArgs e)
        {
            string genre = "";
            string ETAT = "";
            int sw = 0, s;
            for (s = 0; s <= this.GC.RowCount - 2; s++)
            {
                if (CCINC.Text.ToUpper() == this.GC.Rows[s].Cells[5].Value.ToString())
                {
                    sw = 1;
                }
            }



            if (sw == 0)
            {
                if (CCINC.Text != "" && TNOMC.Text != "" && TPRENOMC.Text != "" && TCMAIL.Text !="" && TTELEC.Text!="" && TSN.Text !=""
                    || TPMODE.Text!="" || TPIDANT.Text!="")
                {


                    // Check EMAIL////////////////////////////////////////////////////////////
                    if (!BD.IsValidEmail(TCMAIL.Text))
                    {
                        MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check EMAIL UNIQUE////////////////////////////////////////////////////////////
                    if (BD.IsCreatorEmailExists(TCMAIL.Text))
                    {
                        MessageBox.Show(" email address already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }




                    //CHECK STUDIO NAME IF UNIQUE ////////////////////////////////////////////

                    if(BD.IsStudioNomExists(TSN.Text))
                    {
                        MessageBox.Show("Studio Name Already Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // VALIDATE THE PAIMENT//////////////////////////////////////////////////
                    if (TPMODE.Text.ToUpper()=="PAYPAL")
                    {
                        if (!BD.IsValidEmail(TPIDANT.Text))
                        {
                            MessageBox.Show("Invalid Idantifiant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    


                    if (Information.IsNumeric(TPMODE.Text))
                    {
                        MessageBox.Show("Invalid Paiment Mode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Check GENRE/////////////////////////////////////////////////////////////
                    if (RADIOCF.Checked)
                    {
                        genre = "Female";
                    }
                    else
                    {
                        genre = "Man";
                    }

                    if (RADIOCF.Checked == false && RADIOCM.Checked == false)
                    {
                        MessageBox.Show("NO Genre CHECKED");
                        return;
                    }

                    //  ETAT/////////////////////////////////////////////////////////////
                    ETAT = "inactif";


                    if (!Information.IsNumeric(TTELEC.Text))
                    {
                        MessageBox.Show("Invalid Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    // Check if the age is under 12/////////////////////////////////////////////////////////////

                    DateTime currentDate = DateTime.Now;

                    int years = currentDate.Year - TDN.Value.Year;
                    int months = currentDate.Month - TDN.Value.Month;
                    int days = currentDate.Day - TDN.Value.Day;


                    if (years < 18)
                    {
                        MessageBox.Show("Age is not valid (under 18 years old).");
                        return;
                    }
                    else if (years == 18)
                    {

                        if (months < 0 || (months == 0 && days < 0))
                        {
                            MessageBox.Show("Age is not valid (under 18 years old).");
                            return;
                        }

                    }
                   


                    BD.CNewLigne = BD.Cdtset.Tables["creators"].NewRow();
                    BD.CNewLigne[0] = BD.GenerateNextIdCreator();
                    BD.CNewLigne[5] = CCINC.Text.ToUpper() ;
                    BD.CNewLigne[1] = TNOMC.Text;
                    BD.CNewLigne[2] = TPRENOMC.Text;
                    BD.CNewLigne[7] = imageToByteArray(this.pictureBox3.Image);
                    BD.CNewLigne[3] = TCMAIL.Text;
                    BD.CNewLigne[6] = TSN.Text.ToUpper() ;
                    BD.CNewLigne[8] = CNATIONC.Text;
                    BD.CNewLigne[9] = TTELEC.Text;
                    BD.CNewLigne[10] = TCITYC.Text;
                    BD.CNewLigne[11] = genre;
                    BD.CNewLigne[12] =TDN.Value;
                    BD.CNewLigne[13] = ETAT;
                    
                    Random rnd;
                    int number;
                    rnd = new Random();
                    number = rnd.Next(999, 10000);
                    BD.CNewLigne[14] = HashPassword(number.ToString());

                    BD.Cdtset.Tables["creators"].Rows.Add(BD.CNewLigne);
                    BD.CCmdBuild = new MySqlCommandBuilder(BD.Cdtadapter);
                    BD.Cdtadapter.InsertCommand = BD.CCmdBuild.GetInsertCommand();
                    BD.Cdtadapter.Update(BD.Cdtset, "creators");


            //ADD PAIMENT INFO
                    BD.PaiNewLigne = BD.PaidataSet.Tables["creatorpaiments"].NewRow();
                    BD.PaiNewLigne[0] = BD.GenerateNextIdPai();
                    BD.PaiNewLigne[1] = TPMODE.Text;
                    BD.PaiNewLigne[2] = TPIDANT.Text;
                    BD.PaiNewLigne[4] = DateTime.Now ;
                    BD.PaiNewLigne[5] = "inactif";
                    BD.PaiNewLigne[6] = BD.CNewLigne[0];
                    

                    BD.PaidataSet.Tables["creatorpaiments"].Rows.Add(BD.PaiNewLigne);
                    BD.PaiCmdBuild = new MySqlCommandBuilder(BD.Paiadapter);
                    BD.Paiadapter.InsertCommand = BD.PaiCmdBuild.GetInsertCommand();
                    BD.Paiadapter.Update(BD.PaidataSet, "creatorpaiments");

                    /////////////////////////// email ///////////////////////////////////
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("tahahandi3@gmail.com", "mmqb tlzv qyha irzq");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(TCMAIL.Text);
                    msg.From = new MailAddress("tahahandi3@gmail.com");
                    msg.Subject = "Gemo";
                    msg.Body = "Votre Mote Passe Est : " + number.ToString();
                    client.Send(msg);
                    MessageBox.Show("Mail Envoyé");

                    ///////////////////////////////////end email//////////////////////////////////////


                    MessageBox.Show("Ajout Avec Succes");
                    // BD.DECONNECTER();
                }
                else
                {
                    MessageBox.Show("Vous Devez Remplir Tous Les Champs SVP");
                }
            }
            else
            {
                MessageBox.Show("Référence Existe Déjà");
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {
            string genre = "";
            string ETAT = "";

            if (CCINC.Text == "" || TNOMC.Text == "" || TPRENOMC.Text == "" || TCMAIL.Text =="" || TTELEC.Text=="" || TSN.Text ==""
            || TPMODE.Text=="" || TPIDANT.Text=="")
            {
                MessageBox.Show("Svp Remplir Tous Les Champs");
                return;
            }

            bool SW = false;

            // Check GENRE/////////////////////////////////////////////////////////////
            if (RADIOCF.Checked)
            {
                genre = "Female";
            }
            else
            {
                genre = "Man";
            }

            if (RADIOCF.Checked == false && RADIOCM.Checked == false)
            {
                MessageBox.Show("NO Genre CHECKED");
                return;
            }

         


            if (!Information.IsNumeric(TTELEC.Text))
            {
                MessageBox.Show("Invalid Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            // Check if the age is under 12/////////////////////////////////////////////////////////////

            DateTime currentDate = DateTime.Now;

            int years = currentDate.Year - TDN.Value.Year;
            int months = currentDate.Month - TDN.Value.Month;
            int days = currentDate.Day - TDN.Value.Day;


            if (years < 18)
            {
                MessageBox.Show("Age is not valid (under 18 years old).");
                return;
            }
            else if (years == 18)
            {

                if (months < 0 || (months == 0 && days < 0))
                {
                    MessageBox.Show("Age is not valid (under 18 years old).");
                    return;
                }

            }



            for (int i = 0; i <= this.GC.RowCount - 2; i++)
            {
                if (CCINC.Text.ToUpper() == this.GC.Rows[i].Cells[5].Value.ToString())
                {


                    //effectuer la modification
                    SW = true;
                    BD.Cdtset.Tables["creators"].Rows[i][1] = TNOMC.Text;
                    BD.Cdtset.Tables["creators"].Rows[i][2] = TPRENOMC.Text;
                    BD.Cdtset.Tables["creators"].Rows[i][7] = imageToByteArray(this.pictureBox3.Image);
                    BD.Cdtset.Tables["creators"].Rows[i][8] = CNATIONC.Text;
                    BD.Cdtset.Tables["creators"].Rows[i][9] = TTELEC.Text;
                    BD.Cdtset.Tables["creators"].Rows[i][10] = TCITYC.Text;
                    BD.Cdtset.Tables["creators"].Rows[i][11] = genre;
                    BD.Cdtset.Tables["creators"].Rows[i][12] = TDN.Value;
                    BD.Cdtset.Tables["creators"].Rows[i][13] = ETAT;

                    
                    
                    
                    BD.CCmdBuild = new MySqlCommandBuilder(BD.Cdtadapter);
                    BD.Cdtadapter.UpdateCommand = BD.CCmdBuild.GetUpdateCommand();
                    BD.Cdtadapter.Update(BD.Cdtset, "creators");
                    MessageBox.Show("Createur Modifié Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("ID NON VALIDE");
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
                this.pictureBox3.ImageLocation = this.openFileDialog1.FileName;
            string filePath = this.openFileDialog1.FileName;
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            CCINC.ResetText();
            TNOMC.ResetText();
            TPRENOMC.ResetText();
            TCMAIL.ResetText();
          
            TTELEC.ResetText();
            TSN.ResetText();
        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            int sw = 0;
            if (CCINC.Text != "")
            {
                for (int s = 0; s <= this.GC.RowCount - 2; s++)
                {
                    if (CCINC.Text.ToUpper() == this.GC.Rows[s].Cells[5].Value.ToString())
                    {
                        CCINC.Text = this.GC.Rows[s].Cells[5].Value.ToString();
                        TNOMC.Text = this.GC.Rows[s].Cells[1].Value.ToString();
                        TPRENOMC.Text = this.GC.Rows[s].Cells[2].Value.ToString();
                        TCMAIL.Text = this.GC.Rows[s].Cells[3].Value.ToString();
                        TSN.Text = this.GC.Rows[s].Cells[6].Value.ToString();
                        CNATIONC.Text = this.GC.Rows[s].Cells[8].Value.ToString();
                        TTELEC.Text = this.GC.Rows[s].Cells[9].Value.ToString();
                        TCITYC.Text = this.GC.Rows[s].Cells[10].Value.ToString();
                        TDN.Value =Convert.ToDateTime( this.GC.Rows[s].Cells[12].Value.ToString());
                        MemoryStream ms = new MemoryStream((byte[])this.GC.Rows[s].Cells[7].Value);
                        pictureBox3.Image = Image.FromStream(ms);


                        if (this.GC.Rows[s].Cells[11].Value.ToString()=="Man")
                        {

                            RADIOCM.Checked = true;
                            
                        }
                        else
                        {
                            RADIOCF.Checked = true;
                        }


                        sw = 1;
                    }


                }
                if (sw == 0)
                {
                    MessageBox.Show("ID Introuvable");
                }
            }
            else
            {
                MessageBox.Show("Vous Devez Remplir ID");
            }

        }

        private void guna2Button32_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button35_Click(object sender, EventArgs e)
        {
            if (CCINC.Text == "")
            {
                MessageBox.Show("Svp Saisir ID");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.GC.RowCount - 2; i++)
            {
                if (CCINC.Text == this.GC.Rows[i].Cells[5].Value.ToString())
                {
                    SW = true;
                    BD.Cdtset.Tables["creators"].Rows[i].Delete();
                    BD.CCmdBuild = new MySqlCommandBuilder(BD.Cdtadapter);
                    BD.Cdtadapter.DeleteCommand = BD.CCmdBuild.GetDeleteCommand();
                    BD.Cdtadapter.Update(BD.Cdtset, "creators");
                    MessageBox.Show("Createur Supprimé Avec Succès");
                    pictureBox3.Image = pictureBox3.BackgroundImage;

                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("ID NON VALIDE");
            }
        }

        private void guna2DataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            string genre = "";
            string ETAT = "";
            int sw = 0, s;
            for (s = 0; s <= this.G3.RowCount - 2; s++)
            {
                if (TUSERN.Text.ToUpper() == this.G3.Rows[s].Cells[0].Value.ToString().ToUpper())
                {
                    sw = 1;
                }
            }
            if (sw == 0)
            {
                if (TUSERN.Text != "" && TNOMU.Text != "" && TPRENOMU.Text != "" && CNATIONU.Text != "" && TTELEU.Text !="")
                {

                    // Check EMAIL////////////////////////////////////////////////////////////
                    if(!BD.IsValidEmail(TUMAIL.Text))
                    {
                        MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // Check GENRE/////////////////////////////////////////////////////////////
                    if(RADIOF.Checked)
                    {
                        genre = "Female";
                    }
                    else
                    {
                        genre = "Man";
                    }

                    if (RADIOF.Checked == false && RADIOM.Checked == false)
                    {
                        MessageBox.Show("NO Genre CHECKED");
                        return;
                    }

                    // Check ETAT/////////////////////////////////////////////////////////////
                    if (RADIOACTIF.Checked)
                    {
                        ETAT = "actif";
                    }
                    else
                    {
                        ETAT = "inactif";
                    }

                    if (RADIOACTIF.Checked == false && RADIOINACTIF.Checked == false)
                    {
                        MessageBox.Show("NO ETAT CHECKED");
                        return;
                    }


                   if ( !Information.IsNumeric(TTELEU.Text) )
                             {
                                 MessageBox.Show("Invalid Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                               
                            }
                   // Check if the age is under 12/////////////////////////////////////////////////////////////

                   DateTime currentDate = DateTime.Now;

                   int years = currentDate.Year - guna2DateTimePicker3.Value.Year;
                   int months = currentDate.Month - guna2DateTimePicker3.Value.Month;
                   int days = currentDate.Day - guna2DateTimePicker3.Value.Day;

            
                   if (years < 12)
                   {
                       MessageBox.Show("Age is not valid (under 12 years old).");
                       return;
                   }
                   else if (years == 12)
                   {
                      
                       if (months < 0 || (months == 0 && days < 0))
                       {
                           MessageBox.Show("Age is not valid (under 12 years old).");
                           return;
                       }
                      
                   }

                   if (BD.IsUsernameExists(TUSERN.Text))
                   {
                       MessageBox.Show("Username already exists in the database.");
                       return;
                   }
                  


                    BD.UNewLigne = BD.Udtset.Tables["users"].NewRow();
                    BD.UNewLigne[0] = BD.GenerateNextIdUser();
                    //BD.UNewLigne[5] = CCINC.Text;
                    BD.UNewLigne[1] = TNOMU.Text;
                    BD.UNewLigne[2] = TPRENOMU.Text;
                    //BD.UNewLigne[4] = imageToByteArray(this.pictureBox3.Image);
                    Random rnd;
                    int number;
                    rnd = new Random();
                    number = rnd.Next(999, 10000);
                    BD.UNewLigne[13] = HashPassword(number.ToString());
                    BD.UNewLigne[3] = TUMAIL.Text;
                    BD.UNewLigne[5] = TUSERN.Text.ToUpper();
                    BD.UNewLigne[6] = CNATIONU.Text;
                    BD.UNewLigne[7] = genre;
                    BD.UNewLigne[8] = guna2DateTimePicker3.Value;
                    BD.UNewLigne[9] = TTELEU.Text;
                    BD.UNewLigne[10] = "inactif";
                    BD.UNewLigne[12] = ETAT;
                    BD.UNewLigne[17] = 0;

                 

                    BD.Udtset.Tables["users"].Rows.Add(BD.UNewLigne);
                    BD.UCmdBuild = new MySqlCommandBuilder(BD.Udtadapter);
                    BD.Udtadapter.InsertCommand = BD.UCmdBuild.GetInsertCommand();
                    BD.Udtadapter.Update(BD.Udtset, "users");











                    /////////////////////////// email ///////////////////////////////////
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("tahahandi3@gmail.com", "mmqb tlzv qyha irzq");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(TUMAIL.Text);
                    msg.From = new MailAddress("tahahandi3@gmail.com");
                    msg.Subject = "Gemo";
                    msg.Body = "Votre Mote Passe Est : " + number.ToString();
                    client.Send(msg);
                    MessageBox.Show("Mail Envoyé");

                    ///////////////////////////////////end email//////////////////////////////////////
                

                    




                    MessageBox.Show("Ajout Avec Succes");
                    // BD.DECONNECTER();
                }
                else
                {
                    MessageBox.Show("Vous Devez Remplir Tous Les Champs SVP");
                }
            }
            else
            {
                MessageBox.Show("Référence Existe Déjà");
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            int sw = 0;
            if (TUSERN.Text != "")
            {
                for (int s = 0; s <= this.G3.RowCount - 2; s++)
                {
                    if (TUSERN.Text.ToUpper() == this.G3.Rows[s].Cells[5].Value.ToString().ToUpper())
                    {
                        TUSERN.Text = this.G3.Rows[s].Cells[5].Value.ToString();
                        TNOMU.Text = this.G3.Rows[s].Cells[1].Value.ToString();
                        TPRENOMU.Text = this.G3.Rows[s].Cells[2].Value.ToString();
                        guna2DateTimePicker3.Value =Convert.ToDateTime( this.G3.Rows[s].Cells[8].Value.ToString());
                        TUMAIL.Text = this.G3.Rows[s].Cells[3].Value.ToString();
                        TTELEU.Text=this.G3.Rows[s].Cells[9].Value.ToString();
                        CNATIONU.Text = this.G3.Rows[s].Cells[6].Value.ToString();

                        if (this.G3.Rows[s].Cells[7].Value.ToString()=="Man")
                        {
                            RADIOM.Checked = true;
                        }
                        else
                        {
                            RADIOF.Checked = true;

                        }


                        if (this.G3.Rows[s].Cells[12].Value.ToString() == "actif")
                        {
                            RADIOACTIF.Checked = true;
                        }
                        else
                        {
                            RADIOINACTIF.Checked = true;

                        }
                  
                        //MemoryStream ms = new MemoryStream((byte[])this.G3.Rows[s].Cells[3].Value);
                        //pictureBox1.Image = Image.FromStream(ms);
                        sw = 1;
                    }


                }
                if (sw == 0)
                {
                    MessageBox.Show("USERNAME Introuvable");
                }
            }
            else
            {
                MessageBox.Show("Vous Devez Remplir USERNAME");
            }

        }

        private void JMgroupbox_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            string genre="";
            string ETAT = "";

            if (TUSERN.Text == "" || TNOMU.Text == "" || TPRENOMU.Text == "" || CNATIONU.Text == "" && TTELEU.Text == "") 
            {
                MessageBox.Show("SVP Remplir Tous Les Champs");
                return;
            }

            // Check EMAIL////////////////////////////////////////////////////////////
            if (!BD.IsValidEmail(TUMAIL.Text))
            {
                MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Check GENRE/////////////////////////////////////////////////////////////
            if (RADIOF.Checked)
            {
                genre = "Female";
            }
            else
            {
                genre = "Man";
            }

            if (RADIOF.Checked == false && RADIOM.Checked == false)
            {
                MessageBox.Show("NO Genre CHECKED");
                return;
            }

            // Check ETAT/////////////////////////////////////////////////////////////
            if (RADIOACTIF.Checked)
            {
                ETAT = "actif";
            }
            else
            {
                ETAT = "inactif";
            }

            if (RADIOACTIF.Checked == false && RADIOINACTIF.Checked == false)
            {
                MessageBox.Show("NO ETAT CHECKED");
                return;
            }

            // Check Phone Number/////////////////////////////////////////////////////////////

            if (!Information.IsNumeric(TTELEU.Text))
            {
                MessageBox.Show("Invalid Phone Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            // Check if the age is under 12/////////////////////////////////////////////////////////////

            DateTime currentDate = DateTime.Now;

            int years = currentDate.Year - guna2DateTimePicker3.Value.Year;
            int months = currentDate.Month - guna2DateTimePicker3.Value.Month;
            int days = currentDate.Day - guna2DateTimePicker3.Value.Day;


            if (years < 12)
            {
                MessageBox.Show("Age is not valid (under 12 years old).");
                return;
            }
            else if (years == 12)
            {

                if (months < 0 || (months == 0 && days < 0))
                {
                    MessageBox.Show("Age is not valid (under 12 years old).");
                    return;
                }

            }



            
            bool SW = false;

            for (int i = 0; i <= this.G3.RowCount - 2; i++)
            {
                if (TUSERN.Text.ToUpper() == this.G3.Rows[i].Cells[5].Value.ToString().ToUpper())
                {
                    //effectuer la modification
                    SW = true;
                    BD.Udtset.Tables["users"].Rows[i][1] = TNOMU.Text;
                    BD.Udtset.Tables["users"].Rows[i][2] = TPRENOMU.Text;
                    //BD.Udtset.Tables["users"].Rows[i][3] = imageToByteArray(this.pictureBox1.Image);
                  
                    BD.Udtset.Tables["users"].Rows[i][3] =TUMAIL.Text;
                    BD.Udtset.Tables["users"].Rows[i][6] = CNATIONU.Text;
                    BD.Udtset.Tables["users"].Rows[i][7] = genre;
                    BD.Udtset.Tables["users"].Rows[i][8] = guna2DateTimePicker3.Value;
                    BD.Udtset.Tables["users"].Rows[i][9] = TTELEU.Text;
                    BD.Udtset.Tables["users"].Rows[i][12] = ETAT;

                    BD.UCmdBuild = new MySqlCommandBuilder(BD.Udtadapter);
                    BD.Udtadapter.UpdateCommand = BD.UCmdBuild.GetUpdateCommand();
                    BD.Udtadapter.Update(BD.Udtset, "users");
                    MessageBox.Show("User Modifié Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("ID NON VALIDE");
            }

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (TUSERN.Text == "")
            {
                MessageBox.Show("SVP Saisir Un Username");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.G3.RowCount - 2; i++)
            {
                if (TUSERN.Text.ToUpper() == this.G3.Rows[i].Cells[5].Value.ToString().ToUpper())
                {
                    SW = true;
                    BD.Udtset.Tables["users"].Rows[i].Delete();
                    BD.UCmdBuild = new MySqlCommandBuilder(BD.Udtadapter);
                    BD.Udtadapter.DeleteCommand = BD.UCmdBuild.GetDeleteCommand();
                    BD.Udtadapter.Update(BD.Udtset, "users");
                    MessageBox.Show("user Supprimé Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("Username NON VALIDE");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            TNOMU.ResetText();
            TPRENOMU.ResetText();
            TUMAIL.ResetText();
            TUSERN.ResetText();
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            int sw = 0, s;

            if (!BD.IsValidUrl(TP.Text))
            {
                MessageBox.Show("URL is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(GPM.Image==GPM.BackgroundImage)
            {
                MessageBox.Show("Mising Picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GS1.Image == GS1.BackgroundImage)
            {
                MessageBox.Show("Mising Picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (GS2.Image == GS2.BackgroundImage)
            {
                MessageBox.Show("Mising Picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (GS3.Image == GS3.BackgroundImage)
            {
                MessageBox.Show("Mising Picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (BD.IsTitleGameExists(TT.Text))
            {
                MessageBox.Show("Title Already Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (s = 0; s <= this.GG.RowCount - 2; s++)
            {
                if (TT.Text == this.GG.Rows[s].Cells[1].Value.ToString())
                {
                    sw = 1;
                }
            }
            if (sw == 0)
            {
                if (TT.Text != "" && TPX.Text != "" && TD.Text != "" && TG.Text != "" && TP.Text != "")
                {

                    

                    BD.GNewLigne = BD.Gdtset.Tables["games"].NewRow();
                    BD.GNewLigne[0] = BD.GenerateNextIdGames();
                    //BD.UNewLigne[5] = CCINC.Text;
                    BD.GNewLigne[1] = TT.Text.ToUpper();
                    BD.GNewLigne[4] = TPX.Text;
                    BD.GNewLigne[6] = imageToByteArray(this.GPM.Image);
                    BD.GNewLigne[7] = imageToByteArray(this.GS1.Image);
                    BD.GNewLigne[8] = imageToByteArray(this.GS2.Image);
                    BD.GNewLigne[9] = imageToByteArray(this.GS3.Image);
                    BD.GNewLigne[3] = TG.Text;
                    BD.GNewLigne[2] = TD.Text;
                    BD.GNewLigne[10] = TP.Text;
                    BD.GNewLigne[11] = "inactif";
                    //BD.GNewLigne[12] = HNA KHAS YATHAT CIN DYL EMPLOYE;
                   

                    BD.Gdtset.Tables["games"].Rows.Add(BD.GNewLigne);
                    BD.GCmdBuild = new MySqlCommandBuilder(BD.Gdtadapter);
                    BD.Gdtadapter.InsertCommand = BD.GCmdBuild.GetInsertCommand();
                    BD.Gdtadapter.Update(BD.Gdtset, "games");

                  









                    //                /////////////////////////// Email ///////////////////////////////////
                    //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    //client.EnableSsl = true;
                    //client.Timeout = 10000;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //client.UseDefaultCredentials = false;
                    //client.Credentials = new NetworkCredential("Dir Email Dyalk", "Dir DAK code li genereter");
                    //MailMessage msg = new MailMessage();
                    //msg.To.Add("dir email li bghiti tsift lih");
                    //msg.From = new MailAddress("Dir Email Dyalk");
                    //msg.Body = number.ToString();
                    //client.Send(msg);
                    //                ///////////////////////////////////End Email//////////////////////////////////////
                    //MessageBox.Show("Mail Envoyé");

                    MessageBox.Show("Ajout Avec Succes");
                    // BD.DECONNECTER();
                }
                else
                {
                    MessageBox.Show("Vous Devez Remplir Tous Les Champs SVP");
                }
            }
            else
            {
                MessageBox.Show("Référence Existe Déjà");
            }
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            TT.ResetText();
            TPX.ResetText();
            TP.ResetText();
            TD.ResetText();
            TG.ResetText();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            int sw = 0;
            if (TT.Text != "")
            {
                for (int s = 0; s <= this.GG.RowCount - 2; s++)
                {
                    if (TT.Text == this.GG.Rows[s].Cells[1].Value.ToString())
                    {
                        TT.Text = this.GG.Rows[s].Cells[1].Value.ToString();
                        TPX.Text = this.GG.Rows[s].Cells[4].Value.ToString();
                        TP.Text = this.GG.Rows[s].Cells[10].Value.ToString();
                        TD.Text = this.GG.Rows[s].Cells[2].Value.ToString();
                        TG.Text = this.GG.Rows[s].Cells[3].Value.ToString();
                        MemoryStream ms = new MemoryStream((byte[])this.GG.Rows[s].Cells[6].Value);
                        GPM.Image = Image.FromStream(ms);


                        MemoryStream ms1 = new MemoryStream((byte[])this.GG.Rows[s].Cells[7].Value);
                        GS1.Image = Image.FromStream(ms1);

                        MemoryStream ms2 = new MemoryStream((byte[])this.GG.Rows[s].Cells[8].Value);
                        GS2.Image = Image.FromStream(ms2);

                        MemoryStream ms3 = new MemoryStream((byte[])this.GG.Rows[s].Cells[9].Value);
                        GS3.Image = Image.FromStream(ms3);

                        

                        sw = 1;
                    }


                }
                if (sw == 0)
                {
                    MessageBox.Show("Title Introuvable");
                }
            }
            else
            {
                MessageBox.Show("Vous Devez Remplir Title");
            }

        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            if (!BD.IsValidUrl(TP.Text))
            {
                MessageBox.Show("URL is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            





            if (TT.Text == "" || TPX.Text == "" || TD.Text == "" || TG.Text == "" || TP.Text == "")
            {
                MessageBox.Show("Svp Remplir Tous Les Champs");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.GG.RowCount - 2; i++)
            {
                if (TT.Text == this.GG.Rows[i].Cells[1].Value.ToString())
                {
                    //effectuer la modification
                    SW = true;
                    
                    BD.Gdtset.Tables["games"].Rows[i][2] = TD.Text;
                    BD.Gdtset.Tables["games"].Rows[i][3] = TG.Text;
                    BD.Gdtset.Tables["games"].Rows[i][4] = TPX.Text;
                    BD.Gdtset.Tables["games"].Rows[i][10] = TP.Text;

                    BD.Gdtset.Tables["games"].Rows[i][6] = imageToByteArray(this.GPM.Image);
                    BD.Gdtset.Tables["games"].Rows[i][7] = imageToByteArray(this.GS1.Image);
                    BD.Gdtset.Tables["games"].Rows[i][8] = imageToByteArray(this.GS2.Image);
                    BD.Gdtset.Tables["games"].Rows[i][9] = imageToByteArray(this.GS3.Image);

                    BD.GCmdBuild = new MySqlCommandBuilder(BD.Gdtadapter);
                    BD.Gdtadapter.UpdateCommand = BD.GCmdBuild.GetUpdateCommand();
                    BD.Gdtadapter.Update(BD.Gdtset, "games");
                    MessageBox.Show("Jeux Modifié Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("Jeux NON VALIDE");
            }

        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            if (TT.Text == "")
            {
                MessageBox.Show("Merci de Saisir TITLE");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.GG.RowCount - 2; i++)
            {
                if (TT.Text == this.GG.Rows[i].Cells[1].Value.ToString())
                {
                    SW = true;
                    BD.Gdtset.Tables["games"].Rows[i].Delete();
                    BD.GCmdBuild = new MySqlCommandBuilder(BD.Gdtadapter);
                    BD.Gdtadapter.DeleteCommand = BD.GCmdBuild.GetDeleteCommand();
                    BD.Gdtadapter.Update(BD.Gdtset, "games");
                    MessageBox.Show("Game Supprimé Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("GAME NON VALIDE");
            }
        }
        
        private void guna2Button43_Click(object sender, EventArgs e)
        {

            string Etat = "";
            int sw = 0, s;
            for (s = 0; s <= this.G5.RowCount - 2; s++)
            {
                
                if (TNP.Text == this.G5.Rows[s].Cells[1].Value.ToString())
                {
                    sw = 1;
                }
            }



            if (sw == 0)
            {
                if (TNP.Text != "" && TPP.Text != "" && TPC.Text != "")
                {

                    if( PPICTURE.Image == PPICTURE.BackgroundImage)
                    {
                        MessageBox.Show("Svp Saisir Un Image");
                        return;
                    }

                    if (RADIOPACKACTIF.Checked)
                    {
                        Etat = "actif";
                    }
                    else
                    {
                        Etat = "inactif";
                    }

                    if (!RADIOPACKACTIF.Checked && !RADIOPACKINACTIF.Checked)
                    {
                        MessageBox.Show("Svp Selectioner Un Etat");
                        return;
                    }

                    if (BD.IsPackNomExists(TNP.Text))
                    {
                        MessageBox.Show("Pack Name already exists in the database.");
                        return;
                    }

                    BD.PNewLigne = BD.Pdtset.Tables["packs"].NewRow();
                    BD.PNewLigne[0] = BD.GenerateNextIdPack();
                    //BD.UNewLigne[5] = CCINC.Text;
                    BD.PNewLigne[1] = TNP.Text.ToUpper();
                    BD.PNewLigne[2] = Etat;
                    BD.PNewLigne[3] = TPP.Text;
                    BD.PNewLigne[4] = TPC.Text;
                    BD.PNewLigne[7] = imageToByteArray(this.PPICTURE.Image);
                    



                    BD.Pdtset.Tables["packs"].Rows.Add(BD.PNewLigne);
                    BD.PCmdBuild = new MySqlCommandBuilder(BD.Pdtadapter);
                    BD.Pdtadapter.InsertCommand = BD.PCmdBuild.GetInsertCommand();
                    BD.Pdtadapter.Update(BD.Pdtset, "packs");


                    MessageBox.Show("Ajout Avec Succes");
                    // BD.DECONNECTER();
                }
                else
                {
                    MessageBox.Show("Vous Devez Remplir Tous Les Champs SVP");
                }
            }
            else
            {
                MessageBox.Show("Référence Existe Déjà");
            }
        }

        private void guna2Button40_Click(object sender, EventArgs e)
        {
            int sw = 0;
            if (TNP.Text != "")
            {
                for (int s = 0; s <= this.G5.RowCount - 2; s++)
                {
                    if (TNP.Text.ToUpper() == this.G5.Rows[s].Cells[1].Value.ToString())
                    {
                        TNP.Text = this.G5.Rows[s].Cells[1].Value.ToString();
                        TPP.Text = this.G5.Rows[s].Cells[3].Value.ToString();
                        TPC.Text = this.G5  .Rows[s].Cells[4].Value.ToString();
                        MemoryStream ms = new MemoryStream((byte[])this.G5.Rows[s].Cells[7].Value);
                        PPICTURE.Image = Image.FromStream(ms);

                        if (this.G5.Rows[s].Cells[2].Value.ToString()=="actif")
                        {
                            RADIOPACKACTIF.Checked = true;
                        }
                        else
                        {
                            RADIOPACKINACTIF.Checked = true;
                        }


                        sw = 1;
                    }


                }
                if (sw == 0)
                {
                    MessageBox.Show("PACK Introuvable");
                }
            }
            else
            {
                MessageBox.Show("Vous Devez Remplir ID");
            }

        }

        private void guna2Button42_Click(object sender, EventArgs e)
        {
            string Etat = "";

            if (TNP.Text == "" || TPP.Text == "" || TPC.Text == "")
            {
                MessageBox.Show("Merci de Remplir Tous Les Champs");
                return;
            }

            if (RADIOPACKACTIF.Checked)
            {
                Etat = "actif";
            }
            else
            {
                Etat = "inactif";
            }

            if (!RADIOPACKACTIF.Checked && !RADIOPACKINACTIF.Checked)
            {
                MessageBox.Show("Svp Selectioner Un Etat");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.G5.RowCount - 2; i++)
            {
                if (TNP.Text.ToUpper() == this.G5.Rows[i].Cells[1].Value.ToString())
                {
                    //effectuer la modification
                    SW = true;
                    
                    BD.Pdtset.Tables["packs"].Rows[i][2] = Etat;
                    BD.Pdtset.Tables["packs"].Rows[i][3] = TPP.Text;
                    BD.Pdtset.Tables["packs"].Rows[i][4] = TPC.Text;
                    BD.Pdtset.Tables["packs"].Rows[i][7] = imageToByteArray(this.PPICTURE.Image);
                
                    BD.PCmdBuild = new MySqlCommandBuilder(BD.Pdtadapter);
                    BD.Pdtadapter.UpdateCommand = BD.PCmdBuild.GetUpdateCommand();
                    BD.Pdtadapter.Update(BD.Pdtset, "packs");
                    MessageBox.Show("PACK Modifié Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("ID NON VALIDE");
            }

        }

        private void guna2Button41_Click(object sender, EventArgs e)
        {
            if (TNP.Text == "")
            {
                MessageBox.Show("SVP Saisire Le Nom De Pack");
                return;
            }

            bool SW = false;

            for (int i = 0; i <= this.G5.RowCount - 2; i++)
            {
                if (TNP.Text == this.G5.Rows[i].Cells[1].Value.ToString())
                {
                    SW = true;
                    BD.Pdtset.Tables["packs"].Rows[i].Delete();
                    BD.PCmdBuild = new MySqlCommandBuilder(BD.Pdtadapter);
                    BD.Pdtadapter.DeleteCommand = BD.PCmdBuild.GetDeleteCommand();
                    BD.Pdtadapter.Update(BD.Pdtset, "packs");
                    MessageBox.Show("Pack Supprimé Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("ID NON VALIDE");
            }

        }

        private void PPICTURE_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
                this.PPICTURE.ImageLocation = this.openFileDialog1.FileName;
            string filePath = this.openFileDialog1.FileName;
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
                this.GPM.ImageLocation = this.openFileDialog1.FileName;
            string filePath = this.openFileDialog1.FileName;
        }

        private void GS1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
                this.GS1.ImageLocation = this.openFileDialog1.FileName;
            string filePath = this.openFileDialog1.FileName;
        }

        private void GS2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
                this.GS2.ImageLocation = this.openFileDialog1.FileName;
            string filePath = this.openFileDialog1.FileName;
        }

        private void GS3_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.ShowDialog();
            if (this.openFileDialog1.FileName != "")
                this.GS3.ImageLocation = this.openFileDialog1.FileName;
            string filePath = this.openFileDialog1.FileName;
        }

        private void guna2GroupBox7_Click(object sender, EventArgs e)
        {

        }

        private void BTNGVRECH_Click(object sender, EventArgs e)
        {
            
            int sw = 0;
            if (TVT.Text != "")
            {
                for (int s = 0; s <= this.GG.RowCount - 2; s++)
                {
                    if (TVT.Text == this.GG.Rows[s].Cells[1].Value.ToString())
                    {
                        TVT.Text = this.GV1.Rows[s].Cells[1].Value.ToString();
                        TVPX.Text = this.GV1.Rows[s].Cells[4].Value.ToString();
                        TVP.Text = this.GV1.Rows[s].Cells[10].Value.ToString();
                        TVD.Text = this.GV1.Rows[s].Cells[2].Value.ToString();
                        TVG.Text = this.GV1.Rows[s].Cells[3].Value.ToString();
                       

                        if(this.GV1.Rows[s].Cells[11].Value.ToString()=="actif")
                        {
                            RADIOGVACTIF.Checked = true;
                        }
                        else
                        {
                            RADIOGVINACTIF.Checked = true;
                        }

                        MemoryStream ms = new MemoryStream((byte[])this.GV1.Rows[s].Cells[6].Value);
                        GVPM.Image = Image.FromStream(ms);


                        MemoryStream ms1 = new MemoryStream((byte[])this.GV1.Rows[s].Cells[7].Value);
                        GVS1.Image = Image.FromStream(ms1);

                        MemoryStream ms2 = new MemoryStream((byte[])this.GV1.Rows[s].Cells[8].Value);
                        GVS2.Image = Image.FromStream(ms2);

                        MemoryStream ms3 = new MemoryStream((byte[])this.GV1.Rows[s].Cells[9].Value);
                        GVS3.Image = Image.FromStream(ms3);



                        sw = 1;
                    }


                }
                if (sw == 0)
                {
                    MessageBox.Show("Title Introuvable");
                }
            }
            else
            {
                MessageBox.Show("Vous Devez Remplir Title");
            }
        }

        private void guna2Button29_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            
        }

        private void BTNRECHCV_Click(object sender, EventArgs e)
        {
            int sw = 0;
            if (CCINCV.Text != "")
            {
                for (int s = 0; s <= this.GCV.RowCount - 2; s++)
                {
                    if (CCINCV.Text.ToUpper() == this.GCV.Rows[s].Cells[5].Value.ToString())
                    {
                        CCINCV.Text = this.GCV.Rows[s].Cells[5].Value.ToString();
                        TNOMCV.Text = this.GCV.Rows[s].Cells[1].Value.ToString();
                        TPRENOMCV.Text = this.GCV.Rows[s].Cells[2].Value.ToString();
                        TMAILCV.Text = this.GCV.Rows[s].Cells[3].Value.ToString();
                        TSNCV.Text = this.GCV.Rows[s].Cells[6].Value.ToString();
                        TNATIONCV.Text = this.GCV.Rows[s].Cells[8].Value.ToString();
                        TTELECV.Text = this.GCV.Rows[s].Cells[9].Value.ToString();
                        TCITYCV.Text = this.GCV.Rows[s].Cells[10].Value.ToString();
                        DTPKCV.Value = Convert.ToDateTime(this.GCV.Rows[s].Cells[12].Value.ToString());
                        MemoryStream ms = new MemoryStream((byte[])this.GCV.Rows[s].Cells[7].Value);
                        PICTURECV.Image = Image.FromStream(ms);


                        if (this.GCV.Rows[s].Cells[11].Value.ToString() == "Man")
                        {

                            RADIOMCV.Checked = true;

                        }
                        else
                        {
                            RADIOFCV.Checked = true;
                        }


                        sw = 1;
                    }


                }
                if (sw == 0)
                {
                    MessageBox.Show("ID Introuvable");
                }
            }
            else
            {
                MessageBox.Show("Vous Devez Remplir ID");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            bool SW = false;


            if (BTNLOGCIN.Text == "admin" && BTNLOGPASS.Text=="admin")
            {
                SW = true;
                BTNemp.Enabled = true;
                BTN_AJOUT.Enabled = true;
                BTN_RECHERCHE.Enabled = true;
                BTN_MODIFIER.Enabled = true;
                BTN_SUPPRIMER.Enabled = true;
                BTN_MAJJEUX.Enabled = true;
                BTNAJOUJEUX.Enabled = true;
                BTNRECHJEUX.Enabled = true;
                BTNMODJEUX.Enabled = true;
                BTNSUPPJEUX.Enabled = true;
                BTN_VALJEUX.Enabled = true;
                BTNGVRECH.Enabled = true;
                BTNVDOWNLOAD.Enabled = true;
                BTNJEUXVALID.Enabled = true;
                BTNCREATORMAJ.Enabled = true;
                BTNCAJOUT.Enabled = true;
                BTNCRECH.Enabled = true;
                BTNCMOD.Enabled = true;
                BTNCSUPP.Enabled = true;
                BTNCREATORVAL.Enabled = true;
                BTNRECHCV.Enabled = true;
                BTNCREATORVALID.Enabled = true;
                BTNUSERAJOUT.Enabled = true;
                BTNUSERRECH.Enabled = true;
                BTNUSERMOD.Enabled = true;
                BTNUSERSUPP.Enabled = true;
                BTNPAJOUT.Enabled = true;
                BTNPRECH.Enabled = true;
                BTNPMOD.Enabled = true;
                BTNPSUPP.Enabled = true;
                BTNPAIMENT.Enabled = true;

                BTNemp.Enabled = true;
                BTNclt.Enabled = true;
                BTNcreateur.Enabled = true;
                BTNjeux.Enabled = true;
                BTNpacks.Enabled = true;
                BTNPAIMENT.Enabled = true;



                panelSideMenu.Visible = true;
                PANELCONTROLER.Visible = true;

                this.WindowState = FormWindowState.Maximized;
                groupBox1.Visible = false;

                BTNLOGCIN.Text = "";
                BTNLOGPASS.Text = "";
            }

            for (int i = 0; i <= this.G1.RowCount - 2; i++)
            {
                if (BTNLOGCIN.Text == this.G1.Rows[i].Cells[0].Value.ToString() && BTNLOGPASS.Text == BD.dtset.Tables["employe"].Rows[i][5].ToString())
                {
                    SW = true;
                    
                    if (this.G1.Rows[i].Cells[10].Value.ToString()=="actif")
                    {

                        for (int j = 0; j <= BD.PrevdataSet.Tables["Previlages"].Rows.Count - 1; i++)
                        {
                            
                            if(BTNLOGCIN.Text == BD.PrevdataSet.Tables["Previlages"].Rows[i][24].ToString())
                            {
                                
         //CHECK PREV EMP INTERFACE *************************************************************************

                                if(BD.PrevdataSet.Tables["Previlages"].Rows[i][1].ToString()=="actif")
                                {
                                    BTNemp.Enabled = true;
                                    BTN_AJOUT.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][2].ToString() == "actif")
                                {
                                    BTNemp.Enabled = true;
                                    BTN_RECHERCHE.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][3].ToString() == "actif")
                                {
                                    BTNemp.Enabled = true;
                                    BTN_MODIFIER.Enabled = true;
                                }
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][4].ToString() == "actif")
                                {
                                    BTNemp.Enabled = true;
                                    BTN_SUPPRIMER.Enabled = true;
                                }

           //CHECK PREV JEUX INTERFACE ***********************************************************************                   

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][5].ToString() == "actif")
                                {
                                    BTNjeux.Enabled = true;
                                    BTN_MAJJEUX.Enabled = true;
                                    BTNAJOUJEUX.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][6].ToString() == "actif")
                                {
                                    BTNjeux.Enabled = true;
                                    BTN_MAJJEUX.Enabled = true;
                                    BTNRECHJEUX.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][7].ToString() == "actif")
                                {
                                    BTNjeux.Enabled = true;
                                    BTN_MAJJEUX.Enabled = true;
                                    BTNMODJEUX.Enabled = true;
                                }
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][8].ToString() == "actif")
                                {
                                    BTNjeux.Enabled = true;
                                    BTN_MAJJEUX.Enabled = true;
                                    BTNSUPPJEUX.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][9].ToString() == "actif")
                                {
                                    BTNjeux.Enabled = true;
                                    BTN_VALJEUX.Enabled = true;
                                    BTNGVRECH.Enabled = true;
                                    BTNVDOWNLOAD.Enabled = true;
                                    BTNJEUXVALID.Enabled = true;
                                }

      //CHECK PREV CREATOR INTERFACE ***********************************************************************    
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][10].ToString() == "actif")
                                {
                                    BTNcreateur.Enabled = true;
                                    BTNCREATORMAJ.Enabled = true;
                                    BTNCAJOUT.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][11].ToString() == "actif")
                                {
                                    BTNcreateur.Enabled = true;
                                    BTNCREATORMAJ.Enabled = true;
                                    BTNCRECH.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][12].ToString() == "actif")
                                {
                                    BTNcreateur.Enabled = true;
                                    BTNCREATORMAJ.Enabled = true;
                                    BTNCMOD.Enabled = true;
                                }
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][13].ToString() == "actif")
                                {
                                    BTNcreateur.Enabled = true;
                                    BTNCREATORMAJ.Enabled = true;
                                    BTNCSUPP.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][14].ToString() == "actif")
                                {
                                    BTNcreateur.Enabled = true;
                                    BTNCREATORVAL.Enabled = true;
                                    BTNRECHCV.Enabled = true;
                                    BTNCREATORVALID.Enabled = true;
                                }



   //CHECK PREV USER INTERFACE ***********************************************************************    
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][15].ToString() == "actif")
                                {
                                    BTNclt.Enabled = true;
                                   
                                    BTNUSERAJOUT.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][16].ToString() == "actif")
                                {
                                    BTNclt.Enabled = true;
                                    
                                    BTNUSERRECH.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][17].ToString() == "actif")
                                {
                                    BTNclt.Enabled = true;
                                    
                                    BTNUSERMOD.Enabled = true;
                                }
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][18].ToString() == "actif")
                                {
                                    BTNclt.Enabled = true;
                                    
                                    BTNUSERSUPP.Enabled = true;
                                }


  //CHECK PREV PACK INTERFACE ***********************************************************************    
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][19].ToString() == "actif")
                                {
                                    BTNpacks.Enabled = true;

                                    BTNPAJOUT.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][20].ToString() == "actif")
                                {
                                    BTNpacks.Enabled = true;

                                    BTNPRECH.Enabled = true;
                                }

                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][21].ToString() == "actif")
                                {
                                    BTNpacks.Enabled = true;

                                    BTNPMOD.Enabled = true;
                                }
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][22].ToString() == "actif")
                                {
                                    BTNpacks.Enabled = true;

                                    BTNPSUPP.Enabled = true;
                                }


           //CHECK PREV PAIMAINT INTERFACE
                                if (BD.PrevdataSet.Tables["Previlages"].Rows[i][23].ToString() == "actif")
                                {
                                    

                                    BTNPAIMENT.Enabled = true;
                                }
                                panelSideMenu.Visible = true;
                                PANELCONTROLER.Visible = true;
                               
                                this.WindowState = FormWindowState.Maximized;
                                groupBox1.Visible = false;
                                ShowDash();
                                BTNLOGCIN.Text = "";
                                BTNLOGPASS.Text = "";
                                break;

                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Votre Compte Est Blocké");
                    }



                } 
               
                
               
            }
            if (SW == false)
            {
                MessageBox.Show("Echec Athantification");
            }
               

        }

        

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string Etat = "";



            if (CCINCV.Text == "" || TNOMCV.Text == "" || TPRENOMCV.Text == "" || TMAILCV.Text == "")
            {
                MessageBox.Show("Svp Remplir Le Champ De CIN Et Rechercher");
                return;
            }

            if (RADIOACTIFCV.Checked)
            {
                Etat = "actif";
            }
            else
            {
                Etat = "inactif";
            }


            //CHEKC ETAT *****************************************************
            if (!RADIOACTIFCV.Checked && !RADIOACTIFCV.Checked)
            {
                MessageBox.Show("Svp Selectioner Un Etat");
                return;

            }


            bool SW = false;

            for (int i = 0; i <= this.GCV.RowCount - 2; i++)
            {
                if (CCINCV.Text == this.GCV.Rows[i].Cells[5].Value.ToString())
                {
                    //effectuer la modification
                    SW = true;

                    BD.Cdtset.Tables["creators"].Rows[i][13] = Etat;

                    BD.CCmdBuild = new MySqlCommandBuilder(BD.Cdtadapter);
                    BD.Cdtadapter.UpdateCommand = BD.CCmdBuild.GetUpdateCommand();
                    BD.Cdtadapter.Update(BD.Cdtset, "creators");


                    /////////////////////////// email ///////////////////////////////////
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("tahahandi3@gmail.com", "mmqb tlzv qyha irzq");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(BD.Cdtset.Tables["creators"].Rows[i][3].ToString());
                    msg.From = new MailAddress("tahahandi3@gmail.com");
                    msg.Subject = "Gemo";
                    if (Etat == "actif")
                    {
                        msg.Body = "Votre Compte Validé Avec Success";
                    }
                    else
                    {
                        msg.Body = "Votre Compte Est Suspendu";
                    }

                    client.Send(msg);
                    MessageBox.Show("Mail Envoyé");

                    ///////////////////////////////////end email//////////////////////////////////////




                    MessageBox.Show("Creator Valider Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("Creator NON VALIDE");
            }
        }

        private void JVgroupbox_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            string Etat = "";



            if (TVT.Text == "" || TVP.Text == "" || TVPX.Text == "" || TVG.Text == "")
            {
                MessageBox.Show("Svp Remplir Le Champ De Titre Et Rechercher");
                return;
            }

            if (RADIOGVACTIF.Checked)
            {
                Etat = "actif";
            }
            else
            {
                Etat = "inactif";
            }



            bool SW = false;

            for (int i = 0; i <= this.GG.RowCount - 2; i++)
            {
                if (TVT.Text == this.GG.Rows[i].Cells[1].Value.ToString())
                {
                    //effectuer la modification
                    SW = true;

                    BD.Gdtset.Tables["games"].Rows[i][11] = Etat;

                    BD.GCmdBuild = new MySqlCommandBuilder(BD.Gdtadapter);
                    BD.Gdtadapter.UpdateCommand = BD.GCmdBuild.GetUpdateCommand();
                    BD.Gdtadapter.Update(BD.Gdtset, "games");
                    MessageBox.Show("Jeux Valider Avec Succès");
                    break;
                }
            }
            if (SW == false)
            {
                MessageBox.Show("Jeux NON VALIDE");
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void guna2Button45_Click(object sender, EventArgs e)
        {
            string Etat = "";


            if (RADIOENVOYE.Checked)
            {
                Etat = "actif";
            }
            else
            {
                Etat = "inactif";
            }

            bool SW = false;

            for (int i = 0; i <= this.GCP.RowCount - 2; i++)
            {
                if (IDCP == this.GCP.Rows[i].Cells[0].Value.ToString())
                {
                    //effectuer la modification
                    SW = true;

                    BD.FilteredPaidataSet.Tables["creatorpaiments"].Rows[i][5] = Etat;

                    BD.FilteredPaiCmdBuild = new MySqlCommandBuilder(BD.FilteredPaiadapter);
                    BD.FilteredPaiadapter.UpdateCommand = BD.FilteredPaiCmdBuild.GetUpdateCommand();
                    BD.FilteredPaiadapter.Update(BD.FilteredPaidataSet, "creatorpaiments");




                    /////////////////////////// email ///////////////////////////////////
                    if (Etat == "actif")
                    {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("tahahandi3@gmail.com", "mmqb tlzv qyha irzq");
                    MailMessage msg = new MailMessage();
                    msg.To.Add(CREMAIL);
                    msg.From = new MailAddress("tahahandi3@gmail.com");
                    msg.Subject = "Gemo";

                        msg.Body = "Votre Paiment Envoyé Avec Success";
                    client.Send(msg);
                    MessageBox.Show("Mail Envoyé");
                    }
                    ///////////////////////////////////end email//////////////////////////////////////

                    MessageBox.Show("Paiment Valider Avec Succès");
                    break;
                }
            }
            

           
            for (int i = 0; i <= this.GCP.RowCount - 2; i++)
            {
                if (this.GCP.Rows[i].Cells[5].Value.ToString() == "actif")
                {
                    this.GCP.Rows.RemoveAt(i);
                }
            }

            this.GCP.Refresh();
        }

        private void GCP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int ligneencours;
            ligneencours = GCP.CurrentRow.Index;
            bool SW = false;

            for (int i = 0; i <= this.GC.RowCount - 2; i++)
            {
                if (this.GCP.Rows[ligneencours].Cells[6].Value.ToString()== this.GC.Rows[i].Cells[0].Value.ToString())
                {
                    CCINPAIMENT.Text = this.GC.Rows[i].Cells[5].Value.ToString();
                    CREMAIL = this.GC.Rows[i].Cells[3].Value.ToString();

                }
            }

            AMOUNTPAIMENT.Text = this.GCP.Rows[ligneencours].Cells[3].Value.ToString();
            CMODEPAIMENT.Text = this.GCP.Rows[ligneencours].Cells[1].Value.ToString();
            CIDENTPAIMENT.Text = this.GCP.Rows[ligneencours].Cells[2].Value.ToString();
            IDCP = this.GCP.Rows[ligneencours].Cells[0].Value.ToString();

            if(this.GCP.Rows[ligneencours].Cells[5].Value.ToString()=="actif")
            {
                RADIOENVOYE.Checked = true;
            }
            else
            {
                RADIOATTENT.Checked = true;
            }
          

        }

        private void guna2TextBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BTNemp.Enabled = false;
            BTN_AJOUT.Enabled = false;
            BTN_RECHERCHE.Enabled = false;
            BTN_MODIFIER.Enabled = false;
            BTN_SUPPRIMER.Enabled = false;
            BTN_MAJJEUX.Enabled = false;
            BTNAJOUJEUX.Enabled = false;
            BTNRECHJEUX.Enabled = false;
            BTNMODJEUX.Enabled = false;
            BTNSUPPJEUX.Enabled = false;
            BTN_VALJEUX.Enabled = false;
            BTNGVRECH.Enabled = false;
            BTNVDOWNLOAD.Enabled = false;
            BTNJEUXVALID.Enabled = false;
            BTNCREATORMAJ.Enabled = false;
            BTNCAJOUT.Enabled = false;
            BTNCRECH.Enabled = false;
            BTNCMOD.Enabled = false;
            BTNCSUPP.Enabled = false;
            BTNCREATORVAL.Enabled = false;
            BTNRECHCV.Enabled = false;
            BTNCREATORVALID.Enabled = false;
            BTNUSERAJOUT.Enabled = false;
            BTNUSERRECH.Enabled = false;
            BTNUSERMOD.Enabled = false;
            BTNUSERSUPP.Enabled = false;
            BTNPAJOUT.Enabled = false;
            BTNPRECH.Enabled = false;
            BTNPMOD.Enabled = false;
            BTNPSUPP.Enabled = false;
            BTNPAIMENT.Enabled = false;

            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
            PaiementgroupBox.Visible = false;

            BTNemp.Enabled = false;
            BTNclt.Enabled = false;
            BTNcreateur.Enabled = false;
            BTNjeux.Enabled = false;
            BTNpacks.Enabled = false;
            BTNPAIMENT.Enabled = false;

            panelSideMenu.Visible = false;
            PANELCONTROLER.Visible = false;
            this.WindowState = FormWindowState.Normal;
            groupBox1.Visible = true;
            ShowDash();
            

        }

        private void PACKSgroupbox_Enter(object sender, EventArgs e)
        {

        }



        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowDash();
        }

        public void ShowDash()
        {
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            label49.Visible = false;
            label71.Visible = false;
            CCINPAIMENT.Visible = false;
            AMOUNTPAIMENT.Visible = false;
            panel8.Visible = false;
            CMODEPAIMENT.Visible = false;
            CIDENTPAIMENT.Visible = false;
            guna2Button45.Visible = false;
            GCP.Visible = false;


            EMPgroupbox.Visible = false;
            CLTgroupbox.Visible = false;
            JVgroupbox.Visible = false;
            JMgroupbox.Visible = false;
            PACKSgroupbox.Visible = false;
            CVgroupbox.Visible = false;
            CMgroupbox.Visible = false;
          
            DashVid.Visible = true;
        }


        public void HideDash()
        {
            label46.Visible = true;
            label47.Visible = true;
            label48.Visible = true;
            label49.Visible = true;
            label71.Visible = true;
            CCINPAIMENT.Visible = true;
            AMOUNTPAIMENT.Visible = true;
            panel8.Visible = true;
            CMODEPAIMENT.Visible = true;
            CIDENTPAIMENT.Visible = true;
            guna2Button45.Visible = true;
            GCP.Visible = true;
            DashVid.Visible = false;
        }

        private void BTNLOGCIN_TextChanged(object sender, EventArgs e)
        {

        }        


        }
    
    
}
