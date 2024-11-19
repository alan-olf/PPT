using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPT.App.Core
{
    public class AppConstant
    {

        protected AppConstant() { }


        /// <summary>
        /// The application name.
        /// </summary>
        public const string ApplicationName = "PPT-Tech-Test";

        public const string BaseUrlPartOne = "https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{identifier}";
        public const string BaseUrlVowel = "https://api.dicebear.com/8.x/pixel-art/png?seed={identifier}&size=150";
        public const string BaseUrlDefault = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150";
        public const string BaseUrlNonAlphanumeric = "https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150";


    }
}
