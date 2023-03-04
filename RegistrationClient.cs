using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RegistrationClient
{
    public partial class RegistrationClient : MetroSetForm
    {
        bool txt_first_hasValue = false;
        bool txt_middle_hasValue = false;
        bool txt_last_hasValue = false;
        bool cmb_birthmonth_hasValue = false;
        bool cmb_birthyear_hasValue = false;
        bool cmb_birthday_hasValue = false;
        bool rdb_male_hasValue = false;
        bool rdb_female_hasValue = false;
        bool cmb_region_hasValue = false;
        bool cmb_city_hasValue = false;
        bool txt_voterid_hasValue = false;
        bool txt_number_hasValue = false;
        bool rdb_pres_hasValue = false;
        bool rdb_vice_hasValue = false;
        bool tbc_main_isSubmit = false;
        public RegistrationClient()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            cmb_birthyear.Items.Clear();
            cmb_birthyear.Items.AddRange(Enumerable.Range(DateTime.Now.Year-119, 102).Cast<object>().Reverse().ToArray());
            cmb_birthmonth.Items.Clear();
            cmb_birthmonth.Items.AddRange(CultureInfo.InvariantCulture.DateTimeFormat.MonthNames);
            cmb_birthmonth.Items.RemoveAt(cmb_birthmonth.Items.Count-1);
            cmb_birthday.Items.Clear();
            cmb_birthday.Enabled = false;
            cmb_city.Enabled = false;
            btn_reset.Enabled = false;
            btn_submit.Enabled = false;
        }
        private void btn_reset_setValue()
        {
            if (rdb_pres_hasValue || rdb_vice_hasValue || txt_first_hasValue || txt_middle_hasValue || txt_last_hasValue || rdb_male_hasValue || rdb_female_hasValue || cmb_birthmonth_hasValue || cmb_birthyear_hasValue || cmb_birthday_hasValue || cmb_region_hasValue || cmb_city_hasValue || txt_voterid_hasValue || txt_number_hasValue == true)
            {
                btn_reset.Enabled = true;
            }
            else
            {
                btn_reset.Enabled = false;
            }
           btn_submit_setValue();
        }
        private void btn_submit_setValue()
        {
            if (tbc_main_isSubmit && rdb_pres_hasValue && rdb_vice_hasValue && txt_first_hasValue && txt_middle_hasValue && txt_last_hasValue && ( rdb_male_hasValue || rdb_female_hasValue ) && cmb_birthmonth_hasValue && cmb_birthyear_hasValue && cmb_birthday_hasValue && cmb_region_hasValue && cmb_city_hasValue && txt_voterid_hasValue && txt_number_hasValue == true)
            {
                btn_submit.Enabled = true;
            }
            else
            {
                btn_submit.Enabled = false;
            }
        }
        private void rdb_pres_setValue()
        {
            if (rdb_pres1.Checked || rdb_pres2.Checked || rdb_pres3.Checked || rdb_pres4.Checked || rdb_pres5.Checked || rdb_pres6.Checked || rdb_pres7.Checked || rdb_pres8.Checked || rdb_pres9.Checked || rdb_pres10.Checked == true)
            {
                rdb_pres_hasValue = true;
            }
            else
            {
                rdb_pres_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void rdb_vice_setValue()
        {
            if (rdb_vice1.Checked || rdb_vice2.Checked || rdb_vice3.Checked || rdb_vice4.Checked || rdb_vice5.Checked || rdb_vice6.Checked || rdb_vice7.Checked || rdb_vice8.Checked || rdb_vice9.Checked == true)
            {
                rdb_vice_hasValue = true;
            }
            else
            {
                rdb_vice_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_first.ResetText();
            txt_first_hasValue = false;
            txt_last.ResetText();
            txt_last_hasValue = false;
            txt_middle.ResetText();
            txt_middle_hasValue = false;
            cmb_birthmonth.SelectedIndex = -1;
            cmb_birthmonth.Refresh();
            cmb_birthmonth_hasValue = false;
            cmb_birthday.SelectedIndex = -1;
            cmb_birthday.Refresh();
            cmb_birthday_hasValue = false;
            cmb_birthday.Enabled = false;
            cmb_birthyear.SelectedIndex = -1;
            cmb_birthyear.Refresh();
            cmb_birthyear_hasValue = false;
            rdb_male.Checked = false;
            rdb_male_hasValue = false;
            rdb_female.Checked = false;
            rdb_female_hasValue = false;
            cmb_region.SelectedIndex = -1;
            cmb_region.Refresh();
            cmb_region_hasValue = false;
            cmb_city.SelectedIndex = -1;
            cmb_city.Items.Clear();
            cmb_city.Refresh();
            cmb_city_hasValue = false;
            txt_voterid.ResetText();
            txt_voterid_hasValue = false;
            txt_number.ResetText();
            txt_number_hasValue = false;
            rdb_pres1.Checked = false;
            rdb_pres2.Checked = false;
            rdb_pres3.Checked = false;
            rdb_pres4.Checked = false;
            rdb_pres5.Checked = false;
            rdb_pres6.Checked = false;
            rdb_pres7.Checked = false;
            rdb_pres8.Checked = false;
            rdb_pres9.Checked = false;
            rdb_pres10.Checked = false;
            rdb_vice1.Checked = false;
            rdb_vice2.Checked = false;
            rdb_vice3.Checked = false;
            rdb_vice4.Checked = false;
            rdb_vice5.Checked = false;
            rdb_vice6.Checked = false;
            rdb_vice7.Checked = false;
            rdb_vice8.Checked = false;
            rdb_vice9.Checked = false;
            lbl_checkname.Text = "Name:";
            lbl_checkpres.Text = "For President: ";
            lbl_checkvice.Text = "For Vice President: ";
            lbl_checkbirthdate.Text = "Birth Date: ";
            lbl_checkgender.Text = "Gender: ";
            btn_reset_setValue();
        }
        private void txt_first_TextChanged(object sender, EventArgs e)
        {
            if (txt_first.Text.Length > 0)
            {
                txt_first_hasValue = true;
            }
            else
            {
                txt_first_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void cmb_birthmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_birthmonth_hasValue = true;
            if (cmb_birthmonth_hasValue && cmb_birthyear_hasValue == true)
            {
                cmb_birthday.Enabled = true;
            }
            else 
            { 

            }
            btn_reset_setValue();
        }
        private void cmb_birthyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_birthyear_hasValue = true;
            if (cmb_birthmonth_hasValue && cmb_birthyear_hasValue == true)
            {
                cmb_birthday.Enabled = true;
            }
            else
            {

            }
            btn_reset_setValue();
        }
        private void cmb_birthday_DropDown(object sender, EventArgs e)
        {
            int daysInMonth = DateTime.DaysInMonth(int.Parse(cmb_birthyear.Text), cmb_birthmonth.SelectedIndex);
            cmb_birthday.Items.AddRange(Enumerable.Range(1, daysInMonth).Cast<object>().Reverse().ToArray());
        }
        private void cmb_birthday_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_birthday_hasValue = true;
            btn_reset_setValue();
        }
        private void txt_last_TextChanged(object sender, EventArgs e)
        {
            if (txt_last.Text.Length > 0)
            {
                txt_last_hasValue = true;
            }
            else
            {
                txt_last_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void txt_middle_TextChanged(object sender, EventArgs e)
        {
            if (txt_middle.Text.Length > 0)
            {
                txt_middle_hasValue = true;
            }
            else
            {
                txt_middle_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void rdb_male_CheckedChanged(object sender)
        {
            if(rdb_male.Checked == true)
            {
                rdb_male_hasValue = true;
            }
            else
            {
                rdb_male_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void rdb_female_CheckedChanged(object sender)
        {
            if (rdb_female.Checked == true)
            {
                rdb_female_hasValue = true;
            }
            else
            {
                rdb_female_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void cmb_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_region_hasValue = true;
            btn_reset_setValue();
            cmb_city.Enabled = true;
            cmb_city.Items.Clear();
            if (cmb_region.SelectedIndex == 0)
            {
                cmb_city.Items.AddRange(new string[] { "Manila City", "Mandaluyong City", "Marikina City", "Pasig City", "Quezon City", "San Juan City", "Caloocan City", "Malabon City", "Navotas City", "Valenzuela City", "Las Pinas City", "Makati City", "Muntinlupa City", "Paranaque City", "Pasay City", "Pateros", "Taguig City" });
            }
            else if (cmb_region.SelectedIndex == 1)
            {
                cmb_city.Items.AddRange(new string[] { "Ilocos Norte", "Ilocos Sur", "La Union", "Pangasinan" });
            }
            else if (cmb_region.SelectedIndex == 2)
            {
                cmb_city.Items.AddRange(new string[] { "Abra", "Apayao", "Benguet", "Ifugao", "Kalinga", "Mountain Province", "Baguio City" });
            }
            else if (cmb_region.SelectedIndex == 3)
            {
                cmb_city.Items.AddRange(new string[] { "Batanes", "Cagayan", "Isabela Province", "Nueva Vizcaya", "Quirino" });
            }
            else if (cmb_region.SelectedIndex == 4)
            {
                cmb_city.Items.AddRange(new string[] { "Aurora", "Bataan", "Bulacan", "Nueva Ecija", "Pampanga", "Tarlac", "Zambales", "Angeles City", "Olongapo City" });
            }
            else if (cmb_region.SelectedIndex == 5)
            {
                cmb_city.Items.AddRange(new string[] { "Batangas", "Cavite", "Laguna", "Quezon Province", "Rizal", "Lucena City" });
            }
            else if (cmb_region.SelectedIndex == 6)
            {
                cmb_city.Items.AddRange(new string[] { "Marinduque", "Occidental Mindoro", "Oriental Mindoro", "Palawan", "Romblon", "Puerto Princesa City" });
            }
            else if (cmb_region.SelectedIndex == 7)
            {
                cmb_city.Items.AddRange(new string[] { "Albay", "Camarines Norte", "Camarines Sur", "Catanduanes", "Masbate", "Sorsogon" });
            }
            else if (cmb_region.SelectedIndex == 8)
            {
                cmb_city.Items.AddRange(new string[] { "Aklan", "Antique", "Capiz", "Guimaras", "Iloilo City", "Iloilo Province", "Negros Occidental", "Bacolod City" });
            }
            else if (cmb_region.SelectedIndex == 9)
            {
                cmb_city.Items.AddRange(new string[] { "Bohol", "Cebu", "Negros Oriental", "Siquijor", "Cebu City", "Lapu-Lapu City", "Mandaue City" });
            }
            else if (cmb_region.SelectedIndex == 10)
            {
                cmb_city.Items.AddRange(new string[] { "Biliran", "Eastern Samar", "Leyte", "Northern Samar", "Samar", "Southern Leyte", "Tacloban City" });
            }
            else if (cmb_region.SelectedIndex == 11)
            {
                cmb_city.Items.AddRange(new string[] { "Zamboanga del Norte", "Zamboanga del Sur", "Zamboanga Sibugay", "Isabela City", "Zamboanga City" });
            }
            else if (cmb_region.SelectedIndex == 12)
            {
                cmb_city.Items.AddRange(new string[] { "Bukidnon", "Camiguin", "Lanao del Norte", "Misamis Occidental", "Misamis Oriental", "Cagayan de Oro City", "Iligan City" });
            }
            else if (cmb_region.SelectedIndex == 13)
            {
                cmb_city.Items.AddRange(new string[] { "Compostela Valley", "Davao del Norte", "Davao del Sur", "Davao Occidental", "Davao Oriental", "Davao City" });
            }
            else if (cmb_region.SelectedIndex == 14)
            {
                cmb_city.Items.AddRange(new string[] { "North Cotabato", "Sarangani", "South Cotabato", "Sultan Kudarat", "Cotabato City", "General Santos City" });
            }
            else if (cmb_region.SelectedIndex == 15)
            {
                cmb_city.Items.AddRange(new string[] { "Agusan del Norte", "Agusan del Sur", "Dinagat Islands", "Surigao del Norte", "Surigao del Sur", "Butuan City" });
            }
            else if (cmb_region.SelectedIndex == 16)
            {
                cmb_city.Items.AddRange(new string[] { "Basilan", "Lanao del Sur", "Maguindanao", "Sulu", "Tawi-Tawi" });
            }
            else
            {
                cmb_city.Enabled = false;
            }
        }
        private void cmb_city_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_city_hasValue = true;
            btn_reset_setValue();
        }
        private void txt_voterid_TextChanged(object sender, EventArgs e)
        {
            if (txt_voterid.Text.Length > 0)
            {
                txt_voterid_hasValue = true;
            }
            else
            {
                txt_voterid_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void txt_number_TextChanged(object sender, EventArgs e)
        {
            if (txt_number.Text.Length > 0)
            {
                txt_number_hasValue = true;
            }
            else
            {
                txt_number_hasValue = false;
            }
            btn_reset_setValue();
        }
        private void btn_about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VICS (Voter Information Collection System) Software is developed by Oca Industries and Paonda Technologies. Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), "About");
        }
        private void tbc_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_checkname.Text = "Name: " + txt_first.Text + " " + txt_middle.Text + " " + txt_last.Text;
            if(rdb_pres1.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres1.Text;
            }
            else if (rdb_pres2.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres2.Text;
            }
            else if (rdb_pres3.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres3.Text;
            }
            else if (rdb_pres4.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres4.Text;
            }
            else if (rdb_pres5.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres5.Text;
            }
            else if (rdb_pres6.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres6.Text;
            }
            else if (rdb_pres7.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres7.Text;
            }
            else if (rdb_pres8.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres8.Text;
            }
            else if (rdb_pres9.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres9.Text;
            }
            else if (rdb_pres10.Checked == true)
            {
                lbl_checkpres.Text = "For President: " + rdb_pres10.Text;
            }
            else
            {
                lbl_checkpres.Text = "For President: ";
            }
            if (rdb_vice1.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice1.Text;
            }
            else if (rdb_vice2.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice2.Text;
            }
            else if (rdb_vice3.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice3.Text;
            }
            else if (rdb_vice4.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice4.Text;
            }
            else if (rdb_vice5.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice5.Text;
            }
            else if (rdb_vice6.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice6.Text;
            }
            else if (rdb_vice7.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice7.Text;
            }
            else if (rdb_vice8.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice8.Text;
            }
            else if (rdb_vice9.Checked == true)
            {
                lbl_checkvice.Text = "For Vice President: " + rdb_vice9.Text;
            }
            else
            {
                lbl_checkvice.Text = "For Vice President: ";
            }
            lbl_checkbirthdate.Text = "Birth Date: " + cmb_birthmonth.Text + " " + cmb_birthday.Text + " " + cmb_birthyear.Text;
            if (rdb_male.Checked == true)
            {
                lbl_checkgender.Text = "Gender: Male";
            }
            else if(rdb_female.Checked == true)
            {
                lbl_checkgender.Text = "Gender: Female";
            }
            else
            {
                lbl_checkgender.Text = "Gender: ";
            }
            if (tbc_main.SelectedIndex == 4)
            {
                tbc_main_isSubmit = true;
            }
            else
            {
                tbc_main_isSubmit = false;
            }
            btn_reset_setValue();
        }
        private void rdb_pres1_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres2_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres3_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres4_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres5_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres6_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres7_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres8_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres9_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_pres10_CheckedChanged(object sender)
        {
            rdb_pres_setValue();
        }
        private void rdb_vice1_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice2_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice3_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice4_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice5_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice6_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice7_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice8_CheckedChanged(object sender)
        {
            rdb_vice_setValue();
        }
        private void rdb_vice9_CheckedChanged(object sender)
        {
            rdb_vice_setValue(); 
        }
    }
}