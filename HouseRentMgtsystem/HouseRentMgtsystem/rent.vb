
Imports System.Data.SqlClient
Public Class rent
    Dim Con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim r As Integer
   

    Private Sub rent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet26.ApartTb1' table. You can move, or remove it, as needed.
        Me.ApartTb1TableAdapter2.Fill(Me.HouserentmgtsystemDataSet26.ApartTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet17.TenantTb1' table. You can move, or remove it, as needed.
        Me.TenantTb1TableAdapter1.Fill(Me.HouserentmgtsystemDataSet17.TenantTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet16.TenantTb1' table. You can move, or remove it, as needed.
        Me.TenantTb1TableAdapter.Fill(Me.HouserentmgtsystemDataSet16.TenantTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet15.RentTb1' table. You can move, or remove it, as needed.
        Me.RentTb1TableAdapter.Fill(Me.HouserentmgtsystemDataSet15.RentTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet13.ApartTb1' table. You can move, or remove it, as needed.
        Me.ApartTb1TableAdapter1.Fill(Me.HouserentmgtsystemDataSet14.ApartTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet14.ApartTb1' table. You can move, or remove it, as needed.
        Me.ApartTb1TableAdapter.Fill(Me.HouserentmgtsystemDataSet13.ApartTb1)
        Con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vaishnavi\Documents\HouseRentMgtSystem.mdf;Integrated Security=True;Connect Timeout=30"

        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If
        Con.Open()

        disp_data()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into RentTb1 values('" + Apartment.Text + "','" + Tenant.Text + "','" + Period.Text + "','" + Amount.Text + "')"
        cmd.ExecuteNonQuery()

        disp_data()

        MessageBox.Show("Record Inserted Successfully")

    End Sub

    Public Sub disp_data()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from RentTb1"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.datasource = dt
    End Sub



    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()

            End If
            Con.Open()

            r = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

            cmd = Con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from RentTb1 where RCode=" & r & ""
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                Apartment.Text = dr.GetString(1).ToString()
                Tenant.Text = dr.GetString(2).ToString()
                Period.Text = dr.GetString(3).ToString()
                Amount.Text = dr.GetString(4).ToString()
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Con.State = ConnectionState.Open Then
            Con.Close()

        End If
        Con.Open()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update RentTb1 set Apartment='" + Apartment.Text + "',Tenant='" + Tenant.Text + "',Period='" + Period.Text + "',Amount='" + Amount.Text + "' where RCode=" & r & ""
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Con.State = ConnectionState.Open Then
            Con.Close()

        End If
        Con.Open()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from RentTb1 where Apartment='" + Apartment.Text + "' "
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub
    Private Sub Clear()
        Apartment.Text = ""
        Tenant.Text = ""
        Period.Text = ""
        Amount.Text = ""
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Clear()
    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Dim ten = New tenants
        ten.Show()
        Me.Hide()
    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Dim apart = New apartments
        apart.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim ll = New landlords
        ll.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub

 
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim ten = New tenants
        ten.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Dim apart = New apartments
        apart.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim ll = New landlords
        ll.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub
End Class
