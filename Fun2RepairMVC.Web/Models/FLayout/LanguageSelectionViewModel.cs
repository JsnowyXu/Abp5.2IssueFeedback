﻿using Abp.Localization;
using System.Collections.Generic;

namespace Fun2RepairMVC.Web.Models.FLayout
{ 
    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public string CurrentUrl { get; set; }
    }
}