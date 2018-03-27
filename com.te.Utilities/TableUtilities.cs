using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ADX_Regression.ControlUnit
{
    public class TableUtilities
    {
        static List<TableDataCollection> _tabledatacollections = new List<TableDataCollection>();


        //Method to select Airline from the Matrix

        public static void ReadTable(IWebElement Table)
        {
            //Get All the columns from the Table
            //var columns = Table.FindElements(By.TagName("tr"));

            //Get all the rows
            var rows = Table.FindElements(By.TagName("tr"));

            //Create row index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));


                foreach (var colValue in colDatas)
                {

                    if (rowIndex == 0)
                        _tabledatacollections.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = colValue.Text,
                            ColumnValue = colValue.Text

                        });
                    else
                        _tabledatacollections.Add(new TableDataCollection
                        {
                            RowNumber = rowIndex,
                            ColumnName = _tabledatacollections.ElementAt(colIndex).ColumnName,
                            ColumnValue = colValue.Text,
                            //Airline_click = colValue.Text != "" ? null : colValue.FindElements(By.TagName("a"))

                        });

                    //Move to next column
                    colIndex++;
                }
                rowIndex++;
            }
        }
        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tabledatacollections
                        where e.ColumnName.ToUpper() == columnName.ToUpper() && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();
            return data;
        }
        //public static void PerformActionOnCell(string columnIndex,string refColumnName,string refColumnValue, string controlToOperate = null)
        //{
        //    foreach (int RowNumber in GetDynamicRow(refColumnName, refColumnValue))
        //    {
        //        var cell = (from e in _tabledatacollections
        //                    where e.ColumnName.ToUpper() == columnIndex && e.RowNumber == RowNumber
        //                    select e.Airline_click).SingleOrDefault();


        //        if (controlToOperate != null && cell != null)
        //        {
        //            var returnedControl = (from c in cell
        //                                   where c.GetAttribute("value") == controlToOperate  
        //                                   select c).SingleOrDefault();
        //            returnedControl?.Click();
        //        }
        //        else
        //        {
        //            cell?.First().Click();
        //        }
        //    }


        //}
        //private static IEnumerable GetDynamicRow(string columnName, string columnValue)
        //{
        //    foreach (var Table in _tabledatacollections)
        //    {
        //        if (Table.ColumnName == columnName && Table.ColumnValue == columnValue)
        //            yield return Table.RowNumber;

        //    }

        //}

    }


    public class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }

        public IEnumerable<IWebElement> Airline_click { get; set; }
    }

}



