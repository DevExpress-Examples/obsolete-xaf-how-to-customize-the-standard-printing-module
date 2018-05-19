Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.ExpressApp.Printing.Win
Imports DevExpress.XtraPrinting
Imports System.Drawing

Namespace WinSolution.Module.Win
	Public Class CustomPrintingController
		Inherits PrintingController
		Protected Overrides Function PreparePrintingSystem() As PrintableComponentLink
			Dim link As PrintableComponentLink = MyBase.PreparePrintingSystem()
			CustomizePrintingSystem(link)
			Return link
		End Function
		Private Sub CustomizePrintingSystem(ByVal link As PrintableComponentLink)
			AddHandler link.CreateMarginalHeaderArea, AddressOf OnPrintableComponentLinkCreateMarginalHeaderArea
			AddHandler link.CreateMarginalFooterArea, AddressOf OnPrintableComponentLinkCreateMarginalFooterArea
		End Sub
		Private Sub OnPrintableComponentLinkCreateMarginalFooterArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, New RectangleF(0, 0, 200, 20), BorderSide.None)
			e.Graph.DrawString("Custom text in the footer", Color.Red, New RectangleF(200, 0, 200, 20), BorderSide.None)
		End Sub
		Private Sub OnPrintableComponentLinkCreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, New RectangleF(0, 0, 200, 20), BorderSide.None)
			e.Graph.DrawString("Custom text in the header", Color.Red, New RectangleF(200, 0, 200, 20), BorderSide.None)
		End Sub
	End Class
End Namespace