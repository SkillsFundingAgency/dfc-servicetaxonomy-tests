using DFC.ServiceTaxonomy.TestSuite.Extensions;
using DFC.ServiceTaxonomy.TestSuite.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.PageObjects.JobProfiles
{
    class WhatItTakesTab
    {
        private ScenarioContext _scenarioContext;
        private readonly ManageContent _manageContent;
        string[] ExpectedRelatedSkillRecord;
        public WhatItTakesTab(ScenarioContext context)
        {
            _scenarioContext = context;
            _manageContent = new ManageContent(context);
        }

        public bool RelatedSkillsInSequence { get; set; }

        IWebElement tabWhatItTakes => _scenarioContext.GetWebDriver().FindElement(By.CssSelector(".nav-tabs li:nth-of-type(4) > a"));
        IWebElement dropdownRelatedRestrictions => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_Relatedrestrictions_ContentItemIds + div > .multiselect__tags"));
        IWebElement txtfldOtherRequirements => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("label[for='JobProfile_Otherrequirements_Html'] + div > .trumbowyg-editor"));
        IWebElement dropdownDigitalSkills => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("#JobProfile_DigitalSkills_ContentItemIds + div > .multiselect__tags"));
        IWebElement inputRelatedSkillsDropDown => _scenarioContext.GetWebDriver().FindElement(By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following::div[3]"));
        IWebElement inputRelatedSkillsDropDownCSS => _scenarioContext.GetWebDriver().FindElement(By.CssSelector("input[id='JobProfile_Relatedskills_ContentItemIds'] + div > div:nth-of-type(2)"));
        IWebElement inputRelatedSkills => _scenarioContext.GetWebDriver().FindElement(By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following::div[3]/input[@type='text']"));


        public void DisplayWhatItTakesTab()
        {
            Utilities.Hover(_scenarioContext.GetWebDriver(), tabWhatItTakes);
            tabWhatItTakes.Click();
        }

        public void OptionSelection(string option, string field)
        {
            switch (field)
            {
                case "Related restrictions":
                    Utilities.Wait(_scenarioContext.GetWebDriver(), dropdownRelatedRestrictions);
                    dropdownRelatedRestrictions.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_Relatedrestrictions_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
                case "Digital skills":
                    dropdownDigitalSkills.Click();
                    _scenarioContext.GetWebDriver().FindElement(By.XPath(".//*[@id='JobProfile_DigitalSkills_ContentItemIds']//following-sibling::div/div[3]//li[" + option + "]/span/div/span")).Click();
                    break;
            }
        }

        public void TextEntry(string textToEnter, string field)
        {
            switch (field)
            {
                case "Other requirements":
                    txtfldOtherRequirements.SendKeys(textToEnter);
                    break;
            }
        }

        public IList<IWebElement> RelatedSkillsUI()
        {
            return _scenarioContext.GetWebDriver().FindElements(By.CssSelector("div[data-field='Relatedskills'] > div:nth-of-type(1) li span:nth-of-type(1)"));
        }

        public string[] SingleRelatedSkillRecord(string jobProfile, IList<RelatedSkills> relatedSkills)
        {
            IList<RelatedSkills> record = relatedSkills.Where(p => p.Title == jobProfile).ToArray();

            string[] theSkills = { record[0].Skill_01.Trim(), record[0].Skill_02.Trim(),  record[0].Skill_03.Trim(),  record[0].Skill_04.Trim(),  record[0].Skill_05.Trim(),  record[0].Skill_06.Trim(),  record[0].Skill_07.Trim(),  record[0].Skill_08.Trim(),  record[0].Skill_09.Trim(),  record[0].Skill_10.Trim(),
             record[0].Skill_11.Trim(), record[0].Skill_12.Trim(), record[0].Skill_13.Trim(), record[0].Skill_14.Trim(), record[0].Skill_15.Trim(), record[0].Skill_16.Trim(), record[0].Skill_17.Trim(), record[0].Skill_18.Trim(), record[0].Skill_19.Trim(), record[0].Skill_20.Trim() };

            return theSkills;
        }

        public bool RelatedSkillInSequence(string contentType, string jobProfile, IList<RelatedSkills> relatedSkills)
        {
            Utilities.Wait(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.CssSelector("button[value='submit.SaveAndContinue']")));
            Thread.Sleep(250);
            //Utilities.ScrollIntoView(_scenarioContext.GetWebDriver(), inputRelatedSkillsDropDown);

            ExpectedRelatedSkillRecord = SingleRelatedSkillRecord(jobProfile, relatedSkills);
            IList<RelatedSkills> expectedRelatedSkillRecord = relatedSkills.Where(p => p.Title == jobProfile).ToArray();

            //translate IWebElements into a collection of strings so they can be compared
            IEnumerable<string> actual = RelatedSkillsUI().Select(i => i.Text.Trim());

            RelatedSkillsInSequence = actual.SequenceEqual(ExpectedRelatedSkillRecord);

            return RelatedSkillsInSequence;
        }

        public void RearrangeRelatedSkill()
        {
            if (RelatedSkillsInSequence == false)
            {
                try
                {
                    do
                    {
                        _scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Relatedskills'] > div:nth-of-type(1) li button:nth-of-type(2)")).Click();
                    } while (_scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Relatedskills'] > div:nth-of-type(1) li button:nth-of-type(2)")).Displayed);
                }
                catch (NoSuchElementException)
                {

                }

                foreach (string relatedSkill in ExpectedRelatedSkillRecord)
                {
                    var xxx = relatedSkill;
                    //Utilities.javascriptClick(_scenarioContext.GetWebDriver(), By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following::div[3]"));
                    //Utilities.javascriptClick(_scenarioContext.GetWebDriver(), By.CssSelector("input[id='JobProfile_Relatedskills_ContentItemIds'] + div > div:nth-of-type(2)"));
                    //Thread.Sleep(750);
                    inputRelatedSkillsDropDownCSS.Click();
                    inputRelatedSkills.SendKeys(relatedSkill);
                    //Utilities.WaitVisible(_scenarioContext.GetWebDriver(), By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following-sibling::div/div[3]//li/span"));
                    Thread.Sleep(550);
                    _scenarioContext.GetWebDriver().FindElement(By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following-sibling::div/div[3]//li/span")).Click();
                }
            }
        }
        
        
        //public void CheckAndRearrange(string contentType, string jobProfile, IList<RelatedSkills> relatedSkills)
        //{
        //    Utilities.Wait(_scenarioContext.GetWebDriver(), _scenarioContext.GetWebDriver().FindElement(By.CssSelector("button[value='submit.SaveAndContinue']")));
        //    Utilities.ScrollIntoView(_scenarioContext.GetWebDriver(), inputRelatedSkillsDropDown);

        //    string[] ExpectedRelatedSkillRecord = SingleRelatedSkillRecord(jobProfile, relatedSkills);
        //    IList<RelatedSkills> expectedRelatedSkillRecord = relatedSkills.Where(p => p.Title == jobProfile).ToArray();

        //    //translate IWebElements into a collection of strings so they can be compared
        //    IEnumerable<string> actual = RelatedSkillsUI().Select(i => i.Text);

        //    RelatedSkillsInSequence = actual.SequenceEqual(ExpectedRelatedSkillRecord);

        //    if (RelatedSkillsInSequence == false)
        //    {
        //        try
        //        {
        //            do
        //            {
        //                _scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Relatedskills'] > div:nth-of-type(1) li button:nth-of-type(2)")).Click();
        //            } while (_scenarioContext.GetWebDriver().FindElement(By.CssSelector("div[data-field='Relatedskills'] > div:nth-of-type(1) li button:nth-of-type(2)")).Displayed);
        //        }
        //        catch (NoSuchElementException)
        //        {

        //        }

        //        foreach (string relatedSkill in ExpectedRelatedSkillRecord)
        //        {
        //            var xxx = relatedSkill;
        //            inputRelatedSkillsDropDown.Click();
        //            inputRelatedSkills.SendKeys(relatedSkill);
        //            //Utilities.WaitVisible(_scenarioContext.GetWebDriver(), By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following-sibling::div/div[3]//li/span"));
        //            Thread.Sleep(750);
        //            _scenarioContext.GetWebDriver().FindElement(By.XPath("//input[@id='JobProfile_Relatedskills_ContentItemIds']//following-sibling::div/div[3]//li/span")).Click();
        //        }
        //    }
            
        //}
    }
}