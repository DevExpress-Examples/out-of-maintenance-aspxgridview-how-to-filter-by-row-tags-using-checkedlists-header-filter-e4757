Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub gvOrders_CustomUnboundColumnData(ByVal sender As Object, ByVal e As ASPxGridViewColumnDataEventArgs)
		If e.Column.FieldName = "CustomDescription" Then
			Dim description As String = Convert.ToString(e.GetListSourceFieldValue("Description"))
			Dim items() As String = description.Split(";"c)
			For i As Integer = 0 To items.Length - 1
				items(i) = String.Format("#{0}#", items(i)) 'Wrap items with '#'
			Next i
			e.Value = String.Join(";", items)
		End If
	End Sub

	Protected Sub gvOrders_CustomColumnDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
		If e.Column.FieldName = "CustomDescription" Then
			Dim description As String = Convert.ToString(e.Value)
			Dim items() As String = description.Split(";"c)
			For i As Integer = 0 To items.Length - 1
				Dim item As String = items(i)
				items(i) = item.Substring(1, item.Length - 2)
			Next i
			e.DisplayText = String.Join(", ", items) 'Remove '#' to display values
		End If
	End Sub

	Protected Sub gvOrders_HeaderFilterFillItems(ByVal sender As Object, ByVal e As ASPxGridViewHeaderFilterEventArgs)
		If e.Column.FieldName = "CustomDescription" Then
			Dim exsistingNewValues As New List(Of String)()
			Dim newValues As New List(Of FilterValue)()
			For Each value As FilterValue In e.Values
				Dim description As String = value.Value
				Dim items() As String = description.Split(";"c)
				For Each item As String In items
					If (Not exsistingNewValues.Contains(item)) Then
						exsistingNewValues.Add(item)

						Dim newValue As New FilterValue()
						newValue.DisplayText = item.Substring(1, item.Length - 2)
						newValue.Query = String.Format("Contains([{0}], '{1}')", e.Column.FieldName, item)
						newValues.Add(newValue)
					End If
				Next item
			Next value
			e.Values.Clear()
			e.Values.AddRange(newValues)
		End If
	End Sub
End Class