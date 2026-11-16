<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        cbPelanggan = New ComboBox()
        cbBarang = New ComboBox()
        tbNamaPelanggan = New TextBox()
        tbFaktur = New TextBox()
        tbKodeBarang = New TextBox()
        tbJenis = New TextBox()
        tbJumlahBeli = New TextBox()
        tbSubTotal = New TextBox()
        tbTotal = New TextBox()
        tbHargaKotor = New TextBox()
        tbHargaBersih = New TextBox()
        dgvRinci = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        btnSimpan = New Button()
        btnCetak = New Button()
        btnBatal = New Button()
        Label12 = New Label()
        dtpTanggal = New DateTimePicker()
        CType(dgvRinci, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cbPelanggan
        ' 
        cbPelanggan.DropDownStyle = ComboBoxStyle.DropDownList
        cbPelanggan.FormattingEnabled = True
        cbPelanggan.Location = New Point(195, 40)
        cbPelanggan.Name = "cbPelanggan"
        cbPelanggan.Size = New Size(182, 33)
        cbPelanggan.TabIndex = 0
        ' 
        ' cbBarang
        ' 
        cbBarang.DropDownStyle = ComboBoxStyle.DropDownList
        cbBarang.FormattingEnabled = True
        cbBarang.Location = New Point(195, 163)
        cbBarang.Name = "cbBarang"
        cbBarang.Size = New Size(182, 33)
        cbBarang.TabIndex = 1
        ' 
        ' tbNamaPelanggan
        ' 
        tbNamaPelanggan.Location = New Point(195, 101)
        tbNamaPelanggan.Name = "tbNamaPelanggan"
        tbNamaPelanggan.Size = New Size(182, 31)
        tbNamaPelanggan.TabIndex = 2
        ' 
        ' tbFaktur
        ' 
        tbFaktur.Location = New Point(560, 35)
        tbFaktur.Name = "tbFaktur"
        tbFaktur.Size = New Size(227, 31)
        tbFaktur.TabIndex = 3
        ' 
        ' tbKodeBarang
        ' 
        tbKodeBarang.Location = New Point(560, 77)
        tbKodeBarang.Name = "tbKodeBarang"
        tbKodeBarang.Size = New Size(227, 31)
        tbKodeBarang.TabIndex = 4
        ' 
        ' tbJenis
        ' 
        tbJenis.Location = New Point(560, 118)
        tbJenis.Name = "tbJenis"
        tbJenis.Size = New Size(227, 31)
        tbJenis.TabIndex = 5
        ' 
        ' tbJumlahBeli
        ' 
        tbJumlahBeli.Location = New Point(560, 160)
        tbJumlahBeli.Name = "tbJumlahBeli"
        tbJumlahBeli.Size = New Size(227, 31)
        tbJumlahBeli.TabIndex = 6
        ' 
        ' tbSubTotal
        ' 
        tbSubTotal.Location = New Point(461, 563)
        tbSubTotal.Name = "tbSubTotal"
        tbSubTotal.Size = New Size(150, 31)
        tbSubTotal.TabIndex = 7
        ' 
        ' tbTotal
        ' 
        tbTotal.Location = New Point(461, 619)
        tbTotal.Name = "tbTotal"
        tbTotal.Size = New Size(150, 31)
        tbTotal.TabIndex = 8
        ' 
        ' tbHargaKotor
        ' 
        tbHargaKotor.Location = New Point(812, 563)
        tbHargaKotor.Name = "tbHargaKotor"
        tbHargaKotor.Size = New Size(150, 31)
        tbHargaKotor.TabIndex = 9
        ' 
        ' tbHargaBersih
        ' 
        tbHargaBersih.Location = New Point(812, 619)
        tbHargaBersih.Name = "tbHargaBersih"
        tbHargaBersih.Size = New Size(150, 31)
        tbHargaBersih.TabIndex = 10
        ' 
        ' dgvRinci
        ' 
        dgvRinci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRinci.Location = New Point(53, 211)
        dgvRinci.Name = "dgvRinci"
        dgvRinci.RowHeadersWidth = 62
        dgvRinci.Size = New Size(870, 291)
        dgvRinci.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(53, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 25)
        Label1.TabIndex = 12
        Label1.Text = "Pelanggan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(53, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(146, 25)
        Label2.TabIndex = 13
        Label2.Text = "Nama Pelanggan"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(53, 166)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 25)
        Label3.TabIndex = 14
        Label3.Text = "Barang"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(418, 40)
        Label4.Name = "Label4"
        Label4.Size = New Size(139, 25)
        Label4.TabIndex = 15
        Label4.Text = "Faktur Penjualan"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(418, 79)
        Label5.Name = "Label5"
        Label5.Size = New Size(113, 25)
        Label5.TabIndex = 16
        Label5.Text = "Kode Barang"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(418, 121)
        Label6.Name = "Label6"
        Label6.Size = New Size(49, 25)
        Label6.TabIndex = 17
        Label6.Text = "Jenis"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(418, 164)
        Label7.Name = "Label7"
        Label7.Size = New Size(99, 25)
        Label7.TabIndex = 18
        Label7.Text = "Jumlah Beli"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(323, 563)
        Label8.Name = "Label8"
        Label8.Size = New Size(85, 25)
        Label8.TabIndex = 19
        Label8.Text = "Sub Total"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(323, 622)
        Label9.Name = "Label9"
        Label9.Size = New Size(49, 25)
        Label9.TabIndex = 20
        Label9.Text = "Total"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(678, 563)
        Label10.Name = "Label10"
        Label10.Size = New Size(109, 25)
        Label10.TabIndex = 21
        Label10.Text = "Harga Kotor"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(678, 622)
        Label11.Name = "Label11"
        Label11.Size = New Size(112, 25)
        Label11.TabIndex = 22
        Label11.Text = "Harga Bersih"
        ' 
        ' btnSimpan
        ' 
        btnSimpan.Location = New Point(53, 536)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(112, 34)
        btnSimpan.TabIndex = 24
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        ' 
        ' btnCetak
        ' 
        btnCetak.Location = New Point(53, 591)
        btnCetak.Name = "btnCetak"
        btnCetak.Size = New Size(112, 34)
        btnCetak.TabIndex = 25
        btnCetak.Text = "Cetak"
        btnCetak.UseVisualStyleBackColor = True
        ' 
        ' btnBatal
        ' 
        btnBatal.Location = New Point(53, 653)
        btnBatal.Name = "btnBatal"
        btnBatal.Size = New Size(112, 34)
        btnBatal.TabIndex = 26
        btnBatal.Text = "Batal"
        btnBatal.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(821, 35)
        Label12.Name = "Label12"
        Label12.Size = New Size(73, 25)
        Label12.TabIndex = 27
        Label12.Text = "Tanggal"
        ' 
        ' dtpTanggal
        ' 
        dtpTanggal.Location = New Point(821, 74)
        dtpTanggal.Name = "dtpTanggal"
        dtpTanggal.Size = New Size(300, 31)
        dtpTanggal.TabIndex = 28
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1158, 830)
        Controls.Add(dtpTanggal)
        Controls.Add(Label12)
        Controls.Add(btnBatal)
        Controls.Add(btnCetak)
        Controls.Add(btnSimpan)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dgvRinci)
        Controls.Add(tbSubTotal)
        Controls.Add(tbTotal)
        Controls.Add(tbHargaKotor)
        Controls.Add(tbHargaBersih)
        Controls.Add(tbJumlahBeli)
        Controls.Add(tbJenis)
        Controls.Add(tbKodeBarang)
        Controls.Add(tbFaktur)
        Controls.Add(tbNamaPelanggan)
        Controls.Add(cbBarang)
        Controls.Add(cbPelanggan)
        Name = "Form1"
        Text = "Form1"
        CType(dgvRinci, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cbPelanggan As ComboBox
    Friend WithEvents cbBarang As ComboBox
    Friend WithEvents tbNamaPelanggan As TextBox
    Friend WithEvents tbFaktur As TextBox
    Friend WithEvents tbKodeBarang As TextBox
    Friend WithEvents tbJenis As TextBox
    Friend WithEvents tbJumlahBeli As TextBox
    Friend WithEvents tbSubTotal As TextBox
    Friend WithEvents tbTotal As TextBox
    Friend WithEvents tbHargaKotor As TextBox
    Friend WithEvents tbHargaBersih As TextBox
    Friend WithEvents dgvRinci As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnCetak As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents dtpTanggal As DateTimePicker

End Class
