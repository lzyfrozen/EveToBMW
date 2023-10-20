using Microsoft.AspNetCore.Mvc.TagHelpers;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class ExcelNameAttribute : Attribute
    {
        /// <summary>
        /// 名称属性
        /// </summary>
        public string Name { get; set; }

        //构造函数，设置属性参数
        public ExcelNameAttribute(string name)
        {
            Name = name;
        }
    }

    public class ExcelHelper
    {
        public static readonly ExcelHelper Instance = new ExcelHelper();
        public AppFolders AppFolders { get; set; }

        public ExcelHelper()
        {
            AppFolders = new AppFolders();
        }
        public DownloadFile CreateExcelPackage(string fileName, Action<ExcelHelper, ExcelPackage> creator)
        {
            var file = new DownloadFile(fileName, MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet);

            using (var excelPackage = new ExcelPackage())
            {
                creator(this, excelPackage);
                Save(excelPackage, file);
            }

            return file;
        }

        public void AddHeader(ExcelWorksheet sheet, params string[] headerTexts)
        {

            if (headerTexts == null || headerTexts.Length == 0)
            {
                return;
            }

            for (var i = 0; i < headerTexts.Length; i++)
            {
                AddHeader(sheet, i + 1, headerTexts[i]);
            }
        }

        public void AddHeader(ExcelWorksheet sheet, int columnIndex, string headerText)
        {
            sheet.Cells[1, columnIndex].Value = headerText;
            sheet.Cells[1, columnIndex].Style.Font.Bold = true;
        }

        public void AddObjects<T>(ExcelWorksheet sheet, int startRowIndex, IList<T> items, params Func<T, object>[] propertySelectors)
        {
            if ((items == null || items.Count == 0) || (propertySelectors == null || propertySelectors.Length == 0))
            {
                return;
            }

            for (var i = 0; i < items.Count; i++)
            {
                for (var j = 0; j < propertySelectors.Length; j++)
                {
                    sheet.Cells[i + startRowIndex, j + 1].Value = propertySelectors[j](items[i]);
                }
            }
        }

        public void Save(ExcelPackage excelPackage, DownloadFile file)
        {
            AppFolders.TempFileDownloadFolder = AppDomain.CurrentDomain.BaseDirectory + "Excel";
            var di = new DirectoryInfo(AppFolders.TempFileDownloadFolder);
            if (!di.Exists)
            {
                di.Create();
            }
            var filePath = Path.Combine(AppFolders.TempFileDownloadFolder, file.FileName);
            excelPackage.SaveAs(new FileInfo(filePath));
        }
        public void Save(ExcelPackage excelPackage, DownloadFile file, string path)
        {
            var filePath = Path.Combine(path, file.FileName);
            excelPackage.SaveAs(new FileInfo(filePath));
        }

        public List<ExcelWorksheet> LoadExcel(string fileName)
        {
            List<ExcelWorksheet> lstsheet = new List<ExcelWorksheet>();
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("文件名必须正确!");
            }
            var existingFile = new FileInfo(fileName);

            var dictHeader = new Dictionary<string, int>();

            var package = new ExcelPackage(existingFile);
            if (!package.File.Exists) throw new ArgumentNullException(new StringBuilder(fileName).Append("不存在!").ToString());
            try
            {
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    if (sheet.Dimension == null) throw new ArgumentNullException(new StringBuilder(fileName).Append($"-表[{sheet.Name}]没有数据!").ToString());

                    lstsheet.Add(sheet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstsheet;
        }

        public ExcelWorksheet LoadExcel(string fileName, int indexSheet)
        {
            if (string.IsNullOrEmpty(fileName) || indexSheet <= 0)
            {
                throw new ArgumentNullException("文件名和sheet页必须正确!");
            }
            var existingFile = new FileInfo(fileName);

            var dictHeader = new Dictionary<string, int>();

            var package = new ExcelPackage(existingFile);
            if (!package.File.Exists) throw new ArgumentNullException(new StringBuilder(fileName).Append("不存在!").ToString());
            ExcelWorksheet worksheet;
            try
            {
                worksheet = package.Workbook.Worksheets[indexSheet];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (worksheet.Dimension == null) throw new ArgumentNullException(new StringBuilder(fileName).Append("没有数据!").ToString());

            return worksheet;
        }

        /// <summary>
        /// Excel导入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="indexSheet"></param>
        /// <returns></returns>
        public List<T> LoadFromExcel<T>(string fileName, int indexSheet) where T : new()
        {
            if (string.IsNullOrEmpty(fileName) || indexSheet <= 0)
            {
                throw new ArgumentNullException("文件名和sheet页必须正确!");
            }
            var existingFile = new FileInfo(fileName);
            var resultList = new List<T>();
            var dictHeader = new Dictionary<string, int>();

            var package = new ExcelPackage(existingFile);
            if (!package.File.Exists) throw new ArgumentNullException(new StringBuilder(fileName).Append("不存在!").ToString());
            ExcelWorksheet worksheet;
            try
            {
                worksheet = package.Workbook.Worksheets[indexSheet];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (worksheet.Dimension == null) throw new ArgumentNullException(new StringBuilder(fileName).Append("没有数据!").ToString());
            var colStart = worksheet.Dimension.Start.Column;  //工作区开始列
            var colEnd = worksheet.Dimension.End.Column;       //工作区结束列
            var rowStart = worksheet.Dimension.Start.Row;       //工作区开始行号
            var rowEnd = worksheet.Dimension.End.Row;       //工作区结束行号
            //将每列标题添加到字典中
            for (var i = colStart; i <= colEnd; i++)
            {
                dictHeader[worksheet.Cells[rowStart, i].Value.ToString()] = i;
            }

            var propertyInfoList = new List<PropertyInfo>(typeof(T).GetProperties());
            for (var row = rowStart + 1; row <= rowEnd; row++)
            {
                var result = new T();
                //为对象T的各属性赋值
                foreach (PropertyInfo p in propertyInfoList)
                {
                    try
                    {
                        var colName = (ExcelNameAttribute)p.GetCustomAttribute(typeof(ExcelNameAttribute), true);
                        if (colName == null) continue;
                        var cell = worksheet.Cells[row, dictHeader[colName.Name]]; //与属性名对应的单元格

                        if (cell.Value == null)
                            continue;
                        switch (p.PropertyType.FullName)
                        {
                            case "System.String":
                                p.SetValue(result, cell.GetValue<string>());
                                break;
                            case "System.Int16":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Int32":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Int64":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Decimal":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Double":
                                p.SetValue(result, cell.GetValue<double>());
                                break;
                            case "System.DateTime":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Boolean":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                            case "System.Byte":
                                p.SetValue(result, cell.GetValue<byte>());
                                break;
                            case "System.Char":
                                p.SetValue(result, cell.GetValue<char>());
                                break;
                            case "System.Single":
                                p.SetValue(result, cell.GetValue<float>());
                                break;
                            //可空类型
                            case "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {

                    }
                }
                resultList.Add(result);
            }
            return resultList;
        }

        public List<T> LoadFromExcel<T>(ExcelWorksheet worksheet, Func<T, bool> IgnoreCheck = null) where T : new()
        {
            //if (string.IsNullOrEmpty(fileName) || indexSheet <= 0)
            //{
            //    throw new ArgumentNullException("文件名和sheet页必须正确!");
            //}
            //var existingFile = new FileInfo(fileName);
            var resultList = new List<T>();
            var dictHeader = new Dictionary<string, int>();

            //var package = new ExcelPackage(existingFile);
            //if (!package.File.Exists) throw new ArgumentNullException(new StringBuilder(fileName).Append("不存在!").ToString());
            //ExcelWorksheet worksheet;
            //try
            //{
            //    worksheet = package.Workbook.Worksheets[indexSheet];
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //if (worksheet.Dimension == null) throw new ArgumentNullException(new StringBuilder(fileName).Append("没有数据!").ToString());
            var colStart = worksheet.Dimension.Start.Column;  //工作区开始列
            var colEnd = worksheet.Dimension.End.Column;       //工作区结束列
            var rowStart = worksheet.Dimension.Start.Row;       //工作区开始行号
            var rowEnd = worksheet.Dimension.End.Row;       //工作区结束行号
            //将每列标题添加到字典中
            for (var i = colStart; i <= colEnd; i++)
            {
                dictHeader[worksheet.Cells[rowStart, i].Value.ToString()] = i;
            }
            var propertyInfoList = new List<PropertyInfo>(typeof(T).GetProperties());
            rowStart = 19962;
            for (var row = rowStart + 1; row <= rowEnd; row++)
            {
                var result = new T();
                //为对象T的各属性赋值
                foreach (PropertyInfo p in propertyInfoList)
                {
                    try
                    {
                        var colName = GetExcelName(p);//(ExcelNameAttribute)p.GetCustomAttribute(typeof(ExcelNameAttribute), true);

                        if (colName == null) continue;
                        var cell = worksheet.Cells[row, dictHeader[colName.Name]]; //与属性名对应的单元格

                        if (cell.Value == null)
                            continue;
                        switch (p.PropertyType.FullName)
                        {
                            case "System.String":
                                p.SetValue(result, cell.GetValue<string>());
                                break;
                            case "System.Int16":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Int32":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Int64":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Decimal":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Double":
                                p.SetValue(result, cell.GetValue<double>());
                                break;
                            case "System.DateTime":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Boolean":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                            case "System.Byte":
                                p.SetValue(result, cell.GetValue<byte>());
                                break;
                            case "System.Char":
                                p.SetValue(result, cell.GetValue<char>());
                                break;
                            case "System.Single":
                                p.SetValue(result, cell.GetValue<float>());
                                break;
                            //可空类型
                            case "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                        }
                        //Console.Write($"index:{row},colName:{colName.Name},value:{cell.Value}");
                    }
                    catch (KeyNotFoundException ex)
                    {
                        if (ex.Message.Contains("The given key 'cell_supplier_box_id' was not present in the dictionary"))
                        {
                            continue;
                        }

                    }
                    catch(Exception ex)
                    {
                        var colName = GetExcelName(p);
                        var cell = worksheet.Cells[row, dictHeader[colName.Name]];
                        throw new Exception($"index:{row},colName:{colName.Name},cell:{cell.Value}", ex);
                    }
                }
                if (IgnoreCheck != null && IgnoreCheck(result)) continue;
                resultList.Add(result);
            }
            return resultList;
        }

        public List<T> LoadFromExcel<T>(string fileName, int indexSheet, int colStart, int colEnd, int rowStart, int rowEnd) where T : new()
        {
            if (string.IsNullOrEmpty(fileName) || indexSheet <= 0)
            {
                throw new ArgumentNullException("文件名和sheet页必须正确!");
            }
            var existingFile = new FileInfo(fileName);
            var resultList = new List<T>();
            var dictHeader = new Dictionary<string, int>();

            var package = new ExcelPackage(existingFile);
            if (!package.File.Exists) throw new ArgumentNullException(new StringBuilder(fileName).Append("不存在!").ToString());
            ExcelWorksheet worksheet;
            try
            {
                worksheet = package.Workbook.Worksheets[indexSheet];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (worksheet.Dimension == null) throw new ArgumentNullException(new StringBuilder(fileName).Append("没有数据!").ToString());
            //var colStart = worksheet.Dimension.Start.Column;  //工作区开始列
            //var colEnd = worksheet.Dimension.End.Column;       //工作区结束列
            //var rowStart = worksheet.Dimension.Start.Row;       //工作区开始行号
            //var rowEnd = worksheet.Dimension.End.Row;       //工作区结束行号
            //将每列标题添加到字典中
            for (var i = colStart; i <= colEnd; i++)
            {
                dictHeader[worksheet.Cells[rowStart, i].Value.ToString()] = i;
            }

            var propertyInfoList = new List<PropertyInfo>(typeof(T).GetProperties());
            for (var row = rowStart + 1; row <= rowEnd; row++)
            {
                var result = new T();
                //为对象T的各属性赋值
                foreach (PropertyInfo p in propertyInfoList)
                {
                    try
                    {
                        var colName = (ExcelNameAttribute)p.GetCustomAttribute(typeof(ExcelNameAttribute), true);
                        if (colName == null) continue;
                        var cell = worksheet.Cells[row, dictHeader[colName.Name]]; //与属性名对应的单元格

                        if (cell.Value == null)
                            continue;
                        switch (p.PropertyType.FullName)
                        {
                            case "System.String":
                                p.SetValue(result, cell.GetValue<string>());
                                break;
                            case "System.Int16":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Int32":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Int64":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Decimal":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Double":
                                p.SetValue(result, cell.GetValue<double>());
                                break;
                            case "System.DateTime":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Boolean":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                            case "System.Byte":
                                p.SetValue(result, cell.GetValue<byte>());
                                break;
                            case "System.Char":
                                p.SetValue(result, cell.GetValue<char>());
                                break;
                            case "System.Single":
                                p.SetValue(result, cell.GetValue<float>());
                                break;
                            //可空类型
                            case "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {

                    }
                }
                resultList.Add(result);
            }
            return resultList;
        }

        public List<T> LoadFromExcel<T>(ExcelWorksheet worksheet, int colStart, int colEnd, int rowStart, int rowEnd, Func<T, bool> IgnoreCheck = null) where T : new()
        {
            //if (string.IsNullOrEmpty(fileName) || indexSheet <= 0)
            //{
            //    throw new ArgumentNullException("文件名和sheet页必须正确!");
            //}
            //var existingFile = new FileInfo(fileName);
            var resultList = new List<T>();
            var dictHeader = new Dictionary<string, int>();

            //var package = new ExcelPackage(existingFile);
            //if (!package.File.Exists) throw new ArgumentNullException(new StringBuilder(fileName).Append("不存在!").ToString());
            //ExcelWorksheet worksheet;
            //try
            //{
            //    worksheet = package.Workbook.Worksheets[indexSheet];
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //if (worksheet.Dimension == null) throw new ArgumentNullException(new StringBuilder(fileName).Append("没有数据!").ToString());
            //var colStart = worksheet.Dimension.Start.Column;  //工作区开始列
            //var colEnd = worksheet.Dimension.End.Column;       //工作区结束列
            //var rowStart = worksheet.Dimension.Start.Row;       //工作区开始行号
            //var rowEnd = worksheet.Dimension.End.Row;       //工作区结束行号
            //将每列标题添加到字典中
            for (var i = colStart; i <= colEnd; i++)
            {
                dictHeader[worksheet.Cells[rowStart, i].Value.ToString()] = i;
            }

            var propertyInfoList = new List<PropertyInfo>(typeof(T).GetProperties());
            for (var row = rowStart + 1; row <= rowEnd; row++)
            {
                var result = new T();
                //为对象T的各属性赋值
                foreach (PropertyInfo p in propertyInfoList)
                {
                    try
                    {
                        var colName = (ExcelNameAttribute)p.GetCustomAttribute(typeof(ExcelNameAttribute), true);
                        if (colName == null) continue;
                        var cell = worksheet.Cells[row, dictHeader[colName.Name]]; //与属性名对应的单元格

                        if (cell.Value == null)
                            continue;
                        switch (p.PropertyType.FullName)
                        {
                            case "System.String":
                                p.SetValue(result, cell.GetValue<string>());
                                break;
                            case "System.Int16":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Int32":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Int64":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Decimal":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Double":
                                p.SetValue(result, cell.GetValue<double>());
                                break;
                            case "System.DateTime":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Boolean":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                            case "System.Byte":
                                p.SetValue(result, cell.GetValue<byte>());
                                break;
                            case "System.Char":
                                p.SetValue(result, cell.GetValue<char>());
                                break;
                            case "System.Single":
                                p.SetValue(result, cell.GetValue<float>());
                                break;
                            //可空类型
                            case "System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<DateTime>());
                                break;
                            case "System.Nullable`1[[System.Int16, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<short>());
                                break;
                            case "System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<int>());
                                break;
                            case "System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<long>());
                                break;
                            case "System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<decimal>());
                                break;
                            case "System.Nullable`1[[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]":
                                p.SetValue(result, cell.GetValue<bool>());
                                break;
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {

                    }
                }
                if (IgnoreCheck != null && IgnoreCheck(result)) continue;
                resultList.Add(result);
            }
            return resultList;
        }

        private static Dictionary<PropertyInfo, ExcelNameAttribute> ExcelNameDictionary = new Dictionary<PropertyInfo, ExcelNameAttribute>();
        private ExcelNameAttribute GetExcelName(PropertyInfo p)
        {
            ExcelNameAttribute name = null;
            if (ExcelNameDictionary.TryGetValue(p, out name))
            {
                return name;
            }
            name = (ExcelNameAttribute)p.GetCustomAttribute(typeof(ExcelNameAttribute), true);
            ExcelNameDictionary.Add(p, name);
            return name;
        }
    }

}
