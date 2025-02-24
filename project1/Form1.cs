using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace project1
{
    public partial class Form1 : Form
    {

        static string path = @"Data source = projectdatabase.db;";
        SQLiteConnection connection = new SQLiteConnection(path);
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (bunifuPanel1.Visible == false)
            {
                bunifuTransition1.ShowSync(bunifuPanel1);
                timer2.Start();

            }// Show target tab with animation
            else
            {
                bunifuTransition1.HideSync(bunifuPanel1); // Hide current tab
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            bunifuTransition1.HideSync(bunifuPanel1);
            bunifuPages1.SetPage(tabPage2);
            bunifuTransition1.ShowSync(bunifuPanel3);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            StartPosition.ToString();
        }

        private void girisyap_btn_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(bunifuPanel3);
            bunifuPages1.SetPage(girisyap_tab);
            bunifuTransition1.ShowSync(musteripanel);
        }

        private void yoneticibtn_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(musteripanel);

            bunifuTransition1.ShowSync(yoneticipanel);
        }

        private void musteribtn_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(yoneticipanel);

            bunifuTransition1.ShowSync(musteripanel);
        }

        private void kayitol_btn2_Click(object sender, EventArgs e)
        {
            if (kayitpanel2.Visible == false)
            {
                kayitpanel2.Visible = true;
                tür_panel.Visible = false;
            }
            bunifuTransition1.HideSync(musteripanel);
            bunifuPages1.SetPage(kayittab);
            bunifuTransition1.ShowSync(kayit_panel);
        }

        private void musteri_tc_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void musteri_parola_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void musteri_benihatirla_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void email_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(bunifuPanel3);
            bunifuPages1.SetPage(kayittab);
            bunifuTransition1.ShowSync(kayit_panel);
        }

        private void kayitilerle_btn_Click(object sender, EventArgs e)
        {
            if (isim_textbox.Text.Length == 0 ||
                soyisim_textbox.Text.Length == 0 ||
                kimlikno_textbox.Text.Length == 0 ||
                email_textbox.Text.Length == 0 ||
                telefon_textbox.Text.Length == 0 ||
                parola_textbox.Text.Length == 0 ||
                parolatekrar_textbox.Text.Length == 0)
            {
                MessageBox.Show("Girmediğiniz Bilgiler var\nLütfen İstenen Tüm Bilgileri Giriniz..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (parola_textbox.Text == parolatekrar_textbox.Text)
                {
                    if (kvkk_check.Checked)
                    {
                        bunifuTransition1.HideSync(kayit_panel);
                        bunifuTransition1.ShowSync(tür_panel);
                    }
                    else
                    {
                        MessageBox.Show("KVKK Metinini Okuyup Onaylamanız Gerekir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Parola Tekrarı Doğru Değil.\nLütfen Tekrar Deneyiniz..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void OnaylamaMesajiGoster()
        {
            // Mesaj Kutusunu Göster
            DialogResult result = MessageBox.Show(
                "Çıkış yıpılacak onaylıyor musunuz ?", // Mesaj
                "Onaylama", // Başlık
                MessageBoxButtons.YesNo, // Butonlar (Evet-Hayır)
                MessageBoxIcon.Question // İkon (Soru işareti)
            );

            // Kullanıcı Evet'e bastıysa
            if (result == DialogResult.Yes)
            {
                bunifuTransition1.HideSync(yonetici_main_panel);
                bunifuPages1.SetPage(girisyap_tab);
                bunifuTransition1.ShowSync(musteripanel);
            }
        }

        private void sonayitol_btn_Click(object sender, EventArgs e)
        {
            if (hesapturu_dropdown.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen Hesap Türü Seçin .. ", "Hesap Türü", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string s1 = isim_textbox.Text;
                string s2 = soyisim_textbox.Text;
                string s3 = kimlikno_textbox.Text;
                string s4 = email_textbox.Text;
                string s5 = telefon_textbox.Text;
                string s6 = bunifuDatePicker1.Text;
                string s7 = parola_textbox.Text;
                string s8 = hesapturu_dropdown.Text;

                connection.Open();

                string query = "INSERT INTO musteriler ( isim , soyisim , tcKimlikNo , email , telefonNo , dogumTarihi , parola , hesapTuru , bakiye) VALUES " +
                               "('" + s1 + "' ,'" + s2 + "' ,'" + s3 + "' ,'" + s4 + "', '" + s5 + "','" + s6 + "','" + s7 + "','" + s8 + "' , '" + 500 + "')";

                SQLiteCommand cmnd = new SQLiteCommand(query, connection);
                cmnd.ExecuteNonQuery();

                connection.Close();
                bunifuTransition1.HideSync(kayitpanel2);
                bunifuTransition1.ShowSync(tesekkurler_panel);

                isim_textbox.Clear();
                soyisim_textbox.Clear();
                kimlikno_textbox.Clear();
                email_textbox.Clear();
                telefon_textbox.Clear();
                parola_textbox.Clear();
                parolatekrar_textbox.Clear();
                bunifuDatePicker1.Value = DateTime.Now;
                hesapturu_dropdown.SelectedIndex = -1;
                kvkk_check.Checked = false;

            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            bunifuTransition1.HideSync(tesekkurler_panel);
            bunifuPages1.SetPage(girisyap_tab);
            bunifuTransition1.ShowSync(musteripanel);
        }

        private void girisyap_tab_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormControlBox5_HelpClicked(object sender, EventArgs e)
        {

        }

        private void kayittab_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormControlBox4_HelpClicked(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormControlBox2_HelpClicked(object sender, EventArgs e)
        {

        }

        private void yoneticipanel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {

            string t1 = yonetic_tc_textbox.Text;
            string t2 = bunifuTextBox4.Text; // yonetici girişinde kullandığı şifre textbox

            using (SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.Open();


                string query = "SELECT COUNT(*) FROM yoneticiler WHERE tckimlikNo = '" + t1 + "' AND parola = '" + t2 + "'";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {

                        bunifuTransition1.HideSync(yoneticipanel);
                        bunifuPages1.SetPage(yonetici_tab);
                        bunifuTransition1.ShowSync(yonetici_main_panel);

                        musteri_pages.SetPage(yonetici_home_tab);
                        yonetici_home_panel.Visible = true;
                        bunifuTransition1.ShowSync(yonetici_home_panel);

                        yonetic_tc_textbox.Clear();
                        bunifuTextBox4.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckBox2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void musteripanel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void musterigiris_btn_Click(object sender, EventArgs e)
        {
            string t1 = musteri_tc_textbox.Text;
            string t2 = musteri_parola_textbox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.Open();


                string query = "SELECT COUNT(*) FROM musteriler WHERE tcKimlikNo = '" + t1 + "' AND parola = '" + t2 + "'";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        // laberllara bilgileri aktarmak


                        string query1 = "SELECT isim, soyisim , bakiye , hesapTuru , Id FROM musteriler WHERE tcKimlikNo = '" + t1 + "'";
                        SQLiteCommand comndr = new SQLiteCommand(query1, connection);
                        SQLiteDataReader reader = comndr.ExecuteReader();
                        reader.Read();
                        // İsim ve soyisim bilgilerini oku
                        string isim = reader["isim"].ToString();
                        string soyisim = reader["soyisim"].ToString();
                        string bakiye = reader["bakiye"].ToString();
                        string id = reader["id"].ToString();
                        string hesapturu = reader["hesapTuru"].ToString();


                        // Label'lara bilgileri aktar
                        hesab_sahibi_label.Text = $"{isim} {soyisim}";
                        hesap_no_label.Text = id;
                        hesap_turu_label.Text = hesapturu;
                        musteri_bakiye_hesabim_label.Text = $"{bakiye} TL";

                        bunifuTransition1.HideSync(musteripanel);
                        bunifuPages1.SetPage(musteri_tab_home);

                        musteri_pages.SetPage(musteri_home);
                        musteri_home_panel.Visible = true;
                        bunifuTransition1.ShowSync(musteri_tab_panel);

                        musteri_tc_textbox.Clear();
                        musteri_parola_textbox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormControlBox1_HelpClicked(object sender, EventArgs e)
        {

        }

        private void tesekkurler_panel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void kayitpanel2_Click(object sender, EventArgs e)
        {

        }

        private void tür_panel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void hesapturu_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kayit_panel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kvkk_check_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {

        }

        private void kvkk_Click(object sender, EventArgs e)
        {

        }

        private void parolatekrar_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void parola_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefon_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void kimlikno_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void soyisim_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void isim_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void biligi_panel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFormControlBox3_HelpClicked(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {

        }

        private void musteri_tab_panel_Click(object sender, EventArgs e)
        {

        }

        private void musteri_solbar_Click(object sender, EventArgs e)
        {

        }

        private void musteri_hesabim_panel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton210_Click(object sender, EventArgs e)
        {
            if (musteri_home_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_home_panel);
                musteri_pages.SetPage(musteri_hesabim_tab);
                bunifuTransition1.ShowSync(musteri_hesabim_panel);
            }
            else if (parola_panel.Visible)
            {
                bunifuTransition1.HideSync(parola_panel);
                musteri_pages.SetPage(musteri_hesabim_tab);
                bunifuTransition1.ShowSync(musteri_hesabim_panel);
            }
            else if (alicibilgiler_panel.Visible)
            {
                bunifuTransition1.HideSync(alicibilgiler_panel);
                musteri_pages.SetPage(musteri_hesabim_tab);
                bunifuTransition1.ShowSync(musteri_hesabim_panel);
            }
            else if (musteriler_ayarlar_panel.Visible)
            {
                bunifuTransition1.HideSync(musteriler_ayarlar_panel);
                musteri_pages.SetPage(musteri_parola_tab);
                bunifuTransition1.ShowSync(parola_panel);
            }
        }
        private void hesap_turu_label_Click(object sender, EventArgs e)
        {

        }

        private void eft_btn_Click(object sender, EventArgs e)
        {
            if (musteri_home_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_home_panel);
                musteri_pages.SetPage(musteri_havale_tab);
                bunifuTransition1.ShowSync(alicibilgiler_panel);
            }
            else if (parola_panel.Visible)
            {
                bunifuTransition1.HideSync(parola_panel);
                musteri_pages.SetPage(musteri_havale_tab);
                bunifuTransition1.ShowSync(alicibilgiler_panel);
            }
            else if (musteri_hesabim_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_hesabim_panel);
                musteri_pages.SetPage(musteri_havale_tab);
                bunifuTransition1.ShowSync(alicibilgiler_panel);
            }
            else if (musteriler_ayarlar_panel.Visible)
            {
                bunifuTransition1.HideSync(musteriler_ayarlar_panel);
                musteri_pages.SetPage(musteri_parola_tab);
                bunifuTransition1.ShowSync(parola_panel);
            }

        }

        private void parola_degistir_btn_Click(object sender, EventArgs e)
        {
            if (musteri_home_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_home_panel);
                musteri_pages.SetPage(musteri_parola_tab);
                bunifuTransition1.ShowSync(parola_panel);
            }
            else if (alicibilgiler_panel.Visible)
            {
                bunifuTransition1.HideSync(alicibilgiler_panel);
                musteri_pages.SetPage(musteri_parola_tab);
                bunifuTransition1.ShowSync(parola_panel);
            }
            else if (musteri_hesabim_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_hesabim_panel);
                musteri_pages.SetPage(musteri_parola_tab);
                bunifuTransition1.ShowSync(parola_panel);
            }
            else if (musteriler_ayarlar_panel.Visible)
            {
                bunifuTransition1.HideSync(musteriler_ayarlar_panel);
                musteri_pages.SetPage(musteri_parola_tab);
                bunifuTransition1.ShowSync(parola_panel);
            }

        }

        private void bunifuButton25_Click(object sender, EventArgs e)
        {
            OnaylamaMesajiGoster();
        }

        private void bunifuButton23_Click(object sender, EventArgs e)
        {
            string p1 = EskiParola_textbox.Text;
            string p2 = yeniParola_textbox.Text;
            string p3 = yeniParolaTekrar_textbox.Text;
            short p4 = Convert.ToInt16(hesap_no_label.Text);

            if (p2 != p3)
            {
                MessageBox.Show("Yeni parolalar eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                connection.Open();

                // 1. Adım: Eski parolanın doğru olup olmadığını kontrol et 
                string selectQuery = "SELECT COUNT(*) FROM musteriler WHERE parola = '" + p1 + "' ";

                using (SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection))
                {
                    // Sonuç döner (1 = doğru, 0 = yanlış)
                    int result = Convert.ToInt32(selectCommand.ExecuteScalar());

                    if (result == 0)
                    {
                        MessageBox.Show("Eski parola yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // 2. Adım: Yeni parolayı güncelle
                        string updateQuery = "UPDATE musteriler SET Parola = '" + p2 + "' WHERE Id = '" + p4 + "' ";
                        using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                        {

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Parola başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                EskiParola_textbox.Clear();
                                yeniParola_textbox.Clear();
                                yeniParolaTekrar_textbox.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Parola güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                }
                connection.Close();
            }


        }

        private void ayarlar_btn_Click(object sender, EventArgs e)
        {
            if (musteri_home_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_home_panel);
                musteri_pages.SetPage(musteriler_ayarlar_tab);
                bunifuTransition1.ShowSync(musteriler_ayarlar_panel);
            }
            else if (alicibilgiler_panel.Visible)
            {
                bunifuTransition1.HideSync(alicibilgiler_panel);
                musteri_pages.SetPage(musteriler_ayarlar_tab);
                bunifuTransition1.ShowSync(musteriler_ayarlar_panel);
            }
            else if (musteri_hesabim_panel.Visible)
            {
                bunifuTransition1.HideSync(musteri_hesabim_panel);
                musteri_pages.SetPage(musteriler_ayarlar_tab);
                bunifuTransition1.ShowSync(musteriler_ayarlar_panel);
            }
            else if (parola_panel.Visible)
            {
                bunifuTransition1.HideSync(parola_panel);
                musteri_pages.SetPage(musteriler_ayarlar_tab);
                bunifuTransition1.ShowSync(musteriler_ayarlar_panel);
            }
        }

        private void bunifuButton26_Click(object sender, EventArgs e)
        {

            string e1 = alicininismi_textbox.Text;
            string e2 = alicinin_no_textbox.Text;  // alıcının id no
            short e3 = Convert.ToInt16(tutar_textbox.Text); // gönderilecek tutar
            int e4;    // göndericinin bakiyesi
            short e5 = Convert.ToInt16(hesap_no_label.Text); // göndericinin id numarası
            short e6 = Convert.ToInt16(alicinin_no_textbox.Text);// alıcının id numarası integer


            string query = "SELECT bakiye FROM musteriler WHERE Id = '" + e5 + "'";

            using (SQLiteConnection connection = new SQLiteConnection(path))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    e4 = Convert.ToInt32(result); // Bakiye değerini değişkene atıyoruz

                }
                connection.Close();
            }

            string query2 = "SELECT COUNT(*) FROM musteriler WHERE isim = '" + e1 + "' AND Id = '" + e2 + "' ";

            using (SQLiteCommand command2 = new SQLiteCommand(query2, connection))
            {
                connection.Open();

                int count = Convert.ToInt32(command2.ExecuteScalar());

                if (count > 0) // veritabanda böyle bir alıcı olup olmadığı tesbiti
                {
                    if (e4 < e3)
                    {
                        MessageBox.Show("bakiuye yetersiz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string updateQuery = " UPDATE musteriler SET bakiye = bakiye - '" + e3 + "' WHERE id = '" + e5 + "';" +
                                             " UPDATE musteriler SET bakiye = bakiye + '" + e3 + "' WHERE id = '" + e6 + "'";


                        using (SQLiteCommand command = new SQLiteCommand(updateQuery, connection))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("İşleminiz Gerçekleştirildi ..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            alicininismi_textbox.Clear();
                            alicinin_no_textbox.Clear();
                            tutar_textbox.Clear();
                        }


                    }

                }
                else
                {
                    MessageBox.Show("Alıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                connection.Close();
            }

        }

        private void bunifuButton215_Click(object sender, EventArgs e)
        {
            if (yonetici_home_panel.Visible)
            {
                grafiklistele();
                bunifuTransition1.HideSync(yonetici_home_panel);
                yonetici_pages.SetPage(yonetici_chart_tab);
                bunifuTransition1.ShowSync(chart_panel);
            }
            else if (yoetici_kullaniciler_panel.Visible)
            {
                grafiklistele();
                bunifuTransition1.HideSync(yoetici_kullaniciler_panel);
                yonetici_pages.SetPage(yonetici_chart_tab);
                bunifuTransition1.ShowSync(chart_panel);
            }
            else if (yonetici_ayarlar_panel.Visible)
            {
                grafiklistele();
                bunifuTransition1.HideSync(yonetici_ayarlar_panel);
                yonetici_pages.SetPage(yonetici_chart_tab);
                bunifuTransition1.ShowSync(chart_panel);
            }
            else if (yonetici_ekle_panel.Visible)
            {
                grafiklistele();
                bunifuTransition1.HideSync(yonetici_ekle_panel);
                yonetici_pages.SetPage(yonetici_chart_tab);
                bunifuTransition1.ShowSync(chart_panel);
            }
        }

        private void grafiklistele()
        {
            chart1.Series["HesapTurleri"].Points.Clear();
            connection.Open();
            SQLiteCommand commend = new SQLiteCommand("SELECT hesapTuru,COUNT(*) FROM musteriler GROUP BY hesapTuru", connection);
            SQLiteDataReader reader = commend.ExecuteReader();
            while (reader.Read())
            {
                chart1.Series["HesapTurleri"].Points.AddXY(reader[0], reader[1]);
            }
            connection.Close();
        }

        private void bunifuButton213_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton214_Click(object sender, EventArgs e)
        {
            if (yonetici_home_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_home_panel);
                yonetici_pages.SetPage(yonetici_ekleSil_tab);
                bunifuTransition1.ShowSync(yonetici_ekle_panel);
            }
            else if (chart_panel.Visible)
            {
                bunifuTransition1.HideSync(chart_panel);
                yonetici_pages.SetPage(yonetici_ekleSil_tab);
                bunifuTransition1.ShowSync(yonetici_ekle_panel);
            }
            else if (yonetici_ayarlar_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_ayarlar_panel);
                yonetici_pages.SetPage(yonetici_ekleSil_tab);
                bunifuTransition1.ShowSync(yonetici_ekle_panel);
            }
            else if (yoetici_kullaniciler_panel.Visible)
            {
                bunifuTransition1.HideSync(yoetici_kullaniciler_panel);
                yonetici_pages.SetPage(yonetici_ekleSil_tab);
                bunifuTransition1.ShowSync(yonetici_ekle_panel);
            }
        }

        private void bunifuButton216_Click(object sender, EventArgs e)
        {

            listele();

            if (yonetici_home_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_home_panel);
                yonetici_pages.SetPage(yonetici_kullanıcılar_tab);
                bunifuTransition1.ShowSync(yoetici_kullaniciler_panel);
            }
            else if (chart_panel.Visible)
            {
                bunifuTransition1.HideSync(chart_panel);
                yonetici_pages.SetPage(yonetici_kullanıcılar_tab);
                bunifuTransition1.ShowSync(yoetici_kullaniciler_panel);
            }
            else if (yonetici_ayarlar_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_ayarlar_panel);
                yonetici_pages.SetPage(yonetici_kullanıcılar_tab);
                bunifuTransition1.ShowSync(yoetici_kullaniciler_panel);
            }
            else if (yonetici_ekle_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_ekle_panel);
                yonetici_pages.SetPage(yonetici_kullanıcılar_tab);
                bunifuTransition1.ShowSync(yoetici_kullaniciler_panel);
            }

        }

        private void listele()
        {
            connection.Open();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(" SELECT Id , isim , soyisim , tcKimlikNo ,telefonNo, bakiye , hesapTuru FROM musteriler ", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            bunifuDataGridView1.DataSource = table;
            connection.Close();
        }

        private void bunifuPanel23_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logout_yonetici_Click(object sender, EventArgs e)
        {
            OnaylamaMesajiGoster();
        }

        private void bunifuButton212_Click(object sender, EventArgs e)
        {

            if (yonetici_home_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_home_panel);
                yonetici_pages.SetPage(yoneticiler_ayarlar_tab);
                bunifuTransition1.ShowSync(yonetici_ayarlar_panel);
            }
            else if (chart_panel.Visible)
            {
                bunifuTransition1.HideSync(chart_panel);
                yonetici_pages.SetPage(yoneticiler_ayarlar_tab);
                bunifuTransition1.ShowSync(yonetici_ayarlar_panel);
            }
            else if (yoetici_kullaniciler_panel.Visible)
            {
                bunifuTransition1.HideSync(yoetici_kullaniciler_panel);
                yonetici_pages.SetPage(yoneticiler_ayarlar_tab);
                bunifuTransition1.ShowSync(yonetici_ayarlar_panel);
            }
            else if (yonetici_ekle_panel.Visible)
            {
                bunifuTransition1.HideSync(yonetici_ekle_panel);
                yonetici_pages.SetPage(yoneticiler_ayarlar_tab);
                bunifuTransition1.ShowSync(yonetici_ayarlar_panel);
            }

        }

        private void yoetici_kullaniciler_panel_Click(object sender, EventArgs e)
        {

        }

        private void yonetici_ekle_panel_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void kullanıcıEkle_btn_Click(object sender, EventArgs e)
        {
            if (Eyonetici_isim_textbox.Text.Length == 0 ||
                Eyonetici_soyisim_textbox.Text.Length == 0 ||
                Eyonetici_tc_textbox.Text.Length == 0 ||
                Eyonetici_email_textbox.Text.Length == 0 ||
                Eyonetici_Tel_textbox.Text.Length == 0 ||
                Eyonetici_parola_textbox.Text.Length == 0)
            {
                MessageBox.Show("Girmediğiniz Bilgiler var\nLütfen İstenen Tüm Bilgileri Giriniz..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Eyonetici_hesapTuru_textbox.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen Hesap Türü Seçin .. ", "Hesap Türü", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string s1 = Eyonetici_isim_textbox.Text;
                    string s2 = Eyonetici_soyisim_textbox.Text;
                    string s3 = Eyonetici_tc_textbox.Text;
                    string s4 = Eyonetici_email_textbox.Text;
                    string s5 = Eyonetici_Tel_textbox.Text;
                    string s6 = Eyonetici_dogum_textbox.Text;
                    string s7 = Eyonetici_parola_textbox.Text;
                    string s8 = Eyonetici_hesapTuru_textbox.Text;

                    connection.Open();

                    string query = "INSERT INTO musteriler ( isim , soyisim , tcKimlikNo , email , telefonNo , dogumTarihi , parola , hesapTuru , bakiye) VALUES " +
                                   "('" + s1 + "' ,'" + s2 + "' ,'" + s3 + "' ,'" + s4 + "', '" + s5 + "','" + s6 + "','" + s7 + "','" + s8 + "' , '" + 500 + "')";

                    SQLiteCommand cmnd = new SQLiteCommand(query, connection);
                    cmnd.ExecuteNonQuery();

                    connection.Close();

                    MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Eklendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Eyonetici_isim_textbox.Clear();
                    Eyonetici_soyisim_textbox.Clear();
                    Eyonetici_tc_textbox.Clear();
                    Eyonetici_email_textbox.Clear();
                    Eyonetici_Tel_textbox.Clear();
                    Eyonetici_parola_textbox.Clear();
                    Eyonetici_dogum_textbox.Value = DateTime.Now;
                    Eyonetici_hesapTuru_textbox.SelectedIndex = -1;

                }
            }
        }

        private void kullaniciSil_btn_Click(object sender, EventArgs e)
        {

            string c1 = yonetici_sil_no_textbox.Text;
            string c2 = yonetici_sil_isim_textbox.Text;

            string query2 = "SELECT COUNT(*) FROM musteriler WHERE isim = '" + c2 + "' AND Id = '" + c1 + "' ";

            using (SQLiteCommand command2 = new SQLiteCommand(query2, connection))
            {
                connection.Open();

                int count = Convert.ToInt32(command2.ExecuteScalar());

                if (count > 0) // veritabanda böyle bir kullanıcı olup olmadığı tesbiti
                {
                    connection.Close();
                    connection.Open();

                    string deletequery = "DELETE FROM musteriler WHERE id = '" + c1 + "' ";
                    SQLiteCommand delcommend = new SQLiteCommand(deletequery, connection);
                    delcommend.ExecuteNonQuery();
                    MessageBox.Show("İşleminiz Gerçekleştirildi ..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    yonetici_sil_no_textbox.Clear();
                    yonetici_sil_isim_textbox.Clear();
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ;

            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
