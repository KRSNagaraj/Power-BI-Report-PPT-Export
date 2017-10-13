using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace web_request_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://login.microsoftonline.com/common/oauth2/authorize?client_id=871c010f-5e61-4fb1-83ac-98610a7e9110";
            url = "https://app.powerbi.com/?noSignUpCheck=1";
            //url = "https://login.microsoftonline.com/common/userrealm?user=snagaraj@hcltbi.onmicrosoft.com&api-version=2.1&stsRequest=rQIIACoDMS4xOiQ4NzFjMDEwZi01ZTYxLTRmYjEtODNhYy05ODYxMGE3ZTkxMTByEgoQN1OejVRiD0a41iQjx8IR36oBFGh0dHBzOi8vcG93ZXJiaS5jb20vuAEB0AEB6AEB2gIPT0F1dGgyQXV0aG9yaXplsgMGY29tbW9u2AMB0AQB6gQMMAM6CAgKEAAYACAA-AQBogUSChC_2mKK4e-6T64FgsQ8rhYAygUvT0hneU9IYjVobXdNb1lxU1pxQnBGR1NSa29jK0hwQ3dBUSsxdWtCMm1iVT00OjHACQE1&checkForMicrosoftAccount=true";

            //test_credential_access(url);
            JsonParse();

            var returning_url = "https://powerbi.microsoft.com/en-us/forms/set-returning-user-cookie/";
            //refreshCookies(returning_url);

            var powerBILogin_URL = "https://login.microsoftonline.com/common/login";
            powerBILogin(powerBILogin_URL);


            var appPowerBI_URL = "https://app.powerbi.com/";
            appPowerBIToken(appPowerBI_URL);

        }

        private static void JsonParse()
        {
            //string x = " \"sad \" ";
            //string _json = "{\"dashboards\":[],\"reports\":[{\"name\":\"resources\/Layout.layout_3\",\"displayName\":\"Report Usage Metrics Report\",\"packageId\":3226264,\"packageVersion\":\"1.1\",\"layoutOptimization\":0,\"id\":2599018,\"modelId\":2523770,\"objectId\":\"ccbe200b-071c-47f4-b24a-4e83b976a90e\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"name\":\"resources\/Layout.layout\",\"displayName\":\"RichMixReports\",\"packageId\":3232978,\"packageVersion\":\"companionprovider\/e9daae75-d4b3-4040-a1de-e9f35061aff4xF26yxuGjNAlRZmilPU5WRlsS4p8iJJH-smoZcKqHV4=.pbix\",\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2606802,\"modelId\":2529004,\"objectId\":\"94da52b5-23f5-46c2-907c-5c1003553544\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1233342,\"featuresV2\":[0,0,0]},{\"displayName\":\"PPT-Export-Test-01\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2773290,\"modelId\":2529004,\"objectId\":\"ebfb67f1-6a67-4dd3-ab98-affa58dba2be\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1343643,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787269,\"modelId\":2529004,\"objectId\":\"b69c6eed-165e-4d46-8bc7-d8e1be1d994c\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787301,\"modelId\":2529004,\"objectId\":\"b4d98b78-dbe5-426f-a99b-98c9ac07696c\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787546,\"modelId\":2529004,\"objectId\":\"937a2e4b-bf6b-4e17-9601-729c77911e6a\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787550,\"modelId\":2529004,\"objectId\":\"f5e0b798-83ed-4c09-bb37-6fc8d820cb7d\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787621,\"modelId\":2529004,\"objectId\":\"7b22d30c-8787-460d-b6a7-17935ac0c5c1\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787649,\"modelId\":2529004,\"objectId\":\"6ff9e89d-a3e9-4d0d-af80-97705f88478b\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3232978,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2787696,\"modelId\":2529004,\"objectId\":\"4e30a21d-2854-450f-8e80-4e36b363adda\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"name\":\"resources\/Layout.layout\",\"displayName\":\"RICHMIXREPORTS-DEV-TESTCLIENT\",\"packageId\":3374858,\"packageVersion\":\"companionprovider\/7e717324-927b-4c55-b058-c1cf91e6bc487DZe6f3634zdvWyrzJwETErxynghvwcXN6x17ula75k=.pbix\",\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2759630,\"modelId\":2633561,\"objectId\":\"868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1336292,\"featuresV2\":[0,0,0]},{\"displayName\":\"gabi\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2778616,\"modelId\":2633561,\"objectId\":\"64e46638-8eee-449c-837c-de252500b4ce\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1346657,\"featuresV2\":[0,0,0]},{\"displayName\":\"TEST001\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2792453,\"modelId\":2633561,\"objectId\":\"7a442e9f-f20c-4642-96a3-fdc96cb86208\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171012135538331\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2793715,\"modelId\":2633561,\"objectId\":\"209a662a-48cf-47c0-8cd4-f06ec1802abc\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171012135700101\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2793765,\"modelId\":2633561,\"objectId\":\"3a3ab850-f28e-440b-859f-c0e60aafa161\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171012135700101\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2793766,\"modelId\":2633561,\"objectId\":\"e223afdf-652c-4631-8ecf-53740e38c130\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171012135700101\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2793767,\"modelId\":2633561,\"objectId\":\"6c014e0e-80d5-4106-9ccd-5b8ef647a4f7\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171012135700101\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2793768,\"modelId\":2633561,\"objectId\":\"7e78fadf-d5f4-4509-9c8c-fb5bcaacfbf8\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171013090820975\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2796932,\"modelId\":2633561,\"objectId\":\"cc64dafd-5243-49b7-8ccb-fabb0f6ddb64\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171013091036538\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2796952,\"modelId\":2633561,\"objectId\":\"508131ba-2761-40eb-b46e-39cf176de69b\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171013091415765\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2796999,\"modelId\":2633561,\"objectId\":\"e5f37561-79b9-4c23-bbb5-b88125436861\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171013091504135\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2797013,\"modelId\":2633561,\"objectId\":\"89e6cdb3-3867-4256-bff3-99877dacd3a7\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171013091517771\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2797017,\"modelId\":2633561,\"objectId\":\"5574bda2-18a4-4a1c-9d5f-ceb1bb5ec2aa\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"displayName\":\"Gabriel.Pagu@kantarretail.com_868bcc5a-94b3-43b5-9f9d-a6def2e6f0b9_171013091559173\",\"packageId\":3374858,\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2797030,\"modelId\":2633561,\"objectId\":\"571c509b-d0a0-4145-a9d8-1b1eda276b48\",\"permissions\":15,\"hasExploration\":true,\"featuresV2\":[0,0,0]},{\"name\":\"resources\/Layout.layout\",\"displayName\":\"RICHMIXREPORTS-TST-TESTCLIENT\",\"packageId\":3375102,\"packageVersion\":\"companionprovider\/aacc8480-4a82-411a-bcb7-8de715a29d2dzfzyB3u8HniCphrA6ZB1CM6Gy.t7bQp2.pbix\",\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2759888,\"modelId\":2633832,\"objectId\":\"885499fe-683d-446a-869c-c10fba8f42db\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1336465,\"featuresV2\":[0,0,0]},{\"name\":\"resources\/Layout.layout\",\"displayName\":\"RICHMIXREPORTS-TST-FERRERO\",\"packageId\":3375544,\"packageVersion\":\"companionprovider\/629c68fc-7c36-48cf-9f0a-2dab48de3e6bhZ.4eH9X0Jhz-3wELAiFC0.pbix\",\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2760361,\"modelId\":2634312,\"objectId\":\"73396897-4786-41e8-9e16-8cdc00e96d88\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1336792,\"featuresV2\":[0,0,0]},{\"name\":\"resources\/Layout.layout\",\"displayName\":\"RICHMIXREPORTS-TST-UNILEVER\",\"packageId\":3375592,\"packageVersion\":\"companionprovider\/bc8953cd-2467-4283-a528-71d1f0de76aejWsNN4umN6D5n8RIsGug7ip06wX8ErCd6NWX6NOX1Wg=.pbix\",\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2760410,\"modelId\":2634357,\"objectId\":\"7d1145ac-5b34-49c9-af0e-b096f435d915\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1336821,\"featuresV2\":[0,0,0]},{\"name\":\"resources\/Layout.layout\",\"displayName\":\"RICHMIXREPORTS-PRD-TESTCLIENT\",\"packageId\":3381009,\"packageVersion\":\"companionprovider\/ee989cf4-2e37-4217-baf9-27bb424b2c91RnaXaR2cOWW.pbix\",\"isFromPbix\":true,\"layoutOptimization\":0,\"id\":2764173,\"modelId\":2638365,\"objectId\":\"83993e3d-96f0-421f-8733-f4275bc334a6\",\"permissions\":15,\"hasExploration\":true,\"linguisticSchemaId\":1338824,\"featuresV2\":[0,0,0]}],\"models\":[{\"name\":\"UserReportUsageMetricsModel\",\"displayName\":\"Report Usage Metrics Model\",\"packageId\":3226264,\"packageVersion\":\"1.1\",\"contentProviderId\":102,\"id\":2523770,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"06f9d526-1074-4734-be0b-485787b9fc29\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":3,\"refreshFrequency\":\"120\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507887290683)\/\",\"maxDOP\":3,\"NextRefreshTime\":\"\/Date(1507887290683+0000)\/\",\"LastRefreshTime\":\"\/Date(1507880090683+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507887290683)\/\",\"lastRefreshTime\":\"\/Date(1507880090683)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":102,\"isPackageRefreshEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null},{\"name\":\"PowerBICompanionModelResource\",\"displayName\":\"RichMixReports\",\"packageId\":3232978,\"packageVersion\":\"companionprovider\/e9daae75-d4b3-4040-a1de-e9f35061aff4xF26yxuGjNAlRZmilPU5WRlsS4p8iJJH-smoZcKqHV4=.pbix\",\"contentProviderId\":7,\"id\":2529004,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"805d3568-221c-4e37-b8d4-82967e41e849\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":2,\"refreshFrequency\":\"60\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507889500933)\/\",\"NextRefreshTime\":\"\/Date(1507889500933+0000)\/\",\"LastRefreshTime\":\"\/Date(1507885900933+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507889500933)\/\",\"lastRefreshTime\":\"\/Date(1507885900933)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"isRefreshedByContentProvider\":false,\"isHidden\":false,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":7,\"isPackageRefreshEnabled\":false,\"isBarcodeFilterEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null},{\"name\":\"PowerBICompanionModelResource\",\"displayName\":\"RICHMIXREPORTS-DEV-TESTCLIENT\",\"packageId\":3374858,\"packageVersion\":\"companionprovider\/7e717324-927b-4c55-b058-c1cf91e6bc487DZe6f3634zdvWyrzJwETErxynghvwcXN6x17ula75k=.pbix\",\"contentProviderId\":7,\"id\":2633561,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"5eeb1428-3f1f-4408-a5d5-b8115eddf8f5\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":2,\"refreshFrequency\":\"60\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507885453877)\/\",\"NextRefreshTime\":\"\/Date(1507885453877+0000)\/\",\"LastRefreshTime\":\"\/Date(1507881853877+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507885453877)\/\",\"lastRefreshTime\":\"\/Date(1507881853877)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"isRefreshedByContentProvider\":false,\"isHidden\":false,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":7,\"isPackageRefreshEnabled\":false,\"isBarcodeFilterEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null},{\"name\":\"PowerBICompanionModelResource\",\"displayName\":\"RICHMIXREPORTS-TST-TESTCLIENT\",\"packageId\":3375102,\"packageVersion\":\"companionprovider\/aacc8480-4a82-411a-bcb7-8de715a29d2dzfzyB3u8HniCphrA6ZB1CM6Gy.t7bQp2.pbix\",\"contentProviderId\":7,\"id\":2633832,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"23c11b97-1a8b-441a-99de-22b9cc0fc26a\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":2,\"refreshFrequency\":\"60\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507885945103)\/\",\"NextRefreshTime\":\"\/Date(1507885945103+0000)\/\",\"LastRefreshTime\":\"\/Date(1507882345103+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507885945103)\/\",\"lastRefreshTime\":\"\/Date(1507882345103)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"isRefreshedByContentProvider\":false,\"isHidden\":false,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":7,\"isPackageRefreshEnabled\":false,\"isBarcodeFilterEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null},{\"name\":\"PowerBICompanionModelResource\",\"displayName\":\"RICHMIXREPORTS-TST-FERRERO\",\"packageId\":3375544,\"packageVersion\":\"companionprovider\/629c68fc-7c36-48cf-9f0a-2dab48de3e6bhZ.4eH9X0Jhz-3wELAiFC0.pbix\",\"contentProviderId\":7,\"id\":2634312,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"d9af48eb-0fdb-4112-9220-07b7a2f132e5\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":2,\"refreshFrequency\":\"60\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507889863277)\/\",\"NextRefreshTime\":\"\/Date(1507889863277+0000)\/\",\"LastRefreshTime\":\"\/Date(1507886263277+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507889863277)\/\",\"lastRefreshTime\":\"\/Date(1507886263277)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"isRefreshedByContentProvider\":false,\"isHidden\":false,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":7,\"isPackageRefreshEnabled\":false,\"isBarcodeFilterEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null},{\"name\":\"PowerBICompanionModelResource\",\"displayName\":\"RICHMIXREPORTS-TST-UNILEVER\",\"packageId\":3375592,\"packageVersion\":\"companionprovider\/bc8953cd-2467-4283-a528-71d1f0de76aejWsNN4umN6D5n8RIsGug7ip06wX8ErCd6NWX6NOX1Wg=.pbix\",\"contentProviderId\":7,\"id\":2634357,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"d42b40b5-51e9-4984-8a72-eb1b024df2b1\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":2,\"refreshFrequency\":\"60\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507888863517)\/\",\"NextRefreshTime\":\"\/Date(1507888863517+0000)\/\",\"LastRefreshTime\":\"\/Date(1507885263517+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507888863517)\/\",\"lastRefreshTime\":\"\/Date(1507885263517)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"isRefreshedByContentProvider\":false,\"isHidden\":false,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":7,\"isPackageRefreshEnabled\":false,\"isBarcodeFilterEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null},{\"name\":\"PowerBICompanionModelResource\",\"displayName\":\"RICHMIXREPORTS-PRD-TESTCLIENT\",\"packageId\":3381009,\"packageVersion\":\"companionprovider\/ee989cf4-2e37-4217-baf9-27bb424b2c91RnaXaR2cOWW.pbix\",\"contentProviderId\":7,\"id\":2638365,\"vsName\":\"sobe_wowvirtualserver\",\"dbName\":\"f26e1941-052b-4476-b3d9-035271c1e66e\",\"currentRefreshStartingTime\":\"\",\"refreshSchedule\":{\"importAndRefreshBehavior\":2,\"refreshFrequency\":\"60\",\"executionTime\":null,\"localTimeZoneId\":\"UTC\",\"refreshEnabled\":true,\"isDaily\":false,\"isRefreshable\":true,\"numberOfTimeIntervals\":4,\"refreshNotificationEnabled\":true,\"forceQueryRefreshEnabled\":false,\"forceModelRefreshEnabled\":false,\"refreshDisabledReason\":0},\"nextRefreshTime\":\"\/Date(1507889287620)\/\",\"NextRefreshTime\":\"\/Date(1507889287620+0000)\/\",\"LastRefreshTime\":\"\/Date(1507885687620+0000)\/\",\"nextRefreshTimeUtc\":\"\/Date(1507889287620)\/\",\"lastRefreshTime\":\"\/Date(1507885687620)\/\",\"lastTimeAModelChangeWasDetectedInTheCluster\":\"\",\"lastRefreshStatus\":0,\"permissions\":15,\"packagePublishStatus\":0,\"creatorUserId\":916245,\"directQueryMode\":true,\"sizeInMBs\":1,\"qnaSupported\":true,\"isRefreshedByContentProvider\":false,\"isHidden\":false,\"modelFeatures\":16,\"features\":16,\"isOnPremisesGatewayOverride\":false,\"featuredQuestions\":[],\"lastNLResourceGenerationTime\":\"\",\"packageContentProviderId\":7,\"isPackageRefreshEnabled\":false,\"isBarcodeFilterEnabled\":false,\"isRefreshScheduleAllowed\":true,\"featuresV2\":[16,0,0],\"isInEnterpriseCapacity\":false,\"capacityId\":null}],\"userDashboardListVersion\":\"eebf9c9d-571f-47cf-9a19-8faa70a8f13f\",\"packages\":[{\"id\":3226264,\"version\":\"1.1\",\"name\":\"User Report Usage Metrics Package\",\"contentProviderId\":102,\"lastRefreshTime\":\"\/Date(1505222346957)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(130354241174513)\/\",\"LastRefreshTime\":\"\/Date(1505222346957+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"7427c5a1-bfd8-4c84-a750-cfd4e2df8663\",\"permissions\":7,\"featuresV2\":[0,0,0]},{\"id\":3232978,\"version\":\"companionprovider\/e9daae75-d4b3-4040-a1de-e9f35061aff4xF26yxuGjNAlRZmilPU5WRlsS4p8iJJH-smoZcKqHV4=.pbix\",\"name\":\"RichMixReports.pbix\",\"contentProviderId\":7,\"lastRefreshTime\":\"\/Date(1505384130887)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(253402300799997)\/\",\"LastRefreshTime\":\"\/Date(1505384130887+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"ae20193a-dfc6-4bff-8f83-246de1669c34\",\"storageProviderType\":0,\"permissions\":7,\"featuresV2\":[0,0,0]},{\"id\":3374858,\"version\":\"companionprovider\/7e717324-927b-4c55-b058-c1cf91e6bc487DZe6f3634zdvWyrzJwETErxynghvwcXN6x17ula75k=.pbix\",\"name\":\"RICHMIXREPORTS-DEV-TESTCLIENT.pbix\",\"contentProviderId\":7,\"lastRefreshTime\":\"\/Date(1507617716887)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(253402300799997)\/\",\"LastRefreshTime\":\"\/Date(1507617716887+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"c05910b0-4427-4427-b6c0-7116526723ac\",\"storageProviderType\":0,\"permissions\":7,\"featuresV2\":[0,0,0]},{\"id\":3375102,\"version\":\"companionprovider\/aacc8480-4a82-411a-bcb7-8de715a29d2dzfzyB3u8HniCphrA6ZB1CM6Gy.t7bQp2.pbix\",\"name\":\"RICHMIXREPORTS-TST-TESTCLIENT.pbix\",\"contentProviderId\":7,\"lastRefreshTime\":\"\/Date(1507620683893)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(253402300799997)\/\",\"LastRefreshTime\":\"\/Date(1507620683893+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"14bd4821-6cd1-48b9-b018-e912bf12a66e\",\"storageProviderType\":0,\"permissions\":7,\"featuresV2\":[0,0,0]},{\"id\":3375544,\"version\":\"companionprovider\/629c68fc-7c36-48cf-9f0a-2dab48de3e6bhZ.4eH9X0Jhz-3wELAiFC0.pbix\",\"name\":\"RICHMIXREPORTS-TST-FERRERO.pbix\",\"contentProviderId\":7,\"lastRefreshTime\":\"\/Date(1507620865197)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(253402300799997)\/\",\"LastRefreshTime\":\"\/Date(1507620865197+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"7e10bdeb-e29d-4051-81d4-6bcc18024bf7\",\"storageProviderType\":0,\"permissions\":7,\"featuresV2\":[0,0,0]},{\"id\":3375592,\"version\":\"companionprovider\/bc8953cd-2467-4283-a528-71d1f0de76aejWsNN4umN6D5n8RIsGug7ip06wX8ErCd6NWX6NOX1Wg=.pbix\",\"name\":\"RICHMIXREPORTS-TST-UNILEVER.pbix\",\"contentProviderId\":7,\"lastRefreshTime\":\"\/Date(1507621006127)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(253402300799997)\/\",\"LastRefreshTime\":\"\/Date(1507621006127+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"aecad61c-4fe8-4b0e-af7a-a1f77061c305\",\"storageProviderType\":0,\"permissions\":7,\"featuresV2\":[0,0,0]},{\"id\":3381009,\"version\":\"companionprovider\/ee989cf4-2e37-4217-baf9-27bb424b2c91RnaXaR2cOWW.pbix\",\"name\":\"RICHMIXREPORTS-PRD-TESTCLIENT.pbix\",\"contentProviderId\":7,\"lastRefreshTime\":\"\/Date(1507619869453)\/\",\"publishOrRefreshStatus\":0,\"refreshInterval\":2147483647,\"NextRefreshTime\":\"\/Date(253402300799997)\/\",\"LastRefreshTime\":\"\/Date(1507619869453+0000)\/\",\"IsRefreshEnabled\":true,\"ObjectId\":\"b07885d1-9f38-4a3a-9e99-333854166861\",\"storageProviderType\":0,\"permissions\":7,\"featuresV2\":[0,0,0]}],\"workbooks\":[],\"activeDashboardId\":0,\"apps\":[]}";
            //Newtonsoft 
        }

        private static void powerBILogin(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";

            (request as HttpWebRequest).Host = "login.microsoftonline.com";
            (request as HttpWebRequest).Referer = "https://login.microsoftonline.com/common/oauth2/authorize?client_id=871c010f-5e61-4fb1-83ac-98610a7e9110&response_mode=form_post&response_type=code+id_token&scope=openid+profile&state=OpenIdConnect.AuthenticationProperties%3dKSz_G1bMeT_HM1p8MbJGcrYgMp2PtuxwC4tHWoqiqAzUJFODdTQV02L89Jl9ch7iI-TNbm-2A_eDQN-7LHp82jutb2T7lnIapdIXPh5KkSuOTnLVjG9aokSh5ts3KmXRWJqE9g&nonce=636433469502677563.NTc1ZTVlM2UtMjA1Yy00OTI1LWIxM2ItZDFmMDYzOGUzZjhmM2U4ZmZiZjMtNTQ3ZS00NzFlLTgzMzctOWQ5MWMwZWUzMGU1&site_id=500453&redirect_uri=https%3a%2f%2fapp.powerbi.com%2f%3fnoSignUpCheck%3d1&post_logout_redirect_uri=https%3a%2f%2fapp.powerbi.com%2f%3fnoSignUpCheck%3d1&resource=https%3a%2f%2fanalysis.windows.net%2fpowerbi%2fapi&nux=1&msafed=0";
            (request as HttpWebRequest).ContentType = "application/x-www-form-urlencoded";
            
            request.Headers.Add(File.ReadAllText("pbiLoginHeader.txt"));

            string postData = "";
            postData = File.ReadAllText("pbiLoginBody.txt");

            var _postLength = postData.Length;
            var _postBytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = _postLength;

            var stream = request.GetRequestStream();
            stream.Write(_postBytes, 0, _postLength);
            stream.Close();

            //request.Headers.Add(File.ReadAllText("app_powerbi_header.txt"));

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();
            var reader = new StreamReader(_responseStream);
                //using (var reader = new StreamReader(_responseStream))
                //{
                //    while (!reader.EndOfStream)
                //    {
                //        var s = reader.ReadLine();
                //        if (s.Contains("powerBIAccessToken"))
                //        {
                //            var d = s.Split('\'');
                //            break;
                //        }
                //    }
                //}

              var _http = response as HttpWebResponse;

            var _result = reader.ReadToEnd();


            Console.WriteLine(_result);

        }

        private static void appPowerBIToken(string url)
        {
            WebResponse _res = CallPBI(url);
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            
            (request as HttpWebRequest).Host = "app.powerbi.com";
            request.Headers.Add(File.ReadAllText("pbiLoginHeader.txt"));

            //request.Headers.Add("Cookie: " + _res.Headers["Set-Cookie"].ToString());
            //request.Headers.Add(File.ReadAllText("app_powerbi_header.txt"));
            //request.Headers = _res.Headers;
            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();

            using (var reader = new StreamReader(_responseStream))
            {
                while (!reader.EndOfStream)
                {
                    var s = reader.ReadLine();
                    if(s.Contains("powerBIAccessToken"))
                    {
                        var d = s.Split('\'');
                        break;
                    }
                }
            } 

                var _http = response as HttpWebResponse;

            //var _result = reader.ReadToEnd();
            

            //Console.WriteLine(_result);


           // throw new NotImplementedException();
        }

        private static WebResponse CallPBI(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.Headers.Add(File.ReadAllText("pbiLoginHeader.txt"));

            (request as HttpWebRequest).Host = "app.powerbi.com";

            //request.Headers.Add(File.ReadAllText("app_powerbi_header.txt"));

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();
            var reader = new StreamReader(_responseStream);

            var _result = reader.ReadToEnd();

            return response;
        }

        private static void refreshCookies(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            

            string postData = "";
            postData = File.ReadAllText("Cookie.txt");

            var _postLength = postData.Length;
            var _postBytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = _postLength;

            var stream = request.GetRequestStream();
            stream.Write(_postBytes, 0, _postLength);
            stream.Close();

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();
            var reader = new StreamReader(_responseStream);

            var _http = response as HttpWebResponse;

            var _result = reader.ReadToEnd();

            Console.WriteLine(_result);


            throw new NotImplementedException();
        }

        private static void getRequestHeaderData()
        {
            //File.ReadAllText(c)
            throw new NotImplementedException();
        }

        private static void test_web_get_request()
        {
            var url = "https://login.microsoftonline.com/common/oauth2/authorize?client_id=871c010f-5e61-4fb1-83ac-98610a7e9110";
            url = "https://app.powerbi.com/?noSignUpCheck=1";
            url = "https://login.microsoftonline.com/common/userrealm?user=snagaraj@hcltbi.onmicrosoft.com&api-version=2.1&stsRequest=rQIIACoDMS4xOiQ4NzFjMDEwZi01ZTYxLTRmYjEtODNhYy05ODYxMGE3ZTkxMTByEgoQN1OejVRiD0a41iQjx8IR36oBFGh0dHBzOi8vcG93ZXJiaS5jb20vuAEB0AEB6AEB2gIPT0F1dGgyQXV0aG9yaXplsgMGY29tbW9u2AMB0AQB6gQMMAM6CAgKEAAYACAA-AQBogUSChC_2mKK4e-6T64FgsQ8rhYAygUvT0hneU9IYjVobXdNb1lxU1pxQnBGR1NSa29jK0hwQ3dBUSsxdWtCMm1iVT00OjHACQE1&checkForMicrosoftAccount=true";

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();
            var reader = new StreamReader(_responseStream);

            var _result = reader.ReadToEnd();

            Console.WriteLine(_result);
            throw new NotImplementedException();
        }
        private static void test_web_request(string url)
        {
           
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            string postData = "";

            var _postLength = postData.Length;
            var _postBytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = _postLength;
            
            var stream = request.GetRequestStream();
            stream.Write(_postBytes, 0, _postLength);
            stream.Close();

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse) response).StatusDescription);
            var _responseStream = response.GetResponseStream();
            var reader = new StreamReader(_responseStream);

            var _result = reader.ReadToEnd();

            Console.WriteLine(_result);
            throw new NotImplementedException();
        }

        public static void test_credential_access(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Set some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;

            CredentialCache myCache = new CredentialCache();

            myCache.Add(new Uri("http://www.microsoftonline.com/"), "Basic", new NetworkCredential("snagaraj@hcltbi.onmicroosft.com", "oct-2017"));
            //myCache.Add(new Uri("http://www.microsoftonline.com/"), "Digest", new NetworkCredential(UserName, SecurelyStoredPassword, Domain));

            request.Credentials = myCache;
            // Set credentials to use for this request.
            //request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine("Content length is {0}", response.ContentLength);
            Console.WriteLine("Content type is {0}", response.ContentType);

            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            var _result = reader.ReadToEnd();

            Console.WriteLine("Response stream received.");


            Console.WriteLine(reader.ReadToEnd());
            response.Close();
            reader.Close();
        }
    }
}
