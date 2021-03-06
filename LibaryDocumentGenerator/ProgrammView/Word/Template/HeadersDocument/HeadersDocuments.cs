﻿using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using LibaryDocumentGenerator.ProgrammView.Word.Libary.ParagraphsGenerator;
using LibaryDocumentGenerator.ProgrammView.Word.Libary.TablesGenrerator;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;


namespace LibaryDocumentGenerator.ProgrammView.Word.Template.HeadersDocument
{
   public class HeadersDocuments
    {
        /// <summary>
        /// Создание Шапки документа ИФНС 51 Шаблон №1 без герба
        /// </summary>
        /// <param name="tamplate">Шаблон шапки</param>
        /// <param name="n279">Номер инспекции</param>
        /// <param name="n280">Наименование плательщика</param>
        /// <param name="senderOtd">В какой отдел направляется</param>
        /// <returns></returns>
        public Body DocumentsHeaders(LibaryXMLAutoReports.FullTemplateSheme.Document tamplate, string n279 = null, string n280 = null,string senderOtd = null)
        {
            Body body = new Body();
            Table table = new Table();
            var rows = new RowGenerate();
            ObservableCollection<TableCell> cellcCollection = new ObservableCollection<TableCell>();
            ObservableCollection<Paragraph> paragraphcCollection = new ObservableCollection<Paragraph>();
            var paragraphGenerate = new RunGenerate();
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade1, "20", JustificationValues.Center, 1));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade2, "20", JustificationValues.Center));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade3, "20", JustificationValues.Center));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade4, "20", JustificationValues.Center, 1));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade5, "16", JustificationValues.Center, 1));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade6, "16", JustificationValues.Center, 1));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade7, "16", JustificationValues.Center, 0, "0", false, false, false));
            if (tamplate.Templates.Headers.TextHeade8.Length > 40)
            {
                var t1 = tamplate.Templates.Headers.TextHeade8.Substring(0, 40);
                var t2 = tamplate.Templates.Headers.TextHeade8.Substring(40);
                paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(t1, "16",
                    JustificationValues.Center));
                paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(t2, "16",
                    JustificationValues.Center));
            }
            else
            {
                paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade8, "16", JustificationValues.Center));
            }
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade9, "16", JustificationValues.Center));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(tamplate.Templates.Headers.TextHeade10, "16", JustificationValues.Center));
            cellcCollection.Add(CellGenerate.GenerateCell(ref paragraphcCollection, "100", TableWidthUnitValues.Auto, "0", "200", TableVerticalAlignmentValues.Top, null, 4));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart());
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(n280, "26", JustificationValues.Center,1,"0",false,false,false));
            paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart($"({n279})", "26", JustificationValues.Center, 0, "0", false, false, false));
            if (senderOtd != null)
            {
                paragraphcCollection.Add(paragraphGenerate.RunParagraphGeneratorStandart(senderOtd, "26", JustificationValues.Center));
            }
            cellcCollection.Add(CellGenerate.GenerateCell(ref paragraphcCollection, "5500", TableWidthUnitValues.Dxa, "1500", "0", TableVerticalAlignmentValues.Center));
            table.Append(rows.GenerateRow(ref cellcCollection));
            cellcCollection.Add(CellGenerate.GenerateCell(paragraphGenerate.RunParagraphGeneratorStandart(), CellGenerate.FormulWidthCell(1), TableWidthUnitValues.Dxa, "0", "0", TableVerticalAlignmentValues.Top, CellBorders.GenerateBorder()));
            cellcCollection.Add(CellGenerate.GenerateCell(paragraphGenerate.RunParagraphGeneratorStandart(), CellGenerate.FormulWidthCell(1), TableWidthUnitValues.Dxa, "0", "0", TableVerticalAlignmentValues.Top, CellBorders.GenerateBorder()));
            cellcCollection.Add(CellGenerate.GenerateCell(paragraphGenerate.RunParagraphGeneratorStandart("№", "24", JustificationValues.Center), "0", TableWidthUnitValues.Nil));
            cellcCollection.Add(CellGenerate.GenerateCell(paragraphGenerate.RunParagraphGeneratorStandart(), "0", TableWidthUnitValues.Nil, "0", "1500", TableVerticalAlignmentValues.Top, CellBorders.GenerateBorder()));
            table.Append(rows.GenerateRow(ref cellcCollection));
            cellcCollection.Add(CellGenerate.GenerateCell(paragraphGenerate.RunParagraphGeneratorStandart("На №", "24"), "0", TableWidthUnitValues.Auto));
            cellcCollection.Add(CellGenerate.GenerateCell(paragraphGenerate.RunParagraphGeneratorStandart(), "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Bottom, CellBorders.GenerateBorder(),3));
 
            table.Append(rows.GenerateRow(ref cellcCollection));
            body.Append(table);
            body.Append(paragraphGenerate.LineBreker(3));
            return body;
        }
    }
}
