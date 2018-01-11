using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.OpenXmlFormats;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.Util;

namespace Poxls.Format
{
    class XLSFormat : ILocFormat
    {
        private List<string> metaData;
        public List<string> MetaData
        {
            get
            {
                return metaData;
            }
            private set
            {
                metaData = value;
            }
        }

        private List<LocEntry> entries;
        public List<LocEntry> Entries
        {
            get
            {
                return entries;
            }
            private set
            {
                entries = value;
            }
        }

        public XLSFormat()
        {
            Entries = new List<LocEntry>();
        }

        public XLSFormat(List<LocEntry> entries, List<string> metaData)
        {
            Entries = entries;
            MetaData = metaData;
        }

        public async Task Read(string path, IProgress<string> progressHandler)
        {
            progressHandler.Report("Starting reading *.XLSX file...");
            progressHandler.Report("Path: " + path);

            Entries = new List<LocEntry>();
            MetaData = new List<string>();

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(stream);
                ISheet entriesSheet = workbook.GetSheetAt(0);
                ISheet metaSheet = workbook.GetSheetAt(1);

                for (int i = 0; i <= metaSheet.LastRowNum; i++)
                {
                    IRow row = metaSheet.GetRow(i);
                    MetaData.Add(row.GetCell(0).StringCellValue);
                }

                // First row is contans titles for colums
                for (int i = 1; i <= entriesSheet.LastRowNum; i++)
                {
                    await Task.Run(() =>
                    {
                        var entry = new LocEntry();

                        IRow row = entriesSheet.GetRow(i);

                        entry.msgctxt = row.GetCell(0).StringCellValue;
                        entry.msgid = row.GetCell(1).StringCellValue;
                        entry.msgstr = row.GetCell(2).StringCellValue;
                        entry.translatorComments = GetStringListFromText(row.GetCell(3).StringCellValue);
                        entry.flags = GetStringListFromText(row.GetCell(4).StringCellValue);
                        entry.comments = GetStringListFromText(row.GetCell(5).StringCellValue);
                        entry.references = GetStringListFromText(row.GetCell(6).StringCellValue);

                        Entries.Add(entry);

                        progressHandler.Report(string.Format("Entry {0}/{1}", i, entriesSheet.LastRowNum));
                    });                    
                }
            }
        }

        public void Write(string path, IProgress<string> progressHandler)
        {
            progressHandler.Report("Starting writing *.XLSX file...");
            progressHandler.Report("Path: " + path);

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet entriesSheet = workbook.CreateSheet("Entries");
                ISheet metaSheet = workbook.CreateSheet("MetaData");

                int metaRowIndex = 0;
                foreach (var meta in MetaData)
                {
                    IRow metaRow = metaSheet.CreateRow(metaRowIndex);
                    ICell metaCell = metaRow.CreateCell(0);

                    metaCell.SetCellValue(meta);

                    metaRowIndex++;
                }

                metaSheet.SetColumnWidth(0, 100 * 256);

                IFont titleFont = workbook.CreateFont();
                titleFont.IsBold = true;
                titleFont.FontHeightInPoints = 12;

                ICellStyle titleStyle = workbook.CreateCellStyle();
                titleStyle.FillForegroundColor = HSSFColor.Grey25Percent.Index;
                titleStyle.FillPattern = FillPattern.SolidForeground;
                titleStyle.BorderTop = titleStyle.BorderLeft = titleStyle.BorderRight = titleStyle.BorderBottom = BorderStyle.Thin;
                titleStyle.SetFont(titleFont);

                ICellStyle valuesStyle = workbook.CreateCellStyle();
                valuesStyle.BorderTop = valuesStyle.BorderLeft = valuesStyle.BorderRight = valuesStyle.BorderBottom = BorderStyle.Thin;
                valuesStyle.VerticalAlignment = VerticalAlignment.Center;
                valuesStyle.WrapText = true;

                entriesSheet.DefaultColumnWidth = 30;
                entriesSheet.DefaultRowHeightInPoints = 11 * 3;

                entriesSheet.SetColumnWidth(0, 50 * 256);
                entriesSheet.SetColumnWidth(1, 70 * 256);
                entriesSheet.SetColumnWidth(2, 70 * 256);

                entriesSheet.CreateFreezePane(0, 1);

                IRow titlesRow = entriesSheet.CreateRow(0);
                titlesRow.HeightInPoints = 20;

                ICell keyTitleCell = titlesRow.CreateCell(0);
                ICell nativeTitleCell = titlesRow.CreateCell(1);
                ICell translationTitleCell = titlesRow.CreateCell(2);
                ICell translatorCommentsTitleCell = titlesRow.CreateCell(3);
                ICell flagsTitleCell = titlesRow.CreateCell(4);
                ICell commentsTitleCell = titlesRow.CreateCell(5);
                ICell referencesTitleCell = titlesRow.CreateCell(6);

                foreach (var cell in titlesRow.Cells)
                {
                    cell.CellStyle = titleStyle;
                }

                keyTitleCell.SetCellValue("Key");
                nativeTitleCell.SetCellValue("Orginal");
                translationTitleCell.SetCellValue("Translation");
                translatorCommentsTitleCell.SetCellValue("Comments");
                flagsTitleCell.SetCellValue("Flags");
                commentsTitleCell.SetCellValue("Comments (generated)");
                referencesTitleCell.SetCellValue("References");

                int rowIndex = 1;
                foreach (var entry in Entries)
                {
                    IRow entryRow = entriesSheet.CreateRow(rowIndex);
                    
                    ICell keyCell = entryRow.CreateCell(0);
                    ICell nativeCell = entryRow.CreateCell(1);
                    ICell translationCell = entryRow.CreateCell(2);
                    ICell translatorCommentsCell = entryRow.CreateCell(3);
                    ICell flagsCell = entryRow.CreateCell(4);
                    ICell commentsCell = entryRow.CreateCell(5);
                    ICell referencesCell = entryRow.CreateCell(6);

                    keyCell.SetCellValue(entry.msgctxt);
                    nativeCell.SetCellValue(entry.msgid);
                    translationCell.SetCellValue(entry.msgstr);
                    translatorCommentsCell.SetCellValue(GetMergedStringList(entry.translatorComments));
                    flagsCell.SetCellValue(GetMergedStringList(entry.flags));
                    commentsCell.SetCellValue(GetMergedStringList(entry.comments));
                    referencesCell.SetCellValue(GetMergedStringList(entry.references));


                    foreach (var cell in entryRow.Cells)
                    {
                        cell.CellStyle = valuesStyle;
                    }

                    rowIndex++;
                }

                IConditionalFormattingRule rule = entriesSheet.SheetConditionalFormatting.CreateConditionalFormattingRule(ComparisonOperator.Equal, "\"\"");
                IPatternFormatting fill = rule.CreatePatternFormatting();
                fill.FillBackgroundColor = IndexedColors.Red.Index;
                fill.FillPattern = FillPattern.SolidForeground;

                CellRangeAddress[] regions = {
                        new CellRangeAddress(1, Entries.Count, 2, 2)
                };

                entriesSheet.SheetConditionalFormatting.AddConditionalFormatting(regions, rule);

                workbook.Write(stream);
            }

            progressHandler.Report("File succesfuly created.");
        }

        private static string GetMergedStringList(List<string> list, char separator = ',')
        {
            string mergedList = "";
            foreach (var v in list)
            {
                mergedList += v + separator;
            }

            return mergedList.TrimEnd(separator);
        }

        private static List<string> GetStringListFromText(string text, char separator = ',')
        {
            return text.Split(separator).ToList();
        }
    }
}
