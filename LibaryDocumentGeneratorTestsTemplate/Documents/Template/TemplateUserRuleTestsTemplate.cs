﻿using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text.RegularExpressions;
using EfDatabase.Inventory.BaseLogic.AddObjectDb;
using EfDatabase.Inventory.BaseLogic.Select;
using EfDatabaseAutomation.Automation.Base;
using LibaryDocumentGenerator.Barcode;
using LibaryDocumentGenerator.Documents.Template;
using LibraryAutoSupportSto.Support.SupportPostGet;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LibaryDocumentGeneratorTestsTemplate.Documents.Template
{
    [TestClass()]
    public class TemplateUserRuleTestsTemplate
    {
        [TestMethod()]
        public void CreateDocumTestTemplate()
        {
            var temp = new TemplateUserRule();
            temp.CreateDocum(@"C:\", null, null);
        }
        [TestMethod()]
        public void Inven()
        {
            AddObjectDb add =new AddObjectDb();
            add.IsProcessComplete(1,false);
        }
        [TestMethod()]
        public void TestReportNote()
        {
            var model = new EfDatabaseAutomation.Automation.BaseLogica.ModelGetPost.ModelGetPost();
            var card = model.CardUi("5258111850");
            ReportNote report = new ReportNote();
            report.CreateDocum(@"D:\", card, null);
        }
        [TestMethod()]
        public void FindGroupSecurity()
        {
            var support = new CreateTiсketSupport("7751-00-099", "Qwer1234!!!");
            support.StepTraining();
            support.Steps(support.Logon, "GET");
            support.Dispose();
            support = new CreateTiсketSupport("7751-00-099", "Qwer1234!!!");
            support.StepTraining();
            support.Steps(support.Logon, "GET");
            support.Dispose();
            support = new CreateTiсketSupport("7751-00-099", "Qwer1234!!!");
            support.StepTraining();
            support.Steps(support.Logon, "GET");
            support.Dispose();

        }
        [TestMethod()]
        public void Test()
        {
            using (var users = new UserPrincipal(new PrincipalContext(ContextType.Domain)))
            {
                users.SamAccountName = "7751-00-451";
                using (var searcher = new PrincipalSearcher(users))
                {
                    if (searcher.FindOne() is UserPrincipal user)
                    {
                        var fullPath = user.DistinguishedName.Replace("\\","").Split(',').Where(x => x.Contains("OU=")).Reverse().Aggregate(
                            (element, next) => element + (string.IsNullOrWhiteSpace(element) ? string.Empty : "/") + next).Replace("OU=", "");
                        //return fullPath;
                    }
                }
            }

        }
        [TestMethod()]
        public void Generate()
        {
            var g = new GenerateBarcode();
          //  g.GenerateQrCode();
        }
    }
}