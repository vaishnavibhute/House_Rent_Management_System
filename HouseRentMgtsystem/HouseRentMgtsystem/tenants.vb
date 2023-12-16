Imports System.Data.SqlClient
Public Class tenants
    Dim Con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim i As Integer

    Private Sub tenants_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        cmd.CommandText = "insert into TenantTb1 values('" + TenName.Text + "','" + TenPhone.Text + "','" + TenGen.SelectedItem.ToString() + "')"
        cmd.ExecuteNonQuery()

        disp_data()

        MessageBox.Show("Record Inserted Successfully")

    End Sub

    Public Sub disp_data()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from TenantTb1"
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

            i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

            cmd = Con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from TenantTb1 where TenId=" & i & ""
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                TenName.Text = dr.GetString(1).ToString()
                TenPhone.Text = dr.GetString(2).ToString()
                TenGen.SelectedItem = dr.GetString(3).ToString()
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
        cmd.CommandText = "update TenantTb1 set TenName='" + TenName.Text + "',TenPhone='" + TenPhone.Text + "',TenGen='" + TenGen.SelectedItem + "' where TenId=" & i & ""
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
        cmd.CommandText = "delete from TenantTb1 where TenName='" + TenName.Text +"' "
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub
    Private Sub Clear()
        TenName.Text = ""
        TenPhone.Text = ""
        TenGen.SelectedIndex = -1
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Clear()
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

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Dim ren = New rent
        ren.Show()
        Me.Hide()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim apart = New apartments
        apart.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim ll = New landlords
        ll.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Dim ren = New rent
        ren.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class