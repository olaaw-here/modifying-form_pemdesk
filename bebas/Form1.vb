Imports System.Data.Odbc

Public Class Form1

    Dim conn As OdbcConnection
    Dim cmd As OdbcCommand
    Dim dr As OdbcDataReader

    Dim dtRinci As New DataTable()

    Dim hargaJualTerpilih As Integer = 0
    Dim fakturCetak As String = ""
    Dim pelangganCetak As String = ""
    Dim tanggalCetak As Date = Date.Now
    Dim totalCetak As Integer = 0

    Sub koneksi()
        conn = New OdbcConnection("Dsn=konek_dblatihan;Database=db_latihan;Uid=root;Pwd=")
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                MsgBox("koneksi berhasil")
            End If
        Catch ex As Exception
            MsgBox("Koneksi Gagal.." & ex.Message)
        End Try
    End Sub

    Sub IsiComboPelanggan()
        Try
            Dim query As String = "SELECT kode_pelanggan FROM tbl_pelanggan"
            cmd = New OdbcCommand(query, conn)
            dr = cmd.ExecuteReader()
            cbPelanggan.Items.Clear()
            While dr.Read()
                cbPelanggan.Items.Add(dr("kode_pelanggan").ToString())
            End While
            dr.Close()
        Catch ex As Exception
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Sub IsiComboBarang()
        Try
            Dim query As String = "SELECT Nama_Barang FROM tblbarang"
            cmd = New OdbcCommand(query, conn)
            dr = cmd.ExecuteReader()
            cbBarang.Items.Clear()
            While dr.Read()
                cbBarang.Items.Add(dr("Nama_Barang").ToString())
            End While
            dr.Close()
        Catch ex As Exception
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Sub SiapkanGrid()
        Try
            Dim query As String = "SELECT faktur_penjualan, kode_barang, harga_jual, jumlah, sub_total FROM tbl_penjualan_rinci"
            Dim da As New OdbcDataAdapter(query, conn)
            dtRinci = New DataTable()
            da.Fill(dtRinci)
        Catch ex As Exception
            MsgBox("Error memuat data rinci: " & ex.Message)
            Exit Sub
        End Try

        dgvRinci.DataSource = dtRinci
        dgvRinci.AllowUserToAddRows = False
        dgvRinci.Columns("faktur_penjualan").HeaderText = "Faktur Penjualan"
        dgvRinci.Columns("kode_barang").HeaderText = "Kode Barang"
        dgvRinci.Columns("harga_jual").HeaderText = "Harga Jual"
        dgvRinci.Columns("jumlah").HeaderText = "Jumlah Beli"
        dgvRinci.Columns("sub_total").HeaderText = "Total"
    End Sub

    Function BuatFakturBaru() As String
        Dim prefix As String = "FJ" & Date.Now.ToString("yyyyMMdd")
        Dim urut As Integer = 1
        Try
            Dim query As String = "SELECT faktur_penjualan FROM tbl_penjualan " &
                              "WHERE faktur_penjualan LIKE ? ORDER BY faktur_penjualan DESC LIMIT 1"
            cmd = New OdbcCommand(query, conn)
            cmd.Parameters.Add(New OdbcParameter("p", prefix & "%"))
            Dim hasil As Object = cmd.ExecuteScalar()
            If hasil IsNot Nothing AndAlso hasil IsNot DBNull.Value Then
                urut = Convert.ToInt32(hasil.ToString().Substring(prefix.Length)) + 1
            End If
        Catch ex As Exception
            MsgBox("Error faktur: " & ex.Message)
        End Try
        Return prefix & urut.ToString("000")
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        IsiComboPelanggan()
        IsiComboBarang()
        SiapkanGrid()
        tbFaktur.Text = BuatFakturBaru()
        tbFaktur.ReadOnly = True
    End Sub

    Private Sub cbPelanggan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPelanggan.SelectedIndexChanged
        If cbPelanggan.SelectedIndex = -1 Then Exit Sub
        Try
            Dim selectedKode As String = cbPelanggan.SelectedItem.ToString()
            Dim query As String = "SELECT nama_pelanggan FROM tbl_pelanggan WHERE kode_pelanggan = ?"
            cmd = New OdbcCommand(query, conn)
            cmd.Parameters.Add(New OdbcParameter("kode", selectedKode))
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                tbNamaPelanggan.Text = dr("nama_pelanggan").ToString()
            End If
            dr.Close()
        Catch ex As Exception
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub cbBarang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBarang.SelectedIndexChanged
        If cbBarang.SelectedIndex = -1 Then Exit Sub
        Try
            Dim namaBarang As String = cbBarang.SelectedItem.ToString()
            Dim query As String = "SELECT Kode_Barang, Jenis, Harga_Beli, Harga_Jual FROM tblbarang WHERE Nama_Barang = ?"
            cmd = New OdbcCommand(query, conn)
            cmd.Parameters.Add(New OdbcParameter("nama", namaBarang))
            dr = cmd.ExecuteReader()
            If dr.Read() Then
                tbKodeBarang.Text = dr("Kode_Barang").ToString()
                tbJenis.Text = dr("Jenis").ToString()
                tbHargaKotor.Text = dr("Harga_Beli").ToString()
                tbHargaBersih.Text = dr("Harga_Jual").ToString()
                hargaJualTerpilih = Convert.ToInt32(dr("Harga_Jual"))
            End If
            dr.Close()
            HitungSubTotal()
        Catch ex As Exception
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then dr.Close()
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Sub HitungSubTotal()
        Dim jumlah As Integer
        If Integer.TryParse(tbJumlahBeli.Text, jumlah) Then
            tbSubTotal.Text = (jumlah * hargaJualTerpilih).ToString()
        Else
            tbSubTotal.Text = "0"
        End If
    End Sub

    Sub HitungTotal()
        Dim total As Integer = 0
        For Each row As DataRow In dtRinci.Rows
            If row.RowState = DataRowState.Added Then
                total += Convert.ToInt32(row("sub_total"))
            End If
        Next
        tbTotal.Text = total.ToString()
    End Sub

    Private Sub tbJumlahBeli_TextChanged(sender As Object, e As EventArgs) Handles tbJumlahBeli.TextChanged
        HitungSubTotal()
    End Sub

    Private Sub tbJumlahBeli_KeyDown(sender As Object, e As KeyEventArgs) Handles tbJumlahBeli.KeyDown
        If e.KeyCode <> Keys.Enter Then Exit Sub
        e.SuppressKeyPress = True

        If tbFaktur.Text.Trim() = "" Then
            MsgBox("Faktur penjualan harus diisi.") : Exit Sub
        End If
        If cbBarang.SelectedIndex = -1 OrElse tbKodeBarang.Text = "" OrElse hargaJualTerpilih = 0 Then
            MsgBox("Pilih barang dari daftar ComboBox Barang terlebih dahulu.") : Exit Sub
        End If

        Dim jumlah As Integer
        If Not Integer.TryParse(tbJumlahBeli.Text, jumlah) OrElse jumlah <= 0 Then
            MsgBox("Jumlah beli harus berupa angka lebih dari 0.") : Exit Sub
        End If

        dtRinci.Rows.Add(tbFaktur.Text.Trim(), tbKodeBarang.Text, hargaJualTerpilih, jumlah, jumlah * hargaJualTerpilih)
        HitungTotal()

        cbBarang.SelectedIndex = -1
        tbKodeBarang.Clear()
        tbJenis.Clear()
        tbJumlahBeli.Clear()
        tbSubTotal.Clear()
        tbHargaKotor.Clear()
        tbHargaBersih.Clear()
        hargaJualTerpilih = 0
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If tbFaktur.Text.Trim() = "" OrElse cbPelanggan.Text.Trim() = "" Then
            MsgBox("Lengkapi Pelanggan dan Faktur Penjualan.") : Exit Sub
        End If
        If dtRinci.GetChanges(DataRowState.Added) Is Nothing Then
            MsgBox("Belum ada barang yang ditambahkan. Isi jumlah beli lalu tekan Enter.") : Exit Sub
        End If
        HitungTotal()

        Dim trans As OdbcTransaction = Nothing
        Try
            trans = conn.BeginTransaction()

            Dim qHead As String = "INSERT INTO tbl_penjualan (faktur_penjualan, tgl_penjualan, kode_pelanggan, total) VALUES (?, ?, ?, ?)"
            cmd = New OdbcCommand(qHead, conn, trans)
            cmd.Parameters.Add(New OdbcParameter("faktur", tbFaktur.Text.Trim()))
            cmd.Parameters.Add(New OdbcParameter("tgl", dtpTanggal.Value.ToString("yyyy-MM-dd HH:mm:ss")))
            cmd.Parameters.Add(New OdbcParameter("pelanggan", cbPelanggan.Text.Trim()))
            cmd.Parameters.Add(New OdbcParameter("total", Convert.ToInt32(tbTotal.Text)))
            cmd.ExecuteNonQuery()

            ' 2. Detail penjualan
            Dim qRinci As String = "INSERT INTO tbl_penjualan_rinci (faktur_penjualan, kode_barang, harga_jual, jumlah, sub_total) VALUES (?, ?, ?, ?, ?)"
            For Each row As DataRow In dtRinci.Rows
                If row.RowState <> DataRowState.Added Then Continue For
                cmd = New OdbcCommand(qRinci, conn, trans)
                cmd.Parameters.Add(New OdbcParameter("faktur", row("faktur_penjualan").ToString()))
                cmd.Parameters.Add(New OdbcParameter("kode", row("kode_barang").ToString()))
                cmd.Parameters.Add(New OdbcParameter("harga", Convert.ToInt32(row("harga_jual"))))
                cmd.Parameters.Add(New OdbcParameter("jumlah", Convert.ToInt32(row("jumlah"))))
                cmd.Parameters.Add(New OdbcParameter("sub", Convert.ToInt32(row("sub_total"))))
                cmd.ExecuteNonQuery()
            Next

            trans.Commit()
            tbFaktur.Text = BuatFakturBaru()

            fakturCetak = tbFaktur.Text.Trim()
            pelangganCetak = tbNamaPelanggan.Text
            tanggalCetak = dtpTanggal.Value
            totalCetak = Convert.ToInt32(tbTotal.Text)

            MsgBox("Data berhasil disimpan.")
            SiapkanGrid()

            SiapkanGrid()

        Catch ex As Exception
            If trans IsNot Nothing Then trans.Rollback()
            MsgBox("Gagal menyimpan: " & ex.Message)
        End Try
    End Sub

    Sub TampilRinci(faktur As String)
        Try
            Dim query As String = "SELECT faktur_penjualan, kode_barang, harga_jual, jumlah, sub_total " &
                                  "FROM tbl_penjualan_rinci WHERE faktur_penjualan = ?"
            Dim da As New OdbcDataAdapter(query, conn)
            da.SelectCommand.Parameters.Add(New OdbcParameter("faktur", faktur))

            Dim dt As New DataTable()
            da.Fill(dt)
            dgvRinci.DataSource = dt

            dgvRinci.Columns("faktur_penjualan").HeaderText = "Faktur Penjualan"
            dgvRinci.Columns("kode_barang").HeaderText = "Kode Barang"
            dgvRinci.Columns("harga_jual").HeaderText = "Harga Jual"
            dgvRinci.Columns("jumlah").HeaderText = "Jumlah Beli"
            dgvRinci.Columns("sub_total").HeaderText = "Total"
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        If fakturCetak = "" Then
            MsgBox("Simpan transaksi terlebih dahulu sebelum mencetak.") : Exit Sub
        End If

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("FAKTUR : " & fakturCetak)
        sb.AppendLine("TANGGAL: " & tanggalCetak.ToString("dd MMMM yyyy"))
        sb.AppendLine("PELANGGAN: " & pelangganCetak)
        sb.AppendLine("-----------------------------")
        For Each row As DataGridViewRow In dgvRinci.Rows
            If Not row.IsNewRow AndAlso row.Cells("faktur_penjualan").Value.ToString() = fakturCetak Then
                sb.AppendLine(row.Cells("kode_barang").Value.ToString() & "  x" &
                          row.Cells("jumlah").Value.ToString() & "  = " &
                          row.Cells("sub_total").Value.ToString())
            End If
        Next
        sb.AppendLine("-----------------------------")
        sb.AppendLine("TOTAL: " & totalCetak)
        MsgBox(sb.ToString(), MsgBoxStyle.Information, "Cetak Faktur")
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        cbPelanggan.SelectedIndex = -1
        cbBarang.SelectedIndex = -1
        tbNamaPelanggan.Clear()
        tbFaktur.Clear()
        tbKodeBarang.Clear()
        tbJenis.Clear()
        tbJumlahBeli.Clear()
        tbSubTotal.Clear()
        tbTotal.Clear()
        tbHargaKotor.Clear()
        tbHargaBersih.Clear()
        dtpTanggal.Value = Date.Now
        hargaJualTerpilih = 0

        SiapkanGrid()
        tbFaktur.Text = BuatFakturBaru()
    End Sub
End Class