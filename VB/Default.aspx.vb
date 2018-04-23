Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub label_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        Dim label As ASPxLabel = TryCast(sender, ASPxLabel)
        label.Text = HighlightSearchText(label.Text, gridView.SearchPanelFilter)
    End Sub


    Public Shared Function HighlightSearchText(ByVal source As String, ByVal searchText As String) As String
        If String.IsNullOrWhiteSpace(searchText) Then
            Return source
        End If
        Dim regex = New Regex(System.Text.RegularExpressions.Regex.Escape(searchText), RegexOptions.IgnoreCase)
        If regex.IsMatch(source) Then
            Return String.Format("<span>{0}</span>", regex.Replace(source, "<span class='dxgvHL'>$0</span>"))
        End If
        Return source
    End Function
End Class