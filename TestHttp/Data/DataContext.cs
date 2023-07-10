using System.Collections.Generic;
using TESTHTTP.Models;
namespace TESTHTTP.Data
{
    public class DataContext
    {
        public List<Artist> Artists { get; set; }

        public DataContext()
        {
            Artists = new List<Artist>();
        }
    }
}
