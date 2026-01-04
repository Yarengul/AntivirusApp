using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // Şifreleme (Cryptography) kütüphanesi
using System.IO; // Dosya Giriş/Çıkış (Input/Output) kütüphanesi

namespace AntivirusApp
{
    public partial class Form1 : Form
    {
        // Basit bir virüs imza veritabanı (MD5 Hash Listesi)
        // Buradaki hash değerleri temsilidir.
        string[] virusSignatures = {
            "44d88612fea8a8f36de82e1278abb02f",
            "5d41402abc4b2a76b9719d911017c592"
        };

        public Form1()
        {
            InitializeComponent();
        }

        // MD5 Hesaplama Fonksiyonu (MD5 Calculation Function)
        public string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    // Byte dizisini okunabilir metne (hexadecimal) çeviriyoruz
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        // Dosya Tara Butonu Tıklama Olayı (File Scan Button Click Event)
        private void btnScanFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Taranacak Dosyayı Seçin (Select File to Scan)";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = ofd.FileName;
                lblStatus.Text = "Taranıyor: " + Path.GetFileName(selectedFilePath);

                try
                {
                    // Dosyanın hash değerini hesapla
                    string fileHash = CalculateMD5(selectedFilePath);

                    // Sonucu ListBox'a ekle
                    lstResults.Items.Add("Dosya: " + selectedFilePath);
                    lstResults.Items.Add("MD5: " + fileHash);

                    // Virüs listesiyle karşılaştır
                    bool isVirus = false;
                    foreach (string signature in virusSignatures)
                    {
                        if (fileHash == signature)
                        {
                            isVirus = true;
                            break;
                        }
                    }

                    if (isVirus)
                    {
                        lstResults.Items.Add("DURUM: TEHLİKELİ! (VIRUS DETECTED)");
                        MessageBox.Show("Tehlike Tespit Edildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        lstResults.Items.Add("DURUM: GÜVENLİ (CLEAN)");
                    }

                    lstResults.Items.Add("------------------------------------");
                    lblStatus.Text = "Tarama Tamamlandı.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void btnScanFolder_Click(object sender, EventArgs e)
        {
            // Klasör seçme penceresini aç (Folder Browser Dialog)
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Taramak istediğiniz klasörü seçin (Select Folder to Scan)";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = fbd.SelectedPath;
                // Klasördeki tüm dosyaları al (Get all files in the directory)
                string[] files = Directory.GetFiles(selectedPath, "*.*", SearchOption.AllDirectories);

                // Progress bar ayarlarını yap (Setup progress bar)
                prgStatus.Minimum = 0;
                prgStatus.Maximum = files.Length;
                prgStatus.Value = 0;

                lstResults.Items.Clear(); // Önceki sonuçları temizle
                lblStatus.Text = "Klasör taranıyor...";

                int virusCount = 0;

                foreach (string file in files)
                {
                    try
                    {
                        string fileHash = CalculateMD5(file);
                        bool isVirus = false;

                        foreach (string signature in virusSignatures)
                        {
                            if (fileHash == signature)
                            {
                                isVirus = true;
                                virusCount++;
                                break;
                            }
                        }

                        // Sadece virüs bulunursa veya her dosyayı göstermek isterseniz:
                        if (isVirus)
                        {
                            lstResults.Items.Add("TEHLİKELİ: " + Path.GetFileName(file));
                        }

                        // İlerlemeyi güncelle
                        prgStatus.Value++;
                    }
                    catch (Exception)
                    {
                        // Bazı dosyalara erişim yetkisi olmayabilir, onları atla
                        continue;
                    }
                }

                lblStatus.Text = $"Tarama bitti. {files.Length} dosya tarandı, {virusCount} virüs bulundu.";
                MessageBox.Show($"Tarama tamamlandı!\nBulunan Virüs: {virusCount}", "Tarama Sonucu (Scan Result)");
            }
        }
        // Silme İşlemi (Delete Action)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                string selectedLine = lstResults.SelectedItem.ToString();

                // ListBox'taki metinden dosya yolunu ayıklamamız gerekebilir 
                // Basitlik için sadece dosya yolu yazdırılan satırları seçtiğinizi varsayıyoruz
                if (File.Exists(selectedLine))
                {
                    try
                    {
                        File.Delete(selectedLine);
                        MessageBox.Show("Dosya başarıyla silindi.", "Başarılı (Success)");
                        lstResults.Items.Remove(lstResults.SelectedItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya silinemedi: " + ex.Message);
                    }
                }
            }
        }

        // Karantina İşlemi (Quarantine Action)
        private void btnQuarantine_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedItem != null)
            {
                string sourceFile = lstResults.SelectedItem.ToString();
                string quarantinePath = Path.Combine(Application.StartupPath, "Quarantine");

                if (!Directory.Exists(quarantinePath))
                    Directory.CreateDirectory(quarantinePath);

                if (File.Exists(sourceFile))
                {
                    try
                    {
                        string destFile = Path.Combine(quarantinePath, Path.GetFileName(sourceFile));
                        File.Move(sourceFile, destFile); // Dosyayı taşı (Move)

                        MessageBox.Show("Dosya Karantina klasörüne taşındı.", "Karantina");
                        lstResults.Items.Remove(lstResults.SelectedItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Taşıma hatası: " + ex.Message);
                    }
                }
            }
        }

    }
}