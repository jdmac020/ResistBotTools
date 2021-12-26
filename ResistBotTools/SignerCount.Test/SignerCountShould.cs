using NSubstitute;
using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;
using RestSharp;
using SignerCount.Web.Services;

namespace SignerCount.Test
{
    public class SignerCountShould
    {
        [Fact]
        public async Task GetPageContent()
        {
            var testResponse = Substitute.For<IRestResponse>();
            var restClient = Substitute.For<ICustomRestClient>();
            restClient.MakeCall(Arg.Any<IRestRequest>()).Returns(testResponse);
            restClient.GetResponseContent(testResponse).Returns(_testPage2);
            var counter = new SignerCount.Web.Services.SignatureCounter(restClient);

            var result = await counter.GetPage();

            result.ShouldBe(70);
        }

        private const string _testPage2 = @"<!DOCTYPE html><html lang=""en""><main><div class=""Petition_petitionBase__ccYdR""><a class=""anchor_anchor__e6AjG"" href=""/petitions/PJYTCQ""><div class=""Petition_petitionDetail__RgdwS""><p class=""Petition_subject__Z9M76"">Day 2 of Writing to End Forced Birth</p><p class=""Petition_startedOn__eZm5o""><em>to</em> <!-- -->the U.S. Congress </p></div><div class=""Petition_signatureCounts__9XCWU""><div><p class=""Petition_signCount__Lihvc"">6</p><p class=""text_small__c4eBH Petition_signCountDetail__ULhJq"">Signers</p></div></div></a></div><div class=""Petition_petitionBase__ccYdR""><a class=""anchor_anchor__e6AjG"" href=""/petitions/PXBGMU""><div class=""Petition_petitionDetail__RgdwS""><p class=""Petition_subject__Z9M76"">Day One of Writing Until Abortion is Protected by Law</p><p class=""Petition_startedOn__eZm5o""><em>to</em> <!-- -->the President </p></div><div class=""Petition_signatureCounts__9XCWU""><div><p class=""Petition_signCount__Lihvc"">22</p><p class=""text_small__c4eBH Petition_signCountDetail__ULhJq"">Signers</p></div></div></a></div><div class=""Petition_petitionBase__ccYdR""><a class=""anchor_anchor__e6AjG"" href=""/petitions/PEANFL""><div class=""Petition_petitionDetail__RgdwS""><p class=""Petition_subject__Z9M76"">Day One of Writing Until Abortion is Protected by Law</p><p class=""Petition_startedOn__eZm5o""><em>to</em> <!-- -->State Governors &amp; Legislatures </p></div><div class=""Petition_signatureCounts__9XCWU""><div><p class=""Petition_signCount__Lihvc"">24</p><p class=""text_small__c4eBH Petition_signCountDetail__ULhJq"">Signers</p></div></div></a></div><div class=""Petition_petitionBase__ccYdR""><a class=""anchor_anchor__e6AjG"" href=""/petitions/PUUBTJ""><div class=""Petition_petitionDetail__RgdwS""><p class=""Petition_subject__Z9M76"">Day One of Writing Until Abortion is Protected by Law</p><p class=""Petition_startedOn__eZm5o""><em>to</em> <!-- -->the U.S. Congress </p></div><div class=""Petition_signatureCounts__9XCWU""><div><p class=""Petition_signCount__Lihvc"">18</p><p class=""text_small__c4eBH Petition_signCountDetail__ULhJq"">Signers</p></div></div></a></div><div class=""Petition_petitionBase__ccYdR""><a class=""anchor_anchor__e6AjG"" href=""/petitions/VOLBUHH""><div class=""Petition_petitionDetail__RgdwS""><p class=""Petition_subject__Z9M76"">White Supremacists in the White House</p><p class=""Petition_startedOn__eZm5o""><em>to</em> <!-- -->the U.S. Congress </p></div><div class=""Petition_signatureCounts__9XCWU""><div><p class=""Petition_signCount__Lihvc"">1</p><p class=""text_small__c4eBH Petition_signCountDetail__ULhJq"">Signers</p></div></div></a></div></div></div></body></html>";
    }
}
