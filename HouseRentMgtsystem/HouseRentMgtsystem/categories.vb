Imports System.Data.SqlClient
Public Class categories
    Dim Con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim c As Integer

    Private Sub categories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        cmd.CommandText = "insert into CategoryTb1 values('" + Category.Text + "','" + Remarks.Text + "')"
        cmd.ExecuteNonQuery()

        disp_data()

        MessageBox.Show("Record Inserted Successfully")

    End Sub

    Public Sub disp_data()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from CategoryTb1"
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

            c = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

            cmd = Con.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from CategoryTb1 where CNum=" & c & ""
            cmd.ExecuteNonQuery()
            Dim dt As New DataTable()
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As SqlClient.SqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                Category.Text = dr.GetString(1).ToString()
                Remarks.Text = dr.GetString(2).ToString()

            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Con.State = ConnectionState.Open Then
            Con.Close()

        End If
        Con.Open()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update CategoryTb1 set Category='" + Category.Text + "',Remarks='" + Remarks.Text + "' where CNum=" & c & ""
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Con.State = ConnectionState.Open Then
            Con.Close()

        End If
        Con.Open()

        cmd = Con.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from CategoryTb1 where Category='" + Category.Text + "' "
        cmd.ExecuteNonQuery()

        disp_data()
    End Sub
    Private Sub Clear()
        Category.Text = ""
        Remarks.Text = ""
       
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Clear()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Dim ten = New tenants
        ten.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim ll = New landlords
        ll.Show()
        Me.Hide()
    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Dim apart = New apartments
        apart.Show()
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

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Remarks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remarks.TextChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub Category_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category.TextChanged

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class