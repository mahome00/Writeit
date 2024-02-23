using System.ComponentModel.DataAnnotations;

namespace Writeit.Models
{
    public class Bocker
    {
        public int Id { get; set; }
        public string Boknamn { get; set; }
        public string Forfattare { get; set; }

        [DataType(DataType.MultilineText)]
        public string Sammanfattning { get; set; }
    }
}
