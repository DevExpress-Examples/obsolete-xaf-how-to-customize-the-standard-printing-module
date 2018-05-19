using System;
using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.ExpressApp.Printing.Win;

namespace WinSolution.Module.Win {
    public class CustomPrintingController : PrintingController {
        protected override void OnPrintingSettingsLoaded(PrintableComponentLinkEventArgs args) {
            base.OnPrintingSettingsLoaded(args);
            CustomizePrintingSystem(args.PrintableComponentLink);
        }
        private void CustomizePrintingSystem(PrintableComponentLink link) {
            link.CreateMarginalHeaderArea += link_CreateMarginalHeaderArea;
            link.CreateMarginalFooterArea += link_CreateMarginalFooterArea;
        }
        private void link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e) {
            e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, new RectangleF(0, 0, 200, 20), BorderSide.None);
            e.Graph.DrawString("Custom text in the footer", Color.Red, new RectangleF(200, 0, 200, 20), BorderSide.None);
        }
        private void link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e) {
            e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, new RectangleF(0, 0, 200, 20), BorderSide.None);
            e.Graph.DrawString("Custom text in the header", Color.Red, new RectangleF(200, 0, 200, 20), BorderSide.None);
        }
    }
}