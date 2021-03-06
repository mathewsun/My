﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using LibaryDocumentGenerator.ProgrammView.Word.Libary.ParagraphsGenerator;
using LibaryDocumentGenerator.ProgrammView.Word.Libary.TablesGenrerator;
using LibaryXMLAutoModelXmlSql.PreCheck.ModelCard;

namespace LibaryDocumentGenerator.ProgrammView.FullDocument
{
   public class DocumentsPreChek
    {

        /// <summary>
        /// Генерация докладной записки для пред проверочного анализа
        /// </summary>
        /// <param name="template">Карточка плательщика</param>
        /// <returns></returns>
        public Body GenerateReportNote(CardFaceUl template)
        {
            Body body = new Body();
            ObservableCollection<TableCell> cellCollection = new ObservableCollection<TableCell>();
            var rows = new RowGenerate();
            Table table = new Table();
            var i = 1; //Счетчик циклов
            var paragraphGenerate = new RunGenerate();
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Приложение 1 к письму УФНС России", "20", JustificationValues.Right));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("от «20»марта 2018 г. № 15-15/04660дсп@", "20", JustificationValues.Right));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Докладная записка", "28", JustificationValues.Center, 1));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("ИФНС России №51  по г. Москве", "28", JustificationValues.Center, 1));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("о целесообразности (нецелесообразности) проведения выездной налоговой", "28", JustificationValues.Center, 1));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("проверки в связи с ликвидацией (реорганизацией)", "28", JustificationValues.Center, 1));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("1.", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование налогоплательщика"),
                CellGenerate.FormulWidthCell(5.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.FaceUl?.NameFull),
                CellGenerate.FormulWidthCell(11.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("2.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ИНН / КПП"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{template.FaceUl?.Inn}/{template.FaceUl?.Kpp}"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection, true, rows.FormulHeightRow(0.4)));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("3.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Категория налогоплательщика"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List1Card.Where(key => key.Keys1 == "Группа по масштабу предприятия").Select(param => param.Parameter).FirstOrDefault()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("4.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес местонахождения в соответствии с учредительными документами (юридический), количество организаций, зарегистрированных на адресе"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.FaceUl?.Address),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("5.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес фактического местонахождения"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.FaceUl?.Address),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("6.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сведения о регистрации"),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата постановки на учет"),
                CellGenerate.FormulWidthCell(4.2), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование НО по месту постановки на учет / КПП"),
                CellGenerate.FormulWidthCell(4.2), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с учета", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
            table.Append(rows.GenerateRow(ref cellCollection));

            foreach (var history in template.HistoriUlFace)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(history?.DateNoStart?.ToString("dd.MM.yyyy")),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart($"{history?.KodeNo.ToString()}/{history.Kpp}"),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(history?.DateNoFinish?.ToString("dd.MM.yyyy")),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
                table.Append(rows.GenerateRow(ref cellCollection, true, rows.FormulHeightRow(0.4)));
            }


            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("7.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата внесения в ЕГРЮЛ сведений о том, что юридическое лицо находится в процессе реорганизации или ликвидации (публикации в журнале «Вестник государственной регистрации» сообщения о ликвидации юридического лица в случае опубликования такого сообщения ранее внесения в Единый государственный реестр сведений о том, что юридическое лицо находится в процессе ликвидации)"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.FaceUl.DateResh?.ToString("dd.MM.yyyy")),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Форма реорганизации (присоединение, слияние, выделение, разделение с указанием правопреемника)"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.1.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата государственной регистрации юридического лица"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.2.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Категория налогоплательщика"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.3.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Заявленный вид деятельности"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.4.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Руководитель/ учредитель"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection, true, rows.FormulHeightRow(0.4)));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.5.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес регистрации в соответствии с учредительными документами"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.6.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Зарегистрированные обособленные подразделения"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.7.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сведения о среднесписочной численности"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8.8.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Признаки фирмы - «однодневки»"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("9.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Используемый режим налогообложения (даты перехода на специальный налоговый режим и даты отказа от перехода)"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card.List1Card.Where(key => key.Keys1 == "Сегмент налогоплательщика").Select(param => param.Parameter).FirstOrDefault()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("10.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Информация об имеющихся номерах телефонов, факса"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("11.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сайт в сети Интернет"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection, true, rows.FormulHeightRow(0.4)));

            var codeOkved = template.Card.List1Card.Where(key => key.Keys1 == "ОКВЭД").Select(param => param.Parameter).FirstOrDefault();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("12.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Заявленные экономические виды деятельности"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Код по ОКВЭД"),
                CellGenerate.FormulWidthCell(2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Расшифровка"),
                "0", TableWidthUnitValues.Auto, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrEmpty(codeOkved) ? null : codeOkved.Split('-')[0]),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrEmpty(codeOkved) ? null : codeOkved.Split('-')[1]),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("13.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Фактически осуществляемые виды деятельности"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Код по ОКВЭД"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Расшифровка"),
                "0", TableWidthUnitValues.Auto, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrEmpty(codeOkved) ? null : codeOkved.Split('-')[0]),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrEmpty(codeOkved) ? null : codeOkved.Split('-')[1]),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
            paragraphGenerate.RunParagraphGeneratorStandart("14.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сведения о наличии лицензии"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование лицензии"),
                CellGenerate.FormulWidthCell(2.8), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Номер лицензии"),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Лицензируемый вид деятельности и орган, выдавший лицензию"),
                CellGenerate.FormulWidthCell(4.7), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Период действия"),
                "0", TableWidthUnitValues.Auto, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            table.Append(rows.GenerateRow(ref cellCollection));


            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("15.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Информация о наличии обособленных подразделений"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата постановки на учет"),
                CellGenerate.FormulWidthCell(4.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес местонахождения"),
                CellGenerate.FormulWidthCell(4.2), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с учета"),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
            table.Append(rows.GenerateRow(ref cellCollection));

            foreach (var branch in template.BranchUlFace)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                  paragraphGenerate.RunParagraphGeneratorStandart(),
                  "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
                cellCollection.Add(CellGenerate.GenerateCell(
                  paragraphGenerate.RunParagraphGeneratorStandart(),
                  "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
                cellCollection.Add(CellGenerate.GenerateCell(
                  paragraphGenerate.RunParagraphGeneratorStandart(branch?.DataCreateBranch?.ToString("dd.MM.yyyy")),
                  "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                  paragraphGenerate.RunParagraphGeneratorStandart($"{branch?.IndexAddress},{branch?.RegionAddress},{branch?.DistrictAddress},{branch?.TownAddress},{branch?.LocalityAddress},{branch?.StreetAddress},{branch?.HouseAddress},{branch?.BodyAddress},{branch?.ApartmentAddress}"),
                  "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                  paragraphGenerate.RunParagraphGeneratorStandart(branch?.DataCloseBranch?.ToString("dd.MM.yyyy")),
                  "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3));
                table.Append(rows.GenerateRow(ref cellCollection));
            }

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("16.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сведения о наличии контрольно-кассовой техники"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Заводской номер", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.8), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата регистрации ККТ", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с регистрации ККТ", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4.7), TableWidthUnitValues.Dxa, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес регистрации ККТ", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2));
            table.Append(rows.GenerateRow(ref cellCollection, true, rows.FormulHeightRow(0.4)));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("17.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Обращения из органов внутренних дел, следственных органов, контролирующих органов с приложением документов (информация), подтверждающих наличие нарушений законодательства о налогах и сборах, в том числе применении схем агрессивного налогового планирования"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("отсутствует"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("18.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Факты (информация), позволяющие признать ликвидируемую (реорганизуемую) организацию  взаимозависимым лицом по отношению к крупнейшим налогоплательщикам"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("отсутствует"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("19.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наличие информации из других налоговых органов о выявленной схеме нарушения налогового законодательства"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("отсутствует"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("20.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наличие информации об участии в цепочке взаимосвязанных «схемных» операций, выявленных при отработке «сложных» Расхождений (с указанием «роли»)"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("отсутствует"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("21.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наличие  анализируемого налогоплательщика  в списке налогоплательщиков, отобранных Управлением для включения в проект Плана выездных налоговых проверок"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("отсутствует"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("22.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Информация об отказе  добровольного уточнения анализируемым налогоплательщиком своих налоговых обязательств"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("отсутствует"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 5));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("23. Анализ заключенных государственных и (или) муниципальных контрактов.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Заказчик", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(5.6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Контракт", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Предмет контракта", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(7.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата исполнения", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ИНН", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата/№", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование товаров и услуг", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Цена", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            //Таблица 23 возможно цикл перебора данных
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("24. Сведения о наличии счетов в кредитных учреждениях", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование банка", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(7.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ счета", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.8), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Вид счета", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата открытия", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата закрытия", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            if (template.CashUlFace == null)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }
            else
            {
                //Перебор циклом 24 сведения о счетах
                foreach (var cash in template.CashUlFace)
                {
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cash.NameFull),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cash.CashNumber),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cash.TypeCash),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cash.DataOpenCash?.ToString("dd.MM.yyyy")),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cash.DataClosedCash?.ToString("dd.MM.yyyy")),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    table.Append(rows.GenerateRow(ref cellCollection));
                }
            }

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование банка", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(5.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ счета", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата запроса банковских выписок", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата получения банковских выписок", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Способ доставки документа", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Оборот по дебету, тыс.руб.", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Оборот по кредиту, тыс.руб.", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));
          
            if (template.CashBankSpr == null)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }
            else
            {
                //Перебор циклом 24 выписки
                foreach (var cashSpr in template.CashBankSpr)
                {
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cashSpr.NameBank),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cashSpr.NumberCash),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cashSpr.DateWay?.ToString("dd.MM.yyyy")),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cashSpr.DatePriem?.ToString("dd.MM.yyyy")),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(cashSpr.Dostavka),
                        "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    table.Append(rows.GenerateRow(ref cellCollection));
                }
            }

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("25. Среднесписочная численность организации, численность организации по справкам 2 НДФЛ", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();
            ///Возможно генерация будет автоматическая нужно думать
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                CellGenerate.FormulWidthCell(9.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter) ? $"{DateTime.Now.Year - 3}.г" : $"{param.Parameter}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter1) ? $"{DateTime.Now.Year - 2}.г" : $"{param.Parameter1}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter2) ? $"{DateTime.Now.Year - 1}.г" : $"{param.Parameter2}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter3) ? $"{DateTime.Now.Year}.г" : $"{param.Parameter3}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Среднесписочная численность работников"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Численность сотрудников, работающих больше года").Select(param => param.Parameter).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Численность сотрудников, работающих больше года").Select(param => param.Parameter1).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Численность сотрудников, работающих больше года").Select(param => param.Parameter2).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Численность сотрудников, работающих больше года").Select(param => param.Parameter3).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Количество представленных налоговым агентом сведений о доходах физического лица по форме  № 2-НДФЛ"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Среднемесячная заработная плата на 1 работника"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднемесячная заработная плата по налогоплательщику").Select(param => param.Parameter).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднемесячная заработная плата по налогоплательщику").Select(param => param.Parameter1).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднемесячная заработная плата по налогоплательщику").Select(param => param.Parameter2).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднемесячная заработная плата по налогоплательщику").Select(param => param.Parameter3).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("26. Участие в других организациях, в которых сотрудники являются получателями доходов", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Ф.И.О. сотрудника"),
                CellGenerate.FormulWidthCell(3.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование организации", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ИНН/КПП", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Занимаемая должность", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сумма дохода, тыс.руб.", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(5.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(""),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 3}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 2}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 1}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Перебор циклом сотрудников и их доходов
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("27. Выявление всех  руководителей/ учредителей конкретной организации, а также их участие в других организациях", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Учредитель проверяемой организации", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сведения об организации, в которой указанный учредитель является учредителем, директором или сотрудником (получателем дохода)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(15), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 8, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Ф.И.О. учредителя, или наименование ЮЛ", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование организации", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ИНН/КПП", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата начала", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата окончания", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Занимаемая должность", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сумма дохода, тыс.руб.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3, 1, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 3}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 2}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 1}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Перебор циклом данную вещь учередители
            foreach (var fl in template.FlRukUcrh.Where(fl => fl.Priznak == "Учередитель"))
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart($"{fl.NameFl}/{fl.Inn}"),
                    "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }


            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Руководитель проверяемой организации", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сведения об организации, в которой указанный учредитель является учредителем, директором или сотрудником (получателем дохода)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(14.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 8, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Ф.И.О. руководителя, или наименование ЮЛ", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование организации", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ИНН/КПП", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата начала", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата окончания", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Занимаемая должность", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сумма дохода, тыс.руб.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 3, 1, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 3}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 2}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{DateTime.Now.Year - 1}.г", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "0", "0", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Перебор циклом данную вещь руководители

            foreach (var fl in template.FlRukUcrh.Where(fl => fl.Priznak == "Руководитель"))
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart($"{fl.NameFl}/{fl.Inn}"),
                    "0", TableWidthUnitValues.Nil, "0", "0", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("28. Сведения об аффилированных и (или) взаимозависимых юридических лицах", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование организации", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ИНН/КПП", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Характеристика", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Активы", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сумма взаимоотношений", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Период сделки", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Анализ сделки", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));


            ///Перебор циклом афиллированных лиц
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("29. Сведения об имуществе, транспортных средствах и земельных участках", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("29.1. Определение перечня имущества, зарегистрированного на организацию (строение,  земельные  участки,  транспортные средства)", "24"));
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Имущество", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(18.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата постановки на учет", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с учета", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Тип объекта/наименование объекта", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес объекта", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Площадь", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Стоимость имущества, тыс.руб.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            if (!template.ImZmTrUl.Any(im => im.TypeObject == "Имущество" || im.TypeObject == "Земля"))
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }
            else
            {
                foreach (var imUl in template.ImZmTrUl.Where(im => im.TypeObject == "Имущество" || im.TypeObject == "Земля"))
                {
                    cellCollection.Add(CellGenerate.GenerateCell(
                         paragraphGenerate.RunParagraphGeneratorStandart(imUl.DateFactStart?.ToString("dd.MM.yyyy")),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                         paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrWhiteSpace(imUl.DateFactFinish?.ToString()) ? "н/в" : imUl.DateFactFinish?.ToString("dd.MM.yyyy")),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                         paragraphGenerate.RunParagraphGeneratorStandart(imUl.NameObject),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                         paragraphGenerate.RunParagraphGeneratorStandart(imUl.AddresObject),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                         paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                         paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    table.Append(rows.GenerateRow(ref cellCollection));
                }
            }

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Транспорт", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(18.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата постановки на учет", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с учета", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Марка транспортного средства", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Адрес объекта", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Стоимость транспортного средства, тыс.руб.", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            if (!template.ImZmTrUl.Any(im => im.TypeObject == "Транспорт"))
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                    CellBorders.GenerateBorderFull(), 2));
                table.Append(rows.GenerateRow(ref cellCollection));
            }
            else
            {
                foreach (var imUl in template.ImZmTrUl.Where(im => im.TypeObject == "Транспорт"))
                {
                    //Перебор транспорта циклом
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(imUl.DateFactStart?.ToString("dd.MM.yyyy")),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                        CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrWhiteSpace(imUl.DateFactFinish?.ToString()) ? "н/в" : imUl.DateFactFinish?.ToString("dd.MM.yyyy")),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                        CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(imUl.NameObject),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                        CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(imUl.AddresObject),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                        CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                        CellBorders.GenerateBorderFull(), 2));
                    table.Append(rows.GenerateRow(ref cellCollection));
                }
            }

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("29.2. Определение перечня имущества, зарегистрированного на всех  руководителей/учредителей (строение,  земельные  участки,  транспортные средства)", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());

            if (template.RukAndUcrh != null)
            {
                foreach (var rukAndUch in template.RukAndUcrh)
                {
                    table = new Table();
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart($"{rukAndUch.Priznak} {rukAndUch.NameFl} {rukAndUch.Inn} {Convert.ToDateTime(rukAndUch.DateStart).ToString("dd.MM.yyyy")} по н/в", "20", JustificationValues.Center),
                        CellGenerate.FormulWidthCell(18.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
                    table.Append(rows.GenerateRow(ref cellCollection));

                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Имущество", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
                    table.Append(rows.GenerateRow(ref cellCollection));

                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Дата постановки на учет", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с учета", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Тип объекта/наименование объекта", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Адрес объекта", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Площадь", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Стоимость имущества, тыс.руб.", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    table.Append(rows.GenerateRow(ref cellCollection));

                    //Перебор имущества циклом руководителя учередителя
                    foreach (var imZm in rukAndUch.TypeObject.Where(type => (type.TypeObject1 == "Земля" || type.TypeObject1 == "Имущество") && type.ImZmTrFl!=null))
                    {
                        foreach (var all in imZm.ImZmTrFl)
                        {
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(Convert.ToDateTime(all.DateFactStart).ToString("dd.MM.yyyy")),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrWhiteSpace(all.DateFactFinish) ? "н/в" : Convert.ToDateTime(all.DateFactFinish).ToString("dd.MM.yyyy")),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(all.NameObject),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(all.AddresObject),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                            table.Append(rows.GenerateRow(ref cellCollection));
                        }
                    }
                
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Транспорт", "20", JustificationValues.Center),
                        CellGenerate.FormulWidthCell(18.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
                    table.Append(rows.GenerateRow(ref cellCollection));

                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Дата постановки на учет", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Дата снятия с учета", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Марка транспортного средства", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Адрес объекта", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("Стоимость транспортного средства, тыс.руб.", "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 0, "FFFFCC"));
                    table.Append(rows.GenerateRow(ref cellCollection));

                    //Перебор транспорта циклом руководителя учередителя
                    foreach (var imZm in rukAndUch.TypeObject.Where(type => type.TypeObject1 == "Транспорт" && type.ImZmTrFl != null))
                    {
                        foreach (var all in imZm.ImZmTrFl)
                        {
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(Convert.ToDateTime(all.DateFactStart).ToString("dd.MM.yyyy")),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                                CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(string.IsNullOrWhiteSpace(all.DateFactFinish) ? "н/в" : Convert.ToDateTime(all.DateFactFinish).ToString("dd.MM.yyyy")),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                                CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(all.NameObject),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                                CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(all.AddresObject),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                                CellBorders.GenerateBorderFull()));
                            cellCollection.Add(CellGenerate.GenerateCell(
                                paragraphGenerate.RunParagraphGeneratorStandart(),
                                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center,
                                CellBorders.GenerateBorderFull(), 2));
                            table.Append(rows.GenerateRow(ref cellCollection));
                        }
                    }
                    body.Append(table);
                    body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
                }
            }
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("30. Сведения о предыдущих выездных и камеральных налоговых проверках с указанием их результатов (выявленные нарушения и суммы доначислений)", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                 paragraphGenerate.RunParagraphGeneratorStandart("Вид проверки (камеральная, выездная)", "20", JustificationValues.Center),
                 CellGenerate.FormulWidthCell(6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Проверяемый период", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Дата и № решения", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Основные нарушения  законодательства о налогах и сборах в разрезе налогов (сборов)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Доначисленная сумма налога  (уменьшено убытка, возмещение НДС)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Взыскание", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Перебор выездных проверок циклом
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("31. Структура и динамика налоговых поступлений от налогоплательщика", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ п/п", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(0.8), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование налога", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 3 }.г", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 2 }.г", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 1 }.г", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 1, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year }.г", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 2, 1, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 2, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Начисление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Поступление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Начисление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Поступление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Начисление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Поступление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Начисление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Поступление", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Тестовая модель из БД
            var model1 = new string[] { "Налог на прибыль", "НДС", "Налог на имущество", "Транспортный налог", "Земельный налог", "Водный налог", "НДФЛ" };

            foreach (var s in model1)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                   paragraphGenerate.RunParagraphGeneratorStandart(i.ToString(), "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(s, "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("-"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
                i++;
            }

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                 "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Итого", "20", JustificationValues.Center, 1),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            i = 1;
            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("32. Анализ обеспеченности организации средствами (активами) на последнюю отчетную дату", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ п/п", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Показатели бухгалтерской отчетности", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(6.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 3 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 2 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 1 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.7), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

                foreach (var active in template.Active)
                {
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(i.ToString(), "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(active.NameParametr, "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(active.God1.ToString()),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(active.God2.ToString()),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(active.God3.ToString()),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("0"),
                        "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    table.Append(rows.GenerateRow(ref cellCollection));
                    i++;
                }

            i = 1;
            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("33. Данные бухгалтерского баланса Форма № 2  за максимальный период проверки", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ п/п", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(0.8), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование показателя", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(6.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 3 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 2}.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 1}.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Тестовая модель из БД
            foreach (var balanse in template.Balans)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(balanse.Id.ToString(), "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(balanse.NameParametr, "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(balanse.God1.ToString()),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(balanse.God2.ToString()),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(balanse.God3.ToString()),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("0"),
                    "0", TableWidthUnitValues.Auto, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }
            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("34. Данные деклараций по налогу на прибыль организаций за максимальный период проверки", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                 paragraphGenerate.RunParagraphGeneratorStandart("Наименование показателя", "20", JustificationValues.Center),
                 CellGenerate.FormulWidthCell(6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 3}.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 2}.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 1}.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.9), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            ///Тестовая модель из БД Прибыль
            foreach (var profit in template.Profit)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(profit.NameParametr, "20", JustificationValues.Left),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(profit.God1.ToString()),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(profit.God2.ToString()),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(profit.God3.ToString()),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Проверка по Налогу на прибыль организаций на предмет обоснованности убытков, полученных налогоплательщиком на протяжении нескольких налоговых периодов. Результаты камеральной проверки.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("35. Сравнение доходов, расходов отраженных в бухгалтерской и налоговой отчетности", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                CellGenerate.FormulWidthCell(5.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 3 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 2 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year - 1 }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart($"{ DateTime.Now.Year }.г(тыс.руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Возможные причины расхождений", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сравнение полученных доходов", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            //Тестовая модель из БД
            var modelFormula1 = new string[] { "2_010", "2_020", "2_050" };
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("Доходы по налогу на прибыль организаций, тыс.руб. (стр.010 Листа 02+стр.020 Листа 02 + стр.050 Листа 02 + 010 Листа 05)"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Profit.Where(col => modelFormula1.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God1)?.Sum().ToString()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Profit.Where(col => modelFormula1.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God2)?.Sum().ToString()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Profit.Where(col => modelFormula1.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God3)?.Sum().ToString()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("0"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            var modelFormula2 = new string[] { "2110_4", "2310_4", "2320_4", "2340_4" };
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Доходы по отчету о прибылях и убытках, тыс.руб. (стр. 2110_4 + 2310_4 + 2320_4 + 2340_4)"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Balans.Where(col => modelFormula2.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God1)?.Sum().ToString()),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Balans.Where(col => modelFormula2.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God2)?.Sum().ToString()),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Balans.Where(col => modelFormula2.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God3)?.Sum().ToString()),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("0"),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Отклонение, тыс.руб."),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сравнение понесенных расходов", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 6, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            var modelFormula3 = new string[] { "2_030", "2_040" };
            cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("Расходы по налогу на прибыль организаций, тыс.руб. (стр.030 Листа 02 + стр.040 Листа 02 + стр.030 Листа 05)"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Profit.Where(col => modelFormula3.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God1)?.Sum().ToString()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Profit.Where(col => modelFormula3.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God2)?.Sum().ToString()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Profit.Where(col => modelFormula3.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God3)?.Sum().ToString()),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("0"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            var modelFormula4 = new string[] { "2120_4", "2110_4", "2220_4", "2330_4", "2350_4" };
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Расходы по отчету о прибылях и убытках, тыс.руб. (стр. 2120_4 + 2210_4 + 2220_4 + 2330_4 + 2350_4)"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Balans.Where(col => modelFormula4.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God1)?.Sum().ToString()),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Balans.Where(col => modelFormula4.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God2)?.Sum().ToString()),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template?.Balans.Where(col => modelFormula4.Any(formul => formul.Contains(col.CodeParametr))).Select(yers => yers.God3)?.Sum().ToString()),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("0"),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Отклонение, тыс.руб."),
            "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-"),
           "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("36. Удельный вес вычетов в общей сумме начисленного налога на добавленную стоимость за максимальный период проверки. Сумма заявленного НДС отраженных в декларациях и  результаты камеральных проверок.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Период", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Общая сумма НДС (стр.210) (стр.120 по форме от 15.10.2009)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Общая сумма НДС, подлежащая вычету (стр.340) (стр.220 по форме от 15.10.2009) (руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("В т.ч. сумма налога, уплаченная при ввозе товаров на таможенную территорию РФ (стр.270) (стр.170 по форме от 15.10.2009)  (руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Сумма к уплате (+) (стр.350) / сумма к уменьшению (-) (стр.360) (руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Удельный вес вычетов в общей сумме начисленного налога (гр.3/гр.2 х 100) (%)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Заявленная сумма возмещения НДС по ставке 0% (руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Возмещено / (-отказано) (руб.)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("1", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("2", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("3", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("4", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("5", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("6", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("7", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("8", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            //Тестовая модель из БД
            var modelYear = template.Nds.GroupBy(y => y.God).Select(year => year.Key);

            foreach (var y in modelYear)
            {
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart($"{y.ToString()}.г", "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 8));
                table.Append(rows.GenerateRow(ref cellCollection));
                foreach (var period in template.Nds.Where(year => year.God == y))
                {
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(period.Period, "20", JustificationValues.Center),
                             "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(period.Summ.ToString(), "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(period.SummOut.ToString(), "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(period.SummNalog.ToString(), "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart(period.SummIn.ToString(), "20", JustificationValues.Center),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart($"{ Math.Round(((double)period.SummOut / (double) period.Summ) * 100.0f,2)}"),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("0"),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    cellCollection.Add(CellGenerate.GenerateCell(
                        paragraphGenerate.RunParagraphGeneratorStandart("0"),
                        "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                    table.Append(rows.GenerateRow(ref cellCollection));
                }

                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("ИТОГО", "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(template?.Nds.Where(col => col.God == y).Select(yers => yers.Summ)?.Sum().ToString(), "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(template?.Nds.Where(col => col.God == y).Select(yers => yers.SummOut)?.Sum().ToString(), "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(template?.Nds.Where(col => col.God == y).Select(yers => yers.SummNalog)?.Sum().ToString(), "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart(template?.Nds.Where(col => col.God == y).Select(yers => yers.SummIn)?.Sum().ToString(), "20", JustificationValues.Center),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart($"{ Math.Round(((double)template?.Nds.Where(col => col.God == y).Select(yers => yers.SummOut)?.Sum() / (double)template?.Nds.Where(col => col.God == y).Select(yers => yers.Summ)?.Sum()) * 100.0f,2)}"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("0"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                cellCollection.Add(CellGenerate.GenerateCell(
                    paragraphGenerate.RunParagraphGeneratorStandart("0"),
                    "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
                table.Append(rows.GenerateRow(ref cellCollection));
            }

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("37. Сведения о налоговых льготах по НДС, используемых налогоплательщиком", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("38. Проверка обоснованности сумм, заявленных к возмещению налога на добавленную стоимость на предмет обоснованности возмещения. Результаты камеральной проверки.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("39. Анализ показателей налоговой нагрузки", "24"));
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Показатель", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(11), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter) ? $"{DateTime.Now.Year - 3}.г" : $"{param.Parameter}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter1) ? $"{DateTime.Now.Year - 2}.г" : $"{param.Parameter1}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Показатель").Select(param => string.IsNullOrWhiteSpace(param.Parameter2) ? $"{DateTime.Now.Year - 1}.г" : $"{param.Parameter2}.г").FirstOrDefault(), "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Налоговая нагрузка до проверки,%"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Коэффициент начисленных налогов").Select(param => param.Parameter).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Коэффициент начисленных налогов").Select(param => param.Parameter1).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Коэффициент начисленных налогов").Select(param => param.Parameter2).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Налоговая нагрузка, исходя из предполагаемой суммы доначислений,  указанной в Докладной записке,%"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Максимальная налоговая нагрузка по налогоплательщикам, осуществляющим аналогичный вид экономической деятельности"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("-", "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Справочно: средний показатель налоговой нагрузки по виду экономической деятельности, %"),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднеотраслевой коэффициент по РФ").Select(param => param.Parameter).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднеотраслевой коэффициент по РФ").Select(param => param.Parameter1).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(template.Card?.List2Card.Where(key => key.Keys == "Среднеотраслевой коэффициент по РФ").Select(param => param.Parameter2).FirstOrDefault(), "20", JustificationValues.Center),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("40. Зона риска, в которую входит налогоплательщик (в соответствии с Концепцией системы планирования выездных налоговых проверок (далее - ВНП), утвержденной Приказом ФНС России от 30.05.2007 №ММ-3-06/333 (в ред. Приказа ФНС РФ от 22.09.2010 №ММВ-7-2/461 (далее - Приказ ФНС России от 30.05.2007 №ММ-3-06/333)).", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ п/п", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ по приказу ММ-3 06/333", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Выявленные общедоступные критерии оценки рисков", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(13.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Проведение мероприятий налогового контроля", "24", JustificationValues.Center, 1));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("41. Направленные в рамках ст. 93.1 НК РФ поручения об истребовании документов у анализируемого налогоплательщика и его контрагентов с указанием результатов проведенных мероприятий.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ п/п", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(1.2), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование контрагента (ИНН), в отношении которого истребуются документы", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Налоговый орган, в который направлено поручение", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№, дата поручения", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.6), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№, дата ответа об исполнении поручения", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3.1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Результаты проведенных мероприятий", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("42. Информация о проведенных допросах должностных лиц анализируемого налогоплательщика и его контрагентов.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            table = new Table();
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("ФИО должностного лица", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.5), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Должность", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Наименование (ИНН) налогоплательщика – работодателя должностного лица", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("№ и дата протокола допроса", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(2.4), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Налоговый орган, проводивший допрос", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(3), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart("Результаты допроса (краткое изложение показаний должностного лица)", "20", JustificationValues.Center),
                CellGenerate.FormulWidthCell(4.1), TableWidthUnitValues.Dxa, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull(), 0, 0, "FFFFCC"));
            table.Append(rows.GenerateRow(ref cellCollection));

            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            cellCollection.Add(CellGenerate.GenerateCell(
                paragraphGenerate.RunParagraphGeneratorStandart(),
                "0", TableWidthUnitValues.Nil, "100", "100", TableVerticalAlignmentValues.Center, CellBorders.GenerateBorderFull()));
            table.Append(rows.GenerateRow(ref cellCollection));

            body.Append(table);
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart());
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Заключение отдела урегулирования задолженности", "24", JustificationValues.Left, 2));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("1. Сведения о наличии (отсутствии) задолженности по состоянию на   последний операционный день.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("2. Информация о мерах принудительного взыскания задолженности (в том числе в соответствии со ст. 47 НК РФ).", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("3. Информация об аресте имущества.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("4. Сведения о возможности проведения зачетов в счет погашения задолженности в соответствии со ст. 78 НК РФ", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Заключение юридического отдела", "24", JustificationValues.Left, 2));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Сведения об участии налогоплательщика в досудебных и судебных спорах.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Заключение отдела оперативного контроля", "24", JustificationValues.Left, 2));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("1. Сведения о проверках Контрольно-кассовой техники и их результатах.", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("2. Сведения об установлении местонахождения органов управления юридических лиц (Акт обследования адреса места нахождения постоянно действующего исполнительного органа юридического лица №__от _____г. )", "24"));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Заключение контрольно-аналитического отдела", "24", JustificationValues.Left, 2));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("Информация о выявленных Расхождениях вида «разрыв»", "24"));
            body.Append(new Paragraph(new Run(new Break() { Type = BreakValues.Page })));
            body.Append(paragraphGenerate.RunParagraphGeneratorStandart("ВЫВОДЫ:", "24", JustificationValues.Center, 1));
            return body;
        }
    }
}
