﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CSTJR.RPC.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
            "~/Scripts/bootstrap.js",
            "~/Scripts/jquery-3.0.0.min.js",
            "~/Scripts/site.js"));
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css"));
        }
    }
}