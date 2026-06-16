# 🥛 DairyMart : Sistem Informasi Kasir dan Layanan Langganan Susu Pasteurisasi Ambulu

DairyMart adalah aplikasi *Point of Sale* (POS) dan Sistem Manajemen Inventaris cerdas yang dibangun menggunakan **C# (.NET Windows Forms)** dan **PostgreSQL**. Aplikasi ini dirancang khusus untuk memisahkan logika penjualan fisik (toko/kasir) dan penjualan digital (online/langganan) dalam satu ekosistem *database* yang terintegrasi.

---

## 📖 Latar Belakang
Dalam bisnis retail modern (khususnya produk *FMCG* seperti susu dan olahannya), sering terjadi selisih stok karena pencampuran antara barang yang ada di etalase toko (siap jual) dan barang yang ada di gudang (untuk pengiriman online). 

DairyMart hadir untuk menyelesaikan masalah tersebut dengan menerapkan **Separation of Stock Concept**. Stok barang secara tegas dipisah menjadi dua entitas dalam database:
- `stok_offline`: Alokasi stok fisik di kulkas toko untuk dijual langsung oleh Kasir.
- `stok_online`: Alokasi stok di gudang untuk memenuhi pesanan aplikasi/langganan Pelanggan.

## 🎯 Tujuan
1. **Penerapan Konsep Relational Database Terstruktur:** Mengimplementasikan 10 tabel yang saling berelasi dengan integritas data yang tinggi.
2. **Otomatisasi Database (Database-Driven Logic):** Memanfaatkan fitur *native* PostgreSQL seperti *Views*, *Triggers*, *Stored Procedures*, dan *Transactions* untuk memindahkan beban komputasi berat dari aplikasi (C#) ke dalam *database*.
3. **Role-Based Access Control (RBAC):** Memberikan batasan ruang lingkup kerja yang jelas antara pengelola toko, kasir, dan pelanggan demi keamanan data.

---

## 👥 Role & Hak Akses
Sistem ini membagi pengguna ke dalam 3 *role* utama dengan batasan akses (*view*) yang diatur ketat oleh *database*:

1. **👑 Admin (Pemilik/Manajer)**
   - Mengelola master data (kategori, metode pembayaran, dll).
   - Memiliki akses *CRUD* penuh terhadap **Stok Online (Gudang)**.
   - Memantau laporan keuangan global (gabungan transaksi online & offline).
2. **🧑‍🍳 Kasir (Frontliner Toko)**
   - Hanya memiliki visibilitas terhadap **Stok Offline (Kulkas Etalase)**.
   - Melakukan transaksi penjualan fisik (potong stok offline secara langsung).
3. **📱 Pelanggan (Konsumen Online)**
   - Melakukan pemesanan *checkout* atau langganan melalui aplikasi.
   - Transaksi pelanggan secara otomatis akan memotong **Stok Online** tanpa mengganggu ketersediaan barang di kulkas toko.

---

## ✨ Fitur Utama & Implementasi Database
Aplikasi ini tidak hanya mengandalkan *System Code* (C#), tetapi juga memaksimalkan kapabilitas RDBMS PostgreSQL:

* **Dual-Transaction Engines (Stored Procedures):** Terdapat dua mesin transaksi berbeda (`sp_kasir_jualan` dan `sp_checkout_langganan`) yang memastikan pemotongan stok tepat sasaran dan diikat oleh blok `COMMIT`/`ROLLBACK` (*Transaction*) untuk mencegah anomali data.
* **Auto-Audit Log (Triggers):** Sistem otomatis mencatat setiap mutasi transaksi dan memblokir upaya pengubahan stok menjadi minus (`fn_cegah_stok_minus`).
* **Smart Data Aggregation (Views & Rollup):** Laporan pendapatan global disajikan menggunakan *Teori Himpunan (UNION)* untuk menggabungkan dua sumber transaksi berbeda, serta menggunakan fungsi agregasi *ROLLUP* untuk kalkulasi *Grand Total* yang dinamis.
* **Seamless UI/UX:** Antarmuka C# WinForms yang intuitif dengan fitur deteksi penamaan produk (*Data Mapping*) untuk meminimalisir *human error* saat *checkout*.

---

## 🛠️ Tech Stack
* **Frontend / Application Logic:** C# (.NET Windows Forms)
* **Database Management System:** PostgreSQL
* **Data Provider:** Npgsql
* **Architecture:** Object-Oriented Programming (OOP) & Database-Driven Architecture
