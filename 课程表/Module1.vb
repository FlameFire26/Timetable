Module Module1
    Public Function Times(ByVal time) As String
        Select Case time
            Case "n"
                Return Format(Now, "yyyy")
            Case "y"
                Return Format(Now, "MM")
            Case "r"
                Return Format(Now, "dd")
            Case "s"
                Return Format(Now, "HH")
            Case "f"
                Return Format(Now, "mm")
            Case "m"
                Return Format(Now, "ss")
            Case "date"
                Return Format(Now, "MM.dd")
            Case "dates"
                Return Format(Now, "yyyy.MM.dd")
            Case "time"
                Return Format(Now, "HH:mm")
            Case "times"
                Return Format(Now, "HH:mm:ss")
            Case Else
                Return "error!"
        End Select
    End Function

    Public Function Fresh()
        Form1.KeC = 0
        Form1.RiQ = 0
        For Each i In Form1.Controls
            If TypeOf i Is Label Then
                i.ForeColor = Color.Black
                i.BackColor = Color.Transparent
                If i.Name Like "T#" Then
                    If Between(Times("time"), Mid(i.Text, 3, 5), Mid(i.Text, 9, 5)) Then
                        Form1.KeC = Val(Mid(i.Name, 2))
                        i.ForeColor = Color.DarkGreen
                        i.BackColor = Color.PeachPuff
                    End If
                ElseIf i.Name Like "D#" Then
                    If Convert.ToDateTime(Times("date")) = Convert.ToDateTime(Val(Mid(i.Text, 1, 1)) & "." & Val(Mid(i.Text, 3, 2))) Then
                        Form1.RiQ = Val(Mid(i.Name, 2))
                        i.ForeColor = Color.DarkGreen
                        i.BackColor = Color.PeachPuff
                    End If
                End If
            End If
        Next
        If Form1.RiQ = 0 Then
            Form1.Prompt.Visible = True
            Form1.Prompt.Text = "未在日期范围内"
        ElseIf Form1.KeC = 0 Then
            Form1.Prompt.Visible = True
            Form1.Prompt.Text = "未上课"
        Else
            Form1.Prompt.Visible = False
        End If
        If Form1.oKeC <> Form1.KeC Then
            Form1.oKeC = Form1.KeC
            My.Computer.Audio.Play(Environment.CurrentDirectory & "\News.wav")
        End If
        For Each i In Form1.Controls
            If TypeOf i Is Label Then
                If i.Name Like "Z#" And Val(Mid(i.Name, 2)) = Form1.RiQ Then
                    i.ForeColor = Color.DarkGreen
                    i.BackColor = Color.PeachPuff
                ElseIf i.Name Like "S##" Then
                    If Val(Mid(i.Name, 2, 1)) = Form1.RiQ And Val(Mid(i.Name, 3, 1)) = Form1.KeC Then
                        i.ForeColor = Color.Maroon
                        i.BackColor = Color.PaleGoldenrod
                    ElseIf i.BackColor = Color.PaleGoldenrod And Form1.KeC = 0 Then
                        i.ForeColor = Color.Black
                        i.BackColor = Color.LightGray
                    ElseIf i.BackColor = Color.LightGray And Form1.KeC <> 0 Then
                        i.ForeColor = Color.Black
                        i.BackColor = Color.Transparent
                    End If
                End If
            End If
        Next
        Return Nothing
    End Function
    Public Function ReRead()
        If IO.File.Exists(Environment.CurrentDirectory & "\时间.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\日期.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\星期一.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\星期二.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\星期三.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\星期四.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\星期五.txt") And
            IO.File.Exists(Environment.CurrentDirectory & "\星期六.txt") Then
            For Each i In Form1.Controls
                If i.Name Like "T#" Then
                    i.Text = Mid(i.Text, 1, 2) & IO.File.ReadLines(Environment.CurrentDirectory & "\时间.txt", System.Text.Encoding.Default)(Mid(i.Name, 2) - 1)
                ElseIf i.Name Like "D#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\日期.txt", System.Text.Encoding.Default)(Mid(i.Name, 2) - 1), VbStrConv.Narrow)
                ElseIf i.Name Like "S1#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\星期一.txt", System.Text.Encoding.Default)(Mid(i.Name, 3) - 1), VbStrConv.Narrow)
                ElseIf i.Name Like "S2#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\星期二.txt", System.Text.Encoding.Default)(Mid(i.Name, 3) - 1), VbStrConv.Narrow)
                ElseIf i.Name Like "S3#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\星期三.txt", System.Text.Encoding.Default)(Mid(i.Name, 3) - 1), VbStrConv.Narrow)
                ElseIf i.Name Like "S4#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\星期四.txt", System.Text.Encoding.Default)(Mid(i.Name, 3) - 1), VbStrConv.Narrow)
                ElseIf i.Name Like "S5#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\星期五.txt", System.Text.Encoding.Default)(Mid(i.Name, 3) - 1), VbStrConv.Narrow)
                ElseIf i.Name Like "S6#" Then
                    i.Text = StrConv(IO.File.ReadLines(Environment.CurrentDirectory & "\星期六.txt", System.Text.Encoding.Default)(Mid(i.Name, 3) - 1), VbStrConv.Narrow)
                End If
            Next
        Else
            If MsgBox("丢失文本文件或文件命名格式有误！是否使用预置设置？", vbYesNo) = vbNo Then
                End
            End If
        End If
        Return Nothing
    End Function
    Public Function Between(ByVal n, a, b)
        Return If(n >= a And n < b, True, False)
    End Function
End Module
