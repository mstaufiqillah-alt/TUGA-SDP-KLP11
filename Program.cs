using System;
using System.IO;
using System.Windows.Forms;
using dps.Forms;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace dps
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            // Atur konfigurasi visual standar Windows Forms secara manual
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Load appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // 2. Tes koneksi database Laragon sebelum Form terbuka (Opsional)
            string connString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    // Komentar baris di bawah jika tidak ingin memunculkan pop-up sukses setiap aplikasi dibuka
                    //MessageBox.Show("Koneksi Laragon Berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal terhubung ke database Laragon:\n" + ex.Message, "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 3. Jalankan Form utama Anda
            Application.Run(new LoginForm());
        }
    }
}