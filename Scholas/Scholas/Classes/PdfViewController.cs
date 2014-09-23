﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PdfViewController.cs" company="SemanticArchitecture">
//   http://www.SemanticArchitecture.net pkalkie@gmail.com
// </copyright>
// <summary>
//   Extends the controller with functionality for rendering PDF views
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Scholas.Models;
using Scholas.Classes;

namespace Scholas.Classes
{
    using System.Web.Mvc;

    /// <summary>
    /// Extends the controller with functionality for rendering PDF views
    /// </summary>
    public class PdfViewController : Controller
    {
        private readonly HtmlViewRenderer htmlViewRenderer;
        private readonly StandardPdfRenderer standardPdfRenderer;

        public PdfViewController()
        {
            this.htmlViewRenderer = new HtmlViewRenderer();
            this.standardPdfRenderer = new StandardPdfRenderer();
        }

        protected ActionResult ViewPdf(string pageTitle, string viewName, object model)
        {
            // Render the view html to a string.
            string htmlText = this.htmlViewRenderer.RenderViewToString(this, viewName, model);

            // Let the html be rendered into a PDF document through iTextSharp.
            byte[] buffer = standardPdfRenderer.Render(htmlText, pageTitle);

            // Return the PDF as a binary stream to the client.
            return new BinaryContentResult(buffer, "application/pdf");
        }
    }
}