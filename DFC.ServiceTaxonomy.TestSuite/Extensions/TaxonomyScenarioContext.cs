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
        const string UriGetOccupationsWithMatchingSkills = "GetOccupationsWithMatchingSkills/Execute/";
        const string UriGetSTAXJobProfileSummary = "GetJobProfilesSummary/Execute/";

        const string UriJobProfileSummary = "summary";

        const string keyEscoData = "EscoItemList";
        const string keyOccupationData = "EscoOccupationList";
        const string keySkillData = "EscoSkillList";
        const string keyListOfStrings = "EscoListOfStrings";
        const string keyExpectedRecordCount = "ExpectedRecordCount";
        const string keyCapturedEvents = "CapturedEvents";
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
                case "getoccupationswithmatchingskills":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetOccupationsWithMatchingSkills + "/" + param;
                case "getjobprofilesummary":
                    return context.GetEnv().taxonomyApiBaseUrl + "/" + UriGetSTAXJobProfileSummary + "/" + param;
                default:
                    return "";
            }
        }

        public static Dictionary<string, string> GetGraphSyncPartSettings(this ScenarioContext context)
        {
            return new Dictionary<string, string>()
            {
                { "NodeNameTransform", @"$""{ContentType}"""},
                { "PropertyNameTransform",@"$""{Value}"""},
                { "IDPropertyName", "uri" },
                { "GenerateIDValue", @"$""http://nationalcareers.service.gov.uk/{Value.ToLowerInvariant()}/{Guid.NewGuid()}""" }
            };
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

        public static void StoreUri(this ScenarioContext context, string newUri)
        {
            List<string> uris;
            int count = (context.ContainsKey("uriCount") ? (int)context["uriCount"] : 0);
            if (count == 0)
            {
                //initialise
                uris = new List<string>();
            }
            else
            {
                //retreive
                uris = (List<string>)context["uris"];
            }
            uris.Add(newUri);
            count++;
            context["uriCount"] = count;
            context["uris"] = uris;
        }

        public static string GetUri(this ScenarioContext context, int index)
        {
            //expect zero based index
            List<string> uris = (context.ContainsKey("uris") ? (List<string>)context["uris"] : new List<string>());

            if (uris.Count < index - 1)
            {
                return "";
            }
            return uris[index];
        }

        public static List<ContentEvent> GetCapturedEvents(this ScenarioContext context)
        {
            return context.ContainsKey(keyCapturedEvents) ? (List < ContentEvent > )context[keyCapturedEvents] : new List<ContentEvent> ();
        }

        public static void SetCapturedEvents(this ScenarioContext context, List<ContentEvent> events)
        {
            context[keyCapturedEvents] = events;
        }

        public static void ClearCapturedEvents(this ScenarioContext context)
        {
            var list = GetCapturedEvents(context) ;
            list.Clear();
            SetCapturedEvents(context, list);
        }

        public static void StoreContentItemIndexList(this ScenarioContext context, List<ContentItemIndexRow> list)
        {
            context["contentItemIndexes"] = list;
        }

        public static List<ContentItemIndexRow> GetContentItemIndexList(this ScenarioContext context)
        {
            return (List<ContentItemIndexRow>)context["contentItemIndexes"];
        }

        public static void StoreContentItemId(this ScenarioContext context, string newId)
        {
            if (newId == string.Empty)
                return;
            List<string> uris;
            int count = (context.ContainsKey("contentIdCount") ? (int)context["contentIdCount"] : 0);
            if (count == 0)
            {
                //initialise
                uris = new List<string>();
            }
            else
            {
                //retreive
                uris = (List<string>)context["contentIds"];
            }
            if (!uris.Contains(newId))
            {
                uris.Add(newId);
                count++;
                context["contentIdCount"] = count;
                context["contentIds"] = uris;
            }
        }

        public static string GetContentItemId(this ScenarioContext context, int index)
        {
            //expect zero based index
            List<string> ids = (context.ContainsKey("contentIds") ? (List<string>)context["contentIds"] : new List<string>());

            if (ids.Count == 0 || ids.Count < index - 1)
            {
                return "";
            }
            return ids[index];
        }

        public static string GetLatestContentItemId(this ScenarioContext context)
        {
            return GetContentItemId(context, GetNumberOfStoredContentIds(context) - 1);
        }

        public static int GetNumberOfStoredContentIds(this ScenarioContext context)
        {
            //expect zero based index
            List<string> ids = (context.ContainsKey("contentIds") ? (List<string>)context["contentIds"] : new List<string>());
            return ids.Count;
        }


        public static void StoreRecordId(this ScenarioContext context, string newId)
        {
            List<string> ids;
            int count = (context.ContainsKey("idCount") ? (int)context["idCount"] : 0);
            if (count == 0)
            {
                //initialise
                ids = new List<string>();
            }
            else
            {
                //retreive
                ids = (List<string>)context["ids"];
            }
            ids.Add(newId);
            count++;
            context["idCount"] = count;
            context["ids"] = ids;
        }

        public static string GetId(this ScenarioContext context, int index)
        {
            //expect zero based index
            List<string> ids = (context.ContainsKey("ids") ? (List<string>)context["ids"] : new List<string>());

            if (ids.Count < index + 1 )
            {
                return "";
            }
            return ids[index];
        }

        public static int GetNumberOfStoredUris(this ScenarioContext context)
        {
           return (context.ContainsKey("uriCount") ? (int)context["uriCount"] : 0);
        }

        public static void StoreToken(this ScenarioContext context, string token, string value)
        {
            Dictionary<string,string> tokens;
            int count = (context.ContainsKey("tokenCount") ? (int)context["tokenCount"] : 0);
            if (count == 0)
            {
                //initialise
                tokens = new Dictionary<string, string>();
            }
            else
            {
                //retreive
                tokens = (Dictionary<string, string>)context["tokens"];
            }
            tokens.Add(token, value);
            count++;
            context["tokenCount"] = count;
            context["tokens"] = tokens;
        }

        public static Dictionary<string, string> GetTokens(this ScenarioContext context)
        {
            Dictionary<string, string> tokens = (context.ContainsKey("tokens") ? (Dictionary<string, string>)context["tokens"] : new Dictionary<string, string>());
            return tokens;
        }
        //todo - improve code reuse for above methods

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
