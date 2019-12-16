using DFC.ServiceTaxonomy.TestSuite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DFC.ServiceTaxonomy.TestSuite.Extensions
{
    public static class TaxonomyScenarioContextExtension
    {
        #region contants
        const string UriGetAllOccupations = "GetAllOccupations/Execute/";
        const string UriGetAllSkills = "GetAllSkills/Execute/";

        const string keyEscoData = "EscoItemList";
        const string keyOccupationData = "EscoOccupationList";
        const string keySkillData = "EscoSkillList";
        const string keyListOfStrings = "EscoListOfStrings";
        #endregion

        //public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        //{
        //    Set(context, webDriver, WebDriverKey);
        //}

        public static string GetTaxonomyUri(this ScenarioContext context, string resource)
        {
            switch (resource)
            {
                case "GetAllSkills":
                    return context.GetEnv().taxonomyApiBaseUrl + UriGetAllSkills;
                case "GetAllOccupations":
                    return context.GetEnv().taxonomyApiBaseUrl + UriGetAllOccupations;
                default:
                    return "";
            }
        }

        #region envsettings
        public static string GetEscoApiBaseUrl(this ScenarioContext context) { return context.GetEnv().escoApiBaseUrl; }

        public static string GetTaxonomyApiBaseUrl(this ScenarioContext context) { return context.GetEnv().taxonomyApiBaseUrl; }
        public static string GetTaxonomySubscriptionKey(this ScenarioContext context) { return context.GetEnv().taxonomySubscriptionKey; }

        public static string GetEditorBaseUrl(this ScenarioContext context) { return context.GetEnv().editorBaseUrl; }
        public static string GetEditorUid(this ScenarioContext context) { return context.GetEnv().editorUid; }
        public static string GetEditorPassword(this ScenarioContext context) { return context.GetEnv().editorPassword; }

        public static string GetNeo4JUrl(this ScenarioContext context) { return context.GetEnv().neo4JUrl; }
        public static string GetNeo4JUid(this ScenarioContext context) { return context.GetEnv().neo4JUid; }
        public static string GetNeo4JPassword(this ScenarioContext context) { return context.GetEnv().neo4JPassword; }

        #endregion

        public static string GetSkillOrKnowlegeFromSkillTypeUri(this ScenarioContext context, string uri)
        {
            return (uri.Contains("knowledge") ? "knowledge" : "competency");
        }

        public static string SetEscoResponseDataGetSkillOrKnowlegeFromSkillTypeUri(this ScenarioContext context, string uri)
        {
            return (uri.Contains("knowledge") ? "knowledge" : "competency");
        }

        public static void SetEscoItemListData( this ScenarioContext context, IList<EscoDataItem> escoData)
        {
             context.Set<IList<EscoDataItem>>(escoData, keyEscoData);
        }
        public static IList<EscoDataItem> GetEscoItemListData(this ScenarioContext context)
        {
            return (context.ContainsKey(keyEscoData) ? context.Get<IList<EscoDataItem>>(keyEscoData) : null);
        }

        public static void SetOccupationListData(this ScenarioContext context, IList<Occupation> occupations)
        {
            context.Set<IList<Occupation>>(occupations, keyOccupationData);
        }

        public static IList<Occupation> GetOccupationListData(this ScenarioContext context)
        {
            return (context.ContainsKey(keyOccupationData) ? context.Get<IList<Occupation>>(keyOccupationData) : null);
        }

        public static int GetOccupationCount(this ScenarioContext context)
        {
            return (context.ContainsKey(keyOccupationData) ? context.Get<IList<Occupation>>(keyOccupationData).Count : 0);
        }

        public static void SetSkillListData(this ScenarioContext context, IList<Skill> skills)
        {
            context.Set<IList<Skill>>(skills, keySkillData);
        }

        public static IList<Skill> GetSkillListData(this ScenarioContext context)
        {
            return (context.ContainsKey(keySkillData) ? context.Get<IList<Skill>>(keySkillData) : null);
        }

        public static int GetSkillCount(this ScenarioContext context)
        {
            return (context.ContainsKey(keySkillData) ? context.Get<IList<Skill>>(keySkillData).Count : 0);
        }

        //public static void SetStringListData(this ScenarioContext context, IList<string> strings)
        //{
        //    context.Set<IList<string>>(strings, keyListOfStrings);
        //}

        //public static IList<string> GetListDataData(this ScenarioContext context)
        //{
        //    return (context.ContainsKey(keyListOfStrings) ? context.Get<IList<string>>(keyListOfStrings) : null);
        //}

        //public static int GetStringListCount(this ScenarioContext context)
        //{
        //    return (context.ContainsKey(keyListOfStrings) ? context.Get<IList<string>>(keyListOfStrings).Count : 0);
        //}

        //public static void ClearStringList(this ScenarioContext context)
        //{
        //    if (context.ContainsKey(keyListOfStrings))
        //    {
        //        context.Get<IList<string>>(keyListOfStrings).Clear();
        //    }
        //}

        public static Dictionary<string,string> GetTaxonomyApiHeaders(this ScenarioContext context)
        {
            return new Dictionary<string, string>(){
                                                        { "Content-Type", "application/json" }, 
                                                        { "Ocp-Apim-Subscription-Key", context.GetTaxonomySubscriptionKey() } 
                                                   };
        }


    }
}
