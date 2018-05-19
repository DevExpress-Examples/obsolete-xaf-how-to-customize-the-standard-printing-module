Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.ExpressApp.Printing.Win

Namespace WinSolution.Module.Win
	Public Class CustomPrintingController
		Inherits PrintingController
		Protected Overrides Sub OnPrintingSettingsLoaded(ByVal args As PrintableComponentLinkEventArgs)
			MyBase.OnPrintingSettingsLoaded(args)
			CustomizePrintingSystem(args.PrintableComponentLink)
		End Sub
		Private Sub CustomizePrintingSystem(ByVal link As PrintableComponentLink)
			AddHandler link.CreateMarginalHeaderArea, AddressOf link_CreateMarginalHeaderArea
			AddHandler link.CreateMarginalFooterArea, AddressOf link_CreateMarginalFooterArea
		End Sub
		Private Sub link_CreateMarginalFooterArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, New RectangleF(0, 0, 200, 20), BorderSide.None)
			e.Graph.DrawString("Custom text in the footer", Color.Red, New RectangleF(200, 0, 200, 20), BorderSide.None)
		End Sub
		Private Sub link_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, New RectangleF(0, 0, 200, 20), BorderSide.None)
			e.Graph.DrawString("Custom text in the header", Color.Red, New RectangleF(200, 0, 200, 20), BorderSide.None)
		End Sub
	End Class
End Namespace