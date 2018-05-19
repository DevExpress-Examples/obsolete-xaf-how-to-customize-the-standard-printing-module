using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.ExpressApp.Printing.Win;
using DevExpress.XtraPrinting;
using System.Drawing;

namespace WinSolution.Module.Win {
    public class CustomPrintingController : PrintingController {
        protected override PrintableComponentLink PreparePrintingSystem() {
            PrintableComponentLink link = base.PreparePrintingSystem();
            CustomizePrintingSystem(link);
            return link;
        }
        private void CustomizePrintingSystem(PrintableComponentLink link) {
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(OnPrintableComponentLinkCreateMarginalHeaderArea);
            link.CreateMarginalFooterArea += new CreateAreaEventHandler(OnPrintableComponentLinkCreateMarginalFooterArea);
        }
        private void OnPrintableComponentLinkCreateMarginalFooterArea(object sender, CreateAreaEventArgs e) {
            e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, new RectangleF(0, 0, 200, 20), BorderSide.None);
            e.Graph.DrawString("Custom text in the footer", Color.Red, new RectangleF(200, 0, 200, 20), BorderSide.None);
        }
        private void OnPrintableComponentLinkCreateMarginalHeaderArea(object sender, CreateAreaEventArgs e) {
            e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}", Color.Green, new RectangleF(0, 0, 200, 20), BorderSide.None);
            e.Graph.DrawString("Custom text in the header", Color.Red, new RectangleF(200, 0, 200, 20), BorderSide.None);
        }
    }
}