using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Utilities.IO
{
    public class FilenameSanitizer
    {
        #region Methods
        public string Sanitize(string oldFilename)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex regex = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return regex.Replace(oldFilename, "");
        }
        #endregion
    }
}
