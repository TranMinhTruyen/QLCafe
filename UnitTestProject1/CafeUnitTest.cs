﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe;
using System.Data.SQLite;

namespace CafeTester
{
    [TestClass]
    [DeploymentItem(@"x86\SQLite.Interop.dll", "x86")]
    public class CafeUnitTest
    {
        public TestContext TestContext { get; set; }

        #region Test Account Methods
        [TestMethod]
        public void Test_Account_Is_Exit()
        {
            string userName = "tk123";
            string passWord = "123456789";

            bool expected = true;
            bool actual = Cafe.AccoutProvider.Instance.CheckAccoutExit(userName, passWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Account_IsNot_Exit()
        {
            string userName = "tk121";
            string passWord = "123456789";

            bool expected = false;
            bool actual = Cafe.AccoutProvider.Instance.CheckAccoutExit(userName, passWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(@"AccountDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\AccountDataTest.csv", "AccountDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Account_Show()
        {
            string userName = TestContext.DataRow[0].ToString();
            string passWord = TestContext.DataRow[1].ToString();

            long expected = Convert.ToInt64(TestContext.DataRow[2].ToString());
            long actual = Cafe.AccoutProvider.Instance.CheckAcount(userName, passWord);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DeploymentItem(@"AccountDataTestType.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\AccountDataTestType.csv", "AccountDataTestType#csv", DataAccessMethod.Sequential)]
        public void Test_Account_Type()
        {
            string userName = TestContext.DataRow[0].ToString();

            long expected = Convert.ToInt64(TestContext.DataRow[1].ToString());
            long actual = Cafe.AccoutProvider.Instance.GetAccountType(userName);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Test Table Methods
        [TestMethod]
        public void Test_Get_Table_By_Right_Id()
        {
            long Id = 1;

            Table result = Cafe.TableProvider.Instance.GetTable_By_Id(Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Get_Table_By_Wrong_Id()
        {
            long Id = 0;

            Table result = Cafe.TableProvider.Instance.GetTable_By_Id(Id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Insert_Table()
        {
            string name = "A";

            bool expected = true;
            bool actual = TableProvider.Instance.InsertTable(name);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            long idMax = TableProvider.Instance.GetMaxTableID();
            TableProvider.Instance.DeleteTable(idMax);
        }

        [TestMethod]
        [DeploymentItem(@"TableDataTestUpdate.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TableDataTestUpdate.csv", "TableDataTestUpdate#csv", DataAccessMethod.Sequential)]
        public void Test_Update_Table()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();

            TableProvider.Instance.InsertTable(name); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.TableProvider.Instance.UpdateTable(id, name);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            long idMax = TableProvider.Instance.GetMaxTableID();
            TableProvider.Instance.DeleteTable(idMax);
        }

        [TestMethod]
        [DeploymentItem(@"TableDataTestUpdate.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TableDataTestUpdate.csv", "TableDataTestUpdate#csv", DataAccessMethod.Sequential)]
        public void Test_Update_Status_Table_To_1()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();

            TableProvider.Instance.InsertTable(name); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.TableProvider.Instance.UpdateTableStatus_1(id);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            long idMax = TableProvider.Instance.GetMaxTableID();
            TableProvider.Instance.DeleteTable(idMax);

        }

        [TestMethod]
        [DeploymentItem(@"TableDataTestUpdate.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TableDataTestUpdate.csv", "TableDataTestUpdate#csv", DataAccessMethod.Sequential)]
        public void Test_Update_Status_Table_To_0()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();

            TableProvider.Instance.InsertTable(name); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.TableProvider.Instance.UpdateTableStatus_0(id);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            long idMax = TableProvider.Instance.GetMaxTableID();
            TableProvider.Instance.DeleteTable(idMax);
        }

        [TestMethod]
        [DeploymentItem(@"TableDataTestUpdate.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TableDataTestUpdate.csv", "TableDataTestUpdate#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_Table()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();

            TableProvider.Instance.InsertTable(name); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.TableProvider.Instance.DeleteTable(id);

            Assert.AreEqual(expected, actual);

            if (id == 0)
            {
                long idMax = TableProvider.Instance.GetMaxTableID();
                TableProvider.Instance.DeleteTable(idMax);
            }
        }

        [TestMethod]
        [DeploymentItem(@"TableDataTestSwitch.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\TableDataTestSwitch.csv", "TableDataTestSwitch#csv", DataAccessMethod.Sequential)]
        public void Test_Switch_Table()
        {
            long idOld = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idNew = Convert.ToInt64(TestContext.DataRow[1].ToString());

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.TableProvider.Instance.SwitchTable(idOld, idNew);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Test Category Methods
        [TestMethod]
        public void Test_Insert_Category()
        {
            string name = "A";

            bool expected = true;
            bool actual = CategoryProvider.Instance.InsertCategory(name);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            long idMax = CategoryProvider.Instance.GetMaxCategoryID();
            CategoryProvider.Instance.DeleteCategory(idMax);
        }

        [TestMethod]
        [DeploymentItem(@"CategoryDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\CategoryDataTest.csv", "CategoryDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Update_Category()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();

            CategoryProvider.Instance.InsertCategory(name); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.CategoryProvider.Instance.UpdateCategory(id, name);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            long idMax = CategoryProvider.Instance.GetMaxCategoryID();
            CategoryProvider.Instance.DeleteCategory(idMax);
        }
     
        [TestMethod]
        [DeploymentItem(@"CategoryDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\CategoryDataTest.csv", "CategoryDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_Category()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();

            CategoryProvider.Instance.InsertCategory(name); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.CategoryProvider.Instance.DeleteCategory(id);

            Assert.AreEqual(expected, actual);

            if (id == 0)
            {
                long idMax = CategoryProvider.Instance.GetMaxCategoryID();
                CategoryProvider.Instance.DeleteCategory(idMax);
            }
        }
        #endregion

        #region Test Drink Methods
        [TestMethod]
        [DeploymentItem(@"DrinkDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\DrinkDataTest.csv", "DrinkDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Get_List_Drink_By_CategoryId()
        {
            long idCategory = Convert.ToInt64(TestContext.DataRow[2].ToString());

            long expected = Convert.ToInt64(TestContext.DataRow[3].ToString());
            long actual = Cafe.DrinkProvider.Instance.GetDrink_ByCategoryId(idCategory).Count;

            Assert.AreEqual(expected, actual);
        }

           
        [TestMethod]
        [DeploymentItem(@"DrinkDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\DrinkDataTest.csv", "DrinkDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Insert_Drink()
        {
            string name = TestContext.DataRow[1].ToString();
            long price = 0;
            long idCategory = Convert.ToInt64(TestContext.DataRow[2].ToString());

            bool expected = Convert.ToBoolean(TestContext.DataRow[4].ToString());
            bool actual = Cafe.DrinkProvider.Instance.InsertDrink(name, price, idCategory);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            if(idCategory != 0)
            {
                long idMax = DrinkProvider.Instance.GetMaxDrinkId();
                DrinkProvider.Instance.DeleteDrink(idMax);
            }
        }

        [TestMethod]
        [DeploymentItem(@"DrinkDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\DrinkDataTest.csv", "DrinkDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Update_Drink()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();
            long price = 0;
            long idCategory = Convert.ToInt64(TestContext.DataRow[2].ToString());

            DrinkProvider.Instance.InsertDrink(name, price, idCategory); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[4].ToString());
            bool actual = Cafe.DrinkProvider.Instance.UpdateDrink(id, name, price, idCategory);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            if (id != 0)
            {
                long idMax = DrinkProvider.Instance.GetMaxDrinkId();
                DrinkProvider.Instance.DeleteDrink(idMax);
            }
        }

        [TestMethod]
        [DeploymentItem(@"DrinkDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\DrinkDataTest.csv", "DrinkDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_Drink()
        {
            long id = Convert.ToInt64(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();
            long idCategory = Convert.ToInt64(TestContext.DataRow[2].ToString());

            DrinkProvider.Instance.InsertDrink(name, 0, idCategory); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[4].ToString());
            bool actual = Cafe.DrinkProvider.Instance.DeleteDrink(id);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            if (idCategory == 0 && id != 0)
            {
                long idMax = DrinkProvider.Instance.GetMaxDrinkId();
                DrinkProvider.Instance.DeleteDrink(idMax);
            }
        }
        #endregion

        #region Test Menu Methods
        [TestMethod]
        [DeploymentItem(@"MenuDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\MenuDataTest.csv", "MenuDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Get_List_Menu()
        {
            long idBill = 1;
            long idDrink = 1;
            long idTable = Convert.ToInt64(TestContext.DataRow[0].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data
            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            long expected = Convert.ToInt64(TestContext.DataRow[1].ToString());
            long actual = Cafe.MenuProvider.Instance.GetListMenu(idTable).Count;

            Assert.AreEqual(expected, actual);

            // Create Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillInfoProvider.Instance.DeleteBillInfo_By_IdBillInfo(idBill);
            BillProvider.Instance.DeleteBill(idBill);
        }
        #endregion

        #region Test Bill Methods
        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Get_BillId_By_TableId()
        {
            long idTable = Convert.ToInt64(TestContext.DataRow[1].ToString());
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());

            long expected = Convert.ToInt64(TestContext.DataRow[3].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            long actual = Cafe.BillProvider.Instance.GetBillId_By_TableId(idTable);

            Assert.AreEqual(expected, actual);

            // Create Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillProvider.Instance.DeleteBill(idBill);
        }

        [TestMethod]
        public void Test_Get_BillId_By_Right_IdBill()
        {
            long idTable = 1;
            long idBill = 1;

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            Bill result = Cafe.BillProvider.Instance.GetBill_By_Id(idBill);

            Assert.IsNotNull(result);

            // Create Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(idBill, 0);
            BillProvider.Instance.DeleteBill(idBill);
        }

        [TestMethod]
        public void Test_Get_BillId_By_Wrong_IdBill()
        {
            long idBill = 0;

            Bill result = Cafe.BillProvider.Instance.GetBill_By_Id(idBill);

            Assert.IsNull(result);
        }

        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Get_List_Bill_By_TableId()
        {
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idTable = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            long expected = Convert.ToInt64(TestContext.DataRow[4].ToString());
            long actual = Cafe.BillProvider.Instance.GetListBill_By_TableID(idTable).Count;

            Assert.AreEqual(expected, actual);

            // Create Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Get_List_Bill_By_DrinkId()
        {
            long idTable = 1;
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idDrink = Convert.ToInt64(TestContext.DataRow[2].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data
            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            long expected = Convert.ToInt64(TestContext.DataRow[4].ToString());
            long actual = Cafe.BillProvider.Instance.GetListBillId_By_IdDrink(idDrink).Count;

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillInfoProvider.Instance.DeleteBillInfo_By_idBill(idBill);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        
        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Insert_Bill()
        {
            long idTable = Convert.ToInt64(TestContext.DataRow[1].ToString());

            bool expected = Convert.ToBoolean(TestContext.DataRow[5].ToString());
            bool actual = Cafe.BillProvider.Instance.InsertBill(idTable);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Update_Status_Bill()
        {
            long idTable = Convert.ToInt64(TestContext.DataRow[1].ToString());
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long totalPrice = 0;

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[5].ToString());
            bool actual = Cafe.BillProvider.Instance.UpdateStatusBill(idBill, totalPrice);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_Bill_By_IdBill()
        {
            long idTable = Convert.ToInt64(TestContext.DataRow[1].ToString());
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[5].ToString());
            bool actual = Cafe.BillProvider.Instance.DeleteBill(idBill);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillDataTest.csv", "BillDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_Bill_By_IdTable()
        {
            long idTable = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[5].ToString());
            bool actual = Cafe.BillProvider.Instance.DeleteBill_By_IdTable(idTable);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
        }
        #endregion 

        #region Test BillInfo Methods
        [TestMethod]
        public void Test_Get_BillInfo_By_Right_IdDrink_Wrong_IdBill()
        {
            long idDrink = 10;
            long idBill = 0;

            BillInfo result = Cafe.BillInfoProvider.Instance.GetBillInfo_ByDrinkID_And_BillId(idDrink, idBill);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Get_BillInfo_By_Wrong_IdDrink_Right_IdBill()
        {
            long idDrink = 0;
            long idBill = 1;

            BillInfo result = Cafe.BillInfoProvider.Instance.GetBillInfo_ByDrinkID_And_BillId(idDrink, idBill);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Get_BillInfo_By_Wrong_IdDrink_Wrong_IdBill()
        {
            long idDrink = 0;
            long idBill = 0;

            BillInfo result = Cafe.BillInfoProvider.Instance.GetBillInfo_ByDrinkID_And_BillId(idDrink, idBill);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Test_Get_BillInfo_By_Right_IdDrink_Right_IdBill()
        {
            long idDrink = 1;
            long idBill = 1;
            long idTable = 1;

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            BillInfo result = Cafe.BillInfoProvider.Instance.GetBillInfo_ByDrinkID_And_BillId(idDrink, idBill);

            Assert.IsNotNull(result);

            // Create Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillInfoProvider.Instance.DeleteBillInfo_By_IdBillInfo(result.Id);
            BillProvider.Instance.DeleteBill(idBill);
        }

        [TestMethod]
        [DeploymentItem(@"BillInfoDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillInfoDataTest.csv", "BillInfoDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Get_List_BillInfo_By_IdBill()
        {
            long idTable = 1;
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idDrink = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data
            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            long expected = Convert.ToInt64(TestContext.DataRow[2].ToString());
            long actual = Cafe.BillInfoProvider.Instance.GetListBillInfo_By_IdBill(idBill).Count;

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillInfoProvider.Instance.DeleteBillInfo_By_idBill(idBill);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillInfoDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillInfoDataTest.csv", "BillInfoDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Insert_BillInfo()
        {
            long idTable = 1;
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idDrink = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[3].ToString());
            bool actual = Cafe.BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillInfoProvider.Instance.DeleteBillInfo_By_idBill(idBill);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillInfoDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillInfoDataTest.csv", "BillInfoDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Update_BillInfo()
        {
            long idTable = 1;
            long idBill = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idDrink = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data
            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[3].ToString());
            bool actual = Cafe.BillInfoProvider.Instance.UpdateBillInfo(idDrink, idBill);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillInfoProvider.Instance.DeleteBillInfo_By_idBill(idBill);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillInfoDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillInfoDataTest.csv", "BillInfoDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_BillInfo_By_IdDrink()
        {
            long idTable = 1;
            long idBill= Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idDrink = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data
            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[3].ToString());
            bool actual = Cafe.BillInfoProvider.Instance.DeleteBillInfo_By_idDrink(idDrink);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }

        [TestMethod]
        [DeploymentItem(@"BillInfoDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\BillInfoDataTest.csv", "BillInfoDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Delete_BillInfo_By_IdBill()
        {
            long idTable = 1;
            long idBill= Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idDrink = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data
            BillInfoProvider.Instance.InsertBillInfo(idDrink, idBill); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[3].ToString());
            bool actual = Cafe.BillInfoProvider.Instance.DeleteBillInfo_By_idBill(idBill);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }
        #endregion

        #region Test Report Methods
        [TestMethod]
        [DeploymentItem(@"ReportDataTest.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\ReportDataTest.csv", "ReportDataTest#csv", DataAccessMethod.Sequential)]
        public void Test_Insert_Report()
        {
            long idTable = Convert.ToInt64(TestContext.DataRow[0].ToString());
            long idBill = Convert.ToInt64(TestContext.DataRow[1].ToString());

            BillProvider.Instance.InsertBill(idTable); // Create Test Data

            bool expected = Convert.ToBoolean(TestContext.DataRow[2].ToString());
            bool actual = Cafe.ReportProvider.Instance.InsertReport(idTable, idBill);

            Assert.AreEqual(expected, actual);

            // Delete Test Data
            TableProvider.Instance.UpdateTableStatus_0(idTable);
            BillProvider.Instance.UpdateStatusBill(1, 0);
            BillProvider.Instance.DeleteBill_By_IdTable(idTable);
        }
        #endregion
    }
}
