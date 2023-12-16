Imports System.Data.SqlClient
Public Class Apartments
    Dim Con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim a As Integer

    Private Sub Apartments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet25.LandLordsTb1' table. You can move, or remove it, as needed.
        Me.LandLordsTb1TableAdapter1.Fill(Me.HouserentmgtsystemDataSet25.LandLordsTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet24.LandLordsTb1' table. You can move, or remove it, as needed.
        Me.LandLordsTb1TableAdapter.Fill(Me.HouserentmgtsystemDataSet24.LandLordsTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet23.CategoryTb1' table. You can move, or remove it, as needed.
        Me.CategoryTb1TableAdapter1.Fill(Me.HouserentmgtsystemDataSet23.CategoryTb1)
        'TODO: This line of code loads data into the 'HouserentmgtsystemDataSet22.CategoryTb1' table. You can move, or remove it, as needed.
        Me.CategoryTb1TableAdapter.Fill(Me.HouserentmgtsystemDataSet22.CategoryTb1)
        Con.ConnectionString = "Data Source=LAPTOP-PCFHSE0I;Initial Catalog=HouseRent;User ID=sa;Password=***********"
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If
        Con.Open()

        disp_data()
    End Sub

    Public Sub disp_data()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from ApartTb1"
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

            a = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

            cmd = Con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from ApartTb1 where ANum=" & a & ""
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                AName.Text = dr.GetString(1).ToString()
                AAddress.Text = dr.GetString(2).ToString()
                AType.SelectedItem = dr.GetString(3).ToString()
                ACost.Text = dr.GetString(4).ToString()
                Owner.SelectedItem = dr.GetString(5).ToString()
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
        cmd.CommandText = "update ApartTb1 set AName='" + AName.Text + "',AAddress='" + AAddress.Text + "',AType='" + AType.Text + "',ACost='" + ACost.Text + "',Owner='" + Owner.Text + "' where ANum=" & a & ""
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
        cmd.CommandText = "delete from ApartTb1 where AName='" + AName.Text + "' "
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub
    Private Sub Clear()
        AName.Text = ""
        AAddress.Text = ""
        AType.Text = ""
        ACost.Text = ""
        Owner.Text = ""
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Clear()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Dim ten = New tenants
        ten.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Dim ten = New tenants
        ten.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim ll = New landlords
        ll.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim ll = New landlords
        ll.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Dim ren = New rent
        ren.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Dim ren = New rent
        ren.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into ApartTb1 values('" + AName.Text + "','" + AAddress.Text + "','" + AType.Text + "','" + ACost.Text + "','" + Owner.Text + "')"
        cmd.ExecuteNonQuery()

        disp_data()

        MessageBox.Show("Record Inserted Successfully")
    End Sub
End Class