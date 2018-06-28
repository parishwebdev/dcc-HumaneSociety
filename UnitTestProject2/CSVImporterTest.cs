using System;
using System.Data;
using HumaneSociety;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class CSVImporterTest
    {
        [TestMethod]
        public void Expected_ID_Equal_To_Created_Table_ID()
        {
            // arrange
            DataTable dt = new DataTable();
            object expected = 2;

            // act
            dt = CSVImporter.ConvertCSVtoDataTable("animals.csv");
            object actual = dt.Rows[1][0];
            // assert
            Assert.AreEqual(actual, expected);

        }
    }
}
