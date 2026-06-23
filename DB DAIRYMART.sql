DROP VIEW IF EXISTS v_laporan_penjualan_rollup CASCADE;
DROP VIEW IF EXISTS v_riwayat_global CASCADE;
DROP VIEW IF EXISTS v_stok_kulkas CASCADE;
DROP VIEW IF EXISTS v_stok_gudang CASCADE;
DROP PROCEDURE IF EXISTS sp_checkout_langganan CASCADE;
DROP PROCEDURE IF EXISTS sp_kasir_jualan CASCADE;
DROP FUNCTION IF EXISTS fn_cegah_stok_minus CASCADE;
DROP FUNCTION IF EXISTS fn_catat_log_transaksi CASCADE;

DROP TABLE IF EXISTS shift_kasir CASCADE;
DROP TABLE IF EXISTS supplier CASCADE;
DROP TABLE IF EXISTS transaksi_offline CASCADE;
DROP TABLE IF EXISTS log_transaksi CASCADE;
DROP TABLE IF EXISTS langganan CASCADE;
DROP TABLE IF EXISTS produk CASCADE;
DROP TABLE IF EXISTS pelanggan CASCADE;
DROP TABLE IF EXISTS metode_pembayaran CASCADE;
DROP TABLE IF EXISTS kategori_produk CASCADE;
DROP TABLE IF EXISTS area CASCADE;

-- [1] DDL

-- Tabel 1 & 2: Master Area & Kategori
CREATE TABLE area (
    id_area SERIAL PRIMARY KEY, 
    nama_area VARCHAR(100) NOT NULL
);

CREATE TABLE kategori_produk (
    id_kategori SERIAL PRIMARY KEY, 
    nama_kategori VARCHAR(100) NOT NULL
);

-- Tabel 3: Metode Pembayaran
CREATE TABLE metode_pembayaran (
    id_metode SERIAL PRIMARY KEY, 
    nama_metode VARCHAR(50) NOT NULL
);

-- Tabel 4: Pelanggan (Berfungsi sebagai Data Users / Login)
CREATE TABLE pelanggan (
    id_pelanggan SERIAL PRIMARY KEY, 
    id_area INT REFERENCES area(id_area), 
    nama_pelanggan VARCHAR(150) NOT NULL, 
    no_wa VARCHAR(20) UNIQUE NOT NULL, 
    password VARCHAR(255) NOT NULL, 
    alamat_detail TEXT,
    role VARCHAR(50) NOT NULL -- 'Admin', 'Kasir', 'Pelanggan'
);

-- Tabel 5: Produk (Sudah digabung stok online & offline sejak awal)
CREATE TABLE produk (
    id_produk SERIAL PRIMARY KEY, 
    id_kategori INT REFERENCES kategori_produk(id_kategori), 
    nama_produk VARCHAR(150) NOT NULL, 
    ukuran VARCHAR(50), 
    harga INT NOT NULL,
    stok_online INT NOT NULL DEFAULT 0,    -- Untuk Konsumen Online (Checkout)
    stok_offline INT NOT NULL DEFAULT 0,   -- Untuk Kulkas Toko (Kasir)
    tgl_kadaluarsa DATE,                   
    status_kelayakan VARCHAR(50) DEFAULT 'Susu Segar'
);

-- Tabel 6: Langganan (Transaksi Online Konsumen)
CREATE TABLE langganan (
    id_langganan SERIAL PRIMARY KEY, 
    id_pelanggan INT REFERENCES pelanggan(id_pelanggan), 
    id_produk INT REFERENCES produk(id_produk), 
    id_metode INT REFERENCES metode_pembayaran(id_metode), 
    jumlah INT NOT NULL DEFAULT 1, 
    total_bayar INT NOT NULL, 
    tanggal_transaksi TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel 7: Transaksi Offline (BARU: Khusus Kasir Jualan Langsung)
CREATE TABLE transaksi_offline (
    id_transaksi SERIAL PRIMARY KEY,
    id_produk INT REFERENCES produk(id_produk),
    kuantitas INT NOT NULL,
    total_harga NUMERIC(12,2) NOT NULL,
    tgl_transaksi TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel 8: Log Transaksi (Diisi otomatis oleh Trigger)
CREATE TABLE log_transaksi (
    id_log SERIAL PRIMARY KEY, 
    keterangan VARCHAR(255), 
    waktu TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabel 9 & 10: Supplier & Shift Kasir (Tabel Pasif / Pelengkap Syarat 10 Tabel)
CREATE TABLE supplier (
    id_supplier SERIAL PRIMARY KEY,
    nama_supplier VARCHAR(100) NOT NULL,
    kontak_hp VARCHAR(20)
);

CREATE TABLE shift_kasir (
    id_shift SERIAL PRIMARY KEY,
    id_pelanggan INT REFERENCES pelanggan(id_pelanggan),
    waktu_login TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- [2] DML: INSERT DATA AWAL

INSERT INTO area (nama_area) VALUES ('Pusat Kota (Default)');
INSERT INTO kategori_produk (nama_kategori) VALUES ('Susu Segar Botolan');
INSERT INTO metode_pembayaran (nama_metode) VALUES ('1. QRIS'), ('2. GoPay'), ('3. DANA'), ('4. ShopeePay');
INSERT INTO supplier (nama_supplier) VALUES ('Peternakan Sapi Jember');

-- Akun Login: Admin dan Pembeli
INSERT INTO pelanggan (id_area, nama_pelanggan, no_wa, password, alamat_detail, role) VALUES
(1, 'Admin', '085704578323', 'admin123', 'Kantor Pusat', 'Admin'),
(1, 'Kasir', '085183166370', 'kasir123', 'Toko Cabang', 'Kasir');

-- Data Produk
INSERT INTO produk (id_kategori, nama_produk, ukuran, harga, stok_online, stok_offline, tgl_kadaluarsa, status_kelayakan) VALUES 
(1, 'Susu Segar 1000 ML', '1000 ML', 25000, 100, 50, '2026-08-15', 'Susu Segar'), 
(1, 'Susu Segar 750 ML', '750 ML', 20000, 45, 20, '2026-06-12', 'Hampir Kadaluarsa'),
(1, 'Susu Segar 500 ML', '500 ML', 15000, 100, 50, '2026-12-31', 'Susu Segar');


-- [3] VIEWS 

CREATE OR REPLACE VIEW v_stok_kulkas AS
SELECT p.id_produk, p.nama_produk, k.nama_kategori, p.stok_offline, p.tgl_kadaluarsa, p.status_kelayakan,
    CASE WHEN p.stok_offline = 0 THEN 'HABIS' WHEN p.stok_offline < 10 THEN 'MENIPIS' ELSE 'AMAN' END AS status_stok_kulkas
FROM produk p JOIN kategori_produk k ON p.id_kategori = k.id_kategori;

CREATE OR REPLACE VIEW v_stok_gudang AS
SELECT p.id_produk, p.nama_produk, k.nama_kategori, p.stok_online, p.tgl_kadaluarsa, p.status_kelayakan,
    CASE WHEN p.stok_online = 0 THEN 'HABIS' WHEN p.stok_online < 10 THEN 'MENIPIS' ELSE 'AMAN' END AS status_stok_gudang
FROM produk p JOIN kategori_produk k ON p.id_kategori = k.id_kategori;

CREATE OR REPLACE VIEW v_riwayat_global AS
SELECT 
    'Offline (Kasir)' AS sumber_transaksi,
    (SELECT nama_produk FROM produk WHERE id_produk = t.id_produk) AS nama_produk, 
    t.total_harga AS nominal,
    t.tgl_transaksi AS tanggal
FROM transaksi_offline t
UNION ALL 
SELECT 
    'Online (Langganan)' AS sumber_transaksi,
    (SELECT nama_produk FROM produk WHERE id_produk = l.id_produk) AS nama_produk, 
    l.total_bayar AS nominal,
    l.tanggal_transaksi AS tanggal
FROM langganan l;


-- [4] FUNCTIONS & TRIGGERS (Syarat 7 & 10)

-- A. Cegah Stok Minus (Statement IF)
CREATE OR REPLACE FUNCTION fn_cegah_stok_minus() RETURNS TRIGGER AS $$
BEGIN
    IF NEW.stok_online < 0 THEN RAISE EXCEPTION 'Stok Gudang (Online) tidak mencukupi!'; END IF;
    IF NEW.stok_offline < 0 THEN RAISE EXCEPTION 'Stok Kulkas (Offline) tidak mencukupi!'; END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER trg_cegah_stok_minus BEFORE UPDATE ON produk FOR EACH ROW EXECUTE FUNCTION fn_cegah_stok_minus();

CREATE OR REPLACE FUNCTION fn_catat_log_global() 
RETURNS TRIGGER AS $$
BEGIN
    -- 1. Cek apakah yang masuk adalah transaksi Online (Tabel langganan)
    IF TG_TABLE_NAME = 'langganan' THEN
        INSERT INTO log_transaksi (keterangan)
        VALUES ('[ONLINE] Transaksi Langganan Baru! ID Produk ' || NEW.id_produk || ' terjual sebanyak ' || NEW.jumlah || ' pcs.');
        
    -- 2. Cek apakah yang masuk adalah transaksi Offline (Tabel transaksi_offline)
    ELSIF TG_TABLE_NAME = 'transaksi_offline' THEN
        INSERT INTO log_transaksi (keterangan)
        VALUES ('[OFFLINE] Kasir Toko Jualan! ID Produk ' || NEW.id_produk || ' laku eceran sebanyak ' || NEW.kuantitas || ' pcs.');
    END IF;

    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- 1. Buat Fungsi Logikanya (Menghitung selisih hari)
CREATE OR REPLACE FUNCTION fn_cek_status_kelayakan()
RETURNS TRIGGER AS $$
BEGIN
    -- Sistem mengecek tanggal yang baru diinput/diupdate oleh Admin
    IF CURRENT_DATE > NEW.tgl_kadaluarsa THEN
        NEW.status_kelayakan := 'Kadaluarsa';
        
    ELSIF (NEW.tgl_kadaluarsa - CURRENT_DATE) <= 7 THEN
        NEW.status_kelayakan := 'Hampir Kadaluarsa';
        
    ELSE
        NEW.status_kelayakan := 'Susu Segar';
    END IF;

    -- Kembalikan data yang sudah dikalibrasi statusnya ke tabel
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;


CREATE TRIGGER trg_update_status_otomatis
BEFORE INSERT OR UPDATE ON produk
FOR EACH ROW 
EXECUTE FUNCTION fn_cek_status_kelayakan();
