Imports System.Data.SqlClient
Public Class landlords
    Dim Con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim l As Integer

    Private Sub landlords_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Con.ConnectionString = "Data Source=LAPTOP-PCFHSE0I;Initial Catalog=HouseRent;User ID=sa;Password=***********"
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If
        Con.Open()

        disp_data()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into LandLordsTb1 values('" + LLName.Text + "','" + LLPhone.Text + "','" + LLGen.SelectedItem.ToString() + "')"
        cmd.ExecuteNonQuery()

        disp_data()

        MessageBox.Show("Record Inserted Successfully")

    End Sub

    Public Sub disp_data()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from LandLordsTb1"
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

            l = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

            cmd = Con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from LandLordsTb1 where LLId=" & l & ""
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                LLName.Text = dr.GetString(1).ToString()
                LLPhone.Text = dr.GetString(2).ToString()
                LLGen.SelectedItem = dr.GetString(3).ToString()
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
        cmd.CommandText = "update LandLordsTb1 set LLName='" + LLName.Text + "',LLPhone='" + LLPhone.Text + "',LLGen='" + LLGen.SelectedItem + "' where LLId=" & l & ""
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
        cmd.CommandText = "delete from LandLordsTb1 where LLName='" + LLName.Text + "' "
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub
    Private Sub Clear()
        LLName.Text = ""
        LLPhone.Text = ""
        LLGen.SelectedIndex = -1
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
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Dim ren = New rent
        ren.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim ten = New tenants
        ten.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim apart = New apartments
        apart.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Dim ren = New rent
        ren.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim cate = New categories
        cate.Show()
        Me.Hide()
    End Sub
End Class