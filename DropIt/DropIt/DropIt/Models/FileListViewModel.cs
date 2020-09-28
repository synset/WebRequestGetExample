using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropIt.Models
{
    public class FileListViewModel
    {
        public IEnumerable<string> Files { get; set; }
    }
}