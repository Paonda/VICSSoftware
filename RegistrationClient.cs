using MetroSet_UI.Controls;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RegistrationClient
{
    public partial class RegistrationClient : MetroSetForm
    {
        bool Text_Name_First_HasValue = false;
        bool Text_Name_Middle_HasValue = false;
        bool Text_Name_Last_HasValue = false;
        bool Combo_Birth_Month_HasValue = false;
        bool Combo_Birth_Year_HasValue = false;
        bool Combo_Birth_Day_HasValue = false;
        bool Radio_Male_HasValue = false;
        bool Radio_Female_HasValue = false;
        bool Combo_Voter_Region_HasValue = false;
        bool Combo_Voter_City_HasValue = false;
        bool Text_Voter_ID_HasValue = false;
        bool Text_Voter_Contact_HasValue = false;
        bool Radio_Pres_HasValue = false;
        bool Radio_Vice_HasValue = false;
        bool Radio_Sen_HasValue = false;
        bool TabControl_Main_IsSubmit = false;
        bool Button_Reset_EnableCondition = false;
        bool Button_Submit_EnableCondition = false;
        bool[] Radio_Sen_Check = new bool[22];
        int Radio_Sen_Counter = 0;
        Regions regions = new Regions();
        public RegistrationClient()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text_Version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Combo_Birth_Year.Items.Clear();
            Combo_Birth_Year.Items.AddRange(Enumerable.Range(DateTime.Now.Year-119, 102).Cast<object>().Reverse().ToArray());
            Combo_Birth_Month.Items.Clear();
            Combo_Birth_Month.Items.AddRange(CultureInfo.InvariantCulture.DateTimeFormat.MonthNames);
            Combo_Birth_Month.Items.RemoveAt(Combo_Birth_Month.Items.Count-1);
            Combo_Birth_Day.Items.Clear();
            Combo_Birth_Day.Enabled = false;
            Combo_Voter_City.Enabled = false;
            Button_Reset.Enabled = false;
            Button_Submit.Enabled = false;
            Button_UpdateState();
        }
        private void Check_SenValue()
        {
            Radio_Sen_Check = new bool[22] { Radio_Sen_1.Checked, Radio_Sen_2.Checked, Radio_Sen_3.Checked, Radio_Sen_4.Checked, Radio_Sen_5.Checked, Radio_Sen_6.Checked, Radio_Sen_7.Checked, Radio_Sen_8.Checked, Radio_Sen_9.Checked, Radio_Sen_10.Checked, Radio_Sen_11.Checked, Radio_Sen_12.Checked, Radio_Sen_13.Checked, Radio_Sen_14.Checked, Radio_Sen_15.Checked, Radio_Sen_16.Checked, Radio_Sen_17.Checked, Radio_Sen_18.Checked, Radio_Sen_19.Checked, Radio_Sen_20.Checked, Radio_Sen_21.Checked, Radio_Sen_22.Checked };
            Radio_Sen_Counter = Radio_Sen_Check.Count(c => c);
        }
        private void Check_HasValue()
        {
            Radio_Pres_HasValue = (Radio_Pres_1.Checked || Radio_Pres_2.Checked || Radio_Pres_3.Checked || Radio_Pres_4.Checked || Radio_Pres_5.Checked || Radio_Pres_6.Checked || Radio_Pres_7.Checked || Radio_Pres_8.Checked || Radio_Pres_9.Checked || Radio_Pres_10.Checked);
            Radio_Vice_HasValue = (Radio_Vice_1.Checked || Radio_Vice_2.Checked || Radio_Vice_3.Checked || Radio_Vice_4.Checked || Radio_Vice_5.Checked || Radio_Vice_6.Checked || Radio_Vice_7.Checked || Radio_Vice_8.Checked || Radio_Vice_9.Checked);
            Radio_Sen_HasValue = (Radio_Sen_1.Checked || Radio_Sen_2.Checked || Radio_Sen_3.Checked || Radio_Sen_4.Checked || Radio_Sen_5.Checked || Radio_Sen_6.Checked || Radio_Sen_7.Checked || Radio_Sen_8.Checked || Radio_Sen_9.Checked || Radio_Sen_10.Checked || Radio_Sen_11.Checked || Radio_Sen_12.Checked || Radio_Sen_13.Checked || Radio_Sen_14.Checked || Radio_Sen_15.Checked || Radio_Sen_16.Checked || Radio_Sen_17.Checked || Radio_Sen_18.Checked || Radio_Sen_19.Checked || Radio_Sen_20.Checked || Radio_Sen_21.Checked || Radio_Sen_22.Checked);
            Button_Reset_EnableCondition = (Radio_Pres_HasValue || Radio_Vice_HasValue || Radio_Sen_HasValue || Text_Name_First_HasValue || Text_Name_Middle_HasValue || Text_Name_Last_HasValue || Radio_Male_HasValue || Radio_Female_HasValue || Combo_Birth_Month_HasValue || Combo_Birth_Year_HasValue || Combo_Birth_Day_HasValue || Combo_Voter_Region_HasValue || Combo_Voter_City_HasValue || Text_Voter_ID_HasValue || Text_Voter_Contact_HasValue);
            Button_Submit_EnableCondition = (TabControl_Main_IsSubmit && (Radio_Pres_HasValue || Radio_Vice_HasValue || (( Radio_Sen_Counter > 0 ) && (Radio_Sen_Counter < 13))) && Text_Name_First_HasValue && Text_Name_Middle_HasValue && Text_Name_Last_HasValue && (Radio_Male_HasValue || Radio_Female_HasValue) && Combo_Birth_Month_HasValue && Combo_Birth_Year_HasValue && Combo_Birth_Day_HasValue && Combo_Voter_Region_HasValue && Combo_Voter_City_HasValue && Text_Voter_ID_HasValue && Text_Voter_Contact_HasValue);
        }
        private void Button_UpdateState()
        {
            Check_SenValue();
            Check_HasValue();
            Button_Reset.Enabled = Button_Reset_EnableCondition;
            Button_Submit.Enabled = Button_Submit_EnableCondition;
            string regionsJsonData = File.ReadAllText(@"./regions.json");
            regions = JsonSerializer.Deserialize<Regions>(regionsJsonData);
            regions.regionslist.ForEach(delegate (Region region)
            {
                Combo_Voter_Region.Items.Add(region.name);
            });
        }
        private void Button_Reset_Click(object sender, EventArgs e)
        {
            Text_Name_First.ResetText();
            Text_Name_First_HasValue = false;
            Text_Name_Last.ResetText();
            Text_Name_Last_HasValue = false;
            Text_Name_Middle.ResetText();
            Text_Name_Middle_HasValue = false;
            Combo_Birth_Month.SelectedIndex = -1;
            Combo_Birth_Month.Refresh();
            Combo_Birth_Month_HasValue = false;
            Combo_Birth_Day.SelectedIndex = -1;
            Combo_Birth_Day.Refresh();
            Combo_Birth_Day_HasValue = false;
            Combo_Birth_Day.Enabled = false;
            Combo_Birth_Year.SelectedIndex = -1;
            Combo_Birth_Year.Refresh();
            Combo_Birth_Year_HasValue = false;
            Radio_Male.Checked = false;
            Radio_Male_HasValue = false;
            Radio_Female.Checked = false;
            Radio_Female_HasValue = false;
            Combo_Voter_Region.SelectedIndex = -1;
            Combo_Voter_Region.Refresh();
            Combo_Voter_Region_HasValue = false;
            Combo_Voter_City.SelectedIndex = -1;
            Combo_Voter_City.Items.Clear();
            Combo_Voter_City.Refresh();
            Combo_Voter_City_HasValue = false;
            Combo_Voter_City.Enabled = false;
            Text_Voter_ID.ResetText();
            Text_Voter_ID_HasValue = false;
            Text_Voter_Contact.ResetText();
            Text_Voter_Contact_HasValue = false;
            Radio_Pres_1.Checked = false; Radio_Pres_2.Checked = false; Radio_Pres_3.Checked = false; Radio_Pres_4.Checked = false; Radio_Pres_5.Checked = false; Radio_Pres_6.Checked = false; Radio_Pres_7.Checked = false; Radio_Pres_8.Checked = false; Radio_Pres_9.Checked = false; Radio_Pres_10.Checked = false;
            Radio_Vice_1.Checked = false; Radio_Vice_2.Checked = false; Radio_Vice_3.Checked = false; Radio_Vice_4.Checked = false; Radio_Vice_5.Checked = false; Radio_Vice_6.Checked = false; Radio_Vice_7.Checked = false; Radio_Vice_8.Checked = false; Radio_Vice_9.Checked = false;
            Radio_Sen_1.Checked = false; Radio_Sen_2.Checked = false; Radio_Sen_3.Checked = false; Radio_Sen_4.Checked = false; Radio_Sen_5.Checked = false; Radio_Sen_6.Checked = false; Radio_Sen_7.Checked = false; Radio_Sen_8.Checked = false; Radio_Sen_9.Checked = false; Radio_Sen_10.Checked = false; Radio_Sen_11.Checked = false; Radio_Sen_12.Checked = false; Radio_Sen_13.Checked = false; Radio_Sen_14.Checked = false; Radio_Sen_15.Checked = false; Radio_Sen_16.Checked = false; Radio_Sen_17.Checked = false; Radio_Sen_18.Checked = false; Radio_Sen_19.Checked = false; Radio_Sen_20.Checked = false; Radio_Sen_21.Checked = false; Radio_Sen_22.Checked = false;
            Label_Check_Name.Text = "Name:";
            Label_Check_BirthDate.Text = "Birth Date: ";
            Label_Check_Gender.Text = "Gender: ";
            Label_Check_Region.Text = "Region: ";
            Label_Check_City.Text = "City: ";
            Label_Check_Voter_ID.Text = "Voter ID: ";
            Label_Check_Contact.Text = "Contact ";
            Label_Check_Pres.Text = "For President: ";
            Label_Check_Vice.Text = "For Vice President: ";
            Label_Check_Sen.Text = "For Senator: ";
            Button_UpdateState();
        }
        private void Text_Name_First_TextChanged(object sender, EventArgs e)
        {
            Text_Name_First_HasValue = (Text_Name_First.Text.Length > 0) ? true : false;
            Button_UpdateState();
        }
        private void Text_Name_Last_TextChanged(object sender, EventArgs e)
        {
            Text_Name_Last_HasValue = (Text_Name_Last.Text.Length > 0) ? true : false;
            Button_UpdateState();
        }
        private void Text_Name_Middle_TextChanged(object sender, EventArgs e)
        {
            Text_Name_Middle_HasValue = (Text_Name_Middle.Text.Length > 0) ? true : false;
            Button_UpdateState();
        }
        private void Combo_Birth_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo_Birth_Month_HasValue = true;
            Combo_Birth_Day.Enabled = (Combo_Birth_Month_HasValue && Combo_Birth_Year_HasValue);
            Button_UpdateState();
        }
        private void Combo_Birth_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo_Birth_Year_HasValue = true;
            Combo_Birth_Day.Enabled = (Combo_Birth_Month_HasValue && Combo_Birth_Year_HasValue);
            Button_UpdateState();
        }
        private void Combo_Birth_Day_DropDown(object sender, EventArgs e)
        {
            int daysInMonth = DateTime.DaysInMonth(int.Parse(Combo_Birth_Year.Text), Combo_Birth_Month.SelectedIndex);
            Combo_Birth_Day.Items.AddRange(Enumerable.Range(1, daysInMonth).Cast<object>().Reverse().ToArray());
        }
        private void Combo_Birth_Day_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo_Birth_Day_HasValue = true;
            Button_UpdateState();
        }
        private void Radio_Male_CheckedChanged(object sender)
        {
            Radio_Male_HasValue = (Radio_Male.Checked == true) ? true : false;
            Button_UpdateState();
        }
        private void Radio_Female_CheckedChanged(object sender)
        {
            Radio_Female_HasValue = (Radio_Female.Checked == true) ? true : false;
            Button_UpdateState();
        }
        private void Combo_Voter_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo_Voter_Region_HasValue = true;
            Combo_Voter_City.Enabled = true;
            Combo_Voter_City.Items.Clear();
            int RegionID = Combo_Voter_Region.SelectedIndex;
            if (RegionID != -1)
            {
                regions.regionslist[RegionID].citieslist.ForEach(delegate (City city)
                {
                    Combo_Voter_City.Items.Add(city.name);
                });
            }
            Combo_Voter_City.Refresh();
        }
        private void Combo_Voter_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combo_Voter_City_HasValue = true;
            Button_UpdateState();
        }
        private void Text_Voter_ID_TextChanged(object sender, EventArgs e)
        {
            Text_Voter_ID_HasValue = (Text_Voter_ID.Text.Length > 0) ? true : false;
            Button_UpdateState();
        }
        private void Text_Voter_Contact_TextChanged(object sender, EventArgs e)
        {
            Text_Voter_Contact_HasValue = (Text_Voter_Contact.Text.Length > 0) ? true : false;
            Button_UpdateState();
        }
        private void Button_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VICS (Voter Information Collection System) Software is developed by Oca Industries and Paonda Technologies. Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), "About VICS Software");
        }
        private void TabControl_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl_Main_IsSubmit = (TabControl_Main.SelectedIndex == 4) ? true : false;
            Button_UpdateState();
            Label_Check_Name.Text = "Name: " + Text_Name_First.Text + " " + Text_Name_Middle.Text + " " + Text_Name_Last.Text;
            if(Radio_Pres_1.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_1.Text;
            }
            else if (Radio_Pres_2.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_2.Text;
            }
            else if (Radio_Pres_3.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_3.Text;
            }
            else if (Radio_Pres_4.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_4.Text;
            }
            else if (Radio_Pres_5.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_5.Text;
            }
            else if (Radio_Pres_6.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_6.Text;
            }
            else if (Radio_Pres_7.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_7.Text;
            }
            else if (Radio_Pres_8.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_8.Text;
            }
            else if (Radio_Pres_9.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_9.Text;
            }
            else if (Radio_Pres_10.Checked == true)
            {
                Label_Check_Pres.Text = "For President: " + Radio_Pres_10.Text;
            }
            else
            {
                Label_Check_Pres.Text = "For President: ";
            }
            if (Radio_Vice_1.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_1.Text;
            }
            else if (Radio_Vice_2.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_2.Text;
            }
            else if (Radio_Vice_3.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_3.Text;
            }
            else if (Radio_Vice_4.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_4.Text;
            }
            else if (Radio_Vice_5.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_5.Text;
            }
            else if (Radio_Vice_6.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_6.Text;
            }
            else if (Radio_Vice_7.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_7.Text;
            }
            else if (Radio_Vice_8.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_8.Text;
            }
            else if (Radio_Vice_9.Checked == true)
            {
                Label_Check_Vice.Text = "For Vice President: " + Radio_Vice_9.Text;
            }
            else
            {
                Label_Check_Vice.Text = "For Vice President: ";
            }
            Label_Check_BirthDate.Text = "Birth Date: " + Combo_Birth_Month.Text + " " + Combo_Birth_Day.Text + " " + Combo_Birth_Year.Text;
            if (Radio_Male.Checked == true)
            {
                Label_Check_Gender.Text = "Gender: Male";
            }
            else if(Radio_Female.Checked == true)
            {
                Label_Check_Gender.Text = "Gender: Female";
            }
            else
            {
                Label_Check_Gender.Text = "Gender: ";
            }
            Label_Check_Sen.Text = "For Senator: " + (Radio_Sen_Check[0] == true ? Radio_Sen_1.Text  + ", " : "") + (Radio_Sen_Check[1] == true ? Radio_Sen_2.Text  + ", " : "") + (Radio_Sen_Check[2] == true ? Radio_Sen_3.Text  + ", " : "") + (Radio_Sen_Check[3] == true ? Radio_Sen_4.Text  + ", " : "") + (Radio_Sen_Check[4] == true ? Radio_Sen_5.Text  + ", " : "") + (Radio_Sen_Check[5] == true ? Radio_Sen_6.Text  + ", " : "") + (Radio_Sen_Check[6] == true ? Radio_Sen_7.Text  + ", " : "") + (Radio_Sen_Check[7] == true ? Radio_Sen_8.Text  + ", " : "") + (Radio_Sen_Check[8] == true ? Radio_Sen_9.Text  + ", " : "") + (Radio_Sen_Check[9] == true ? Radio_Sen_10.Text  + ", " : "") + (Radio_Sen_Check[10] == true ? Radio_Sen_11.Text  + ", " : "") + (Radio_Sen_Check[11] == true ? Radio_Sen_12.Text  + ", " : "") + (Radio_Sen_Check[12] == true ? Radio_Sen_13.Text  + ", " : "") + (Radio_Sen_Check[13] == true ? Radio_Sen_14.Text  + ", " : "") + (Radio_Sen_Check[14] == true ? Radio_Sen_15.Text  + ", " : "") + (Radio_Sen_Check[15] == true ? Radio_Sen_16.Text  + ", " : "") + (Radio_Sen_Check[16] == true ? Radio_Sen_17.Text  + ", " : "") + (Radio_Sen_Check[17] == true ? Radio_Sen_18.Text  + ", " : "") + (Radio_Sen_Check[18] == true ? Radio_Sen_19.Text  + ", " : "") + (Radio_Sen_Check[19] == true ? Radio_Sen_20.Text  + ", " : "") + (Radio_Sen_Check[20] == true ? Radio_Sen_21.Text  + ", " : "") + (Radio_Sen_Check[21] == true ? Radio_Sen_22.Text  + ", " : "");
            Label_Check_Region.Text = "Region: " + Combo_Voter_Region.Text;
            Label_Check_City.Text = "City: " + Combo_Voter_City.Text;
            Label_Check_Voter_ID.Text = "Voter ID: " + Text_Voter_ID.Text;
            Label_Check_Contact.Text = "Contact: " + Text_Voter_Contact.Text;
            if(Radio_Sen_Counter > 12 && TabControl_Main.SelectedIndex == 4)
            {
                MessageBox.Show("A voter is only allowed to vote up to 12 senatorial candidates. Please select only 12 candidates from the Senator tab.", "Maximum Senator Vote Reached");
            }
        }
        private void Radio_Pres_1_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_2_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_3_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_4_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_5_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_6_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_7_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_8_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_9_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Pres_10_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_1_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_2_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_3_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_4_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_5_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_6_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_7_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_8_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
        private void Radio_Vice_9_CheckedChanged(object sender)
        {
            Button_UpdateState(); 
        }

        private void Radio_Sen_1_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_2_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_3_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_4_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_5_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_6_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_7_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_8_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_9_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_10_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_11_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_12_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_13_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_14_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_15_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_16_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_17_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_18_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_19_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_20_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_21_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }

        private void Radio_Sen_22_CheckedChanged(object sender)
        {
            Button_UpdateState();
        }
    }
}