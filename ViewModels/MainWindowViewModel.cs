using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DaftarMahasiswaApp.ViewModels;

// Partial class wajib digunakan agar CommunityToolkit bisa meng-generate kode secara otomatis di belakang layar
public partial class MainWindowViewModel : ViewModelBase
{
    // 1. Wadah untuk menampung teks dari form input
    [ObservableProperty]
    private string _inputNama = string.Empty;

    // 2. Wadah untuk menampung teks sapaan "Hello {nama}!"
    [ObservableProperty]
    private string _teksSapaan = string.Empty;

    // 3. Wadah besar untuk daftar mahasiswa (Menggunakan ObservableCollection agar UI otomatis update)
    [ObservableProperty]
    private ObservableCollection<string> _daftarMahasiswa = new ObservableCollection<string>();

    // 4. Wadah untuk mendeteksi baris mana yang sedang diklik user di List (untuk dihapus nanti)
    [ObservableProperty]
    private string? _mahasiswaTerpilih;

    // Skill 1: Menambah Mahasiswa
    [RelayCommand]
    private void TambahMahasiswa()
    {
        // Cek dulu, jangan sampai wadah inputnya kosong atau cuma spasi
        if (!string.IsNullOrWhiteSpace(InputNama))
        {
            // Set output sapaan sesuai instruksi tugas
            TeksSapaan = $"Hello {InputNama}!";
            
            // Masukkan data ke dalam list daftar mahasiswa
            DaftarMahasiswa.Add(InputNama);
            
            // Kosongkan form input kembali agar user bisa mengetik nama baru
            InputNama = string.Empty;
        }
    }

    // Skill 2: Menghapus Mahasiswa
    [RelayCommand]
    private void HapusMahasiswa()
    {
        // Cek apakah ada mahasiswa yang sedang dipilih di List
        if (!string.IsNullOrWhiteSpace(MahasiswaTerpilih))
        {
            // Hapus dari daftar
            DaftarMahasiswa.Remove(MahasiswaTerpilih);
            
            // Kembalikan status pilihan menjadi kosong
            MahasiswaTerpilih = null;
        }
    }
}