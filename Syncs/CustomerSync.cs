using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;

namespace UmbracoTools.Syncs
{
    public class CustomerSync
    {
        private readonly IMemberService _memberService;
        private readonly UmbracoHelper _umbraco;
        private readonly IConfiguration _config;

        public CustomerSync(IMemberService memberService, UmbracoHelper umbracoHelper, IConfiguration configuration)
        {
            _memberService = memberService;
            _umbraco = umbracoHelper;
            _config = configuration;
        }

        public void Start()
        {
            Console.WriteLine("It's working");

        }
    }
}
