
Partial Class Statistics
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim arrValues1() As Integer = {16, 10, 12, 18, 23, 26, 27, 28, 30, 34, 37, 45, 125, 40, 200, 310, 500, 400, 100}
        Dim arrLabels1() As Integer = {"11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "26", "27", "28", "29", "30"}

        'myFirstChart.Text = BuildChartHTML(arrValues1, arrLabels1, arrValues1, arrValues1, arrValues1)

    End Sub

    Public Function BuildChartHTML(ByVal aValues() As Integer, ByVal aLabels() As String, ByVal strTitle() As Integer, ByVal strXAxisLabel() As Integer, _
                                    ByVal strYAxisLabel() As Integer)
        Const GRAPH_WIDTH As Integer = 550  ' The width of the body of the graph
        Const GRAPH_HEIGHT As Integer = 100  ' The heigth of the body of the graph
        Const GRAPH_BORDER As Integer = 3    ' The size of the black border
        Const GRAPH_SPACER As Integer = 1    ' The size of the space between the bars

        Const TABLE_BORDER As Integer = 0
        Dim I As Integer
        Dim iMaxValue As Integer
        Dim iBarWidth As Integer
        Dim iBarHeight As Integer
        Dim myStringBuilder As StringBuilder

        iMaxValue = 0
        For I = 0 To UBound(aValues)
            If iMaxValue < aValues(I) Then iMaxValue = aValues(I)
        Next I


        iBarWidth = (GRAPH_WIDTH \ (UBound(aValues) + 1)) - GRAPH_SPACER
        myStringBuilder = New StringBuilder()

        myStringBuilder.Append("<TABLE BORDER=""" & TABLE_BORDER & """ CELLSPACING=""0"" CELLPADDING=""0""> " & vbCrLf)
        myStringBuilder.Append("<TR><TD COLSPAN=""1"" ALIGN=""center""><H2>" & "" & "</H2></TD></TR> " & vbCrLf)
        myStringBuilder.Append("<TR> " & vbCrLf)
        myStringBuilder.Append("    <TD VALIGN=""center""><B>" & "" & "</B></TD> " & vbCrLf)
        myStringBuilder.Append("    <TD VALIGN=""top""> " & vbCrLf)
        myStringBuilder.Append("      <TABLE BORDER=""" & TABLE_BORDER & """ CELLSPACING=""0"" CELLPADDING=""0""> " & vbCrLf)
        myStringBuilder.Append("        <TR> " & vbCrLf)
        myStringBuilder.Append("          <TD ROWSPAN=""1""><IMG SRC=""spacer.bmp""  BORDER=""0"" WIDTH=""1"" HEIGHT=""" & GRAPH_HEIGHT & """></TD> " & vbCrLf)
        myStringBuilder.Append("          <TD VALIGN=""top"" ALIGN=""right"">" & iMaxValue & "&nbsp;</TD> " & vbCrLf)
        myStringBuilder.Append("        </TR> " & vbCrLf)
        myStringBuilder.Append("        <TR> " & vbCrLf)
        myStringBuilder.Append("          <TD VALIGN=""bottom"" ALIGN=""right"">0&nbsp;</TD> " & vbCrLf)
        myStringBuilder.Append("        </TR> " & vbCrLf)
        myStringBuilder.Append("      </TABLE> " & vbCrLf)
        myStringBuilder.Append("    </TD> " & vbCrLf)
        myStringBuilder.Append("    <TD> " & vbCrLf)

        myStringBuilder.Append("      <TABLE BORDER=""" & TABLE_BORDER & """ CELLSPACING=""1"" CELLPADDING=""0""> " & vbCrLf)
        myStringBuilder.Append("        <TR> " & vbCrLf)
        myStringBuilder.Append("          <TD VALIGN=""bottom""><IMG SRC=""spacer_black.bmp"" BORDER=""0"" WIDTH=""" & GRAPH_BORDER & """ HEIGHT=""" & GRAPH_HEIGHT & """></TD> " & vbCrLf)

        For I = 0 To UBound(aValues)
            iBarHeight = Int((aValues(I) / iMaxValue) * GRAPH_HEIGHT)

            If iBarHeight = 0 Then iBarHeight = 1
            myStringBuilder.Append("          <TD VALIGN=""bottom""></TD> " & vbCrLf)
            myStringBuilder.Append("          <TD VALIGN=""bottom""><IMG SRC=""spacer_red.bmp"" BORDER=""0"" WIDTH=""" & iBarWidth & """ HEIGHT=""" & iBarHeight & """ ALT=""" & aValues(I) & """></TD> " & vbCrLf)
        Next I
        myStringBuilder.Append("        </TR> " & vbCrLf)

        myStringBuilder.Append("        <TR> " & vbCrLf)
        myStringBuilder.Append("          <TD COLSPAN=""" & (2 * (UBound(aValues) + 1)) + 1 & """></TD> " & vbCrLf)
        myStringBuilder.Append("        </TR> " & vbCrLf)

        If IsArray(aLabels) Then
            myStringBuilder.Append("        <TR> " & vbCrLf)
            myStringBuilder.Append("          <TD><!-- Spacing for Left Border Column --></TD> " & vbCrLf)
            For I = 0 To UBound(aValues)
                myStringBuilder.Append("          <TD><!-- Spacing for Spacer Column --></TD> " & vbCrLf)
                myStringBuilder.Append("          <TD ALIGN=""center""><FONT SIZE=""1"">" & aLabels(I) & "</FONT></TD> " & vbCrLf)
            Next I
            myStringBuilder.Append("        </TR> " & vbCrLf)
        End If
        myStringBuilder.Append("      </TABLE> " & vbCrLf)
        myStringBuilder.Append("    </TD> " & vbCrLf)
        myStringBuilder.Append("  </TR> " & vbCrLf)
        myStringBuilder.Append("  <TR> " & vbCrLf)
        myStringBuilder.Append("    <TD COLSPAN=""2""><!-- Place holder for X Axis label centering--></TD> " & vbCrLf)
        myStringBuilder.Append("    <TD ALIGN=""center""><BR><B>" & "" & "</B></TD> " & vbCrLf)
        myStringBuilder.Append("  </TR>")
        myStringBuilder.Append("</TABLE>")
        myFirstChart.Text = myStringBuilder.ToString()
        BuildChartHTML = myStringBuilder.ToString
    End Function
End Class
