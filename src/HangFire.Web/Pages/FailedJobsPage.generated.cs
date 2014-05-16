﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    
    #line 2 "..\..\Pages\FailedJobsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 3 "..\..\Pages\FailedJobsPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Pages\FailedJobsPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Pages\FailedJobsPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\FailedJobsPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class FailedJobsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








            
            #line 8 "..\..\Pages\FailedJobsPage.cshtml"
  
    Layout = new LayoutPage { Title = "Failed Jobs" };

    int from, perPage;

    int.TryParse(Request.QueryString["from"], out from);
    int.TryParse(Request.QueryString["count"], out perPage);

    Pager pager;
    JobList<FailedJobDto> failedJobs;

    using (var monitor = JobStorage.Current.GetMonitoringApi())
    {
        pager = new Pager(from, perPage, monitor.FailedCount())
        {
            BasePageUrl = Request.LinkTo("/failed")
        };

        failedJobs = monitor
            .FailedJobs(pager.FromRecord, pager.RecordsPerPage);
    }


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 31 "..\..\Pages\FailedJobsPage.cshtml"
 if (pager.TotalPageCount == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-success\">\r\n        You have no failed jobs at the mom" +
"ent.\r\n    </div>\r\n");


            
            #line 36 "..\..\Pages\FailedJobsPage.cshtml"
}
else
{
    
            
            #line default
            #line hidden
            
            #line 39 "..\..\Pages\FailedJobsPage.cshtml"
Write(RenderPartial(new PerPageSelector(pager)));

            
            #line default
            #line hidden
            
            #line 39 "..\..\Pages\FailedJobsPage.cshtml"
                                              
    

            
            #line default
            #line hidden
WriteLiteral("    <table class=\"table failed-table\">\r\n        <thead>\r\n            <tr>\r\n      " +
"          <th>Id</th>\r\n                <th>Failed</th>\r\n                <th>Job<" +
"/th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <t" +
"body>\r\n");


            
            #line 51 "..\..\Pages\FailedJobsPage.cshtml"
               var index = 0; 

            
            #line default
            #line hidden

            
            #line 52 "..\..\Pages\FailedJobsPage.cshtml"
             foreach (var job in failedJobs)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr class=\"");


            
            #line 54 "..\..\Pages\FailedJobsPage.cshtml"
                       Write(!job.Value.InFailedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                    <td rowspan=\"");


            
            #line 55 "..\..\Pages\FailedJobsPage.cshtml"
                             Write(job.Value.InFailedState ? "2" : "1");

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <a href=\"");


            
            #line 56 "..\..\Pages\FailedJobsPage.cshtml"
                            Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 57 "..\..\Pages\FailedJobsPage.cshtml"
                       Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");


            
            #line 59 "..\..\Pages\FailedJobsPage.cshtml"
                         if (!job.Value.InFailedState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span title=\"Job\'s state has been changed while fetch" +
"ing data.\" class=\"glyphicon glyphicon-question-sign\"></span>\r\n");


            
            #line 62 "..\..\Pages\FailedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td>\r\n");


            
            #line 65 "..\..\Pages\FailedJobsPage.cshtml"
                         if (job.Value.FailedAt.HasValue)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <span data-moment=\"");


            
            #line 67 "..\..\Pages\FailedJobsPage.cshtml"
                                          Write(JobHelper.ToStringTimestamp(job.Value.FailedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 68 "..\..\Pages\FailedJobsPage.cshtml"
                           Write(job.Value.FailedAt);

            
            #line default
            #line hidden
WriteLiteral("        \r\n                            </span>\r\n");


            
            #line 70 "..\..\Pages\FailedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td class=\"");


            
            #line 72 "..\..\Pages\FailedJobsPage.cshtml"
                           Write(job.Value.InFailedState ? "expander" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <div>\r\n                            <span title=\"");


            
            #line 74 "..\..\Pages\FailedJobsPage.cshtml"
                                    Write(HtmlHelper.DisplayMethodHint(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 75 "..\..\Pages\FailedJobsPage.cshtml"
                           Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                        </div>\r\n");


            
            #line 78 "..\..\Pages\FailedJobsPage.cshtml"
                         if (!String.IsNullOrEmpty(job.Value.ExceptionMessage))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div style=\"color: #888;\">\r\n                         " +
"       ");


            
            #line 81 "..\..\Pages\FailedJobsPage.cshtml"
                           Write(job.Value.Reason);

            
            #line default
            #line hidden
WriteLiteral(" <span class=\"caret\"></span>\r\n                            </div>\r\n");


            
            #line 83 "..\..\Pages\FailedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td>\r\n");


            
            #line 86 "..\..\Pages\FailedJobsPage.cshtml"
                         if (job.Value.InFailedState)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div class=\"pull-right\">\r\n                           " +
"     <button class=\"btn btn-primary btn-sm\" data-ajax=\"");


            
            #line 89 "..\..\Pages\FailedJobsPage.cshtml"
                                                                             Write(Request.LinkTo("/failed/retry/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral(@""" data-loading-text=""Retrying..."">
                                    <span class=""glyphicon glyphicon-repeat""></span>
                                    Retry
                                </button>
                                
                                <button class=""btn btn-death btn-sm"" data-ajax=""");


            
            #line 94 "..\..\Pages\FailedJobsPage.cshtml"
                                                                           Write(Request.LinkTo("/failed/delete/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\" data-loading-text=\"Deleting...\">\r\n                                    <span cla" +
"ss=\"glyphicon glyphicon-remove\"></span>\r\n                                    Del" +
"ete\r\n                                </button>\r\n                            </di" +
"v>\r\n");


            
            #line 99 "..\..\Pages\FailedJobsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");


            
            #line 102 "..\..\Pages\FailedJobsPage.cshtml"
                if (job.Value.InFailedState)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td colspan=\"4\" class=\"failed-j" +
"ob-details\">\r\n                            <div class=\"expandable\" style=\"");


            
            #line 106 "..\..\Pages\FailedJobsPage.cshtml"
                                                       Write(index++ == 0 ? "display: block;" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                <h4>");


            
            #line 107 "..\..\Pages\FailedJobsPage.cshtml"
                               Write(job.Value.ExceptionType);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n                                <p>\r\n                                    ");


            
            #line 109 "..\..\Pages\FailedJobsPage.cshtml"
                               Write(job.Value.ExceptionMessage);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </p>\r\n                        \r\n");


            
            #line 112 "..\..\Pages\FailedJobsPage.cshtml"
                                 if (!String.IsNullOrEmpty(job.Value.ExceptionDetails))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <pre class=\"stack-trace\">");


            
            #line 114 "..\..\Pages\FailedJobsPage.cshtml"
                                                        Write(HtmlHelper.MarkupStackTrace(job.Value.ExceptionDetails));

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n");


            
            #line 115 "..\..\Pages\FailedJobsPage.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </div>\r\n                        </td>\r\n              " +
"      </tr>\r\n");


            
            #line 119 "..\..\Pages\FailedJobsPage.cshtml"
                }
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");


            
            #line 123 "..\..\Pages\FailedJobsPage.cshtml"
    
    
            
            #line default
            #line hidden
            
            #line 124 "..\..\Pages\FailedJobsPage.cshtml"
Write(RenderPartial(new Paginator(pager)));

            
            #line default
            #line hidden
            
            #line 124 "..\..\Pages\FailedJobsPage.cshtml"
                                        
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
