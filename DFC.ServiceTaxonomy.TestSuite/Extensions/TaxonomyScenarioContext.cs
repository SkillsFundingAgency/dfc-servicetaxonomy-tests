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
        const string UriGetSkillById = "GetSkillById/Execute";
        const string UriGetSkillsForOccupation = "GetAllSkillsForOccupation/Execute";
        const string UriGetSkillsGapForOccupationAndGivenSkills = "GetSkillsGapForOccupationAndGivenSkills/Execute";
        const string UriGetJobProfileDetail = "GetJobProfileByTitle/Execute/";
        const string UriGetSkillByLabelSearch = "GetSkillsByLabel/Execute/";
        const string UriGetOCcupationByLabelSearch = "GetOccupationsByLabel/Execute/";
        const string UriGetSTAXJobProfileSummary = "GetJobProfilesSummary/Execute/";

        const string UriJobProfileSummary = "summary";

        const string keyEscoData = "EscoItemList";
        const string keyOccupationData = "EscoOccupationList";
        const string keySkillData = "EscoSkillList";
        const string keyListOfStrings = "EscoListOfStrings";
        const string keyExpectedRecordCount = "ExpectedRecordCount";
        #endregion

        //public static void SetWebDriver(this ScenarioContext context, IWebDriver webDriver)
        //{
        //    Set(context, webDriver, WebDriverKey);
        //}

        public static string GetTaxonomyUri(this ScenarioContext context, string resource, string param = "")
        {
            switch (resource.ToLower())
            {
                case "getallskills":
                    return context.GetEnv().taxonomyApiBaseUrl +"/" + UriGetAllSkills;
                case "getalloccupations":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetAllOccupations;
                case "getskillbyid":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetSkillById;
                case "getskillsforoccupation":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetSkillsForOccupation;
                case "getskillsgapforoccupationandgivenskills":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetSkillsGapForOccupationAndGivenSkills;
                case "jobprofiledetail":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetJobProfileDetail + "/" + param;
                case "getskillsbylabelsearch":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetSkillByLabelSearch + "/" + param;
                case "getoccupationsbylabelsearch":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetOCcupationByLabelSearch + "/" + param;
                case "getjobprofilesummary":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetSTAXJobProfileSummary + "/" + param;
                default:
                    return "";
            }
        }


        public static string GetJobProfileUri(this ScenarioContext context, string resource)
        {
            switch (resource.ToLower())
            {
                case "summary":
                    return context.GetEnv().jobProfileApiBaseUrl + "/" + UriJobProfileSummary;
                default:
                    return context.GetEnv().jobProfileApiBaseUrl + "/" + resource;
            }
        }


        #region envsettings
        public static string GetEscoApiBaseUrl(this ScenarioContext context) { return context.GetEnv().escoApiBaseUrl; }

        public static string GetTaxonomyApiBaseUrl(this ScenarioContext context) { return context.GetEnv().taxonomyApiBaseUrl; }
        public static string GetTaxonomySubscriptionKey(this ScenarioContext context) { return context.GetEnv().taxonomySubscriptionKey; }

        public static string GetJobProfileApiBaseUrl(this ScenarioContext context) { return context.GetEnv().jobProfileApiBaseUrl; }
        public static string GetJobProfileSubscriptionKey(this ScenarioContext context) { return context.GetEnv().jobProfileSubscriptionKey; }

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

        public static void SetExpectedRecordCount(this ScenarioContext context, int recordCount)
        {
            context.Set<int>(recordCount, keyExpectedRecordCount);
        }

        public static int GetExpectedRecordCount(this ScenarioContext context)
        {
            return (context.ContainsKey(keyExpectedRecordCount) ? context.Get<int>(keyExpectedRecordCount) : 0);
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

        public static Dictionary<string, string> GetJobProfileApiHeaders(this ScenarioContext context)
        {
            return new Dictionary<string, string>(){
                                                        { "Content-Type", "application/json" },
                                                        { "Ocp-Apim-Subscription-Key", context.GetJobProfileSubscriptionKey() },
                                                        { "version", "v1" }
                                                   };
        }


    }
}
