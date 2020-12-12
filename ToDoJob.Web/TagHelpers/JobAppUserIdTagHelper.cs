using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using ToDoJob.Business.Interfaces;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.Web.TagHelpers
{
    [HtmlTargetElement("getJobAppUserId")]
  
    public class JobAppUserIdTagHelper:TagHelper
    {
        private readonly IJobService _jobService;

        public JobAppUserIdTagHelper(IJobService jobService)
        {
            _jobService = jobService;
        }

        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Job> jobs= _jobService.GetByAppUserId(AppUserId);
            int completedJobCount = jobs.Count(I => I.State);
            int incompletedJobCount = jobs.Count(I => !I.State);

            string htmlString = $"Tamamladığı görev sayısı : {completedJobCount} <br>" +
                                $"Üstünde çalıştığı görev sayısı : {incompletedJobCount}";
            output.Content.SetHtmlContent(htmlString);
        }
    }
}
