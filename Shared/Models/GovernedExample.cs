using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Playbook.Module.GovernedExample.Models
{
    [Table("PlaybookGovernedExample")]
    public class GovernedExample : ModelBase
    {
        [Key]
        public int GovernedExampleId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
    }
}

