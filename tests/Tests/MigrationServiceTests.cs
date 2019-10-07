﻿using ArdiLabs.Yuniql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.IO;
using Shouldly;

namespace Yuniql.Tests
{
    [TestClass]
    public class MigrationServiceTests
    {
        [TestInitialize]
        public void Setup()
        {
            var workingPath = TestHelper.GetWorkingPath();
            if (!Directory.Exists(workingPath))
            {
                Directory.CreateDirectory(workingPath);
            }
        }

        [TestMethod]
        public void Test_Run_Without_AutocreateDB_Throws_Exception()
        {
            //arrange
            var workingPath = TestHelper.GetWorkingPath();
            var databaseName = new DirectoryInfo(workingPath).Name;
            var connectionString = TestHelper.GetConnectionString(databaseName);

            var localVersionService = new LocalVersionService();
            localVersionService.Init(workingPath);

            //act and assert
            var migrationService = new MigrationService();
            Assert.ThrowsException<SqlException>(() =>
            {
                migrationService.Run(workingPath, connectionString, null, autoCreateDatabase: false);
            }).Message.Contains($"Cannot open database \"{databaseName}\"").ShouldBeTrue();
        }

        [TestMethod]
        public void Test_Run_With_AutocreateDB()
        {
            //arrange
            var workingPath = TestHelper.GetWorkingPath();
            var databaseName = new DirectoryInfo(workingPath).Name;
            var connectionString = TestHelper.GetConnectionString(databaseName);

            var localVersionService = new LocalVersionService();
            localVersionService.Init(workingPath);
            localVersionService.IncrementMajorVersion(workingPath, null);
            localVersionService.IncrementMinorVersion(workingPath, null);

            //act
            var migrationService = new MigrationService();
            migrationService.Run(workingPath, connectionString, "v1.01", autoCreateDatabase: true);

            //assert
            migrationService.IsTargetDatabaseExists(new SqlConnectionStringBuilder(connectionString), databaseName);
        }

        [TestMethod]
        public void Test_Run_Database_Already_Updated()
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void Test_Run_Database_Init_Scripts_Executed()
        {
            throw new System.NotImplementedException();
        }
        public void Test_Run_Database_Pre_Scripts_Executed()
        {
            throw new System.NotImplementedException();
        }

        public void Test_Run_Database_Draft_Scripts_Executed()
        {
            throw new System.NotImplementedException();
        }

        public void Test_Run_Database_Version_Scripts_Executed()
        {
            throw new System.NotImplementedException();
        }

        public void Test_Run_Database_Executed_All_Versions()
        {
            throw new System.NotImplementedException();
        }

        public void Test_Run_Database_Skipped_Versions_Lower_Or_Same_As_Latest()
        {
            throw new System.NotImplementedException();
        }

        public void Test_Run_Database_Skipped_Versions_Higher_Than_Target_Version()
        {
            throw new System.NotImplementedException();
        }

    }
}